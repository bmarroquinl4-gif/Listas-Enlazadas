using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaEnlazada
{
    public class Nodo
    {
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }

        public Nodo Siguiente { get; set; }

        public Nodo(int codigo, string titulo, string autor)
        {
            Codigo = codigo;
            Titulo = titulo;
            Autor = autor;
            Siguiente = null;
        }
    }
}
