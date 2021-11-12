using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace display_list.Models
{
    public class list
    {
        public static List<display_entity> displays_student()
        {
            SqlConnection con = new SqlConnection("Data Source=61.0.171.102;Initial Catalog=ESS;Persist Security Info=True;User ID=sa;Password=Turbopower76");

            List<display_entity> displays_l = new List<display_entity>();
            SqlCommand com = new SqlCommand("Sp_tbl_select", con);
            com.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(com);
            adp.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                displays_l.Add(new display_entity
                {
                    id = Convert.ToInt32(dr[0]),
                    txtName = Convert.ToString(dr[1]),
                    sex = Convert.ToString(dr[2]),
                    txtCourse = Convert.ToString(dr[3]),
                    TC = Convert.ToString(dr[4]),
                    txtFeed = Convert.ToString(dr[5]),
                    //std_sugg = Convert.ToString(dr[6])

                });

            }
           // return lst;

            return displays_l;

        }
    }
}
