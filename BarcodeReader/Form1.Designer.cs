namespace BarcodeReader
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.saveBtn = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.comBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.dateBoxPassport = new System.Windows.Forms.ComboBox();
            this.exportBtnPassport = new System.Windows.Forms.Button();
            this.inputListBoxPassport = new System.Windows.Forms.ListBox();
            this.importBtnPassport = new System.Windows.Forms.Button();
            this.textInputBoxPassport = new System.Windows.Forms.TextBox();
            this.moveDownBtnPassport = new System.Windows.Forms.Button();
            this.addToOutputBtnPassport = new System.Windows.Forms.Button();
            this.moveUpBtnPassport = new System.Windows.Forms.Button();
            this.deleteBtnPassport = new System.Windows.Forms.Button();
            this.deleteAllBtnPassport = new System.Windows.Forms.Button();
            this.outputListBoxPassport = new System.Windows.Forms.ListBox();
            this.addTextToOutputBtnPassport = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.exportBtnId = new System.Windows.Forms.Button();
            this.importBtnId = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dateBoxId = new System.Windows.Forms.ComboBox();
            this.inputListBoxId = new System.Windows.Forms.ListBox();
            this.textInputBoxId = new System.Windows.Forms.TextBox();
            this.moveDownBtnId = new System.Windows.Forms.Button();
            this.addToOutputBtnId = new System.Windows.Forms.Button();
            this.moveUpBtnId = new System.Windows.Forms.Button();
            this.deleteBtnId = new System.Windows.Forms.Button();
            this.deleteAllBtnId = new System.Windows.Forms.Button();
            this.outputListBoxId = new System.Windows.Forms.ListBox();
            this.addTextToOutputBtnId = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.saveBtn.BackColor = System.Drawing.Color.MediumBlue;
            this.saveBtn.Font = new System.Drawing.Font("Simplified Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.ForeColor = System.Drawing.Color.White;
            this.saveBtn.Location = new System.Drawing.Point(17, 453);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(135, 42);
            this.saveBtn.TabIndex = 10;
            this.saveBtn.Text = "حفظ";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.SystemColors.Control;
            this.button9.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button9.Location = new System.Drawing.Point(3, 4);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(64, 36);
            this.button9.TabIndex = 14;
            this.button9.Text = "حول";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click_1);
            // 
            // comBox
            // 
            this.comBox.Font = new System.Drawing.Font("Tahoma", 12F);
            this.comBox.Location = new System.Drawing.Point(73, 9);
            this.comBox.Name = "comBox";
            this.comBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comBox.Size = new System.Drawing.Size(79, 27);
            this.comBox.TabIndex = 18;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.dateBoxPassport);
            this.tabPage2.Controls.Add(this.exportBtnPassport);
            this.tabPage2.Controls.Add(this.inputListBoxPassport);
            this.tabPage2.Controls.Add(this.importBtnPassport);
            this.tabPage2.Controls.Add(this.textInputBoxPassport);
            this.tabPage2.Controls.Add(this.moveDownBtnPassport);
            this.tabPage2.Controls.Add(this.addToOutputBtnPassport);
            this.tabPage2.Controls.Add(this.moveUpBtnPassport);
            this.tabPage2.Controls.Add(this.deleteBtnPassport);
            this.tabPage2.Controls.Add(this.deleteAllBtnPassport);
            this.tabPage2.Controls.Add(this.outputListBoxPassport);
            this.tabPage2.Controls.Add(this.addTextToOutputBtnPassport);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(740, 385);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "جواز سفر";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(648, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 28);
            this.label2.TabIndex = 21;
            this.label2.Text = "صيغة التاريخ";
            // 
            // dateBoxPassport
            // 
            this.dateBoxPassport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateBoxPassport.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.dateBoxPassport.FormattingEnabled = true;
            this.dateBoxPassport.Items.AddRange(new object[] {
            "yyyy-mm-dd",
            "yyyy/mm/dd",
            "yyyy-dd-mm",
            "yyyy/dd/mm",
            "dd-mm-yyyy",
            "dd/mm/yyyy",
            "mm-dd-yyyy",
            "mm/dd/yyyy"});
            this.dateBoxPassport.Location = new System.Drawing.Point(467, 18);
            this.dateBoxPassport.Name = "dateBoxPassport";
            this.dateBoxPassport.Size = new System.Drawing.Size(171, 36);
            this.dateBoxPassport.TabIndex = 20;
            // 
            // exportBtnPassport
            // 
            this.exportBtnPassport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exportBtnPassport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.exportBtnPassport.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportBtnPassport.ForeColor = System.Drawing.Color.Black;
            this.exportBtnPassport.Location = new System.Drawing.Point(208, 310);
            this.exportBtnPassport.Name = "exportBtnPassport";
            this.exportBtnPassport.Size = new System.Drawing.Size(87, 41);
            this.exportBtnPassport.TabIndex = 16;
            this.exportBtnPassport.Text = "تصدير";
            this.exportBtnPassport.UseVisualStyleBackColor = false;
            this.exportBtnPassport.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // inputListBoxPassport
            // 
            this.inputListBoxPassport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.inputListBoxPassport.Font = new System.Drawing.Font("Simplified Arabic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputListBoxPassport.FormattingEnabled = true;
            this.inputListBoxPassport.ItemHeight = 26;
            this.inputListBoxPassport.Items.AddRange(new object[] {
            "الاسم",
            "النسبة",
            "اسم الأب",
            "اسم الأم",
            "محل الولادة",
            "تاريخ الولادة",
            "يوم الولادة",
            "شهر الولادة",
            "سنة الولادة",
            "الرقم الوطني",
            "رقم الجواز",
            "تاريخ انتهاء الصلاحية",
            "يوم انتهاء الصلاحية",
            "شهر انتهاء الصلاحية",
            "سنة انتهاء الصلاحية",
            "تاريخ الاصدار",
            "يوم الاصدار",
            "شهر الاصدار",
            "سنة الاصدار",
            "Space",
            "Enter",
            "Tab",
            "/",
            "-",
            "تأخير(0.5 ثانية)"});
            this.inputListBoxPassport.Location = new System.Drawing.Point(467, 69);
            this.inputListBoxPassport.Name = "inputListBoxPassport";
            this.inputListBoxPassport.Size = new System.Drawing.Size(172, 238);
            this.inputListBoxPassport.TabIndex = 13;
            // 
            // importBtnPassport
            // 
            this.importBtnPassport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.importBtnPassport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.importBtnPassport.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importBtnPassport.ForeColor = System.Drawing.Color.Black;
            this.importBtnPassport.Location = new System.Drawing.Point(118, 310);
            this.importBtnPassport.Name = "importBtnPassport";
            this.importBtnPassport.Size = new System.Drawing.Size(87, 41);
            this.importBtnPassport.TabIndex = 15;
            this.importBtnPassport.Text = "استرجاع";
            this.importBtnPassport.UseVisualStyleBackColor = false;
            this.importBtnPassport.Click += new System.EventHandler(this.importBtn_Click);
            // 
            // textInputBoxPassport
            // 
            this.textInputBoxPassport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textInputBoxPassport.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.textInputBoxPassport.Location = new System.Drawing.Point(467, 313);
            this.textInputBoxPassport.Name = "textInputBoxPassport";
            this.textInputBoxPassport.Size = new System.Drawing.Size(172, 34);
            this.textInputBoxPassport.TabIndex = 18;
            // 
            // moveDownBtnPassport
            // 
            this.moveDownBtnPassport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.moveDownBtnPassport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("moveDownBtnPassport.BackgroundImage")));
            this.moveDownBtnPassport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.moveDownBtnPassport.Location = new System.Drawing.Point(60, 171);
            this.moveDownBtnPassport.Name = "moveDownBtnPassport";
            this.moveDownBtnPassport.Size = new System.Drawing.Size(54, 50);
            this.moveDownBtnPassport.TabIndex = 23;
            this.moveDownBtnPassport.UseVisualStyleBackColor = true;
            this.moveDownBtnPassport.Click += new System.EventHandler(this.moveDownBtn_Click);
            // 
            // addToOutputBtnPassport
            // 
            this.addToOutputBtnPassport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addToOutputBtnPassport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.addToOutputBtnPassport.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addToOutputBtnPassport.Location = new System.Drawing.Point(335, 118);
            this.addToOutputBtnPassport.Name = "addToOutputBtnPassport";
            this.addToOutputBtnPassport.Size = new System.Drawing.Size(87, 41);
            this.addToOutputBtnPassport.TabIndex = 15;
            this.addToOutputBtnPassport.Text = "إضافة";
            this.addToOutputBtnPassport.UseVisualStyleBackColor = false;
            this.addToOutputBtnPassport.Click += new System.EventHandler(this.addToOutputBtn_Click);
            // 
            // moveUpBtnPassport
            // 
            this.moveUpBtnPassport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.moveUpBtnPassport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("moveUpBtnPassport.BackgroundImage")));
            this.moveUpBtnPassport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.moveUpBtnPassport.Location = new System.Drawing.Point(60, 113);
            this.moveUpBtnPassport.Name = "moveUpBtnPassport";
            this.moveUpBtnPassport.Size = new System.Drawing.Size(54, 50);
            this.moveUpBtnPassport.TabIndex = 22;
            this.moveUpBtnPassport.UseVisualStyleBackColor = true;
            this.moveUpBtnPassport.Click += new System.EventHandler(this.bmoveUpBtn_Click);
            // 
            // deleteBtnPassport
            // 
            this.deleteBtnPassport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteBtnPassport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.deleteBtnPassport.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.deleteBtnPassport.Location = new System.Drawing.Point(335, 165);
            this.deleteBtnPassport.Name = "deleteBtnPassport";
            this.deleteBtnPassport.Size = new System.Drawing.Size(87, 41);
            this.deleteBtnPassport.TabIndex = 16;
            this.deleteBtnPassport.Text = "حذف";
            this.deleteBtnPassport.UseVisualStyleBackColor = false;
            this.deleteBtnPassport.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // deleteAllBtnPassport
            // 
            this.deleteAllBtnPassport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteAllBtnPassport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.deleteAllBtnPassport.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.deleteAllBtnPassport.Location = new System.Drawing.Point(335, 212);
            this.deleteAllBtnPassport.Name = "deleteAllBtnPassport";
            this.deleteAllBtnPassport.Size = new System.Drawing.Size(87, 41);
            this.deleteAllBtnPassport.TabIndex = 17;
            this.deleteAllBtnPassport.Text = "حذف الكل";
            this.deleteAllBtnPassport.UseVisualStyleBackColor = false;
            this.deleteAllBtnPassport.Click += new System.EventHandler(this.deleteAllBtn_Click);
            // 
            // outputListBoxPassport
            // 
            this.outputListBoxPassport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.outputListBoxPassport.Font = new System.Drawing.Font("Simplified Arabic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputListBoxPassport.FormattingEnabled = true;
            this.outputListBoxPassport.ItemHeight = 26;
            this.outputListBoxPassport.Location = new System.Drawing.Point(120, 69);
            this.outputListBoxPassport.Name = "outputListBoxPassport";
            this.outputListBoxPassport.Size = new System.Drawing.Size(172, 238);
            this.outputListBoxPassport.TabIndex = 14;
            // 
            // addTextToOutputBtnPassport
            // 
            this.addTextToOutputBtnPassport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addTextToOutputBtnPassport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.addTextToOutputBtnPassport.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.addTextToOutputBtnPassport.Location = new System.Drawing.Point(335, 310);
            this.addTextToOutputBtnPassport.Name = "addTextToOutputBtnPassport";
            this.addTextToOutputBtnPassport.Size = new System.Drawing.Size(87, 41);
            this.addTextToOutputBtnPassport.TabIndex = 19;
            this.addTextToOutputBtnPassport.Text = "إضافة";
            this.addTextToOutputBtnPassport.UseVisualStyleBackColor = false;
            this.addTextToOutputBtnPassport.Click += new System.EventHandler(this.addTextToOutputBtn_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.exportBtnId);
            this.tabPage1.Controls.Add(this.importBtnId);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.dateBoxId);
            this.tabPage1.Controls.Add(this.inputListBoxId);
            this.tabPage1.Controls.Add(this.textInputBoxId);
            this.tabPage1.Controls.Add(this.moveDownBtnId);
            this.tabPage1.Controls.Add(this.addToOutputBtnId);
            this.tabPage1.Controls.Add(this.moveUpBtnId);
            this.tabPage1.Controls.Add(this.deleteBtnId);
            this.tabPage1.Controls.Add(this.deleteAllBtnId);
            this.tabPage1.Controls.Add(this.outputListBoxId);
            this.tabPage1.Controls.Add(this.addTextToOutputBtnId);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(740, 385);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "هوية شخصية";
            // 
            // exportBtnId
            // 
            this.exportBtnId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exportBtnId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.exportBtnId.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportBtnId.ForeColor = System.Drawing.Color.Black;
            this.exportBtnId.Location = new System.Drawing.Point(208, 310);
            this.exportBtnId.Name = "exportBtnId";
            this.exportBtnId.Size = new System.Drawing.Size(87, 41);
            this.exportBtnId.TabIndex = 18;
            this.exportBtnId.Text = "تصدير";
            this.exportBtnId.UseVisualStyleBackColor = false;
            this.exportBtnId.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // importBtnId
            // 
            this.importBtnId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.importBtnId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.importBtnId.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importBtnId.ForeColor = System.Drawing.Color.Black;
            this.importBtnId.Location = new System.Drawing.Point(118, 310);
            this.importBtnId.Name = "importBtnId";
            this.importBtnId.Size = new System.Drawing.Size(87, 41);
            this.importBtnId.TabIndex = 17;
            this.importBtnId.Text = "استرجاع";
            this.importBtnId.UseVisualStyleBackColor = false;
            this.importBtnId.Click += new System.EventHandler(this.importBtn_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(648, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 28);
            this.label1.TabIndex = 9;
            this.label1.Text = "صيغة التاريخ";
            // 
            // dateBoxId
            // 
            this.dateBoxId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateBoxId.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.dateBoxId.FormattingEnabled = true;
            this.dateBoxId.Items.AddRange(new object[] {
            "yyyy-mm-dd",
            "yyyy/mm/dd",
            "yyyy-dd-mm",
            "yyyy/dd/mm",
            "dd-mm-yyyy",
            "dd/mm/yyyy",
            "mm-dd-yyyy",
            "mm/dd/yyyy"});
            this.dateBoxId.Location = new System.Drawing.Point(467, 18);
            this.dateBoxId.Name = "dateBoxId";
            this.dateBoxId.Size = new System.Drawing.Size(171, 36);
            this.dateBoxId.TabIndex = 8;
            // 
            // inputListBoxId
            // 
            this.inputListBoxId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.inputListBoxId.Font = new System.Drawing.Font("Simplified Arabic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputListBoxId.FormattingEnabled = true;
            this.inputListBoxId.ItemHeight = 26;
            this.inputListBoxId.Items.AddRange(new object[] {
            "الاسم",
            "النسبة",
            "اسم الأب",
            "اسم الأم",
            "محل الولادة",
            "تاريخ الولادة",
            "اليوم",
            "الشهر",
            "السنة",
            "الرقم الوطني",
            "Space",
            "Enter",
            "Tab",
            "/",
            "-",
            "تأخير(0.5 ثانية)"});
            this.inputListBoxId.Location = new System.Drawing.Point(467, 69);
            this.inputListBoxId.Name = "inputListBoxId";
            this.inputListBoxId.Size = new System.Drawing.Size(172, 238);
            this.inputListBoxId.TabIndex = 1;
            // 
            // textInputBoxId
            // 
            this.textInputBoxId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textInputBoxId.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.textInputBoxId.Location = new System.Drawing.Point(467, 313);
            this.textInputBoxId.Name = "textInputBoxId";
            this.textInputBoxId.Size = new System.Drawing.Size(172, 34);
            this.textInputBoxId.TabIndex = 6;
            // 
            // moveDownBtnId
            // 
            this.moveDownBtnId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.moveDownBtnId.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("moveDownBtnId.BackgroundImage")));
            this.moveDownBtnId.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.moveDownBtnId.Location = new System.Drawing.Point(60, 171);
            this.moveDownBtnId.Name = "moveDownBtnId";
            this.moveDownBtnId.Size = new System.Drawing.Size(54, 50);
            this.moveDownBtnId.TabIndex = 12;
            this.moveDownBtnId.UseVisualStyleBackColor = true;
            this.moveDownBtnId.Click += new System.EventHandler(this.moveDownBtn_Click);
            // 
            // addToOutputBtnId
            // 
            this.addToOutputBtnId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addToOutputBtnId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.addToOutputBtnId.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addToOutputBtnId.Location = new System.Drawing.Point(335, 118);
            this.addToOutputBtnId.Name = "addToOutputBtnId";
            this.addToOutputBtnId.Size = new System.Drawing.Size(87, 41);
            this.addToOutputBtnId.TabIndex = 3;
            this.addToOutputBtnId.Text = "إضافة";
            this.addToOutputBtnId.UseVisualStyleBackColor = false;
            this.addToOutputBtnId.Click += new System.EventHandler(this.addToOutputBtn_Click);
            // 
            // moveUpBtnId
            // 
            this.moveUpBtnId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.moveUpBtnId.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("moveUpBtnId.BackgroundImage")));
            this.moveUpBtnId.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.moveUpBtnId.Location = new System.Drawing.Point(60, 113);
            this.moveUpBtnId.Name = "moveUpBtnId";
            this.moveUpBtnId.Size = new System.Drawing.Size(54, 50);
            this.moveUpBtnId.TabIndex = 11;
            this.moveUpBtnId.UseVisualStyleBackColor = true;
            this.moveUpBtnId.Click += new System.EventHandler(this.bmoveUpBtn_Click);
            // 
            // deleteBtnId
            // 
            this.deleteBtnId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteBtnId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.deleteBtnId.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.deleteBtnId.Location = new System.Drawing.Point(335, 165);
            this.deleteBtnId.Name = "deleteBtnId";
            this.deleteBtnId.Size = new System.Drawing.Size(87, 41);
            this.deleteBtnId.TabIndex = 4;
            this.deleteBtnId.Text = "حذف";
            this.deleteBtnId.UseVisualStyleBackColor = false;
            this.deleteBtnId.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // deleteAllBtnId
            // 
            this.deleteAllBtnId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteAllBtnId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.deleteAllBtnId.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.deleteAllBtnId.Location = new System.Drawing.Point(335, 212);
            this.deleteAllBtnId.Name = "deleteAllBtnId";
            this.deleteAllBtnId.Size = new System.Drawing.Size(87, 41);
            this.deleteAllBtnId.TabIndex = 5;
            this.deleteAllBtnId.Text = "حذف الكل";
            this.deleteAllBtnId.UseVisualStyleBackColor = false;
            this.deleteAllBtnId.Click += new System.EventHandler(this.deleteAllBtn_Click);
            // 
            // outputListBoxId
            // 
            this.outputListBoxId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.outputListBoxId.Font = new System.Drawing.Font("Simplified Arabic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputListBoxId.FormattingEnabled = true;
            this.outputListBoxId.ItemHeight = 26;
            this.outputListBoxId.Location = new System.Drawing.Point(120, 69);
            this.outputListBoxId.Name = "outputListBoxId";
            this.outputListBoxId.Size = new System.Drawing.Size(172, 238);
            this.outputListBoxId.TabIndex = 2;
            // 
            // addTextToOutputBtnId
            // 
            this.addTextToOutputBtnId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addTextToOutputBtnId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.addTextToOutputBtnId.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.addTextToOutputBtnId.Location = new System.Drawing.Point(335, 310);
            this.addTextToOutputBtnId.Name = "addTextToOutputBtnId";
            this.addTextToOutputBtnId.Size = new System.Drawing.Size(87, 41);
            this.addTextToOutputBtnId.TabIndex = 7;
            this.addTextToOutputBtnId.Text = "إضافة";
            this.addTextToOutputBtnId.UseVisualStyleBackColor = false;
            this.addTextToOutputBtnId.Click += new System.EventHandler(this.addTextToOutputBtn_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.tabControl1.ItemSize = new System.Drawing.Size(102, 24);
            this.tabControl1.Location = new System.Drawing.Point(3, 22);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(748, 417);
            this.tabControl1.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 507);
            this.Controls.Add(this.comBox);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.saveBtn);
            this.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(130, 100);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(771, 546);
            this.MinimumSize = new System.Drawing.Size(771, 546);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "إعدادات الباركود";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox comBox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox dateBoxPassport;
        private System.Windows.Forms.Button exportBtnPassport;
        private System.Windows.Forms.ListBox inputListBoxPassport;
        private System.Windows.Forms.Button importBtnPassport;
        private System.Windows.Forms.TextBox textInputBoxPassport;
        private System.Windows.Forms.Button moveDownBtnPassport;
        private System.Windows.Forms.Button addToOutputBtnPassport;
        private System.Windows.Forms.Button moveUpBtnPassport;
        private System.Windows.Forms.Button deleteBtnPassport;
        private System.Windows.Forms.Button deleteAllBtnPassport;
        private System.Windows.Forms.ListBox outputListBoxPassport;
        private System.Windows.Forms.Button addTextToOutputBtnPassport;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button exportBtnId;
        private System.Windows.Forms.Button importBtnId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox dateBoxId;
        private System.Windows.Forms.ListBox inputListBoxId;
        private System.Windows.Forms.TextBox textInputBoxId;
        private System.Windows.Forms.Button moveDownBtnId;
        private System.Windows.Forms.Button addToOutputBtnId;
        private System.Windows.Forms.Button moveUpBtnId;
        private System.Windows.Forms.Button deleteBtnId;
        private System.Windows.Forms.Button deleteAllBtnId;
        private System.Windows.Forms.ListBox outputListBoxId;
        private System.Windows.Forms.Button addTextToOutputBtnId;
        private System.Windows.Forms.TabControl tabControl1;
    }
}

