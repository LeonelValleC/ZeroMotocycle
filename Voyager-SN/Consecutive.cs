using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero_SN
{
    class Consecutive : Conexion
    {
        int id_consecutive;
        string type;
        int consecutive;

        public int Id_consecutive { get => id_consecutive; set => id_consecutive = value; }
        public string Type { get => type; set => type = value; }
        public int Cons { get => consecutive; set => consecutive = value; }
    }
}
