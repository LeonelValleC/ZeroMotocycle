using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero_SN
{
    class User : Conexion
    {
        static int id_user;
        string name;
        static int nemploy;
        string user;
        string password;
        static int id_level;

        public int Id_user { get => id_user; set => id_user = value; }
        public string Name { get => name; set => name = value; }
        public int Nemploy { get => nemploy; set => nemploy = value; }
        public string Users { get => user; set => user = value; }
        public string Password { get => password; set => password = value; }
        public int Id_level { get => id_level; set => id_level = value; }

        public int Login(string user, string password)
        {
            int id = -1;
            SqlCommand cmd = new SqlCommand("select id_user from tb_User where users='" + user + "' and password='" + password + "'", Con1);
            //using (SqlCommand cmd = new SqlCommand("select id_user from tb_User where users='" + user + "' and password='" + password + "'", Con1))
            //{
            Con1.Open();
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //da.Fill(ds);

            //if (cmd.ExecuteScalar() != null)
            id = int.Parse(cmd.ExecuteScalar().ToString());
            //}

            Con1.Close();

            return id;
        }

        public int LoginReprint(string user, string password)
        {
            int id = -1;
            //SqlCommand cmd = new SqlCommand("select * from tb_Usuario where username='" + user + "' and password='" + password + "'", Con1);
            using (SqlCommand cmd = new SqlCommand("select id_user from tb_User u join tb_level tu on u.id_level = tu.id_level where u.users='" + user + "' and u.password='" + password + "' and tu.id_level = 1", Con1))
            {
                Con1.Open();
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //da.Fill(ds);

                if (cmd.ExecuteScalar() != null)
                    id = int.Parse(cmd.ExecuteScalar().ToString());
            }

            Con1.Close();

            return id;
        }
    }
}
