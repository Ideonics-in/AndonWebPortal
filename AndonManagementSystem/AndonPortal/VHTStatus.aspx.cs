using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using AndonPortal.DALayer;
using System.Drawing;

namespace AndonPortal
{
    public partial class VHTStatus : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        DataAccess da;
        protected void Page_Load(object sender, EventArgs e)
        {

            da = new DataAccess();
            DataTable dt = da.getVHTStatus();
            
            for (int i = 1; i <= 26; i++)
            {
                DateTime? startTs = da.GetCycleStartTs(i);
                DateTime? endTs = da.GetCycleEndTs(i);
                DateTime endTimestamp = new DateTime() ;
                if (startTs == null)
                {
                    endTs = null;
                }
                else if (endTs == null || endTs.Value < startTs.Value)
                {
                    endTimestamp = startTs.Value.AddHours(72);

                }
                else
                    endTimestamp = endTs.Value;

                if (i == 1 || i == 2 || i == 5 || i == 6 || i == 7
                    ||i == 8 || i == 15 || i== 16 || i == 25 || i == 26 )
                    continue;
                switch (i)
                {
                    case 1:
                        
                        displayStatus(VHT_1,"VHT 1", (int)dt.Rows[i-1]["Status"],
                             (startTs == null) ? "" : startTs.Value.ToString("dd-MMM-yyyy"),
                            (startTs == null) ? "" : startTs.Value.ToString("HH:mm:ss"),
                            (endTs == null) ? "" : endTimestamp.ToString("dd-MMM-yyyy"),
                            (endTs == null) ? "" : endTimestamp.ToString("HH:mm:ss"));
                        break;
                    case 2:

                        displayStatus(VHT_2, "VHT 2", (int)dt.Rows[i-1]["Status"],
                              (startTs == null) ? "" : startTs.Value.ToString("dd-MMM-yyyy"),
                            (startTs == null) ? "" : startTs.Value.ToString("HH:mm:ss"),
                            (endTs == null) ? "" : endTimestamp.ToString("dd-MMM-yyyy"),
                            (endTs == null) ? "" : endTimestamp.ToString("HH:mm:ss"));
                        break;
                        

                    case 3:

                        displayStatus(VHT_3, "VHT 3", (int)dt.Rows[i-1]["Status"],
                             (startTs == null) ? "" : startTs.Value.ToString("dd-MMM-yyyy"),
                            (startTs == null) ? "" : startTs.Value.ToString("HH:mm:ss"),
                            (endTs == null) ? "" : endTimestamp.ToString("dd-MMM-yyyy"),
                            (endTs == null) ? "" : endTimestamp.ToString("HH:mm:ss"));
                        break;
                        
                    case 4:

                        displayStatus(VHT_4, "VHT 4", (int)dt.Rows[i-1]["Status"],
                              (startTs == null) ? "" : startTs.Value.ToString("dd-MMM-yyyy"),
                            (startTs == null) ? "" : startTs.Value.ToString("HH:mm:ss"),
                            (endTs == null) ? "" : endTimestamp.ToString("dd-MMM-yyyy"),
                            (endTs == null) ? "" : endTimestamp.ToString("HH:mm:ss"));
                        break;
                        

                    case 5:

                        displayStatus(VHT_5, "VHT 5", (int)dt.Rows[i-1]["Status"],
                            (startTs == null) ? "" : startTs.Value.ToString("dd-MMM-yyyy"),
                            (startTs == null) ? "" : startTs.Value.ToString("HH:mm:ss"),
                            (endTs == null) ? "" : endTimestamp.ToString("dd-MMM-yyyy"),
                            (endTs == null) ? "" : endTimestamp.ToString("HH:mm:ss"));
                        break;
                       
                    case 6:

                        displayStatus(VHT_6, "VHT 6", (int)dt.Rows[i-1]["Status"],
                              (startTs == null) ? "" : startTs.Value.ToString("dd-MMM-yyyy"),
                            (startTs == null) ? "" : startTs.Value.ToString("HH:mm:ss"),
                            (endTs == null) ? "" : endTimestamp.ToString("dd-MMM-yyyy"),
                            (endTs == null) ? "" : endTimestamp.ToString("HH:mm:ss"));
                        break;
                        

                    case 7:

                        displayStatus(VHT_7, "VHT 7", (int)dt.Rows[i-1]["Status"],
                              (startTs == null) ? "" : startTs.Value.ToString("dd-MMM-yyyy"),
                            (startTs == null) ? "" : startTs.Value.ToString("HH:mm:ss"),
                            (endTs == null) ? "" : endTimestamp.ToString("dd-MMM-yyyy"),
                            (endTs == null) ? "" : endTimestamp.ToString("HH:mm:ss"));
                        break;
                        
                    case 8:

                        displayStatus(VHT_8, "VHT 8", (int)dt.Rows[i-1]["Status"],
                            (startTs == null) ? "" : startTs.Value.ToString("dd-MMM-yyyy"),
                            (startTs == null) ? "" : startTs.Value.ToString("HH:mm:ss"),
                            (endTs == null) ? "" : endTimestamp.ToString("dd-MMM-yyyy"),
                            (endTs == null) ? "" : endTimestamp.ToString("HH:mm:ss"));
                        break;
                        


                    case 9:

                        displayStatus(VHT_9, "VHT 9", (int)dt.Rows[i-1]["Status"],
                              (startTs == null) ? "" : startTs.Value.ToString("dd-MMM-yyyy"),
                            (startTs == null) ? "" : startTs.Value.ToString("HH:mm:ss"),
                            (endTs == null) ? "" : endTimestamp.ToString("dd-MMM-yyyy"),
                            (endTs == null) ? "" : endTimestamp.ToString("HH:mm:ss"));
                        break;
                       
                    case 10:

                        displayStatus(VHT_10, "VHT 10", (int)dt.Rows[i-1]["Status"],
                             (startTs == null) ? "" : startTs.Value.ToString("dd-MMM-yyyy"),
                            (startTs == null) ? "" : startTs.Value.ToString("HH:mm:ss"),
                            (endTs == null) ? "" : endTimestamp.ToString("dd-MMM-yyyy"),
                            (endTs == null) ? "" : endTimestamp.ToString("HH:mm:ss"));
                        break;
                        

                    case 11:

                        displayStatus(VHT_11, "VHT 11", (int)dt.Rows[i-1]["Status"],
                              (startTs == null) ? "" : startTs.Value.ToString("dd-MMM-yyyy"),
                            (startTs == null) ? "" : startTs.Value.ToString("HH:mm:ss"),
                            (endTs == null) ? "" : endTimestamp.ToString("dd-MMM-yyyy"),
                            (endTs == null) ? "" : endTimestamp.ToString("HH:mm:ss"));
                        break;
                       
                    case 12:

                        displayStatus(VHT_12, "VHT 12", (int)dt.Rows[i-1]["Status"],
                              (startTs == null) ? "" : startTs.Value.ToString("dd-MMM-yyyy"),
                            (startTs == null) ? "" : startTs.Value.ToString("HH:mm:ss"),
                            (endTs == null) ? "" : endTimestamp.ToString("dd-MMM-yyyy"),
                            (endTs == null) ? "" : endTimestamp.ToString("HH:mm:ss"));
                        break;
                        

                    case 13:

                        displayStatus(VHT_13, "VHT 13", (int)dt.Rows[i-1]["Status"],
                             (startTs == null) ? "" : startTs.Value.ToString("dd-MMM-yyyy"),
                            (startTs == null) ? "" : startTs.Value.ToString("HH:mm:ss"),
                            (endTs == null) ? "" : endTimestamp.ToString("dd-MMM-yyyy"),
                            (endTs == null) ? "" : endTimestamp.ToString("HH:mm:ss"));
                        break;
                        
                    case 14:

                        displayStatus(VHT_14, "VHT 14", (int)dt.Rows[i-1]["Status"],
                             (startTs == null) ? "" : startTs.Value.ToString("dd-MMM-yyyy"),
                            (startTs == null) ? "" : startTs.Value.ToString("HH:mm:ss"),
                            (endTs == null) ? "" : endTimestamp.ToString("dd-MMM-yyyy"),
                            (endTs == null) ? "" : endTimestamp.ToString("HH:mm:ss"));
                        break;
                        break;

                    case 15:

                        displayStatus(VHT_15, "VHT 15", (int)dt.Rows[i-1]["Status"],
                            (startTs == null) ? "" : startTs.Value.ToString("dd-MMM-yyyy"),
                            (startTs == null) ? "" : startTs.Value.ToString("HH:mm:ss"),
                            (endTs == null) ? "" : endTimestamp.ToString("dd-MMM-yyyy"),
                            (endTs == null) ? "" : endTimestamp.ToString("HH:mm:ss"));
                        break;
                       
                    case 16:

                        displayStatus(VHT_16, "VHT 16", (int)dt.Rows[i-1]["Status"],
                            (startTs == null) ? "" : startTs.Value.ToString("dd-MMM-yyyy"),
                            (startTs == null) ? "" : startTs.Value.ToString("HH:mm:ss"),
                            (endTs == null) ? "" : endTimestamp.ToString("dd-MMM-yyyy"),
                            (endTs == null) ? "" : endTimestamp.ToString("HH:mm:ss"));
                        break;
                       

                    case 17:

                        displayStatus(VHT_17, "VHT 17", (int)dt.Rows[i-1]["Status"],
                           (startTs == null) ? "" : startTs.Value.ToString("dd-MMM-yyyy"),
                            (startTs == null) ? "" : startTs.Value.ToString("HH:mm:ss"),
                            (endTs == null) ? "" : endTimestamp.ToString("dd-MMM-yyyy"),
                            (endTs == null) ? "" : endTimestamp.ToString("HH:mm:ss"));
                        break;
                       

                    case 18:

                        displayStatus(VHT_18, "VHT 18", (int)dt.Rows[i-1]["Status"],
                            (startTs == null) ? "" : startTs.Value.ToString("dd-MMM-yyyy"),
                            (startTs == null) ? "" : startTs.Value.ToString("HH:mm:ss"),
                            (endTs == null) ? "" : endTimestamp.ToString("dd-MMM-yyyy"),
                            (endTs == null) ? "" : endTimestamp.ToString("HH:mm:ss"));
                        break;
                       
                    case 19:

                        displayStatus(VHT_19, "VHT 19", (int)dt.Rows[i-1]["Status"],
                           (startTs == null) ? "" : startTs.Value.ToString("dd-MMM-yyyy"),
                            (startTs == null) ? "" : startTs.Value.ToString("HH:mm:ss"),
                            (endTs == null) ? "" : endTimestamp.ToString("dd-MMM-yyyy"),
                            (endTs == null) ? "" : endTimestamp.ToString("HH:mm:ss"));
                        break;
                        

                    case 20:

                        displayStatus(VHT_20, "VHT 20", (int)dt.Rows[i-1]["Status"],
                              (startTs == null) ? "" : startTs.Value.ToString("dd-MMM-yyyy"),
                            (startTs == null) ? "" : startTs.Value.ToString("HH:mm:ss"),
                            (endTs == null) ? "" : endTimestamp.ToString("dd-MMM-yyyy"),
                            (endTs == null) ? "" : endTimestamp.ToString("HH:mm:ss"));
                        break;
                       
                    case 21:

                        displayStatus(VHT_21, "VHT 21", (int)dt.Rows[i-1]["Status"],
                             (startTs == null) ? "" : startTs.Value.ToString("dd-MMM-yyyy"),
                            (startTs == null) ? "" : startTs.Value.ToString("HH:mm:ss"),
                            (endTs == null) ? "" : endTimestamp.ToString("dd-MMM-yyyy"),
                            (endTs == null) ? "" : endTimestamp.ToString("HH:mm:ss"));
                        break;
                        break;

                    case 22:

                        displayStatus(VHT_22, "VHT 22", (int)dt.Rows[i-1]["Status"],
                              (startTs == null) ? "" : startTs.Value.ToString("dd-MMM-yyyy"),
                            (startTs == null) ? "" : startTs.Value.ToString("HH:mm:ss"),
                            (endTs == null) ? "" : endTimestamp.ToString("dd-MMM-yyyy"),
                            (endTs == null) ? "" : endTimestamp.ToString("HH:mm:ss"));
                        break;
                        
                    case 23:

                        displayStatus(VHT_23, "VHT 23", (int)dt.Rows[i-1]["Status"],
                            (startTs == null) ? "" : startTs.Value.ToString("dd-MMM-yyyy"),
                            (startTs == null) ? "" : startTs.Value.ToString("HH:mm:ss"),
                            (endTs == null) ? "" : endTimestamp.ToString("dd-MMM-yyyy"),
                            (endTs == null) ? "" : endTimestamp.ToString("HH:mm:ss"));
                        break;
                       

                    case 24:

                        displayStatus(VHT_24, "VHT 24", (int)dt.Rows[i-1]["Status"],
                             (startTs == null) ? "" : startTs.Value.ToString("dd-MMM-yyyy"),
                            (startTs == null) ? "" : startTs.Value.ToString("HH:mm:ss"),
                            (endTs == null) ? "" : endTimestamp.ToString("dd-MMM-yyyy"),
                            (endTs == null) ? "" : endTimestamp.ToString("HH:mm:ss"));
                        break;
                       

                    case 25:

                        displayStatus(VHT_25, "VHT 25", (int)dt.Rows[i-1]["Status"],
                            (startTs == null) ? "" : startTs.Value.ToString("dd-MMM-yyyy"),
                            (startTs == null) ? "" : startTs.Value.ToString("HH:mm:ss"),
                            (endTs == null) ? "" : endTimestamp.ToString("dd-MMM-yyyy"),
                            (endTs == null) ? "" : endTimestamp.ToString("HH:mm:ss"));
                        break;
                        
                    case 26:

                        displayStatus(VHT_26, "VHT 26", (int)dt.Rows[i-1]["Status"],
                            (startTs == null) ? "" : startTs.Value.ToString("dd-MMM-yyyy"),
                            (startTs == null) ? "" : startTs.Value.ToString("HH:mm:ss"),
                            (endTs == null) ? "" : endTimestamp.ToString("dd-MMM-yyyy"),
                            (endTs == null) ? "" : endTimestamp.ToString("HH:mm:ss"));
                        break;
                        
                }
            }

        }

        private void displayStatus(Button VHT, string vht, int p, string startDate, String startTime,string endDate, String endTime)
        {
            String status = string.Empty;
            Color backcolor = Color.Black;
            switch(p)
            {
                case 0 : status = "STOPPED";
                    backcolor = Color.Cyan;
                    break;
                case 1 : status = "EVACUATION";
                    backcolor = Color.PaleGreen;
                    break;

                case 2 : status = "N2 FEEDING";
                    backcolor = Color.Blue;
                    break;
                case 3 : status = "PROFILE HEATING 1";
                    backcolor = Color.Orange;
                    break;
                case 4 : status = "PROFILE HEATING 2";
                    backcolor = Color.OrangeRed;
                    break;
                case 5 : status = "VACUUM DRYING";
                    backcolor = Color.Red;
                    break;

                case 6 : status = "COOLING 1";
                    backcolor = Color.Yellow;
                    break;
                case 7 : status = "COOLING 2";
                    backcolor = Color.Lime;
                    break;

                case 8 : status = "N2 COOLING";
                    backcolor = Color.DarkGreen;
                    break;
                case 9 : status = "CYCLE COMPLETED";
                    backcolor = Color.Cyan;
                    break;
            }

            VHT.ForeColor = Color.Black;
            if (p == 0)
            {
                startDate = startTime = endDate = endTime = "";
            }
            else
            {

                if (startDate != String.Empty)
                    startDate = "Start Date-" + startDate;
                if (startTime != String.Empty)
                    startTime = "Start Time-" + startTime;

                if (endDate != String.Empty)
                    endDate = ((p == 9) ? "End Date-" : "Exp End Date-") + endDate;
                if (endTime != String.Empty)
                    endTime = ((p == 9) ? "End Time-" : "Exp End Time-") + endTime;
            }
                    


            VHT.Text = vht + Environment.NewLine + status + Environment.NewLine + 
                startDate + Environment.NewLine + startTime + Environment.NewLine + endDate + Environment.NewLine + endTime;
            VHT.BackColor = backcolor;
        }



        protected void VHT_1_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("~/VHTDetails.aspx?VHT_Id=" +VHT_1.ID);
                    
        }

        protected void VHT_2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/VHTDetails.aspx?VHT_Id=" + VHT_2.ID);
      
        }

        protected void VHT_3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/VHTDetails.aspx?VHT_Id=" + VHT_3.ID);
        }

        protected void VHT_4_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/VHTDetails.aspx?VHT_Id=" + VHT_4.ID);
        }

        protected void VHT_5_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/VHTDetails.aspx?VHT_Id=" + VHT_5.ID);
        }

        protected void VHT_6_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/VHTDetails.aspx?VHT_Id=" + VHT_6.ID);
        }

        protected void VHT_7_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/VHTDetails.aspx?VHT_Id=" + VHT_7.ID);
        }

        protected void VHT_8_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/VHTDetails.aspx?VHT_Id=" + VHT_8.ID);
        }

        protected void VHT_9_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/VHTDetails.aspx?VHT_Id=" + VHT_9.ID);
        }

        protected void VHT_10_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/VHTDetails.aspx?VHT_Id=" + VHT_10.ID);
        }

        protected void VHT_11_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/VHTDetails.aspx?VHT_Id=" + VHT_11.ID);
        }

        protected void VHT_12_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/VHTDetails.aspx?VHT_Id=" + VHT_12.ID);
        }

        protected void VHT_13_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/VHTDetails.aspx?VHT_Id=" + VHT_13.ID);
        }

        protected void VHT_14_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/VHTDetails.aspx?VHT_Id=" + VHT_14.ID);
        }


        protected void VHT_15_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/VHTDetails.aspx?VHT_Id=" + VHT_15.ID);
        }

        protected void VHT_16_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/VHTDetails.aspx?VHT_Id=" + VHT_16.ID);
        }

        protected void VHT_17_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/VHTDetails.aspx?VHT_Id=" + VHT_17.ID);
        }

        protected void VHT_18_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/VHTDetails.aspx?VHT_Id=" + VHT_18.ID);
        }

        protected void VHT_19_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/VHTDetails.aspx?VHT_Id=" + VHT_19.ID);
        }

        protected void VHT_20_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/VHTDetails.aspx?VHT_Id=" + VHT_20.ID);
        }

        protected void VHT_21_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/VHTDetails.aspx?VHT_Id=" + VHT_21.ID);
        }

        protected void VHT_22_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/VHTDetails.aspx?VHT_Id=" + VHT_22.ID);
        }

        protected void VHT_23_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/VHTDetails.aspx?VHT_Id=" + VHT_23.ID);
        }

        protected void VHT_24_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/VHTDetails.aspx?VHT_Id=" + VHT_24.ID);
        }

        protected void VHT_25_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/VHTDetails.aspx?VHT_Id=" + VHT_25.ID);
        }

        protected void VHT26_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/VHTDetails.aspx?VHT_Id=" + VHT_26.ID);
        }



        public string s { get; set; }
    }
}