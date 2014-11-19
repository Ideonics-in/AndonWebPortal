using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AndonPortal.StatusUpdation
{
    public partial class UpdateIssueInfo : System.Web.UI.Page
    {
        public String Name = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            Name = Request.QueryString["Name"];
            String from = Request.QueryString["From"];
            DateTime FromDate = DateTime.Parse(from);
            DateTime TDate = DateTime.Parse(Request.QueryString["To"]);

            DateTime ToDate = TDate.AddDays(1);

            String qry = @" SELECT Name='{0}', issue_info.issue AS ISSUE, 
            Substring(Convert(nvarchar,raised.timestamp,0),0,12) as DATE,
            lines.description AS LINE, stations.description AS STATION, 
            issues.data AS DETAILS,
            CONVERT(TIME(0), raised.timestamp,0) as RAISED , 
                       
                        CONVERT(TIME(0), resolved.timestamp,0) as RESOLVED ,
                        CONVERT(Time(0) , resolved.timestamp - raised.timestamp , 0) as DOWNTIME,
            issue_info.cause AS CAUSE, issue_info.corrective_action AS [CORRECTIVE ACTION],
             issue_info.containment_action AS [CONTATIMENT ACTION], issue_info.cost AS COST, issue_info.spare AS SPARE
             FROM issues 
            INNER  JOIN issue_info ON issues.slNo = issue_info.issue
             INNER JOIN lines ON issues.line = lines.id 
            INNER JOIN stations ON issues.station = stations.id AND issues.line = stations.line
             inner join ( select issue, timestamp from issue_tracker where status = 'raised') as raised 
                        on raised.issue = issues.slNo

                        left outer join (select issue , timestamp from issue_tracker where status = 'acknowledged')
                        as acknowledged on acknowledged.issue = issues.slNo 

                        inner  join (select issue , timestamp from issue_tracker where status = 'resolved')
                        as resolved on resolved.issue = issues.slNo 
            where issues.[timestamp]>'{1}' and issues.[timestamp] < '{2}' and issues.department = {3}";

            qry = String.Format(qry,Name, FromDate.ToString("MM-dd-yyyy"), ToDate.ToString("MM-dd-yyyy"), Request.QueryString["Department"]);
            String conStr = System.Configuration.ConfigurationManager.
                             ConnectionStrings["IAS_SchneiderConnectionString"].ConnectionString;
            SqlConnection localCon = new SqlConnection(conStr);
            localCon.Open();
            SqlCommand cmd = new SqlCommand(qry, localCon);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();

            IssueGrid.DataSource = dt;
            IssueGrid.DataBind();

        }

        protected void IssueGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {    
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int Issue = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Issue"));
                HyperLink hyp = (HyperLink)e.Row.FindControl("IssueLink");
                hyp.NavigateUrl = "~/StatusUpdation/UpdateInfo.aspx?Name='" + Name + "&Issue=" + Issue.ToString();
            }
        }
    }
}