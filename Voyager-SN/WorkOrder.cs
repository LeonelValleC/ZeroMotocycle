using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero_SN
{
    class WorkOrder : Conexion
    {
        int id_wo;
        static string wo;
        int qty;
        int qtyReq;
        int totalUsed;
        DateTime dateReg;

        public int Id_wo { get => id_wo; set => id_wo = value; }
        public string Wo { get => wo; set => wo = value; }
        public int Qty { get => qty; set => qty = value; }
        public int QtyReq { get => qtyReq; set => qtyReq = value; }
        public int TotalUsed { get => totalUsed; set => totalUsed = value; }
        public DateTime DateReg { get => dateReg; set => dateReg = value; }


        private SqlConnection Conex; // Obj Conexion

        public WorkOrder() =>
        Conex = new SqlConnection(@"Data Source=192.168.4.5\SQLEXPRESS;Initial Catalog=master;User ID=sa;Password=Mexmei15!;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        private SqlConnection Con { get => Conex; set => Conex = value; }


        /// <summary>
        /// Metodo para abrir la conexion con la base de datos
        /// </summary>
        public new void Abrir() // Metodo para Abrir la Conexion
        {
            Conex.Open();
        }

        /// <summary>
        /// Metodo para cerrar la conexion con la base de datos
        /// </summary>
        public new void Cerrar() // Metodo para Cerrar la Conexion
        {
            Conex.Close();
        }

        public string ReturnFromROI(string comando)
        {
            string valor;
            try
            {
                using (SqlCommand CMD = new SqlCommand(comando, Conex))
                {
                    this.Abrir();
                    //CMD.ExecuteNonQuery();
                    valor = CMD.ExecuteScalar().ToString();
                }
                if (valor == "")
                    valor = "0";
            }
            catch (Exception)
            {
                valor = "0";
            }
            this.Cerrar();
            return valor;
        }
    }
}
