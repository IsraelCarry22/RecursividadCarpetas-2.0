using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecursividadCarpetas_2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            using (var SeleccionaCarpeta = new FolderBrowserDialog())
            {
                if (SeleccionaCarpeta.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                string RutaCarpeta = SeleccionaCarpeta.SelectedPath;
                listBox1.Items.Clear();
                ListaRecursividadCarpetas(RutaCarpeta);
            }
        }

        public void ListaRecursividadCarpetas(string carpetas)
        {
            DirectoryInfo directory = new DirectoryInfo(carpetas);
            foreach (FileInfo Archivo in directory.GetFiles())
            {
                string nombre = Archivo.Name;
                string extension = Archivo.Extension;
                listBox1.Items.Add($"Nom: {nombre} || extension: {extension}.");
            }
            foreach (DirectoryInfo subdirectory in directory.GetDirectories())
            {
                listBox1.Items.Add($"Subcarpeta: {subdirectory.Name}");
                ListaRecursividadCarpetas(subdirectory.FullName);
            }
        }
    }
}
