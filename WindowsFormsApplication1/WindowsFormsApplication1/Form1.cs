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

        List<album> cancionesss = new List<album>();

        public string nom;
        public List<string> lista = new List<string>();
        public string can = "";

        XmlDocument xDoc = new XmlDocument();
        XmlDocument xDoc2 = new XmlDocument();

        public Form1()
        {
            InitializeComponent();
            MessageBox.Show("Bienvenido a mi Reproductor: aca puedes escuchar canciones de cualquier carpeta o usar mi modo karaoke con las canciones que puedes ver en la Biblioteca, solo sigue el ritmo de la cancion y repite la letra");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = new System.Drawing.Bitmap(@"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\imagenes\biblioteca.jpg");        
            button1.Visible = false;
            //mostrar lista
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\musica.txt");
          
           
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

                cancionesss.Add(musicatemp);
                contador = contador + 1;
            }

            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = cancionesss;
            dataGridView1.Columns[0].DisplayIndex = 1;
            dataGridView1.Update();       
        }


   
    private void pictureBox2_Click(object sender, EventArgs e)
        {
            int ind;

            ind = dataGridView1.CurrentRow.Index;

            axWindowsMediaPlayer1.URL = dataGridView1[0, ind].Value.ToString();

            label1.Text = Path.GetFileNameWithoutExtension(axWindowsMediaPlayer1.URL);

            try
            {
                
                pictureBox1.Image = new System.Drawing.Bitmap(@"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\imagenes\" + label1.Text + ".jpg");                
               listBox1.Items.Clear();
                listBox1.Visible = true;

                StreamReader R = new StreamReader(@"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\letras\" + label1.Text + ".txt");
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
                pictureBox1.Image = new System.Drawing.Bitmap(@"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\imagenes\biblioteca.jpg");
               

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

            if (ind > 0)
            {

                dataGridView1.CurrentCell = dataGridView1[0, ind - 1];
                int inu;
                inu = dataGridView1.CurrentRow.Index;
                axWindowsMediaPlayer1.URL = dataGridView1[0, inu].Value.ToString();
                label1.Text = Path.GetFileNameWithoutExtension(axWindowsMediaPlayer1.URL);

                try
                {
                    pictureBox1.Image = new System.Drawing.Bitmap(@"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\imagenes\" + label1.Text + ".jpg");
                  
                    listBox1.Items.Clear();
                    listBox1.Visible = true;
                    StreamReader R = new StreamReader(@"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\letras\" + label1.Text + ".txt");
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
                    pictureBox1.Image = new System.Drawing.Bitmap(@"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\imagenes\biblioteca.jpg");
                   
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
                    pictureBox1.Image = new System.Drawing.Bitmap(@"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\imagenes\" + label1.Text + ".jpg");                
                    listBox1.Items.Clear();
                    listBox1.Visible = true;
                    StreamReader R = new StreamReader(@"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\letras\" + label1.Text + ".txt");
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
                    pictureBox1.Image = new System.Drawing.Bitmap(@"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\imagenes\biblioteca.jpg");
                    
                }

            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            int ind;
            ind = dataGridView1.CurrentRow.Index;

            if (ind < contador)
            {


                dataGridView1.CurrentCell = dataGridView1[0, ind + 1];



                int inu;

                inu = dataGridView1.CurrentRow.Index;

                axWindowsMediaPlayer1.URL = dataGridView1[0, inu].Value.ToString();
                label1.Text = Path.GetFileNameWithoutExtension(axWindowsMediaPlayer1.URL);

                try
                {
                    pictureBox1.Image = new System.Drawing.Bitmap(@"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\imagenes\" + label1.Text + ".jpg");               
                    listBox1.Items.Clear();
                    listBox1.Visible = true;

                    StreamReader R = new StreamReader(@"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\letras\" + label1.Text + ".txt");
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
                    pictureBox1.Image = new System.Drawing.Bitmap(@"C: \Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\imagenes\biblioteca.jpg");                 
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
                    pictureBox1.Image = new System.Drawing.Bitmap(@"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\imagenes\" + label1.Text + ".jpg");
                 

                    listBox1.Items.Clear();
                    listBox1.Visible = true;

                    StreamReader R = new StreamReader(@"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\letras\" + label1.Text + ".txt");
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
                    pictureBox1.Image = new System.Drawing.Bitmap(@"C: \Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\imagenes\biblioteca.jpg");
                   
                }
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void autorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("HECHO POR MARCO ANTONIO RIOS GARCIA");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int ind;
            ind = dataGridView1.CurrentRow.Index;
            axWindowsMediaPlayer1.URL = dataGridView1[0, ind].Value.ToString();
            label1.Text = Path.GetFileNameWithoutExtension(axWindowsMediaPlayer1.URL);
            try
            {
                pictureBox1.Image = new System.Drawing.Bitmap(@"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\imagenes\" + label1.Text + ".jpg");             
                listBox1.Items.Clear();
                listBox1.Visible = true;

                StreamReader R = new StreamReader(@"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\letras\" + label1.Text + ".txt");
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
                pictureBox1.Image = new System.Drawing.Bitmap(@"C: \Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\imagenes\biblioteca.jpg");
             
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void button5_Click(object sender, EventArgs e)
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
                    pictureBox1.Image = new System.Drawing.Bitmap(@"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\imagenes\" + label1.Text + ".jpg");
                    //I:\reproductor\reproductor\bin\Debug\imagenes }

                    listBox1.Items.Clear();
                    listBox1.Visible = true;

                    StreamReader R = new StreamReader(@"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\letras\" + label1.Text + ".txt");
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
                    pictureBox1.Image = new System.Drawing.Bitmap(@"C: \Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\imagenes\biblioteca.jpg");
                    //"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\imagenes\biblioteca.jpg
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
                    pictureBox1.Image = new System.Drawing.Bitmap(@"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\imagenes\" + label1.Text + ".jpg");
                    //C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\imagenes

                    listBox1.Items.Clear();
                    listBox1.Visible = true;

                    StreamReader R = new StreamReader(@"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\letras\" + label1.Text + ".txt");
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
                    pictureBox1.Image = new System.Drawing.Bitmap(@"C: \Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\imagenes\biblioteca.jpg");
                    //"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\imagenes\biblioteca.jpg
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog mi_pc = new OpenFileDialog();
            mi_pc.InitialDirectory = @"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\music\";
            if (mi_pc.ShowDialog() == DialogResult.OK)
            {
                string nombre = mi_pc.FileName;


                label2.Text = mi_pc.FileName;


                label1.Text = Path.GetFileNameWithoutExtension(label2.Text);


            }





            //agrega cancion


            string pathxml = @"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\musica.txt";

            XmlDocument doc = new XmlDocument();
            doc.Load(pathxml);

            XmlNode nodecanciones = doc.CreateElement("cancion");


            XmlNode nodenombre = doc.CreateElement("nombre");
            nodenombre.InnerText = label1.Text;

            XmlNode nodeubicacion = doc.CreateElement("ubicacion");
            nodeubicacion.InnerText = label2.Text;


            nodecanciones.AppendChild(nodenombre);
            nodecanciones.AppendChild(nodeubicacion);



            doc.SelectSingleNode("canciones").AppendChild(nodecanciones);

            doc.Save(pathxml);

            dataGridView1.Update();
            //


            //limpiar lista
            cancionesss.Clear();
            //


            //mostrar lista

            XmlDocument xDoc = new XmlDocument();


            xDoc.Load(@"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\musica.txt");



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



                cancionesss.Add(musicatemp);
                // contador = contador + 1;


            }



            dataGridView1.DataSource = null;
            dataGridView1.Refresh();

            dataGridView1.DataSource = cancionesss;

            dataGridView1.Columns[0].DisplayIndex = 1;
            dataGridView1.Update();



        }

        private void button2_Click(object sender, EventArgs e)
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
                    pictureBox1.Image = new System.Drawing.Bitmap(@"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\imagenes\" + label1.Text + ".jpg");
                    listBox1.Items.Clear();
                    listBox1.Visible = true;
                    StreamReader R = new StreamReader(@"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\letras\" + label1.Text + ".txt");
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
                    pictureBox1.Image = new System.Drawing.Bitmap(@"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\imagenes\biblioteca.jpg");
                    
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
                    pictureBox1.Image = new System.Drawing.Bitmap(@"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\imagenes\" + label1.Text + ".jpg");
                    listBox1.Items.Clear();

                    listBox1.Visible = true;
                    StreamReader R = new StreamReader(@"C: \Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\letras\" + label1.Text + ".txt");
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
                    pictureBox1.Image = new System.Drawing.Bitmap(@"C: \Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\imagenes\biblioteca.jpg");
                 
                }


            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void reproducirCancionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\music\";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                axWindowsMediaPlayer1.URL = openFileDialog1.FileName;
            }
            listBox1.Visible = false;
            axWindowsMediaPlayer1.Ctlcontrols.play();
            pictureBox1.Image = new System.Drawing.Bitmap(@"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\imagenes\biblioteca.jpg");
        }

        private void agregarCancionABibliotecaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog mi_pc = new OpenFileDialog();
            mi_pc.InitialDirectory = @"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\music\";
            if (mi_pc.ShowDialog() == DialogResult.OK)
            {
                string nombre = mi_pc.FileName;           
                label2.Text = mi_pc.FileName;
                label1.Text = Path.GetFileNameWithoutExtension(label2.Text);
            }

            //agrega cancion

            string pathxml = @"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\musica.txt";
            XmlDocument doc = new XmlDocument();
            doc.Load(pathxml);
            XmlNode nodecanciones = doc.CreateElement("cancion");
            XmlNode nodenombre = doc.CreateElement("nombre");
            nodenombre.InnerText = label1.Text;
            XmlNode nodeubicacion = doc.CreateElement("ubicacion");
            nodeubicacion.InnerText = label2.Text;
           nodecanciones.AppendChild(nodenombre);
            nodecanciones.AppendChild(nodeubicacion);

            doc.SelectSingleNode("canciones").AppendChild(nodecanciones);
            doc.Save(pathxml);
            dataGridView1.Update();
            //
            //limpiar lista
            cancionesss.Clear();
            //
            //mostrar lista

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\musica.txt");
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
                cancionesss.Add(musicatemp);
                // contador = contador + 1;
            }
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = cancionesss;
            dataGridView1.Columns[0].DisplayIndex = 1;
            dataGridView1.Update();

        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void misListasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }
    }
}

