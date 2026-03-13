using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListaEnlazada
{
    // Clase principal del formulario
    public partial class Form1 : Form
    {
        // Se crea una instancia de la clase ListaEnlazada
        // Esta lista almacenará los datos de los libros
        ListaEnlazada lista = new ListaEnlazada();

        // ---------------------------------------------------------
        // MÉTODO PARA ACTUALIZAR LA TABLA (DataGridView)
        // ---------------------------------------------------------
        void ActualiarTabla()
        {
            // Se limpia el origen de datos actual
            dgvDatos.DataSource = null;

            // Se vuelve a cargar con los datos de la lista enlazada
            dgvDatos.DataSource = lista.ObtenerLista();
        }

        // ---------------------------------------------------------
        // EVENTO QUE SE EJECUTA CUANDO EL FORMULARIO SE CARGA
        // ---------------------------------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {
            // Ajusta automáticamente el tamaño de las columnas
            // para que ocupen todo el ancho del DataGridView
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ---------------------------------------------------------
        // CONSTRUCTOR DEL FORMULARIO
        // ---------------------------------------------------------
        public Form1()
        {
            InitializeComponent(); // Inicializa todos los componentes visuales
        }

        // ---------------------------------------------------------
        // MÉTODO PARA LIMPIAR LOS CAMPOS DEL FORMULARIO
        // ---------------------------------------------------------
        void LimpiarCampos()
        {
            // Se limpian todos los TextBox
            txtCodigo.Text = "";
            txtTitulo.Text = "";
            txtAutor.Text = "";

            // El cursor vuelve al campo código
            txtCodigo.Focus();
        }

        // Evento del label (no realiza ninguna acción)
        private void label1_Click(object sender, EventArgs e)
        {

        }

        // ---------------------------------------------------------
        // BOTÓN INSERTAR AL INICIO DE LA LISTA
        // ---------------------------------------------------------
        private void btnInicio_Click(object sender, EventArgs e)
        {
            // Convierte el texto del TextBox a entero
            int codgo = int.Parse(txtCodigo.Text);

            // Inserta un nuevo nodo al inicio de la lista
            lista.InsertarInicio(codgo, txtTitulo.Text, txtAutor.Text);

            // Muestra un mensaje confirmando la inserción
            MessageBox.Show("Insertado");

            // Actualiza la tabla para mostrar el nuevo registro
            ActualiarTabla();

            // Limpia los campos del formulario
            LimpiarCampos();
        }

        // ---------------------------------------------------------
        // BOTÓN INSERTAR AL FINAL DE LA LISTA
        // ---------------------------------------------------------
        private void btnFinal_Click(object sender, EventArgs e)
        {
            // Convierte el código a entero
            int codigo = int.Parse(txtCodigo.Text);

            // Inserta un nodo al final de la lista enlazada
            lista.InsertarFInal(codigo, txtTitulo.Text, txtAutor.Text);

            // Actualiza la tabla
            ActualiarTabla();

            // Limpia los campos
            LimpiarCampos();
        }

        // ---------------------------------------------------------
        // BOTÓN INSERTAR EN UNA POSICIÓN ESPECÍFICA
        // ---------------------------------------------------------
        private void btnPosicion_Click(object sender, EventArgs e)
        {
            // Obtiene el código ingresado
            int codigo = int.Parse(txtCodigo.Text);

            // Obtiene la posición donde se insertará el nodo
            int pos = int.Parse(txtPosicion.Text);

            // Inserta el nodo en la posición indicada
            lista.InsertarPosicion(pos, codigo, txtTitulo.Text, txtAutor.Text);

            // Actualiza la tabla
            ActualiarTabla();

            // Limpia los campos
            LimpiarCampos();
        }

        // ---------------------------------------------------------
        // BOTÓN ELIMINAR UN NODO DE LA LISTA
        // ---------------------------------------------------------
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Obtiene el código del libro a eliminar
            int codigo = int.Parse(txtCodigo.Text);

            // Llama al método eliminar de la lista enlazada
            lista.Eliminar(codigo);

            // Actualiza la tabla
            ActualiarTabla();

            // Limpia los campos
            LimpiarCampos();
        }

        // ---------------------------------------------------------
        // BOTÓN BUSCAR UN LIBRO EN LA LISTA
        // ---------------------------------------------------------
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Obtiene el código a buscar
            int codigo = int.Parse(txtCodigo.Text);

            // Busca el nodo dentro de la lista enlazada
            Nodo encontrado = lista.Buscar(codigo);

            // Si el nodo fue encontrado
            if (encontrado != null)
            {
                // Se muestran los datos en los TextBox
                txtTitulo.Text = encontrado.Titulo;
                txtAutor.Text = encontrado.Autor;
            }
            else
            {
                // Si no existe el código
                MessageBox.Show("NO se encontro");
            }

            // Limpia los campos después de la búsqueda
            LimpiarCampos();
        }
    }
}