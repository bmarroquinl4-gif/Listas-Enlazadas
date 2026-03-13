using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListaEnlazada
{
    public class ListaEnlazada
    {
        Nodo cabeza = null;

        // Insertar al inicio 

        public void InsertarInicio( int codigo, string titulo, string autor)
        {
            Nodo nuevo = new Nodo(codigo, titulo, autor);

            nuevo.Siguiente = cabeza;
            cabeza = nuevo;
        }

        // insetar al final
        public void InsertarFInal(int codigo, string titulo, string autor)
        {
            Nodo nuevo = new Nodo(codigo, titulo, autor);

            if (cabeza == null)
            {
                cabeza = nuevo;
                return;

            }
            Nodo actual = cabeza;

            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevo;

        }

        // insertar en posiscion intermedio 
        public void InsertarPosicion(int posicion, int codigo, string titulo, string autor)
        {
            Nodo nuevo= new Nodo(codigo,titulo,autor);

            Nodo actual = cabeza;

            for (int i=0; i < posicion - 1; i++)
            {
                if (actual.Siguiente !=null)
                    actual = actual.Siguiente;

            }
            nuevo.Siguiente = actual.Siguiente;
            actual.Siguiente = nuevo;

        }

        //Eliminar
        public void Eliminar(int codigo)
        {
            if (cabeza == null) return;

            if (cabeza.Codigo == codigo)
            {
                cabeza = cabeza.Siguiente;
                return;

            }
            Nodo actual = cabeza;

            while(actual.Siguiente != null)
            {
                if( actual.Siguiente.Codigo== codigo)
                {
                    actual.Siguiente = actual.Siguiente.Siguiente;
                    return;
                }
                actual = actual.Siguiente;
            }
        }

        //Buscar
        public Nodo Buscar(int codigo)
        {
            Nodo actual = cabeza;

            while (actual != null)
            {
                if (actual.Codigo == codigo)
                    return actual;

                actual = actual.Siguiente;
            }

            return null;
        }
        // Convertir lista a list para mostrar la tabla
        public List<Nodo> ObtenerLista()
        {
            List<Nodo> lista = new List<Nodo>();

            Nodo actual = cabeza;

            while (actual != null)
            {
                lista.Add(actual);
                actual = actual.Siguiente;
            }

            return lista;
        }

    }
}
