using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NixPDC
{
    class Constantes
    {
        public static string path = AppDomain.CurrentDomain.BaseDirectory;
        public static bool headless = false;
        public static int timeOut = 180; //tempo maximo para uma página carregar

        public static string connectionString = "Data Source=108.167.188.175; user id=assismai_assis; password=Ndbjhib6!@x5p7kkrj; database=assismai_assis;";

        public static string usuarioPDC = "";
        public static string senhaPDC = "";
    }
}
