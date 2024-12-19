using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Archivos_Sec
{
    public partial class Form1 : Form
    {
        // Declaración de variables y objetos utilizados
        entero n1;              // Objeto de tipo entero (personalizado)
        VectorEnt v1, v2, v3, vR;   // Objetos de tipo VectorEnt (vectores)
        Archivo a1, a2, a3, a4;     // Objetos de tipo Archivo (para manipulación de archivos)

        // Constructor del formulario
        public Form1()
        {
            InitializeComponent(); // Inicializa los componentes del formulario
        }

        // Evento que se ejecuta al cargar el formulario
        private void Form1_Load(object sender, EventArgs e)
        {
            // Inicialización de los objetos personalizados
            n1 = new entero();
            v1 = new VectorEnt();
            v2 = new VectorEnt();
            v3 = new VectorEnt();
            vR = new VectorEnt();
            a1 = new Archivo();
            a2 = new Archivo();
            a3 = new Archivo();
            a4 = new Archivo();
        }

        // Evento del botón "Limpiar" para limpiar los campos de texto
        private void button1_Click(object sender, EventArgs e)
        {
            // Borra el contenido de los TextBox
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        // Evento para cargar datos en el vector v1
        private void cargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            v1.cargar(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text));
            v1.OrdAsc();
            //v1.OrdDesc();
        }

        // Evento para descargar los datos del vector v1 y mostrarlos en textBox4
        private void descargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox4.Text = v1.descargar();
        }

        // Evento para acceder a un archivo y cargar sus datos en el vector vR
        private void accesarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog(); // Muestra el cuadro de diálogo para abrir archivos
            vR.AccesarV(openFileDialog1.FileName); // Carga el archivo seleccionado en vR
        }

        // Evento para grabar los datos del vector v1 en un archivo
        private void grabarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog(); // Muestra el cuadro de diálogo para guardar archivos
            v1.GrabarV(saveFileDialog1.FileName); // Guarda el vector v1 en el archivo seleccionado
        }

        // Evento para ejecutar el "Ejercicio 1" en el objeto a1
        private void ejercicio1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            saveFileDialog1.ShowDialog();
            a1.Ejer1(openFileDialog1.FileName, saveFileDialog1.FileName, a2);

        }

        // Evento para ejecutar el "Ejercicio 2" y mostrar el resultado en textBox6
        private void ejercicio2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBox6.Text = string.Concat(a1.Ejer2(openFileDialog1.FileName, int.Parse(textBox3.Text)));
        }

        // Evento para descargar el contenido del vector vR y mostrarlo en textBox7
        private void descargarRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox7.Text = vR.descargar();
        }

        // Evento para descargar el contenido del vector v2 y mostrarlo en textBox5
        private void descargarv2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        // Evento para grabar el contenido del vector v2 en un archivo
        private void grabarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        // Evento para cargar manualmente datos en el vector v2
        private void cargarManual2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
        //------------------------------------------------------------------------------------------
        //MENU V3
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            
        }

        private void ejercicio5ExamenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }



        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }

        private void ejercicio7ExamenRepechajeSBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //7
            // Abre los diálogos para seleccionar los archivos de entrada y salida.
            openFileDialog1.ShowDialog(); // Archivo 1 (entrada)
            saveFileDialog1.ShowDialog(); // Archivo 2 (resultado purado)

            // Ejecuta el método PurarArchivo con los archivos seleccionados.
            a1.PurarArchivo(openFileDialog1.FileName, saveFileDialog1.FileName,a2);

        }

        //------------------------------------------------------------------------------------------


        // Evento para cargar datos en el vector v2
        private void cargarv2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
       
        }

        // Evento para cargar manualmente datos en el vector v1
        private void cargarManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            v1.cargarmanual(int.Parse(textBox1.Text));
        }

        // Evento para ejecutar el "Ejercicio 3" con archivos
        private void ejercicio3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            openFileDialog2.ShowDialog();
            saveFileDialog1.ShowDialog();
            a1.Ejer3(openFileDialog1.FileName, openFileDialog2.FileName, saveFileDialog1.FileName, a2, a3);
        }

        // Evento sin funcionalidad específica aún
        private void proyectoArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        // Evento para ejecutar el "Ejercicio 4" con archivos
        private void ejercicio4ToolStripMenuItem_Click(object sender, EventArgs e)
        {



        }

        private void ejercicio5ExamenToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            
        }

    }
}
