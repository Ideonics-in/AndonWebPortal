using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AndonPortal
{
    public partial class OpenIssues : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String conStr = System.Configuration.ConfigurationManager.
                            ConnectionStrings["IAS_SchneiderConnectionString"].ConnectionString;
            SqlConnection localCon = new SqlConnection(conStr);
            String qry = @"select distinct Substring(Convert(nvarchar,issues.timestamp,0),0,12) as DATE, 
                        lines.description as LINE , 
                        stations.description as STATION_NAME,
                        departments.description as ISSUE , 
                        issues.data as DETAILS,
                        CONVERT(TIME(0), issues.timestamp,0) as RAISED 
                        from issues
                        LEFT OUTER JOIN stations on (stations.id = issues.station and stations.line = issues.line)
                        inner join lines on lines.id = issues.line
                        inner join departments on issues.department = departments.id
                        where status<>'resolved' and issues.line={0}";

            qry = String.Format(qry, Request.QueryString["id"]);


            localCon.Open();

            SqlCommand cmd = new SqlCommand(qry, localCon);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);

            OpenIssuesGrid.DataSource = dt;
            OpenIssuesGrid.DataBind();
        }
    }
}