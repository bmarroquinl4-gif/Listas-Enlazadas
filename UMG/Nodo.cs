using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMG
{
    public class Nodo
    {
        public int Carnet { get; set; }
        public string Nombre { get; set; }
        public string Carrera { get; set; }

        public Nodo Siguiente { get; set; }

        public Nodo(int carnet, string nombre, string carrera)
        {
            Carnet = carnet;
            Nombre = nombre;
            Carrera = carrera;
            Siguiente = null;
        }
    }
}
