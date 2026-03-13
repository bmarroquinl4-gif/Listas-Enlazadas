using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace UMG
{
    // Clase principal del formulario de Windows Forms
    public partial class Form1 : Form
    {
        // Se crea una instancia de la lista enlazada
        // Esta lista almacenará los estudiantes
        ListaEnlazada lista = new ListaEnlazada();

        // Constructor del formulario
        public Form1()
        {
            InitializeComponent(); // Inicializa todos los controles del formulario
        }

        // ---------------------------------------------------------
        // MÉTODO PARA ACTUALIZAR LA TABLA (DataGridView)
        // ---------------------------------------------------------
        void ActualizarTabla()
        {
            // Primero se limpia el origen de datos
            dgvDatos.DataSource = null;

            // Luego se vuelve a cargar con la lista actual
            // ObtenerLista() devuelve todos los datos de la lista enlazada
            dgvDatos.DataSource = lista.ObtenerLista();
        }

        // ---------------------------------------------------------
        // MÉTODO PARA LIMPIAR LOS CAMPOS DEL FORMULARIO
        // ---------------------------------------------------------
        void LimpiarCampos()
        {
            // Se limpian todos los TextBox
            txtCarnet.Text = "";
            txtNombre.Text = "";
            txtCarrera.Text = "";
            txtPosicion.Text = "";

            // El cursor vuelve al campo Carnet
            txtCarnet.Focus();
        }

        // ---------------------------------------------------------
        // BOTÓN ELIMINAR
        // ---------------------------------------------------------
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Convierte el texto del TextBox a entero
            int carnet = int.Parse(txtCarnet.Text);

            // Llama al método Eliminar de la lista enlazada
            lista.Eliminar(carnet);

            // Actualiza la tabla con los datos nuevos
            ActualizarTabla();

            // Limpia los campos
            LimpiarCampos();
        }

        // ---------------------------------------------------------
        // BOTÓN INSERTAR AL INICIO
        // ---------------------------------------------------------
        private void btnInicio_Click(object sender, EventArgs e)
        {
            // Convierte el carnet ingresado a entero
            int carnet = int.Parse(txtCarnet.Text);

            // Inserta un nuevo nodo al inicio de la lista
            lista.InsertarInicio(carnet, txtNombre.Text, txtCarrera.Text);

            // Actualiza la tabla para mostrar los cambios
            ActualizarTabla();

            // Limpia los campos
            LimpiarCampos();
        }

        // ---------------------------------------------------------
        // BOTÓN INSERTAR AL FINAL
        // ---------------------------------------------------------
        private void btnFInal_Click(object sender, EventArgs e)
        {
            // Convierte el carnet ingresado a entero
            int carnet = int.Parse(txtCarnet.Text);

            // Inserta un nodo al final de la lista enlazada
            lista.InsertarFinal(carnet, txtNombre.Text, txtCarrera.Text);

            // Actualiza la tabla con los datos nuevos
            ActualizarTabla();

            // Limpia los campos
            LimpiarCampos();
        }

        // ---------------------------------------------------------
        // BOTÓN INSERTAR EN POSICIÓN ESPECÍFICA
        // ---------------------------------------------------------
        private void btnPosicion_Click(object sender, EventArgs e)
        {
            // Obtiene el carnet ingresado
            int carnet = int.Parse(txtCarnet.Text);

            // Obtiene la posición donde se insertará el nodo
            int pos = int.Parse(txtPosicion.Text);

            // Inserta el nodo en la posición indicada
            lista.InsertarPosicion(pos, carnet, txtNombre.Text, txtCarrera.Text);

            // Actualiza la tabla
            ActualizarTabla();

            // Limpia los campos
            LimpiarCampos();
        }

        // ---------------------------------------------------------
        // BOTÓN BUSCAR
        // ---------------------------------------------------------
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Convierte el carnet ingresado a entero
            int carnet = int.Parse(txtCarnet.Text);

            // Busca el nodo en la lista enlazada
            Nodo encontrado = lista.Buscar(carnet);

            // Si se encontró el estudiante
            if (encontrado != null)
            {
                // Se muestran los datos en los TextBox
                txtNombre.Text = encontrado.Nombre;
                txtCarrera.Text = encontrado.Carrera;
            }
            else
            {
                // Si no existe el carnet en la lista
                MessageBox.Show("No se encontro el estudianate");
            }
        }
    }
}
