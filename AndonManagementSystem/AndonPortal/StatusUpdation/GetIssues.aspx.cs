using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AndonPortal.StatusUpdation
{
    public partial class GetIssues : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FromDate.SelectedDate = DateTime.Today;
                FromDate.VisibleDate = DateTime.Today;
                ToDate.SelectedDate = DateTime.Today;
                ToDate.VisibleDate = DateTime.Today;
            }
        }

        protected void Generate_Click(object sender, EventArgs e)
        {
            int department = DepartmentSelection.SelectedIndex + 1;
            Response.Redirect("~/StatusUpdation/UpdateIssueInfo.aspx?Name="
           + NameTextBox.Text
           + "&Department=" + department.ToString()
          
               + "&From=" + FromDate.SelectedDate.ToString()
               + "&To=" + ToDate.SelectedDate.ToString());

        }

        protected void DepartmentSelection_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}