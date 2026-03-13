using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace UMG
{
    public  class ListaEnlazada
    {
        Nodo cabeza = null;

        // Insertar al inicio
        public void InsertarInicio(int carnet, string nombre, string carrera)
        {
            Nodo nuevo = new Nodo(carnet, nombre, carrera);

            nuevo.Siguiente = cabeza;
            cabeza = nuevo;
        }

        // Insertar al final
        public void InsertarFinal(int carnet, string nombre, string carrera)
        {
            Nodo nuevo = new Nodo(carnet, nombre, carrera);

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

        // Insertar en posición
        public void InsertarPosicion(int posicion, int carnet, string nombre, string carrera)
        {
            Nodo nuevo = new Nodo(carnet, nombre, carrera);

            Nodo actual = cabeza;

            for (int i = 0; i < posicion - 1; i++)
            {
                if (actual.Siguiente != null)
                    actual = actual.Siguiente;
            }

            nuevo.Siguiente = actual.Siguiente;
            actual.Siguiente = nuevo;
        }

        // Eliminar
        public void Eliminar(int carnet)
        {
            if (cabeza == null) return;

            if (cabeza.Carnet == carnet)
            {
                cabeza = cabeza.Siguiente;
                return;
            }

            Nodo actual = cabeza;

            while (actual.Siguiente != null)
            {
                if (actual.Siguiente.Carnet == carnet)
                {
                    actual.Siguiente = actual.Siguiente.Siguiente;
                    return;
                }

                actual = actual.Siguiente;
            }
        }

        // Buscar
        public Nodo Buscar(int carnet)
        {
            Nodo actual = cabeza;

            while (actual != null)
            {
                if (actual.Carnet == carnet)
                    return actual;

                actual = actual.Siguiente;
            }

            return null;
        }

        // Convertir a lista para el DataGridView
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
