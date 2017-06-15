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
    public partial class Form2 : Form
    {
        string [] archivo;
        string [] ruta;
        List<string> musicas = new List<string>();
        public Form2()
        {
            InitializeComponent();
        }

        private void cargarMusicaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog openfileDialog1 = new OpenFileDialog();
            openfileDialog1.InitialDirectory = @"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\music";
            openfileDialog1.Multiselect = true;
            if (openfileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                archivo = openfileDialog1.SafeFileNames;
                ruta = openfileDialog1.FileNames;
               
                for (int i = 0; i < archivo.Length; i++)
                {
                    listBox1.Items.Add(ruta[i]);

                }
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Add(listBox1.SelectedItem);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("La lista: " + textBox1.Text + "se ha guardado con exito");
            StreamWriter W = new StreamWriter(@"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\listas\" + textBox1.Text + ".txt");
            foreach (string k in listBox2.Items)
            {
                W.WriteLine(k);
                musicas.Add(k);

            }
            W.Close();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            textBox1.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //Directorio en donde se va a iniciar la busqueda
            openFileDialog1.InitialDirectory = @"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\listas\";
            //Tipos de archivos que se van a buscar
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            //Muestra la ventana para abrir el archivo y verifica que si se pueda abrir
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                //Guardamos en una variable el nombre del archivo que abrimos
                string fileName = openFileDialog1.FileName;


                label1.Text = openFileDialog1.FileName;
                //Abrimos el archivo, en este caso lo abrimos para lectura
                FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);
                //Un ciclo para leer el archivo hasta el final del archivo
                //Lo leido se va guardando en un control richTextBox
                while (reader.Peek() > -1)
                {
                    //richTextBox1.AppendText(reader.ReadLine());
                    if (listBox4.Visible == false)
                    {
                        listBox3.Items.Add(reader.ReadLine());
                    }
                    if (listBox4.Visible == true)
                    {
                        listBox4.Items.Add(reader.ReadLine());
                    }

                }
                //Cerrar el archivo
                reader.Close();
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listBox3.Visible == true)
            {
                media.URL = label2.Text;
            }
            if (listBox3.Visible == false && listBox4.Visible == false)
            {
                media.URL = label5.Text;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfileDialog1 = new OpenFileDialog();
            openfileDialog1.InitialDirectory = @"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\music";
            openfileDialog1.Multiselect = true;
            if (openfileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string ru;
                archivo = openfileDialog1.SafeFileNames;
                ru = openfileDialog1.FileName;
                label2.Text = ru;
                //string[] nombre = openFileDialog1 .FileNames;
                listBox3.Items.Add(ru);
            }
            StreamWriter W = new StreamWriter(label1.Text);
            foreach (string k in listBox3.Items)
            {
                W.WriteLine(k);
            }
            W.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string[] todos = File.ReadAllLines(label1.Text);
            int numer = 0;
            int borrar = listBox3.SelectedIndex;
            StreamWriter sw = new StreamWriter(label1.Text);
            foreach (string dice in todos)
            {
                if (numer != listBox3.SelectedIndex)
                {
                    sw.WriteLine(dice);
                }
                numer++;
            }
            sw.Close();
            musicas.Remove(label2.Text);
            listBox3.Items.Remove(listBox3.SelectedItem);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                cargarMusicaToolStripMenuItem.Enabled = true;
                listBox1.Visible = true;
                listBox2.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                textBox1.Visible = true;

                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                listBox3.Items.Clear();
                listBox3.Visible = false;

            }

            if (comboBox1.SelectedIndex == 1)
            {
                cargarMusicaToolStripMenuItem.Enabled = false;
                listBox1.Visible = false;
                listBox2.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                textBox1.Visible = false;

                listBox3.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = true;

                listBox1.Items.Clear();
                listBox2.Items.Clear();
                listBox3.Items.Clear();
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            media.Ctlcontrols.stop();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (listBox4.Items.Count <= 1)
            {

            }

            else if (listBox4.SelectedIndex <= 0)
            {
                listBox4.SelectedIndex = listBox4.Items.Count - 1;
                media.URL = label5.Text;
            }

            else
            {
                listBox4.SelectedIndex = listBox4.SelectedIndex - 1;
                media.URL = label5.Text;
            }

            label6.Text = Path.GetFileNameWithoutExtension(label5.Text);

            try
            {

                pictureBox1.Image = new System.Drawing.Bitmap(@"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\imagenes\" + label6.Text + ".jpg");
               

                listBox5.Items.Clear();
                listBox5.Visible = true;

                StreamReader R = new StreamReader(@"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\letras\" + label6.Text + ".txt");
                string r;
                while ((r = R.ReadLine()) != null)
                {
                    listBox5.Items.Add(r);
                }
                R.Close();
            }
            catch (Exception)
            {
                listBox5.Visible = false;
                pictureBox1.Image = new System.Drawing.Bitmap(@"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\imagenes\biblioteca.jpg");
              

            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (listBox4.Visible == true)
            {
                media.URL = label5.Text;
            }

            label6.Text = Path.GetFileNameWithoutExtension(label5.Text);

            try
            {

                pictureBox1.Image = new System.Drawing.Bitmap(@"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\imagenes\" + label6.Text + ".jpg");
            
                listBox5.Items.Clear();
                listBox5.Visible = true;

                StreamReader R = new StreamReader(@"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\letras\" + label6.Text + ".txt");
                string r;
                while ((r = R.ReadLine()) != null)
                {
                    listBox5.Items.Add(r);
                }
                R.Close();
            }
            catch (Exception)
            {
                listBox5.Visible = false;
                pictureBox1.Image = new System.Drawing.Bitmap(@"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\imagenes\biblioteca.jpg");
               

            }


        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            label6.Text = Path.GetFileNameWithoutExtension(label5.Text);

            if (listBox4.Items.Count <= 0)
            {

            }

            else if (listBox4.SelectedIndex == listBox4.Items.Count - 1)
            {
                listBox4.SelectedIndex = 0;
                media.URL = label5.Text;



            }

            else
            {
                listBox4.SelectedIndex = listBox4.SelectedIndex + 1;
                media.URL = label5.Text;
            }

            label6.Text = Path.GetFileNameWithoutExtension(label5.Text);

            try
            {

                pictureBox1.Image = new System.Drawing.Bitmap(@"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\imagenes\" + label6.Text + ".jpg");
           
                listBox5.Items.Clear();
                listBox5.Visible = true;

                StreamReader R = new StreamReader(@"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\letras\" + label6.Text + ".txt");
                string r;
                while ((r = R.ReadLine()) != null)
                {
                    listBox5.Items.Add(r);
                }
                R.Close();
            }
            catch (Exception)
            {
                listBox5.Visible = false;
                pictureBox1.Image = new System.Drawing.Bitmap(@"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\imagenes\biblioteca.jpg");
        

            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int index = rnd.Next(0, listBox4.Items.Count);

            label3.Text = listBox4.Items[index].ToString();
            media.URL = label3.Text;
            label6.Text = Path.GetFileNameWithoutExtension(label3.Text);
            try
            {
                pictureBox1.Image = new System.Drawing.Bitmap(@"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\imagenes\" + label6.Text + ".jpg");
               
                listBox5.Items.Clear();
                listBox5.Visible = true;

                StreamReader R = new StreamReader(@"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\letras\" + label6.Text + ".txt");
                string r;
                while ((r = R.ReadLine()) != null)
                {
                    listBox5.Items.Add(r);
                }
                R.Close();
            }
            catch (Exception)
            {
                listBox5.Visible = false;
                pictureBox1.Image = new System.Drawing.Bitmap(@"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\imagenes\biblioteca.jpg");
               
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label5.Visible = false;
            label6.Visible = false;

            pictureBox5.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox6.Visible = false;


            pictureBox1.Visible = false;

            listBox5.Visible = false;

            label5.Visible = false;
            media.Visible = false;
            button7.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;


            label4.Visible = false;

            listBox1.Visible = false;
            listBox2.Visible = false;
            listBox3.Visible = false;

            listBox4.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            textBox1.Visible = false;

            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;



            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;

            button6.Visible = false;

            comboBox1.Visible = false;

            comboBox1.Items.Add("Crear Lista");
            comboBox1.Items.Add("Modificar Lista");
            comboBox1.Items.Add("Eliminar Lista");
            cargarMusicaToolStripMenuItem.Enabled = false;
        }

        private void cargarMusicaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            OpenFileDialog openfileDialog1 = new OpenFileDialog();

            openfileDialog1.InitialDirectory = @"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\music";
            openfileDialog1.Multiselect = true;

            if (openfileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                archivo = openfileDialog1.SafeFileNames;
                ruta = openfileDialog1.FileNames;
                
                for (int i = 0; i < archivo.Length; i++)
                {

                    listBox1.Items.Add(ruta[i]);

                }
            }
        }

        private void crearListaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pictureBox5.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox6.Visible = false;

            listBox5.Visible = false;
            pictureBox1.Visible = false;
            media.Ctlcontrols.stop();
            label4.Visible = true;
            button7.Visible = true;
            cargarMusicaToolStripMenuItem.Enabled = true;
            listBox1.Visible = true;
            listBox2.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
            textBox1.Visible = true;

            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox3.Visible = false;


            listBox4.Items.Clear();
            listBox4.Visible = false;

            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;

            button6.Visible = false;


        }

        private void modificarListaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox5.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox6.Visible = false;

            pictureBox1.Visible = false;

            listBox5.Visible = false;
            media.Ctlcontrols.stop();
            label4.Visible = false;
            button7.Visible = true;
            cargarMusicaToolStripMenuItem.Enabled = false;
            listBox1.Visible = false;
            listBox2.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            textBox1.Visible = false;
            listBox2.Enabled = false;

            listBox3.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;

            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();

            listBox4.Visible = false;
            listBox4.Items.Clear();

            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;

            button6.Visible = false;
        }

        private void eliminarListaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox5.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox6.Visible = false;

            pictureBox1.Visible = false;
            listBox5.Visible = false;
            media.Ctlcontrols.stop();
            label4.Visible = false;
            button7.Visible = false;

            listBox1.Visible = false;
            listBox2.Visible = false;
            listBox3.Visible = false;

            listBox4.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            textBox1.Visible = false;

            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;



            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;

            button6.Visible = false;

            comboBox1.Visible = false;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //Directorio en donde se va a iniciar la busqueda
            openFileDialog1.InitialDirectory = @"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\listas\";
            //Tipos de archivos que se van a buscar
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                //Guardamos en una variable el nombre del archivo que abrimos
                string fileName = openFileDialog1.FileName;
                label1.Text = openFileDialog1.FileName;
                File.Delete(label1.Text);

                MessageBox.Show("La lista a sido eliminada");

                label1.Text = "";

            }
        }

        private void verListasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            textBox1.Visible = false;
            pictureBox5.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            pictureBox4.Visible = true;
            pictureBox6.Visible = true;
            listBox3.Visible = false;

            pictureBox1.Visible = true;

            pictureBox1.Image = new System.Drawing.Bitmap(@"C:\Users\Marco Rios\Source\Repos\NewRepo2\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\imagenes\biblioteca.jpg");
 
            listBox5.Visible = true;
        
            cargarMusicaToolStripMenuItem.Enabled = false;
            media.Ctlcontrols.stop();
            label4.Visible = false;
            button7.Visible = false;
            listBox4.Items.Clear();
            listBox1.Visible = false;
            listBox2.Visible = false;

            button3.Visible = true;
            button4.Visible = false;
            button5.Visible = false;

            listBox4.Visible = true;
            button8.Visible = true;
            button9.Visible = true;
            button10.Visible = true;
            button11.Visible = true;

            button1.Visible = false;
            button2.Visible = false;

            button6.Visible = true;
        }

        private void volverABibliotecaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            media.Ctlcontrols.stop();
            this.Close();
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Text = listBox3.Text;
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            label5.Text = listBox4.Text;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label5.Text = listBox1.Text;
        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
