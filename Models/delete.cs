using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace display_list.Models
{
    public class delete
    {
        public void Delete_id(int id)
        {
            using (SqlConnection con = new SqlConnection("jn1PQ9CLQ3bbNmJ2uQidfaE2ig9WTypY"))
            {
                SqlCommand cmd = new SqlCommand("sp_Employee_delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                cmd.Parameters.Add(paramId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }
    }
}
