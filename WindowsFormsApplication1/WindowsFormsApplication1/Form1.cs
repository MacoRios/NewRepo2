using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data; 
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form

    {
        int contador = -1;

        List<album> cancioness = new List<album>();

        public string nom;
        public List<string> lista = new List<string>();
        public string can = "";


        XmlDocument xDoc = new XmlDocument();
        XmlDocument xDoc2 = new XmlDocument();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = new System.Drawing.Bitmap(@"H:\reproductor\reproductor\bin\Debug\imagenes\biblioteca.jpg");
            //I:\reproductor\reproductor\bin\Debug\imagenes }
            button1.Visible = false;

            //mostrar lista

            XmlDocument xDoc = new XmlDocument();


            xDoc.Load(@"H:\reproductor\reproductor\bin\Debug\musicas.txt");



            XmlNodeList canciones = xDoc.GetElementsByTagName("canciones");
            XmlNodeList lista = ((XmlElement)canciones[0]).GetElementsByTagName("cancion");


            foreach (XmlElement nodo in lista)
            {
                int i = 0;


                album musicatemp = new album();


                XmlNodeList Nombre = nodo.GetElementsByTagName("nombre");
                XmlNodeList Ubicacion = nodo.GetElementsByTagName("ubicacion");


                musicatemp.Nombre = Nombre[i].InnerText;
                musicatemp.Ubicacion = Ubicacion[i].InnerText;



                cancioness.Add(musicatemp);
                contador = contador + 1;
            }


            dataGridView1.DataSource = null;
            dataGridView1.Refresh();

            dataGridView1.DataSource = cancioness;

            dataGridView1.Columns[0].DisplayIndex = 1;

            dataGridView1.Update();



            //////

        }


    

    private void pictureBox2_Click(object sender, EventArgs e)
        {
            int ind;

            ind = dataGridView1.CurrentRow.Index;

            axWindowsMediaPlayer1.URL = dataGridView1[0, ind].Value.ToString();

            label1.Text = Path.GetFileNameWithoutExtension(axWindowsMediaPlayer1.URL);

            try
            {
                pictureBox1.Image = new System.Drawing.Bitmap(@"H:\reproductor\reproductor\bin\Debug\imagenes\" + label1.Text + ".jpg");
                //I:\reproductor\reproductor\bin\Debug\imagenes }

                listBox1.Items.Clear();
                listBox1.Visible = true;

                StreamReader R = new StreamReader(@"H:\reproductor\reproductor\bin\Debug\letras\" + label1.Text + ".txt");
                string r;
                while ((r = R.ReadLine()) != null)
                {
                    listBox1.Items.Add(r);
                }
                R.Close();
            }
            catch (Exception)
            {
                listBox1.Visible = false;
                pictureBox1.Image = new System.Drawing.Bitmap(@"H:\reproductor\reproductor\bin\Debug\imagenes\biblioteca.jpg");
                //I:\reproductor\reproductor\bin\Debug\imagenes }

            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            int ind;
            ind = dataGridView1.CurrentRow.Index;



            //obtiene el valor de la celda
            // int cont=dataGridView1.RowCount ;
            // int asu=0;


            if (ind > 0)
            {


                dataGridView1.CurrentCell = dataGridView1[0, ind - 1];


                int inu;

                inu = dataGridView1.CurrentRow.Index;

                axWindowsMediaPlayer1.URL = dataGridView1[0, inu].Value.ToString();
                label1.Text = Path.GetFileNameWithoutExtension(axWindowsMediaPlayer1.URL);

                try
                {
                    pictureBox1.Image = new System.Drawing.Bitmap(@"H:\reproductor\reproductor\bin\Debug\imagenes\" + label1.Text + ".jpg");
                    //I:\reproductor\reproductor\bin\Debug\imagenes }
                    listBox1.Items.Clear();
                    listBox1.Visible = true;
                    StreamReader R = new StreamReader(@"H:\reproductor\reproductor\bin\Debug\letras\" + label1.Text + ".txt");
                    string r;
                    while ((r = R.ReadLine()) != null)
                    {
                        listBox1.Items.Add(r);
                    }
                    R.Close();
                }
                catch (Exception)
                {
                    listBox1.Visible = false;
                    pictureBox1.Image = new System.Drawing.Bitmap(@"H:\reproductor\reproductor\bin\Debug\imagenes\biblioteca.jpg");
                    //I:\reproductor\reproductor\bin\Debug\imagenes }
                }


            }
            else
            {

                dataGridView1.CurrentCell = dataGridView1[0, contador];

                int inu;

                inu = dataGridView1.CurrentRow.Index;

                axWindowsMediaPlayer1.URL = dataGridView1[0, inu].Value.ToString();
                label1.Text = Path.GetFileNameWithoutExtension(axWindowsMediaPlayer1.URL);

                try
                {
                    pictureBox1.Image = new System.Drawing.Bitmap(@"H:\reproductor\reproductor\bin\Debug\imagenes\" + label1.Text + ".jpg");
                    //I:\reproductor\reproductor\bin\Debug\imagenes }
                    listBox1.Items.Clear();

                    listBox1.Visible = true;
                    StreamReader R = new StreamReader(@"H:\reproductor\reproductor\bin\Debug\letras\" + label1.Text + ".txt");
                    string r;
                    while ((r = R.ReadLine()) != null)
                    {
                        listBox1.Items.Add(r);
                    }
                    R.Close();

                }
                catch (Exception)
                {
                    listBox1.Visible = false;
                    pictureBox1.Image = new System.Drawing.Bitmap(@"H:\reproductor\reproductor\bin\Debug\imagenes\biblioteca.jpg");
                    //I:\reproductor\reproductor\bin\Debug\imagenes }
                }


            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            int ind;
            ind = dataGridView1.CurrentRow.Index;



            //obtiene el valor de la celda
            // int cont=dataGridView1.RowCount ;
            // int asu=0;


            if (ind < contador)
            {


                dataGridView1.CurrentCell = dataGridView1[0, ind + 1];



                int inu;

                inu = dataGridView1.CurrentRow.Index;

                axWindowsMediaPlayer1.URL = dataGridView1[0, inu].Value.ToString();
                label1.Text = Path.GetFileNameWithoutExtension(axWindowsMediaPlayer1.URL);

                try
                {
                    pictureBox1.Image = new System.Drawing.Bitmap(@"H:\reproductor\reproductor\bin\Debug\imagenes\" + label1.Text + ".jpg");
                    //I:\reproductor\reproductor\bin\Debug\imagenes }

                    listBox1.Items.Clear();
                    listBox1.Visible = true;

                    StreamReader R = new StreamReader(@"H:\reproductor\reproductor\bin\Debug\letras\" + label1.Text + ".txt");
                    string r;
                    while ((r = R.ReadLine()) != null)
                    {
                        listBox1.Items.Add(r);
                    }
                    R.Close();
                }
                catch (Exception)
                {
                    listBox1.Visible = false;
                    pictureBox1.Image = new System.Drawing.Bitmap(@"H:\reproductor\reproductor\bin\Debug\imagenes\biblioteca.jpg");
                    //I:\reproductor\reproductor\bin\Debug\imagenes }
                }


            }
            else
            {
                dataGridView1.CurrentCell = dataGridView1[0, 0];
                int inu;

                inu = dataGridView1.CurrentRow.Index;

                axWindowsMediaPlayer1.URL = dataGridView1[0, inu].Value.ToString();
                label1.Text = Path.GetFileNameWithoutExtension(axWindowsMediaPlayer1.URL);

                try
                {
                    pictureBox1.Image = new System.Drawing.Bitmap(@"H:\reproductor\reproductor\bin\Debug\imagenes\" + label1.Text + ".jpg");
                    //I:\reproductor\reproductor\bin\Debug\imagenes }

                    listBox1.Items.Clear();
                    listBox1.Visible = true;

                    StreamReader R = new StreamReader(@"H:\reproductor\reproductor\bin\Debug\letras\" + label1.Text + ".txt");
                    string r;
                    while ((r = R.ReadLine()) != null)
                    {
                        listBox1.Items.Add(r);
                    }
                    R.Close();
                }
                catch (Exception)
                {
                    listBox1.Visible = false;
                    pictureBox1.Image = new System.Drawing.Bitmap(@"H:\reproductor\reproductor\bin\Debug\imagenes\biblioteca.jpg");
                    //I:\reproductor\reproductor\bin\Debug\imagenes }
                }
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void autorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
