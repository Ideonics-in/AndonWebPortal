using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace AndonPortal.DALayer
{
    public class DataAccess
    {
        String conStr = System.Configuration.ConfigurationManager.
                           ConnectionStrings["IAS_SchneiderConnectionString"].ConnectionString;
        public DataAccess()
        {
            SqlConnection localCon = new SqlConnection(conStr);

            localCon.Open();
            localCon.Close();
        }

        public DataTable getVHTStatus()
        {
            SqlConnection localCon = new SqlConnection(conStr);
            String qry = @"select * from VHT";




            localCon.Open();

            SqlCommand cmd = new SqlCommand(qry, localCon);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);

            cmd.Dispose();
            localCon.Close();
            localCon.Dispose();

            return dt;
        }
        internal DateTime? GetCycleStartTs(int i)
        {

            SqlConnection localCon = new SqlConnection(conStr);
            String qry = @"select top(1) [Timestamp] from VHTStatusTracker where VHT={0} and Status={1} order by [Timestamp] desc ";




            localCon.Open();
            qry = String.Format(qry, i, 1);

            SqlCommand cmd = new SqlCommand(qry, localCon);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);

            cmd.Dispose();
            localCon.Close();
            localCon.Dispose();
            if(dt.Rows.Count > 0 )
                return (DateTime)dt.Rows[0][0];
            return null;
        }


         internal DateTime? GetCycleEndTs(int i)
        {

            SqlConnection localCon = new SqlConnection(conStr);
            String qry = @"select top(1) [Timestamp] from VHTStatusTracker where VHT={0} and Status={1} order by [Timestamp] desc ";




            localCon.Open();
            qry = String.Format(qry, i, 9);

            SqlCommand cmd = new SqlCommand(qry, localCon);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);

            cmd.Dispose();
            localCon.Close();
            localCon.Dispose();
            if(dt.Rows.Count > 0 )
                return (DateTime)dt.Rows[0][0];
            return null;
        }
    
    }
}

