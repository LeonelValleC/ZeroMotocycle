using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxLabel
{
    class Inprocess : Conexion
    {
        int id_inprocess;
        string serialNumber;
        DateTime regSN;

        public int Id_inprocess { get => id_inprocess; set => id_inprocess = value; }
        public string SerialNumber { get => serialNumber; set => serialNumber = value; }
        public DateTime RegSN { get => regSN; set => regSN = value; }
    }
}
