using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Configuration;

namespace AndonPortal
{
    public class DowntimeRecord
    {
         public String Date { get; set; }
        public String  Line { get; set; }

        public String Station { get; set; }
        public String Department { get; set; }
        public String Raised { get; set; }

        public String Acknowledged { get; set; }

        public String Resolved { get; set; }

        public String Downtime { get; set; }

        public override string ToString()
        {
            return
                Date + "," + Line + "," + Station + "," + Department
                + "," + Raised + "," + Acknowledged + "," + Resolved;
        }
    }
    public partial class Reports : System.Web.UI.Page
    {
        List<line> Lines;
        List<String> LineNames;

        
        protected void Page_Load(object sender, EventArgs e)
        {
            DBDataContext db = new DBDataContext();
            

            var q = from l in db.lines select l;
            Lines = q.ToList();
            if (!Page.IsPostBack)
            {
                if (LineNames == null)
                {
                    LineNames = new List<string>();
                    foreach (line l in Lines)
                        LineNames.Add(l.description);
                    LineSelection.DataSource = LineNames;
                    LineSelection.DataBind();
                }
            }
            //object index = Session["SelectedLine"];
            //if (index != null)
            //    LineSelection.SelectedIndex = (int)index;
        }

        protected void Generate_Click(object sender, EventArgs e)
        {
            int lineID = Lines[LineSelection.SelectedIndex].id;
            Response.Redirect("~/ReportDisplay.aspx?Type="
            + TypeSelection.SelectedValue
            + "&Line="+lineID.ToString()
            + "&LineName=" + Lines[LineSelection.SelectedIndex].description
            +"&Shifts="+ShiftTextBox.Text
                + "&From=" + FromDate.SelectedDate.ToString()
                + "&To=" + ToDate.SelectedDate.ToString());

        }

        protected void LineSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["SelectedLine"] = LineSelection.SelectedIndex;
        }
    }
}