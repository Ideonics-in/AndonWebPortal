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
    public partial class LiveStatus : System.Web.UI.Page
    {
         Dictionary<int, LineStatus> LineStatusDictionary;
        protected void Page_Load(object sender, EventArgs e)
        {

            LineStatusDictionary = new Dictionary<int, LineStatus>();
            DBDataContext db = new DBDataContext();


            var q = from l in db.lines select l;
            var Lines = q.ToList();
            foreach (line l in Lines)
            {
                LineStatusDictionary.Add(l.id,
                    new LineStatus()
                    {
                        ID = l.id,
                        Name = l.description,
                        Image1 = "~/Images/GREENSMILEY.PNG",
                        Image2 = "~/Images/GREENSMILEY.PNG",
                        Image3 = "~/Images/GREENSMILEY.PNG",
                        Image4 = "~/Images/GREENSMILEY.PNG",
                        Image5 = "~/Images/GREENSMILEY.PNG",
                        Image6 = "~/Images/GREENSMILEY.PNG",
                    });
            }

            String qry = String.Empty;



            qry = @"select * from
                    (Select  department,line,DATEDIFF(ss,[timestamp],GETDATE()) as duration,
                    Rank()over(partition by [department],[line] order by [timestamp] asc)as Ran
                    from issues where [status]<>'resolved' )
                    as t where Ran=1";



            String conStr = System.Configuration.ConfigurationManager.
                             ConnectionStrings["IAS_SchneiderConnectionString"].ConnectionString;
            SqlConnection localCon = new SqlConnection(conStr);
            localCon.Open();
            SqlCommand cmd = new SqlCommand(qry, localCon);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                switch ((int)dt.Rows[i]["department"])
                {
                    case 1:
                        if ((int)dt.Rows[i]["duration"] > 755)
                        {
                            LineStatusDictionary[(int)dt.Rows[i]["line"]].Image1 = "~/Images/REDSMILEY.jpg";
                        }
                        else
                        {
                            LineStatusDictionary[(int)dt.Rows[i]["line"]].Image1 = "~/Images/ORANGESMILEY.jpg";
                        }
                        break;


                    case 2:
                        if ((int)dt.Rows[i]["duration"] > 755)
                        {
                            LineStatusDictionary[(int)dt.Rows[i]["line"]].Image2 = "~/Images/REDSMILEY.jpg";
                        }
                        else
                        {
                            LineStatusDictionary[(int)dt.Rows[i]["line"]].Image2 = "~/Images/ORANGESMILEY.jpg";
                        }
                        break;


                    case 3:
                        if ((int)dt.Rows[i]["duration"] > 755)
                        {
                            LineStatusDictionary[(int)dt.Rows[i]["line"]].Image3 = "~/Images/REDSMILEY.jpg";
                        }
                        else
                        {
                            LineStatusDictionary[(int)dt.Rows[i]["line"]].Image3 = "~/Images/ORANGESMILEY.jpg";
                        }
                        break;


                    case 4:
                        if ((int)dt.Rows[i]["duration"] > 755)
                        {
                            LineStatusDictionary[(int)dt.Rows[i]["line"]].Image4 = "~/Images/REDSMILEY.jpg";
                        }
                        else
                        {
                            LineStatusDictionary[(int)dt.Rows[i]["line"]].Image4 = "~/Images/ORANGESMILEY.jpg";
                        }
                        break;


                    case 5:
                        if ((int)dt.Rows[i]["duration"] > 755)
                        {
                            LineStatusDictionary[(int)dt.Rows[i]["line"]].Image5 = "~/Images/REDSMILEY.jpg";
                        }
                        else
                        {
                            LineStatusDictionary[(int)dt.Rows[i]["line"]].Image5 = "~/Images/ORANGESMILEY.jpg";
                        }
                        break;


                    case 6:
                        if ((int)dt.Rows[i]["duration"] > 755)
                        {
                            LineStatusDictionary[(int)dt.Rows[i]["line"]].Image6 = "~/Images/REDSMILEY.jpg";
                        }
                        else
                        {
                            LineStatusDictionary[(int)dt.Rows[i]["line"]].Image6 = "~/Images/ORANGESMILEY.jpg";
                        }
                        break;
               
                }
            }

            LiveStatusGrid.DataSource = LineStatusDictionary.Values.ToList();
            LiveStatusGrid.DataBind();

        }
    }

    class LineStatus
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Image1 { get; set; }
        public String Image2 { get; set; }
        public String Image3 { get; set; }
        public String Image4 { get; set; }
        public String Image5 { get; set; }
        public String Image6 { get; set; }
    }
}