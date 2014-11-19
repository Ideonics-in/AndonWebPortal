using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.Configuration;
using AndonPortal.Models;

namespace AndonPortal
{
   
    public partial class ReportDisplay : System.Web.UI.Page
    {
        DateTime FromDate;
        DateTime TDate;
        List<DowntimeRecord> reportData;
        DataTable ReportTable;
        Chart ch;
        protected void Page_Load(object sender, EventArgs e)
        {
            Configuration c = WebConfigurationManager.OpenWebConfiguration("");
            String conStr = System.Configuration.ConfigurationManager.
                             ConnectionStrings["IAS_SchneiderConnectionString"].ConnectionString;
            SqlConnection localCon = new SqlConnection(conStr);

            String from = Request.QueryString["From"];
            FromDate = DateTime.Parse(from);
            TDate = DateTime.Parse(Request.QueryString["To"]);

            DateTime ToDate = TDate.AddDays(1);

            String qry = @"select Substring(Convert(nvarchar,raised.timestamp,0),0,12) as DATE, 
                        
                        lines.description as LINE , 
                        stations.description as STATION,
                        departments.description as ISSUE , 
                        issues.data as DETAILS,

                        CONVERT(TIME(0), raised.timestamp,0) as RAISED , 
                        CONVERT(TIME(0), acknowledged.timestamp,0) as ACKNOWLEDGED , 
                        CONVERT(TIME(0), resolved.timestamp,0) as RESOLVED ,
                        CONVERT(Time(0) , resolved.timestamp - raised.timestamp , 0) as DOWNTIME,

                        issue_info.cause as CAUSE,
                        issue_info.corrective_action as [CORRECTIVE ACTION],
                        issue_info.containment_action as [CONTAINMENT ACTION],
                        issue_info.cost as COST,
                        issue_info.spare as SPARE,
                        issue_info.updated_by as [UPDATED BY],
                        issue_info.[timestamp] as [UPDATED AT]

                        from issues
                        inner join stations on (stations.id = issues.station and stations.line = issues.line)
                        inner join lines on lines.id = issues.line
                        inner join departments on issues.department = departments.id
                        inner join ( select issue, timestamp from issue_tracker where status = 'raised') as raised 
                        on raised.issue = issues.slNo

                        left outer join (select issue , timestamp from issue_tracker where status = 'acknowledged')
                        as acknowledged on acknowledged.issue = issues.slNo 

                        left outer join (select issue , timestamp from issue_tracker where status = 'resolved')
                        as resolved on resolved.issue = issues.slNo 
                        
                        left outer join issue_info on issues.slNo = issue_info.issue
                        where raised.timestamp >= '{0}' and raised.timestamp <= '{1}' ";

          



            
            //DBDataContext db = new DBDataContext();
            //var req = from record in db.issues
            //          join l in db.lines on record.line equals l.id
            //          join s in db.stations on new {record.station,record.line} equals new {s.id , s.line}
                      
            //          join d in db.departments on record.department equals d.id
            //          join ra in db.issue_trackers.DefaultIfEmpty() on record.slNo equals ra.issue
            //          where ra.status == "raised"
            //          join rack in db.issue_trackers.DefaultIfEmpty() on record.slNo equals rack.issue
            //          where rack.status == "acknowledged"
            //          join rs in db.issue_trackers.DefaultIfEmpty() on record.slNo equals rs.issue
            //          where rs.status == "resolved"
            //          where ra.timestamp > FromDate
            //          where ra.timestamp < ToDate
            //          where l.id == Convert.ToInt32(Request.QueryString["Line"])
            //          orderby ra.timestamp
            //          select new DowntimeRecord()
            //          {
            //              Date = ra.timestamp.ToString(),
            //              Line = l.description,
            //              Station = s.description,
            //              Department = d.description,
            //              Raised = ra.timestamp.ToString(),
            //              Acknowledged =(rack != null )? ( rack.timestamp.ToString()):"",
            //              Resolved = (rs != null )? (rs.timestamp.ToString()):"",

            //              Downtime = (rs != null )? (rs.timestamp - ra.timestamp).ToString() : ""
            //          };

            switch( Request.QueryString["Type"])
            {
                case "Downtime":
                    Response.Redirect("~/Reports/Downtime.aspx?From=" + FromDate.ToString() + "&To=" + ToDate.ToString());
                    break;


                case "MTTR":
                    qry = @"select stations.description as STATION, count(issues.slNo) as COUNT,sum(DATEDIFF(mi,Raised,Resolved)) as DOWNTIME 
                            from stations 
                            left outer join  (select issues.slNo, issues.station, issues.line, ist.raised, ist.resolved from  issues  
                            inner join 
                            (select issue, ISNULL(max(case when status='resolved' then [timestamp] else NULL end) , getdate()) as Resolved
                             ,max(case when status='raised' then [timestamp] else NULL end) as Raised  from issue_tracker  group by issue ) ist on ist.issue=issues.slNo

                             inner join departments on departments.id = issues.department
                             where Raised between Convert(datetime,'{0}',20) and Convert(datetime,'{1}',20)  
                              AND DATEDIFF(SS,Raised,Resolved) > 180 and department=1) issues on (stations.id = issues.station and stations.line = issues.line)
                               where stations.line = {2} group by stations.description ";

                    qry = String.Format(qry, FromDate.ToString("yyyy-MM-dd HH:mm:ss"), ToDate.ToString("yyyy-MM-dd HH:mm:ss"),
                          Request.QueryString["Line"]);

                    localCon.Open();

                    SqlCommand cmd = new SqlCommand(qry, localCon);
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);

                    dr.Close();

                    List<MTTR> mttr = new List<MTTR>();
                    for(int i = 0 ; i < dt.Rows.Count; i++)
                    {

                        mttr.Add(new AndonPortal.Models.MTTR((String)dt.Rows[i]["STATION"], (int)dt.Rows[i]["COUNT"], 
                            dt.Rows[i]["DOWNTIME"] == DBNull.Value ?0:((int)dt.Rows[i]["DOWNTIME"])));
                    }

                    ch = new Chart();
                    ch.Width = 800;
                    ch.Height = 500;
                    ChartArea area = new ChartArea("MainArea");
                    Series series = new Series("MainSeries");
                    series.ChartType = SeriesChartType.Column;
                    series.ChartArea = "MainArea";
                    series.IsValueShownAsLabel = true;
                    
                    foreach(MTTR  m in mttr)
                    {
                        series.Points.AddXY(m.Station, m.Value);
                    }
                    //series.Points.DataBindXY(mttr,"Station",mttr,"Value");
                    ch.ChartAreas.Add(area);
                    ch.Series.Add(series);
                    ch.ChartAreas["MainArea"].AxisX.Interval = 1;
                    ch.ChartAreas["MainArea"].AxisX.Title = "Station";
                    ch.ChartAreas["MainArea"].AxisX.IsLabelAutoFit = true;
                    ch.ChartAreas["MainArea"].AxisY.Title = "Time[minutes]";
                    ch.ChartAreas["MainArea"].AxisX.LabelStyle.Angle = -45;
                    ch.ChartAreas["MainArea"].AxisX.MajorGrid.Enabled = false;
                    ch.ChartAreas["MainArea"].AxisY.MajorGrid.Enabled = false;
                    
                    ch.Titles.Add("MTTR -- " + Request.QueryString["LineName"]
                        + Environment.NewLine + FromDate.ToString("dd-MMM-yyyy") + "   To   " + TDate.ToString("dd-MMM-yyyy"));

                    ReportDataPlaceHolder.Controls.Add(ch);
                    
                    break;

                case "MTBF":
                                        qry = @"select stations.description as STATION, count(issues.slNo) as COUNT,sum(DATEDIFF(mi,Raised,Resolved)) as DOWNTIME 
                            from stations 
                            left outer join  (select issues.slNo, issues.station, issues.line, ist.raised, ist.resolved from  issues  
                            inner join 
                            (select issue, ISNULL(max(case when status='resolved' then [timestamp] else NULL end) , getdate()) as Resolved
                             ,max(case when status='raised' then [timestamp] else NULL end) as Raised  from issue_tracker  group by issue ) ist on ist.issue=issues.slNo

                             inner join departments on departments.id = issues.department
                             where Raised between Convert(datetime,'{0}',20) and Convert(datetime,'{1}',20)  
                              AND DATEDIFF(SS,Raised,Resolved) > 180 and department=1) issues on (stations.id = issues.station and stations.line = issues.line)
                               where stations.line = {2} group by stations.description ";

                    qry = String.Format(qry, FromDate.ToString("yyyy-MM-dd HH:mm:ss"), ToDate.ToString("yyyy-MM-dd HH:mm:ss"),
                          Request.QueryString["Line"]);

                    localCon.Open();

                    cmd = new SqlCommand(qry, localCon);
                    dr = cmd.ExecuteReader();
                    dt = new DataTable();
                    dt.Load(dr);

                    dr.Close();

                    List<MTBF> mtbf = new List<MTBF>();
                    for(int i = 0 ; i < dt.Rows.Count; i++)
                    {

                        mtbf.Add(new AndonPortal.Models.MTBF((String)dt.Rows[i]["STATION"], (int)dt.Rows[i]["COUNT"], 
                            Convert.ToInt32(Request.QueryString["Shifts"])));
                    }

                    ch= new Chart();
                    ch.Width = 800;
                    ch.Height = 500;
                    ChartArea area1 = new ChartArea("MainArea");
                    Series series1 = new Series("MainSeries");
                    series1.ChartType = SeriesChartType.Column;
                    series1.ChartArea = "MainArea";
                    series1.IsValueShownAsLabel = true;
                    
                    foreach(MTBF  m in mtbf)
                    {
                        series1.Points.AddXY(m.Station, m.Value);
                    }
                    //series.Points.DataBindXY(mttr,"Station",mttr,"Value");
                    ch.ChartAreas.Add(area1);
                    ch.Series.Add(series1);
                    ch.ChartAreas["MainArea"].AxisX.Interval = 1;
                    ch.ChartAreas["MainArea"].AxisX.Title = "Station";
                    ch.ChartAreas["MainArea"].AxisX.IsLabelAutoFit = true;
                    ch.ChartAreas["MainArea"].AxisY.Title = "Time[Hours]";
                    ch.ChartAreas["MainArea"].AxisX.LabelStyle.Angle = -45;
                    ch.ChartAreas["MainArea"].AxisX.MajorGrid.Enabled = false;
                    ch.ChartAreas["MainArea"].AxisY.MajorGrid.Enabled = false;
                    
                    ch.Titles.Add("MTBF -- " + Request.QueryString["LineName"] 
                        + Environment.NewLine+"Shifts -- "+ Request.QueryString["Shifts"]
                        + Environment.NewLine + FromDate.ToString("dd-MMM-yyyy") + "   To   " + TDate.ToString("dd-MMM-yyyy"));

                    ReportDataPlaceHolder.Controls.Add(ch);
                    break;
                default: break;
            }

           


        }

        protected void Download_Click(object sender, EventArgs e)
        {
            switch(Request.QueryString["Type"])
            {
                case "Downtime":
                  

                case "MTBF":
                    Response.ContentType = "image/jpeg";
                    Response.AddHeader("Content-Disposition",
                   String.Format("attachment; filename=MTBF_{0}_{1}.jpeg",
                                 Request.QueryString["LineName"],
                                FromDate.ToString("dd-MMM-yyyy") + "_" + TDate.ToString("dd-MMM-yyyy")));
                    ch.SaveImage(Response.OutputStream, ChartImageFormat.Jpeg);

                    Response.End();
                    break;

                case "MTTR":
                     Response.ContentType = "image/jpeg";
                    Response.AddHeader("Content-Disposition",
                   String.Format("attachment; filename=MTTR_{0}_{1}.jpeg",
                                 Request.QueryString["LineName"],
                                FromDate.ToString("dd-MMM-yyyy") + "_" + TDate.ToString("dd-MMM-yyyy")));
                    ch.SaveImage(Response.OutputStream, ChartImageFormat.Jpeg);

                    Response.End();
                    break;
            }
           

        }
    }
}