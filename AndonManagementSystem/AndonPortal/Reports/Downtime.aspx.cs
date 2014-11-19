using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AndonPortal.Report
{
    public partial class Downtime : System.Web.UI.Page
    {
        List<DowntimeRecord> reportData;
        DataTable ReportTable;
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime FromDate;
            DateTime TDate;
           
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



            qry += "order by raised.timestamp";
            qry = String.Format(qry, FromDate.ToString("MM-dd-yyyy"), ToDate.ToString("MM-dd-yyyy"));

            localCon.Open();

            SqlCommand cmd = new SqlCommand(qry, localCon);
            SqlDataReader dr = cmd.ExecuteReader();
            ReportTable = new DataTable();
            ReportTable.Load(dr);

            dr.Close();
            IssueGrid.DataSource = ReportTable;
            IssueGrid.DataBind();


        }

        protected void Download_Click(object sender, EventArgs e)
        {
            StringBuilder b = new StringBuilder();
            b.AppendLine("DATE,LINE,STATION,ISSUE,DETAILS,RAISED,ACKNOWLEDGED,RESOLVED,DOWNTIME,CAUSE,CORRECTIVE ACTION,CONTAINMENT ACTION,COST,SPARE,UPDATED BY, UPDATED AT");
            for (int i = 0; i < ReportTable.Rows.Count; i++)
            {
                String raisedTime = ReportTable.Rows[i]["RAISED"] == DBNull.Value ? ("")
                                    : ((TimeSpan)ReportTable.Rows[i]["RAISED"]).ToString();
                String acknowledgedTime = ReportTable.Rows[i]["ACKNOWLEDGED"] == DBNull.Value ? ("")
                                    : ((TimeSpan)ReportTable.Rows[i]["ACKNOWLEDGED"]).ToString();
                String resolvedTime = ReportTable.Rows[i]["RESOLVED"] == DBNull.Value ? ("")
                                    : ((TimeSpan)ReportTable.Rows[i]["RESOLVED"]).ToString();

                String downTime = ReportTable.Rows[i]["DOWNTIME"] == DBNull.Value ? ("")
                                    : ((TimeSpan)ReportTable.Rows[i]["DOWNTIME"]).ToString();

                String cause = ReportTable.Rows[i]["CAUSE"] == DBNull.Value ? ("")
                                   : ((String)ReportTable.Rows[i]["CAUSE"]);
                String corrective_action = ReportTable.Rows[i]["CORRECTIVE ACTION"] == DBNull.Value ? ("")
                                    : ((String)ReportTable.Rows[i]["CORRECTIVE ACTION"]);
                String containment_action = ReportTable.Rows[i]["CONTAINMENT ACTION"] == DBNull.Value ? ("")
                                    : ((String)ReportTable.Rows[i]["CONTAINMENT ACTION"]);

                String cost = ReportTable.Rows[i]["COST"] == DBNull.Value ? ("")
                                    : ((double)ReportTable.Rows[i]["COST"]).ToString();

                String spare = ReportTable.Rows[i]["SPARE"] == DBNull.Value ? ("")
                                   : ((String)ReportTable.Rows[i]["SPARE"]);
                String updatedBy = ReportTable.Rows[i]["UPDATED BY"] == DBNull.Value ? ("")
                                    : ((String)ReportTable.Rows[i]["UPDATED BY"]);

                String updatedAT = ReportTable.Rows[i]["UPDATED AT"] == DBNull.Value ? ("")
                                    : ((DateTime)ReportTable.Rows[i]["UPDATED AT"]).ToString("dd-MM-yyyy HH:mm:ss");



                String reportEntry = (String)ReportTable.Rows[i]["DATE"] + ","

                            + (String)ReportTable.Rows[i]["LINE"] + ","
                            + (String)ReportTable.Rows[i]["STATION"] + ","
                            + (String)ReportTable.Rows[i]["ISSUE"] + ","
                            + (String)ReportTable.Rows[i]["DETAILS"] + ","
                            + raisedTime + ","
                            + acknowledgedTime + ","
                            + resolvedTime + ","
                            + downTime + ","
                            + cause + ","
                            + corrective_action + ","
                            + containment_action + ","
                                + cost + ","
                                + spare + ","
                                + updatedBy + ","
                                + updatedAT;


                b.AppendLine(reportEntry);
            }
            Response.Clear();
            Response.ContentType = "text/csv";
            Response.AddHeader("Content-Disposition", "attachment;filename=myfilename.csv");
            Response.Write(b.ToString());
            Response.End();
        }
    }


   
}