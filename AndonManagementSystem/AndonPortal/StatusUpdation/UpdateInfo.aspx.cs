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
    public partial class UpdateInfo : System.Web.UI.Page
    {
        static String prev = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int issue = Convert.ToInt32(Request.QueryString["issue"]);

                String qry = @"select * from issue_info where issue = {0}";

                qry = String.Format(qry, Convert.ToInt32(Request.QueryString["Issue"]));
                String conStr = System.Configuration.ConfigurationManager.
                                 ConnectionStrings["IAS_SchneiderConnectionString"].ConnectionString;
                SqlConnection localCon = new SqlConnection(conStr);
                localCon.Open();
                SqlCommand cmd = new SqlCommand(qry, localCon);

                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dr.Close();

                CauseTextBox.Text = (dt.Rows[0]["cause"] == DBNull.Value ? ("") : (String)dt.Rows[0]["cause"]);
                CorrectiveTextBox.Text = (dt.Rows[0]["corrective_action"] == DBNull.Value ? ("") : (String)dt.Rows[0]["corrective_action"]);
                ContainmentTextBox.Text = (dt.Rows[0]["containment_action"] == DBNull.Value ? ("") : (String)dt.Rows[0]["containment_action"]);
                CostTextBox.Text = (dt.Rows[0]["cost"] == DBNull.Value ? ("0.00") : (Math.Round((double)dt.Rows[0]["cost"], 2).ToString()));
                SpareTextBox.Text = (dt.Rows[0]["spare"] == DBNull.Value ? ("") : (String)dt.Rows[0]["spare"]);


                prev = Request.UrlReferrer.ToString();
            }

        }

        protected void Update_Click(object sender, EventArgs e)
        {
            int issue = Convert.ToInt32(Request.QueryString["issue"]);

            String qry = @"update issue_info set 
                            cause='{0}', corrective_action='{1}',containment_action='{2}',
                            cost={3},spare='{4}',updated_by='{5}',[timestamp]='{6}'
                            where issue={7}";

            qry = String.Format(qry, CauseTextBox.Text, CorrectiveTextBox.Text, ContainmentTextBox.Text,
                        Convert.ToDouble( CostTextBox.Text), SpareTextBox.Text,Request.QueryString["Name"],
                        DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss"),Convert.ToInt32(Request.QueryString["Issue"]));
            String conStr = System.Configuration.ConfigurationManager.
                             ConnectionStrings["IAS_SchneiderConnectionString"].ConnectionString;
            SqlConnection localCon = new SqlConnection(conStr);
            localCon.Open();
            SqlCommand cmd = new SqlCommand(qry, localCon);
            cmd.ExecuteNonQuery();

            Response.Redirect(prev);
        }
    }
}