using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using Microsoft.Win32;
using System.IO;

namespace BarcodeReader {
    public partial class Form1 : Form {
        public static String formatPassportFileName = "format_passport.txt";

        string[] readText;
        string[] readPassoprtText;
        string s0 = "", s1 = "", sp0 = "", sp1 = "", com = "";

        public Form1() {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) {
            try {
                string[] read = File.ReadAllLines("com.txt");
                com = read[0];
            } catch { }
            comBox.Text = com;
            try {
                readText = File.ReadAllLines("format.txt");
                s0 = readText[0];
                s1 = readText[1];

            } catch { }

            try {
                readPassoprtText = File.ReadAllLines(formatPassportFileName);
                sp0 = readPassoprtText[0];
                sp1 = readPassoprtText[1];
            } catch { }

            dateBoxId.SelectedIndex = Convert.ToInt32(s0);
            dateBoxPassport.SelectedIndex = Convert.ToInt32(sp0);

            if (!s1.Equals("XX")) {
                string[] arr = s1.Split('^');
                outputListBoxId.Items.Clear();

                for (int i = 0; i < arr.Length; i++) {
                    outputListBoxId.Items.Add(arr[i]);
                }

            }

            if (!sp1.Equals("XX")) {
                string[] arr = sp1.Split('^');
                outputListBoxPassport.Items.Clear();

                for (int i = 0; i < arr.Length; i++) {
                    outputListBoxPassport.Items.Add(arr[i]);
                }

            }

        }

        private void addToOutputBtn_Click(object sender, EventArgs e) {
            string buttonName = ((Button)sender).Name;
            switch (buttonName) {
                case "addToOutputBtnId":
                    try {
                        string text = inputListBoxId.GetItemText(inputListBoxId.SelectedItem);
                        outputListBoxId.Items.Add(text);
                    } catch {
                        MessageBox.Show("يرجى اختيار عنصر");
                    }
                    break;
                case "addToOutputBtnPassport":
                    try {
                        string text = inputListBoxPassport.GetItemText(inputListBoxPassport.SelectedItem);
                        outputListBoxPassport.Items.Add(text);
                    } catch {
                        MessageBox.Show("يرجى اختيار عنصر");
                    }
                    break;
                case "addToOutputBtnMId":
                    try {
                        //string text = inputListBoxMId.GetItemText(inputListBoxMId.SelectedItem);
                        //outputListBoxMId.Items.Add(text);
                    } catch {
                        MessageBox.Show("يرجى اختيار عنصر");
                    }
                    break;
            }

        }

        private void deleteBtn_Click(object sender, EventArgs e) {
            string buttonName = ((Button)sender).Name;
            switch (buttonName) {
                case "deleteBtnId":
                    try {
                        outputListBoxId.Items.RemoveAt(outputListBoxId.SelectedIndex);
                    } catch {
                        MessageBox.Show("يرجى اختيار عنصر");
                    }
                    break;
                case "deleteBtnPassport":
                    try {
                        outputListBoxPassport.Items.RemoveAt(outputListBoxPassport.SelectedIndex);
                    } catch {
                        MessageBox.Show("يرجى اختيار عنصر");
                    }
                    break;
                case "deleteBtnMId":
                    try {
                        //outputListBoxMId.Items.RemoveAt(outputListBoxMId.SelectedIndex);
                    } catch {
                        MessageBox.Show("يرجى اختيار عنصر");
                    }
                    break;
            }

        }

        private void deleteAllBtn_Click(object sender, EventArgs e) {
            string buttonName = ((Button)sender).Name;
            switch (buttonName) {
                case "deleteAllBtnId":
                    outputListBoxId.Items.Clear();
                    break;
                case "deleteAllBtnPassport":
                    outputListBoxPassport.Items.Clear();
                    break;
                case "deleteAllBtnMId":
                    //outputListBoxMId.Items.Clear();
                    break;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e) {
            saveFormats();
            try {
                com = comBox.Text;
                string[] toSave = new string[4];
                toSave[0] = com;
                File.WriteAllLines("com.txt", toSave);
            } catch { }
            MessageBox.Show("تم الحفظ");
            Close();
        }

        private void saveFormats() {
            /// ID
            /// 
            s0 = "" + dateBoxId.SelectedIndex;
            s1 = "";
            for (int a = 0; a < outputListBoxId.Items.Count; a++) {
                if (a == outputListBoxId.Items.Count - 1) {
                    s1 = s1 + outputListBoxId.Items[a].ToString();
                } else {
                    s1 = s1 + outputListBoxId.Items[a].ToString() + "^";
                }
            }
            string[] toSave = new string[4];
            toSave[0] = s0;
            toSave[1] = s1;
            File.WriteAllLines("format.txt", toSave);


            /// Passport
            /// 
            sp0 = "" + dateBoxPassport.SelectedIndex;
            sp1 = "";
            for (int a = 0; a < outputListBoxPassport.Items.Count; a++) {
                if (a == outputListBoxPassport.Items.Count - 1) {
                    sp1 = sp1 + outputListBoxPassport.Items[a].ToString();
                } else {
                    sp1 = sp1 + outputListBoxPassport.Items[a].ToString() + "^";
                }
            }
            string[] toSaveP = new string[4];
            toSaveP[0] = sp0;
            toSaveP[1] = sp1;
            File.WriteAllLines(formatPassportFileName, toSaveP);



        }


        private void bmoveUpBtn_Click(object sender, EventArgs e) {
            string buttonName = ((Button)sender).Name;
            switch (buttonName) {
                case "moveUpBtnId":
                    moveItemUp(outputListBoxId);
                    break;
                case "moveUpBtnPassport":
                    moveItemUp(outputListBoxPassport);

                    break;
                case "moveUpBtnMId":
                    //moveItemUp(outputListBoxMId);
                    break;
            }

        }

        private void moveDownBtn_Click(object sender, EventArgs e) {
            string buttonName = ((Button)sender).Name;
            switch (buttonName) {
                case "moveDownBtnId":
                    moveItemDown(outputListBoxId);
                    break;
                case "moveDownBtnPassport":
                    moveItemDown(outputListBoxPassport);
                    break;
                case "moveDownBtnMId":
                    //moveItemDown(outputListBoxMId);
                    break;
            }

        }


        private void exportBtn_Click(object sender, EventArgs e) {
            string buttonName = ((Button)sender).Name;
            if (buttonName == "exportBtnId") {
                try {

                    saveFormats();

                    using (var fbd = new FolderBrowserDialog()) {
                        DialogResult result = fbd.ShowDialog();

                        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath)) {
                            File.Copy(Application.ExecutablePath.Replace("BarcodeReader.EXE", "").Replace("BarcodeReader.exe", "").TrimEnd('\\') + "\\format.txt", fbd.SelectedPath + "\\format.bar", true);

                            MessageBox.Show("تم أخذ نسخة لصيغة الهوية");
                        }
                    }
                } catch { MessageBox.Show("حدث خطأ"); }
            } else if (buttonName == "exportBtnPassport") {
                try {

                    saveFormats();

                    using (var fbd = new FolderBrowserDialog()) {
                        DialogResult result = fbd.ShowDialog();

                        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath)) {
                            File.Copy(Application.ExecutablePath.Replace("BarcodeReader.EXE", "").Replace("BarcodeReader.exe", "").TrimEnd('\\') + "\\" + formatPassportFileName, fbd.SelectedPath + "\\format_passport.bar", true);

                            MessageBox.Show("تم أخذ نسخة لصيغة جواز السفر");
                        }
                    }
                } catch { MessageBox.Show("حدث خطأ"); }
            }
        }

        private void importBtn_Click(object sender, EventArgs e) {
            string buttonName = ((Button)sender).Name;
            if (buttonName == "importBtnId") {
                try {

                    OpenFileDialog openFileDialog1 = new OpenFileDialog();
                    string file_path = "";
                    if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                        file_path = openFileDialog1.FileName;
                        //  MessageBox.Show(openFileDialog1.FileName);
                        //   MessageBox.Show( Application.ExecutablePath.Replace("BarcodeReader.EXE", "").Replace("BarcodeReader.exe", "").TrimEnd('\\') + "\\format.txt");

                        File.Copy(openFileDialog1.FileName, Application.ExecutablePath.Replace("BarcodeReader.EXE", "").Replace("BarcodeReader.exe", "").TrimEnd('\\') + "\\format.txt", true);

                        try {
                            readText = File.ReadAllLines("format.txt");
                            s0 = readText[0];
                            s1 = readText[1];
                        } catch { }
                        dateBoxId.SelectedIndex = Convert.ToInt32(s0);
                        if (!s1.Equals("XX")) {
                            string[] arr = s1.Split('^');
                            outputListBoxId.Items.Clear();

                            for (int i = 0; i < arr.Length; i++) {
                                outputListBoxId.Items.Add(arr[i]);
                            }

                        }

                        MessageBox.Show("تم استرداد صيغة الهوية الشخصية");

                    }
                } catch { MessageBox.Show("حدث خطأ"); }
            } else if (buttonName == "importBtnPassport") {
                try {

                    OpenFileDialog openFileDialog1 = new OpenFileDialog();
                    string file_path = "";
                    if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                        file_path = openFileDialog1.FileName;
                        //  MessageBox.Show(openFileDialog1.FileName);
                        //   MessageBox.Show( Application.ExecutablePath.Replace("BarcodeReader.EXE", "").Replace("BarcodeReader.exe", "").TrimEnd('\\') + "\\format.txt");

                        File.Copy(openFileDialog1.FileName, Application.ExecutablePath.Replace("BarcodeReader.EXE", "").Replace("BarcodeReader.exe", "").TrimEnd('\\') + "\\"+ formatPassportFileName, true);

                        try {
                            readPassoprtText = File.ReadAllLines(formatPassportFileName);
                            sp0 = readPassoprtText[0];
                            sp1 = readPassoprtText[1];
                        } catch { }
                        dateBoxPassport.SelectedIndex = Convert.ToInt32(sp0);
                        if (!sp1.Equals("XX")) {
                            string[] arr = sp1.Split('^');
                            outputListBoxPassport.Items.Clear();

                            for (int i = 0; i < arr.Length; i++) {
                                outputListBoxPassport.Items.Add(arr[i]);
                            }

                        }

                        MessageBox.Show("تم استرداد صيغة جواز السفر");

                    }
                } catch { MessageBox.Show("حدث خطأ"); }
            }

        }

        private void addTextToOutputBtn_Click(object sender, EventArgs e) {
            string buttonName = ((Button)sender).Name;
            switch (buttonName) {
                case "addTextToOutputBtnId":
                    if (!textInputBoxId.Text.Equals(""))
                        outputListBoxId.Items.Add(textInputBoxId.Text);
                    break;
                case "addTextToOutputBtnPassport":
                    if (!textInputBoxPassport.Text.Equals(""))
                        outputListBoxPassport.Items.Add(textInputBoxPassport.Text);
                    break;
                case "addTextToOutputBtnMId":
                    //if (!textInputBoxMId.Text.Equals(""))
                    //    outputListBoxMId.Items.Add(textInputBoxMId.Text);
                    break;
            }
            //DateTime.Now.ToString("yyyy-MM-dd hh:mmtt"); 


        }

        private void moveItemUp(ListBox listBox) {
            try {
                string sdo = "";
                for (int a = 0; a < listBox.Items.Count; a++) {
                    if (a == listBox.Items.Count - 1) {
                        sdo = sdo + listBox.Items[a].ToString();
                    } else {
                        sdo = sdo + listBox.Items[a].ToString() + "^";
                    }
                }

                string[] sdo_arr = sdo.Split('^');
                int ind = listBox.SelectedIndex;
                string temp = sdo_arr[ind - 1];

                sdo_arr[ind - 1] = sdo_arr[ind];
                sdo_arr[ind] = temp;
                listBox.Items.Clear();
                for (int i = 0; i < sdo_arr.Length; i++) {
                    listBox.Items.Add(sdo_arr[i]);
                }
                listBox.SelectedIndex = ind - 1;
            } catch { }
        }


        private void moveItemDown(ListBox listBox) {
            try {
                string sdo = "";
                for (int a = 0; a < listBox.Items.Count; a++) {
                    if (a == listBox.Items.Count - 1) {
                        sdo = sdo + listBox.Items[a].ToString();
                    } else {
                        sdo = sdo + listBox.Items[a].ToString() + "^";
                    }
                }

                string[] sdo_arr = sdo.Split('^');
                int ind = listBox.SelectedIndex;
                string temp = sdo_arr[ind + 1];

                sdo_arr[ind + 1] = sdo_arr[ind];
                sdo_arr[ind] = temp;
                listBox.Items.Clear();
                for (int i = 0; i < sdo_arr.Length; i++) {
                    listBox.Items.Add(sdo_arr[i]);
                }
                listBox.SelectedIndex = ind + 1;
            } catch { }
        }

        private void button9_Click_1(object sender, EventArgs e) {
            Form3 fm = new Form3();
            fm.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e) {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\OurSettings");
            // storing the values
            key.SetValue("Setting1", "This is our setting 1");
            key.SetValue("Setting2", "This is our setting 2");
            key.Close();
        }

        private void button9_Click(object sender, EventArgs e) {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\OurSettings");
            if (key != null) {
                Console.WriteLine(key.GetValue("Setting1"));
                Console.WriteLine(key.GetValue("Setting2"));
                key.Close();
            }
        }


        private void button6_Click(object sender, EventArgs e) {
            int year = 1992;
            int month = 4;
            int day = 14;
            DateTime dt = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
            string new_dt = dt.ToString("yyyy-MM-dd");
            Console.WriteLine(new_dt);
            dt = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
            new_dt = dt.ToString("yyyy/MM/dd");
            Console.WriteLine(new_dt);
            dt = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
            new_dt = dt.ToString("yyyy-dd-MM");
            Console.WriteLine(new_dt);
            dt = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
            new_dt = dt.ToString("yyyy/dd/MM");
            Console.WriteLine(new_dt);
            dt = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
            new_dt = dt.ToString("dd-MM-yyyy");
            Console.WriteLine(new_dt);
            dt = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
            new_dt = dt.ToString("dd/MM/yyyy");
            Console.WriteLine(new_dt);

            dt = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
            new_dt = dt.ToString("MM-dd-yyyy");
            Console.WriteLine(new_dt);
            dt = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
            new_dt = dt.ToString("MM/dd/yyyy");
            Console.WriteLine(new_dt);
        }


        public string GetMachineGuid() {
            string location = @"SOFTWARE\Microsoft\Cryptography";
            string name = "MachineGuid";

            using (RegistryKey localMachineX64View =
                RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)) {
                using (RegistryKey rk = localMachineX64View.OpenSubKey(location)) {
                    if (rk == null)
                        throw new KeyNotFoundException(
                            string.Format("Key Not Found: {0}", location));

                    object machineGuid = rk.GetValue(name);
                    if (machineGuid == null)
                        throw new IndexOutOfRangeException(
                            string.Format("Index Not Found: {0}", name));

                    return machineGuid.ToString();
                }
            }
        }
    }
}
