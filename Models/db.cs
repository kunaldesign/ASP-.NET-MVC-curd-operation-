using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace display_list.Models
{
    public class db
    {
        SqlConnection con = new SqlConnection("Data Source=61.0.171.102;Initial Catalog=ESS;Persist Security Info=True;User ID=sa;Password=Turbopower76");
        public string AddFeedbackRecord(display_entity rg)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[tbl_regis]
           ([st_name]
           ,[st_sex]
           ,[st_coures]
           ,[st_Tech]
           ,[st_sugg])
     VALUES
           ('" + rg.txtName + "','" + rg.sex + "','" + rg.txtCourse + "','" + rg.TC + "','" + rg.txtFeed + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


                //start
                SqlCommand cot = new SqlCommand("Sp_id", con);
                cot.CommandType = CommandType.StoredProcedure;
                cot.Parameters.AddWithValue("@st_name", rg.txtName);
                SqlParameter objid = new SqlParameter();
                objid.ParameterName = "@return";
                objid.SqlDbType = SqlDbType.Int;
                objid.Direction = ParameterDirection.Output;
                cot.Parameters.Add(objid);
                con.Open();
                cot.ExecuteNonQuery();
                int res = Convert.ToInt32(objid.Value);
                con.Close();
                return "your feed back id is " + Convert.ToString(res);
                //end

                //return "you feedback has been recorded";

            }




            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return (ex.Message.ToString());
            }
        }
    }
}
