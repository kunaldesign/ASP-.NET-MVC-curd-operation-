using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace display_list.Models
{
    public class Update
    {
        public bool UpdateDetails(display_entity de)
        {
            int i;
            SqlConnection con = new SqlConnection("Data Source=61.0.171.102;Initial Catalog=ESS;Persist Security Info=True;User ID=sa;Password=Turbopower76");
            
                SqlCommand cmd = new SqlCommand("sp_update", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", de.id);
                cmd.Parameters.AddWithValue("@st_name", de.txtName);
                cmd.Parameters.AddWithValue("@st_sex", de.sex);
                cmd.Parameters.AddWithValue("@st_coures", de.txtCourse);
                cmd.Parameters.AddWithValue("@st_Tech", de.TC);
                cmd.Parameters.AddWithValue("@st_sugg", de.txtFeed);

               
                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
    }
}
