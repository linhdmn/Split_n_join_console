using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace split_n_join
{
    public partial class Form1 : Form
    {
        int type;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            type = 1;
            timer1.Start();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 1;
            progressBar1.Maximum = 10;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(type == 2)
            {
                //Path file
                string currPath = @textBox1.Text;
                string destPath, tail;
                tail = currPath.Substring(currPath.Length - 4, 4);
                destPath = currPath.Substring(0, currPath.Length - 4);


                int numPart = Int32.Parse(tail.Substring(1, 3));

                using (Stream result = File.Open(destPath, FileMode.Open, FileAccess.Write, FileShare.None))
                {
                    while (File.Exists(currPath))
                    {
                        byte[] data = File.ReadAllBytes(currPath);
                        result.Seek(0, SeekOrigin.Current);
                        result.Write(data, 0, data.Length);
                        numPart++;
                        if (numPart >= 10 && numPart < 100)
                        {
                            currPath = destPath + ".0" + numPart.ToString();
                        }
                        else
                            currPath = destPath + ".00" + numPart.ToString();
                    }
                }
            }

            else
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            type = 2;
            timer1.Start();
        }
    }
}
