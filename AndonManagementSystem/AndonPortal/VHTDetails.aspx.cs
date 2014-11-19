using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AndonPortal
{
    public partial class VHTDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                    char d = '_';
                    String text = Request.QueryString["VHT_Id"];
                    String[] s = text.Split(d);
                    
                    int Id = Convert.ToInt32(s[1]);
                    Label2.Text = Id.ToString();
              
            }
        }
    }
}