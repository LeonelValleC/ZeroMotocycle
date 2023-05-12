using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero_SN
{
    class PN : Conexion
    {
        int id_pn;
        string pn;
        string rev;

        public int Id_pn { get => id_pn; set => id_pn = value; }
        public string Pn { get => pn; set => pn = value; }
        public string Rev { get => rev; set => rev = value; }
    }
}
