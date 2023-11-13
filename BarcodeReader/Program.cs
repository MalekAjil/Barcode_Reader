using BarcodeReader.Properties;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Timers;
using System.Net.NetworkInformation;

namespace BarcodeReader {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ApplicationStartUp());
        }

        public class ApplicationStartUp : Form {
            private static NotifyIcon trayIcon;
            private static NotifyIcon trayIcon1;
            private static ContextMenu trayMenu;
            System.Windows.Forms.Timer timer1;
            System.Timers.Timer timer;

            string[] readActivateFile;

            private void InitializeComponent() {


                //RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\WINDOWS_FILE");
                //bool is_key_existed = false;
                //bool is_key_zero = false;
                //if (key != null)
                //{
                //    is_key_existed = true;

                //    Console.WriteLine(key.GetValue("delete"));
                //    if (key.GetValue("delete").Equals("0"))
                //    {
                //        is_key_zero = true;


                //    }
                //    else
                //    {
                //        is_key_zero = false;
                //    }

                //}
                //else
                //{
                //    is_key_existed = false;
                //}


                //if (is_key_existed)
                //{
                //    //key.Close();
                //    if (is_key_zero)
                //    {

                //        Form2 log = new Form2();
                //        log.ShowDialog();
                //        string[] toSave = new string[4];
                //        toSave[0] = "0";
                //        toSave[1] = "يجب ضبط الباركود";
                //        File.WriteAllLines("format.txt", toSave);


                //        if (log.a == 1)//WINDOWS_FILE
                //        {
                //            key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\WINDOWS_FILE");
                //            key.DeleteValue("delete");
                //            key.SetValue("delete", "1");
                //            key.Close();
                //        }
                //        else
                //        {
                //            Application.Exit();
                //            return;
                //        }
                //    }
                string cpuId = getCpuId();
                string mac = getMacAddress();
                string hard = getHardDiskId();
                string driveC = GetSerialFromDrive("C:");
                string driveD = GetSerialFromDrive("D:");
                string motherSerial = getMotherboardSerial();
                //string motherStepping = getMotherboardStepping();
                Console.WriteLine("cpuId = " + cpuId);
                Console.WriteLine("mac = " + mac);
                Console.WriteLine("motherSerial = " + motherSerial);
                Console.WriteLine("hard = " + hard);
                Console.WriteLine("driveC = " + driveC);
                Console.WriteLine("driveD = " + driveD);
                //Console.WriteLine("motherStepping = " + motherStepping);
                cpuId = cpuId.Substring(cpuId.Length - 6);
                string line1 = "";
                try {
                    readActivateFile = File.ReadAllLines("activate.txt");
                    line1 = string.IsNullOrEmpty(readActivateFile[0]) ? "" : readActivateFile[0];
                } catch { }


                string md5 = CreateMD5(cpuId);
                Console.WriteLine(md5);
                if (line1 != md5) {
                    ActivateForm activateForm = new ActivateForm(cpuId);
                    activateForm.ShowDialog();
                }

                try {
                    string[] read = File.ReadAllLines("com.txt");
                    com = string.IsNullOrEmpty(read[0]) ? "" : read[0];
                } catch { }


                Console.WriteLine("Cpu Id = " + cpuId);
                trayMenu = new ContextMenu();
                trayMenu.MenuItems.Add("Exit", OnExit);

                trayIcon = new NotifyIcon();
                trayIcon.Text = Resources.ResourceManager.BaseName;
                trayIcon.Icon = Properties.Resources.bar;
                trayIcon.Click += new EventHandler(FireClickEvent);
                trayIcon.ContextMenu = trayMenu;
                trayIcon.Visible = true;


                //trayIcon1 = new NotifyIcon();
                //trayIcon1.Text = Resources.ResourceManager.BaseName;
                //trayIcon1.Icon = Properties.Resources.grean;
                //trayIcon1.Click += new EventHandler(FireClickEvent);
                //trayIcon1.ContextMenu = trayMenu;
                //trayIcon1.Visible = true;

                USB = new SerialPort();
                USB.BaudRate = 9600;
                USB.DataBits = 8;
                USB.ReadTimeout = 1000;
                USB.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);

                //timer1 = new System.Windows.Forms.Timer
                //{
                //    Interval = 200
                //};
                //timer1.Enabled = true;
                //timer1.Tick += new System.EventHandler(TmrUsbCheck_Tick);
                timer = new System.Timers.Timer(300);

                // Hook up the Elapsed event for the timer.
                timer.Elapsed += OnTimedEvent;

                timer.Enabled = true;
                readFormatFile();
                readPassportFormatFile();


                //}
                //    else
                //    {
                //        Console.WriteLine("dddddddddddddddd");
                //       // trayIcon.Dispose();
                //        Application.Exit();

                //    }








            }

            private void readFormatFile() {
                try {
                    readText = File.ReadAllLines("format.txt");
                    ss0 = readText[0];
                    ss1 = readText[1];
                } catch { }
                format_date = ss0;
                if (!ss1.Equals("XX") || ss1.Equals("")) {
                    format_arr = ss1.Split('^');
                }
            }
            private void readPassportFormatFile() {
                try {
                    readPassportText = File.ReadAllLines(Form1.formatPassportFileName);
                    ssp0 = readPassportText[0];
                    ssp1 = readPassportText[1];
                } catch { }
                format_date_passport = ssp0;
                if (!ssp1.Equals("XX") || ssp1.Equals("")) {
                    format_passport_arr = ssp1.Split('^');
                }
            }

            string format_date;
            string format_date_passport;
            string[] format_arr;
            string[] format_passport_arr;
            string[] readText;
            string[] readPassportText;
            string ss0 = "", ss1 = "";
            string ssp0 = "", ssp1 = "";
            public static string com = "";

            // PERSONAL ID PROPERTIES
            string name;
            string knya;
            string father;
            string mother;
            string birth_b;
            string birth_d;
            string day;
            string month;
            string year;
            string nach_num;

            // PASSPORT PROPERTIES
            string nameP;
            string knyaP;
            string fatherP;
            string motherP;
            string birth_bP;
            string birth_dP;
            string dayP;
            string monthP;
            string yearP;
            string nach_numP;
            string releaseDateP;
            string releaseDayP;
            string releaseMonthP;
            string releaseYearP;
            string endDateP;
            string endDayP;
            string endMonthP;
            string endYearP;
            string passportNumP;

            private void port_DataReceived(object sender, SerialDataReceivedEventArgs e) {
                // Shortened and error checking removed for brevity...
                if (!USB.IsOpen) return;
                int bytes = USB.BytesToRead;
                byte[] buffer = new byte[bytes];
                USB.Read(buffer, 0, bytes);
                HandleSerialData(buffer);
            }

            string res_usb = "";


            private void HandleSerialData(byte[] respBuffer) {
                //MessageBox.Show(""+ respBuffer.Length);
                try {
                    res_usb = res_usb + Encoding.Default.GetString(respBuffer);
                    //res_usb = "0.0730@يمان#مرشحه#عماد الدين#زمرد#2014/01/31#حلب#2014/06/15#2020/05/04#009184205#009184205#020-20758865@ےطےàJFIFvvےلPIC#ےہ\r";
                    if (respBuffer[respBuffer.Length - 1] == Encoding.ASCII.GetBytes(Environment.NewLine)[0]) {
                        Console.WriteLine("okkkkkkkkkkkkkkkkk");
                        Console.WriteLine(Encoding.Default.GetString(respBuffer));
                        //res_usb = Encoding.Default.GetString(respBuffer);
                        string[] res_arr = res_usb.Split('#');
                        if (res_arr[4].Contains("-")) {
                            parsePersonalId(res_arr);
                        } else if (res_arr[4].Contains("/")) {
                            parsePassport(res_arr);
                        }
                        res_usb = "";

                    }
                } catch (Exception ex) {
                    res_usb = "";
                }//MessageBox.Show(""+ex+" i="+ vv); }



            }

            private void parsePersonalId(string[] res_arr) {

                name = res_arr[0];
                knya = res_arr[1];
                father = res_arr[2];
                mother = res_arr[3];
                string[] ds = res_arr[4].Split(' ');
                birth_b = ds[0];
                birth_d = ds[1];
                ds = birth_d.Split('-');
                day = ds[0];
                month = ds[1];
                year = ds[2];
                nach_num = res_arr[5];
                for (int i = 0; i < format_arr.Length; i++) {
                    send_key(format_arr[i]);
                }
            }

            private void parsePassport(string[] res_arr) {
                bool oldPassportBarcode = false;
                if (res_arr[0].Contains("@")) {
                    oldPassportBarcode = true;
                    res_arr[0] = res_arr[0].Split('@')[1];
                }
                if (res_arr[10].Contains('@')) {
                    oldPassportBarcode = true;
                    res_arr[10] = res_arr[10].Split('@')[0];
                }
                nameP = res_arr[0];
                knyaP = res_arr[1];
                fatherP = res_arr[2];
                motherP = res_arr[3];
                birth_dP = res_arr[4];
                birth_bP = res_arr[5];
                string[] ds = birth_dP.Split('/');
                if (oldPassportBarcode) {
                    dayP = ds[2];
                    monthP = ds[1];
                    yearP = ds[0];
                } else {
                    dayP = ds[0];
                    monthP = ds[1];
                    yearP = ds[2];
                }
                releaseDateP = res_arr[6];
                ds = releaseDateP.Split('/');
                if (oldPassportBarcode) {
                    releaseDayP = ds[2];
                    releaseMonthP = ds[1];
                    releaseYearP = ds[0];
                } else {
                    releaseDayP = ds[0];
                    releaseMonthP = ds[1];
                    releaseYearP = ds[2];
                }
                endDateP = res_arr[7];
                ds = endDateP.Split('/');
                if (oldPassportBarcode) {
                    endDayP = ds[2];
                    endMonthP = ds[1];
                    endYearP = ds[0];
                } else {
                    endDayP = ds[0];
                    endMonthP = ds[1];
                    endYearP = ds[2];
                }
                passportNumP = res_arr[9];
                nach_numP = res_arr[10];
                for (int i = 0; i < format_passport_arr.Length; i++) {
                    send_key_p(format_passport_arr[i]);
                }
            }

            void send_key(string s) {
                if (s.Equals("الاسم")) {
                    SendKeys.SendWait(name);
                } else if (s.Equals("النسبة")) {
                    SendKeys.SendWait(knya);
                } else if (s.Equals("اسم الأب")) {
                    SendKeys.SendWait(father);
                } else if (s.Equals("اسم الأم")) {
                    SendKeys.SendWait(mother);
                } else if (s.Equals("تاريخ الولادة")) {
                    if (ss0.Equals("0")) {
                        DateTime dt = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
                        string new_dt = dt.ToString("yyyy-MM-dd");
                        SendKeys.SendWait(new_dt);
                    }
                    if (ss0.Equals("1")) {
                        DateTime dt = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
                        string new_dt = dt.ToString("yyyy/MM/dd");
                        SendKeys.SendWait(new_dt);
                    }
                    if (ss0.Equals("2")) {
                        DateTime dt = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
                        string new_dt = dt.ToString("yyyy-dd-MM");
                        SendKeys.SendWait(new_dt);
                    }
                    if (ss0.Equals("3")) {
                        DateTime dt = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
                        string new_dt = dt.ToString("yyyy/dd/MM");
                        SendKeys.SendWait(new_dt);
                    }
                    if (ss0.Equals("4")) {
                        DateTime dt = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
                        string new_dt = dt.ToString("dd-MM-yyyy");
                        SendKeys.SendWait(new_dt);
                    }
                    if (ss0.Equals("5")) {
                        DateTime dt = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
                        string new_dt = dt.ToString("dd/MM/yyyy");
                        SendKeys.SendWait(new_dt);
                    }
                    if (ss0.Equals("6")) {
                        DateTime dt = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
                        string new_dt = dt.ToString("MM-dd-yyyy");
                        SendKeys.SendWait(new_dt);
                    }
                    if (ss0.Equals("7")) {
                        DateTime dt = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
                        string new_dt = dt.ToString("MM/dd/yyyy");
                        SendKeys.SendWait(new_dt);
                    }

                } else if (s.Equals("محل الولادة")) {
                    SendKeys.SendWait(birth_b);
                } else if (s.Equals("اليوم")) {
                    SendKeys.SendWait(day);

                } else if (s.Equals("الشهر")) {

                    SendKeys.SendWait(month);
                } else if (s.Equals("السنة")) {
                    SendKeys.SendWait(year);

                } else if (s.Equals("الرقم الوطني")) {

                    SendKeys.SendWait(nach_num);
                } else if (s.Equals("Space")) {
                    SendKeys.SendWait(" ");

                } else if (s.Equals("Enter")) {
                    SendKeys.SendWait("{ENTER}");

                } else if (s.Equals("Tab")) {
                    SendKeys.SendWait("{TAB}");

                } else if (s.IndexOf("0.5") > -1) {
                    Thread.Sleep(500);
                } else if (s.Equals("/")) {
                    SendKeys.SendWait("/");

                } else if (s.Equals("-")) {

                    SendKeys.SendWait("-");
                } else {
                    SendKeys.SendWait(s);
                }

            }
            void send_key_p(string s) {
                if (s.Equals("الاسم")) {
                    SendKeys.SendWait(nameP);
                } else if (s.Equals("النسبة")) {
                    SendKeys.SendWait(knyaP);
                } else if (s.Equals("اسم الأب")) {
                    SendKeys.SendWait(fatherP);
                } else if (s.Equals("اسم الأم")) {
                    SendKeys.SendWait(motherP);
                } else if (s.Equals("تاريخ الولادة")) {
                    if (ssp0.Equals("0")) {
                        DateTime dt = new DateTime(Convert.ToInt32(yearP), Convert.ToInt32(monthP), Convert.ToInt32(dayP));
                        string new_dt = dt.ToString("yyyy-MM-dd");
                        SendKeys.SendWait(new_dt);
                    }
                    if (ssp0.Equals("1")) {
                        DateTime dt = new DateTime(Convert.ToInt32(yearP), Convert.ToInt32(monthP), Convert.ToInt32(dayP));
                        string new_dt = dt.ToString("yyyy/MM/dd");
                        SendKeys.SendWait(new_dt);
                    }
                    if (ssp0.Equals("2")) {
                        DateTime dt = new DateTime(Convert.ToInt32(yearP), Convert.ToInt32(monthP), Convert.ToInt32(dayP));
                        string new_dt = dt.ToString("yyyy-dd-MM");
                        SendKeys.SendWait(new_dt);
                    }
                    if (ssp0.Equals("3")) {
                        DateTime dt = new DateTime(Convert.ToInt32(yearP), Convert.ToInt32(monthP), Convert.ToInt32(dayP));
                        string new_dt = dt.ToString("yyyy/dd/MM");
                        SendKeys.SendWait(new_dt);
                    }
                    if (ssp0.Equals("4")) {
                        DateTime dt = new DateTime(Convert.ToInt32(yearP), Convert.ToInt32(monthP), Convert.ToInt32(dayP));
                        string new_dt = dt.ToString("dd-MM-yyyy");
                        SendKeys.SendWait(new_dt);
                    }
                    if (ssp0.Equals("5")) {
                        DateTime dt = new DateTime(Convert.ToInt32(yearP), Convert.ToInt32(monthP), Convert.ToInt32(dayP));
                        string new_dt = dt.ToString("dd/MM/yyyy");
                        SendKeys.SendWait(new_dt);
                    }
                    if (ssp0.Equals("6")) {
                        DateTime dt = new DateTime(Convert.ToInt32(yearP), Convert.ToInt32(monthP), Convert.ToInt32(dayP));
                        string new_dt = dt.ToString("MM-dd-yyyy");
                        SendKeys.SendWait(new_dt);
                    }
                    if (ssp0.Equals("7")) {
                        DateTime dt = new DateTime(Convert.ToInt32(yearP), Convert.ToInt32(monthP), Convert.ToInt32(dayP));
                        string new_dt = dt.ToString("MM/dd/yyyy");
                        SendKeys.SendWait(new_dt);
                    }

                } else if (s.Equals("محل الولادة")) {
                    SendKeys.SendWait(birth_bP);

                } else if (s.Equals("يوم الولادة")) {
                    SendKeys.SendWait(dayP);

                } else if (s.Equals("شهر الولادة")) {
                    SendKeys.SendWait(monthP);

                } else if (s.Equals("سنة الولادة")) {
                    SendKeys.SendWait(yearP);

                } else if (s.Equals("الرقم الوطني")) {
                    SendKeys.SendWait(nach_numP);

                } else if (s.Equals("رقم الجواز")) {
                    SendKeys.SendWait(passportNumP);

                } else if (s.Equals("تاريخ انتهاء الصلاحية")) {
                    if (ssp0.Equals("0")) {
                        DateTime dt = new DateTime(Convert.ToInt32(endYearP), Convert.ToInt32(endMonthP), Convert.ToInt32(endDayP));
                        string new_dt = dt.ToString("yyyy-MM-dd");
                        SendKeys.SendWait(new_dt);
                    }
                    if (ssp0.Equals("1")) {
                        DateTime dt = new DateTime(Convert.ToInt32(endYearP), Convert.ToInt32(endMonthP), Convert.ToInt32(endDayP));
                        string new_dt = dt.ToString("yyyy/MM/dd");
                        SendKeys.SendWait(new_dt);
                    }
                    if (ssp0.Equals("2")) {
                        DateTime dt = new DateTime(Convert.ToInt32(endYearP), Convert.ToInt32(endMonthP), Convert.ToInt32(endDayP));
                        string new_dt = dt.ToString("yyyy-dd-MM");
                        SendKeys.SendWait(new_dt);
                    }
                    if (ssp0.Equals("3")) {
                        DateTime dt = new DateTime(Convert.ToInt32(endYearP), Convert.ToInt32(endMonthP), Convert.ToInt32(endDayP));
                        string new_dt = dt.ToString("yyyy/dd/MM");
                        SendKeys.SendWait(new_dt);
                    }
                    if (ssp0.Equals("4")) {
                        DateTime dt = new DateTime(Convert.ToInt32(endYearP), Convert.ToInt32(endMonthP), Convert.ToInt32(endDayP));
                        string new_dt = dt.ToString("dd-MM-yyyy");
                        SendKeys.SendWait(new_dt);
                    }
                    if (ssp0.Equals("5")) {
                        DateTime dt = new DateTime(Convert.ToInt32(endYearP), Convert.ToInt32(endMonthP), Convert.ToInt32(endDayP));
                        string new_dt = dt.ToString("dd/MM/yyyy");
                        SendKeys.SendWait(new_dt);
                    }
                    if (ssp0.Equals("6")) {
                        DateTime dt = new DateTime(Convert.ToInt32(endYearP), Convert.ToInt32(endMonthP), Convert.ToInt32(endDayP));
                        string new_dt = dt.ToString("MM-dd-yyyy");
                        SendKeys.SendWait(new_dt);
                    }
                    if (ssp0.Equals("7")) {
                        DateTime dt = new DateTime(Convert.ToInt32(endYearP), Convert.ToInt32(endMonthP), Convert.ToInt32(endDayP));
                        string new_dt = dt.ToString("MM/dd/yyyy");
                        SendKeys.SendWait(new_dt);
                    }


                } else if (s.Equals("يوم انتهاء الصلاحية")) {
                    SendKeys.SendWait(endDayP);

                } else if (s.Equals("شهر انتهاء الصلاحية")) {
                    SendKeys.SendWait(endMonthP);

                } else if (s.Equals("سنة انتهاء الصلاحية")) {
                    SendKeys.SendWait(endYearP);

                } else if (s.Equals("تاريخ الاصدار")) {
                    if (ssp0.Equals("0")) {
                        DateTime dt = new DateTime(Convert.ToInt32(releaseYearP), Convert.ToInt32(releaseMonthP), Convert.ToInt32(releaseDayP));
                        string new_dt = dt.ToString("yyyy-MM-dd");
                        SendKeys.SendWait(new_dt);
                    }
                    if (ssp0.Equals("1")) {
                        DateTime dt = new DateTime(Convert.ToInt32(releaseYearP), Convert.ToInt32(releaseMonthP), Convert.ToInt32(releaseDayP));
                        string new_dt = dt.ToString("yyyy/MM/dd");
                        SendKeys.SendWait(new_dt);
                    }
                    if (ssp0.Equals("2")) {
                        DateTime dt = new DateTime(Convert.ToInt32(releaseYearP), Convert.ToInt32(releaseMonthP), Convert.ToInt32(releaseDayP));
                        string new_dt = dt.ToString("yyyy-dd-MM");
                        SendKeys.SendWait(new_dt);
                    }
                    if (ssp0.Equals("3")) {
                        DateTime dt = new DateTime(Convert.ToInt32(releaseYearP), Convert.ToInt32(releaseMonthP), Convert.ToInt32(releaseDayP));
                        string new_dt = dt.ToString("yyyy/dd/MM");
                        SendKeys.SendWait(new_dt);
                    }
                    if (ssp0.Equals("4")) {
                        DateTime dt = new DateTime(Convert.ToInt32(releaseYearP), Convert.ToInt32(releaseMonthP), Convert.ToInt32(releaseDayP));
                        string new_dt = dt.ToString("dd-MM-yyyy");
                        SendKeys.SendWait(new_dt);
                    }
                    if (ssp0.Equals("5")) {
                        DateTime dt = new DateTime(Convert.ToInt32(releaseYearP), Convert.ToInt32(releaseMonthP), Convert.ToInt32(releaseDayP));
                        string new_dt = dt.ToString("dd/MM/yyyy");
                        SendKeys.SendWait(new_dt);
                    }
                    if (ssp0.Equals("6")) {
                        DateTime dt = new DateTime(Convert.ToInt32(releaseYearP), Convert.ToInt32(releaseMonthP), Convert.ToInt32(releaseDayP));
                        string new_dt = dt.ToString("MM-dd-yyyy");
                        SendKeys.SendWait(new_dt);
                    }
                    if (ssp0.Equals("7")) {
                        DateTime dt = new DateTime(Convert.ToInt32(releaseYearP), Convert.ToInt32(releaseMonthP), Convert.ToInt32(releaseDayP));
                        string new_dt = dt.ToString("MM/dd/yyyy");
                        SendKeys.SendWait(new_dt);
                    }


                } else if (s.Equals("يوم الاصدار")) {
                    SendKeys.SendWait(releaseDayP);

                } else if (s.Equals("شهر الاصدار")) {
                    SendKeys.SendWait(releaseMonthP);

                } else if (s.Equals("سنة الاصدار")) {
                    SendKeys.SendWait(releaseYearP);

                } else if (s.Equals("Space")) {

                    SendKeys.SendWait(" ");
                } else if (s.Equals("Enter")) {

                    SendKeys.SendWait("{ENTER}");
                } else if (s.Equals("Tab")) {
                    SendKeys.SendWait("{TAB}");

                } else if (s.IndexOf("0.5") > -1) {
                    Thread.Sleep(500);
                } else if (s.Equals("/")) {
                    SendKeys.SendWait("/");

                } else if (s.Equals("-")) {

                    SendKeys.SendWait("-");
                } else {
                    SendKeys.SendWait(s);
                }

            }
            static SerialPort USB;
            const string OutputVID = "1EAB", OutputPID = "1A06";
            const string Output2VID = "0C2E", Output2PID = "090A";
            static string UsbPortName;
            public static ConnectionOptions PrepareOptions() {
                ConnectionOptions options = new ConnectionOptions();
                options.Impersonation = ImpersonationLevel.Impersonate;
                options.Authentication = AuthenticationLevel.Default;
                options.EnablePrivileges = true;
                return options;
            }
            public static ManagementScope PrepareScope(string machineName, ConnectionOptions options, string path) {
                ManagementScope scope = new ManagementScope();
                scope.Path = new ManagementPath(@"\\" + machineName + path);
                scope.Options = options;
                scope.Connect();
                return scope;
            }
            public static string search() {


                List<string> portList = new List<string>();
                ConnectionOptions options = PrepareOptions();
                ManagementScope scope = PrepareScope(Environment.MachineName, options, @"\root\CIMV2");

                // Prepare the query and searcher objects.
                ObjectQuery objectQuery = new ObjectQuery("SELECT * FROM Win32_PnPEntity  where  ConfigManagerErrorCode = 0 and (  Caption like '%NLscan VCOM port for NLDC M9%'  OR   Caption like '%Newland%'   )"); // NLDC M9 USB device
                //  ObjectQuery objectQuery = new ObjectQuery("SELECT * FROM Win32_PnPEntity  where Caption like '%USB Serial Device%'  ");
                ManagementObjectSearcher mos = new ManagementObjectSearcher(scope, objectQuery);
                string Port = "";
                try {

                    foreach (ManagementObject mo in mos.Get()) {
                        try {
                            string currentObjectCaption = mo["Caption"].ToString();

                            string mycom = currentObjectCaption.Split(')')[0].Split('(')[1];
                            //  string mycom = mo["AttachedTo"].ToString();
                            //  mycom = "COM5";
                            Port = mycom;


                        } catch (Exception ex) { }
                    }
                    return Port;
                } catch (Exception ex) { return ""; Console.WriteLine("" + ex); }

            }
            static bool searchingUsb = false;
            public static string search2(String vid, String pid) {
                searchingUsb = true;
                string port = "";
                String pattern = String.Format("^VID_{0}.PID_{1}", vid, pid);
                Regex _rx = new Regex(pattern, RegexOptions.IgnoreCase);
                RegistryKey rk1 = Registry.LocalMachine;
                RegistryKey rk2 = rk1.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum");

                foreach (String s3 in rk2.GetSubKeyNames()) {
                    RegistryKey rk3 = rk2.OpenSubKey(s3);
                    foreach (String s in rk3.GetSubKeyNames()) {
                        Console.WriteLine(s);
                        if (_rx.Match(s).Success) {
                            RegistryKey rk4 = rk3.OpenSubKey(s);
                            foreach (String s2 in rk4.GetSubKeyNames()) {
                                RegistryKey rk5 = rk4.OpenSubKey(s2);
                                string location = (string)rk5.GetValue("LocationInformation");
                                RegistryKey rk6 = rk5.OpenSubKey("Device Parameters");
                                string portName = (string)rk6.GetValue("PortName");
                                bool t = false;
                                foreach (string p in SerialPort.GetPortNames()) {
                                    if (p == portName)
                                        t = true;
                                }
                                if (!String.IsNullOrEmpty(portName) && t) {

                                    // USB.PortName = UsbPortName;// UsbPortName;//COM11
                                    port = (string)rk6.GetValue("PortName"); ;
                                }
                            }
                        }
                    }
                }
                searchingUsb = false;
                return port;
            }
            static int hh = 0;
            private static void OnTimedEvent(object source, ElapsedEventArgs e) {
                if (searchingUsb) return;
                try {
                    string winson = search2(OutputVID, OutputPID);
                    Console.WriteLine("winson = " + winson);
                    if (!winson.Equals("")) {
                        UsbPortName = winson;
                    } else {
                        string honeywell = search2(Output2VID, Output2PID);
                        Console.WriteLine("honeywell = " + honeywell);
                        if (!honeywell.Equals("")) {
                            UsbPortName = honeywell;
                        } else {
                            Console.WriteLine("com = " + com);
                            if (com.Trim().Length > 0) {
                                UsbPortName = com.Trim();
                            } else {
                                UsbPortName = "";
                            }
                        }
                    }
                    Console.WriteLine("UsbPortName=" + UsbPortName);
                    if (UsbPortName.Equals("") || (!USB.IsOpen)) {
                        USB.Close();
                        if (hh == 0) {

                            UsbPortName = "";
                            try {
                                com = "";
                                string[] toSave = new string[4];
                                toSave[0] = com;
                                File.WriteAllLines("com.txt", toSave);
                            } catch { }
                            trayIcon.Icon = Properties.Resources.red;
                            trayIcon.ShowBalloonTip(100, "Information", "تم فصل قارئ الباركود", ToolTipIcon.Info);

                            hh = 1;
                        }
                    }

                    USB.PortName = UsbPortName; // UsbPortName;//COM11
                    if (!USB.IsOpen) {
                        Console.WriteLine("USB.IsOpen:" + USB.IsOpen);
                        USB.Open();
                        hh = 0;


                        trayIcon.Icon = Properties.Resources.grean;
                        trayIcon.ShowBalloonTip(100, "Information", "تم الاتصال بقارئ الباركود", ToolTipIcon.Info);
                        try {
                            com = USB.PortName.ToLower().Replace("com", "");
                            string[] toSave = new string[4];
                            toSave[0] = com;
                            File.WriteAllLines("com.txt", toSave);
                        } catch { }

                        // MessageBox.Show("UsbPortName=" + UsbPortName);
                    }
                } catch { }


            }
            void Method1() {
                //SendKeys.SendWait("Hello World!");
                //SendKeys.SendWait("{TAB}");
                //SendKeys.SendWait("Fater");
            }
            bool editingFormat = false;
            void FireClickEvent(object sender, EventArgs e) {

                if (!editingFormat) {
                    editingFormat = true;
                    new Form1().ShowDialog(); // Start editing format
                    editingFormat = false; // End of editing format
                    try {
                        string[] read = File.ReadAllLines("com.txt");
                        com = string.IsNullOrEmpty(read[0]) ? "" : read[0];
                    } catch { }
                    readFormatFile();
                    readPassportFormatFile();

                }


            }
            //Ctor
            public ApplicationStartUp() {
                InitializeComponent();
            }

            protected override void OnLoad(EventArgs e) {
                Visible = false;
                ShowInTaskbar = false;
                base.OnLoad(e);
            }

            private static void OnExit(object sender, EventArgs e) {
                // Release the icon resource.
                trayIcon.Dispose();
                Application.Exit();
            }

            protected override void Dispose(bool isDisposing) {

                try {
                    if (isDisposing) {
                        // Release the icon resource.
                        if (trayIcon != null)
                            trayIcon.Dispose();
                    }
                    base.Dispose(isDisposing);
                } catch { }
            }


            private string getCpuId() {
                string cpuID = string.Empty;
                var mbs = new ManagementObjectSearcher("Select ProcessorID From Win32_processor");
                //ManagementClass mc = new ManagementClass("win32_processor");
                ManagementObjectCollection moc = mbs.Get();

                foreach (ManagementObject mo in moc) {
                    if (cpuID == "") {
                        //Remark gets only the first CPU ID
                        cpuID = mo.Properties["processorID"].Value.ToString();
                    }
                }
                return cpuID;
            }

            private string getMotherboardSerial() {
                string cpuID = string.Empty;
                var mbs = new ManagementObjectSearcher("Select SerialNumber From Win32_BaseBoard");
                //ManagementClass mc = new ManagementClass("win32_processor");
                ManagementObjectCollection moc = mbs.Get();

                foreach (ManagementObject mo in moc) {
                    if (cpuID == "") {
                        //Remark gets only the first CPU ID
                        cpuID = mo.Properties["SerialNumber"].Value.ToString();
                    }
                }
                return cpuID;
            }
            
            private string getHardDiskId() {
                string cpuID = string.Empty;
                var mbs = new ManagementObjectSearcher("Select VolumeSerialNumber From win32_logicaldisk");
                //ManagementClass mc = new ManagementClass("win32_processor");
                ManagementObjectCollection moc = mbs.Get();

                foreach (ManagementObject mo in moc) {
                    if (cpuID == "") {
                        //Remark gets only the first CPU ID
                        cpuID = mo.Properties["VolumeSerialNumber"].Value.ToString();
                    }
                }
                return cpuID;
            }

            public static string GetSerialFromDrive(string driveLetter) {
                try {
                    using (var partitions = new ManagementObjectSearcher("ASSOCIATORS OF {Win32_LogicalDisk.DeviceID='" + driveLetter +
                                                        "'} WHERE ResultClass=Win32_DiskPartition")) {
                        foreach (var partition in partitions.Get()) {
                            using (var drives = new ManagementObjectSearcher("ASSOCIATORS OF {Win32_DiskPartition.DeviceID='" +
                                                                    partition["DeviceID"] +
                                                                    "'} WHERE ResultClass=Win32_DiskDrive")) {
                                foreach (var drive in drives.Get()) {
                                    return (string)drive["SerialNumber"];
                                }
                            }
                        }
                    }
                } catch {
                    return "<unknown>";
                }

                // Not Found
                return "<unknown>";
            }

            private string getMacAddress() {
                return NetworkInterface
                            .GetAllNetworkInterfaces()
                            .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                            .Select(nic => nic.GetPhysicalAddress().ToString())
                            .FirstOrDefault();
            }

            public static string CreateMD5(string input) {
                // Use input string to calculate MD5 hash
                using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create()) {
                    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                    byte[] hashBytes = md5.ComputeHash(inputBytes);

                    // Convert the byte array to hexadecimal string
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < hashBytes.Length; i++) {
                        sb.Append(hashBytes[i].ToString("X2"));
                    }
                    string serialized = sb.ToString().Substring(sb.Length - 6);
                    return serialized;
                }
            }
        }


    }
}
