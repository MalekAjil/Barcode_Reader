using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static BarcodeReader.Program;

namespace BarcodeReader
{
    public partial class ActivateForm : Form
    {
        string id;
        public ActivateForm(string id)
        {
            InitializeComponent();
            this.id = id;
            registerBox.Text = id;
        }

        bool activated = false;
        private void button1_Click(object sender, EventArgs e) {
            string md5 = ApplicationStartUp.CreateMD5(id);
            string activateCode = activateTextBox.Text;
            
            if (activateCode == md5) {
                File.WriteAllText("activate.txt", md5);
                activated = true;
                Close();
            } else {
                MessageBox.Show("كود الترخيص خاطئ", "خطأ في التفعيل", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActivateForm_FormClosed(object sender, FormClosedEventArgs e) {
            if (!activated)
                Application.Exit();
        }
    }
}
