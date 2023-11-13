using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeReader
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public int a = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "@dm906#iN") {

                a = 1;
            }
            Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.PasswordChar = '*';
        }
    }
}
