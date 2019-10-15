namespace TBC
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
            this.tblog = new System.Windows.Forms.TextBox();
            this.btest = new System.Windows.Forms.Button();
            this.bstart = new System.Windows.Forms.Button();
            this.gbevent = new System.Windows.Forms.GroupBox();
            this.bsave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpstartdate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tblocation = new System.Windows.Forms.TextBox();
            this.cbcategory = new System.Windows.Forms.ComboBox();
            this.lvevents = new System.Windows.Forms.ListView();
            this.chtitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chstart = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chend = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chcategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chlocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rbnew = new System.Windows.Forms.RadioButton();
            this.rbupdate = new System.Windows.Forms.RadioButton();
            this.tbid = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbduration = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbtitle = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gbevent.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblog
            // 
            this.tblog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblog.Location = new System.Drawing.Point(10, 237);
            this.tblog.Multiline = true;
            this.tblog.Name = "tblog";
            this.tblog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tblog.Size = new System.Drawing.Size(424, 275);
            this.tblog.TabIndex = 0;
            // 
            // btest
            // 
            this.btest.Location = new System.Drawing.Point(12, 201);
            this.btest.Name = "btest";
            this.btest.Size = new System.Drawing.Size(75, 23);
            this.btest.TabIndex = 1;
            this.btest.Text = "Test";
            this.btest.UseVisualStyleBackColor = true;
            this.btest.Click += new System.EventHandler(this.btest_Click);
            // 
            // bstart
            // 
            this.bstart.Location = new System.Drawing.Point(104, 201);
            this.bstart.Name = "bstart";
            this.bstart.Size = new System.Drawing.Size(75, 23);
            this.bstart.TabIndex = 2;
            this.bstart.Text = "Start";
            this.bstart.UseVisualStyleBackColor = true;
            this.bstart.Click += new System.EventHandler(this.bstart_Click);
            // 
            // gbevent
            // 
            this.gbevent.Controls.Add(this.label6);
            this.gbevent.Controls.Add(this.tbtitle);
            this.gbevent.Controls.Add(this.label5);
            this.gbevent.Controls.Add(this.cbduration);
            this.gbevent.Controls.Add(this.label4);
            this.gbevent.Controls.Add(this.tbid);
            this.gbevent.Controls.Add(this.rbupdate);
            this.gbevent.Controls.Add(this.rbnew);
            this.gbevent.Controls.Add(this.bsave);
            this.gbevent.Controls.Add(this.label3);
            this.gbevent.Controls.Add(this.dtpstartdate);
            this.gbevent.Controls.Add(this.label2);
            this.gbevent.Controls.Add(this.label1);
            this.gbevent.Controls.Add(this.tblocation);
            this.gbevent.Controls.Add(this.cbcategory);
            this.gbevent.Location = new System.Drawing.Point(440, 237);
            this.gbevent.Name = "gbevent";
            this.gbevent.Size = new System.Drawing.Size(283, 275);
            this.gbevent.TabIndex = 3;
            this.gbevent.TabStop = false;
            this.gbevent.Text = "Event";
            // 
            // bsave
            // 
            this.bsave.Location = new System.Drawing.Point(202, 246);
            this.bsave.Name = "bsave";
            this.bsave.Size = new System.Drawing.Size(75, 23);
            this.bsave.TabIndex = 10;
            this.bsave.Text = "Save";
            this.bsave.UseVisualStyleBackColor = true;
            this.bsave.Click += new System.EventHandler(this.bsave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Start";
            // 
            // dtpstartdate
            // 
            this.dtpstartdate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpstartdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpstartdate.Location = new System.Drawing.Point(61, 160);
            this.dtpstartdate.Name = "dtpstartdate";
            this.dtpstartdate.Size = new System.Drawing.Size(132, 20);
            this.dtpstartdate.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Location";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Category";
            // 
            // tblocation
            // 
            this.tblocation.Location = new System.Drawing.Point(61, 131);
            this.tblocation.Name = "tblocation";
            this.tblocation.Size = new System.Drawing.Size(121, 20);
            this.tblocation.TabIndex = 1;
            // 
            // cbcategory
            // 
            this.cbcategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbcategory.FormattingEnabled = true;
            this.cbcategory.Items.AddRange(new object[] {
            "Cecilia",
            "Dan",
            "Holidays",
            "Mamma",
            "Miscellaneous",
            "Personal",
            "Public Holiday"});
            this.cbcategory.Location = new System.Drawing.Point(61, 104);
            this.cbcategory.Name = "cbcategory";
            this.cbcategory.Size = new System.Drawing.Size(121, 21);
            this.cbcategory.TabIndex = 0;
            // 
            // lvevents
            // 
            this.lvevents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chtitle,
            this.chstart,
            this.chend,
            this.chcategory,
            this.chlocation,
            this.chid});
            this.lvevents.FullRowSelect = true;
            this.lvevents.GridLines = true;
            this.lvevents.HideSelection = false;
            this.lvevents.Location = new System.Drawing.Point(12, 12);
            this.lvevents.MultiSelect = false;
            this.lvevents.Name = "lvevents";
            this.lvevents.Size = new System.Drawing.Size(711, 183);
            this.lvevents.TabIndex = 4;
            this.lvevents.UseCompatibleStateImageBehavior = false;
            this.lvevents.View = System.Windows.Forms.View.Details;
            this.lvevents.SelectedIndexChanged += new System.EventHandler(this.lvevents_SelectedIndexChanged);
            // 
            // chtitle
            // 
            this.chtitle.Text = "Title";
            this.chtitle.Width = 120;
            // 
            // chstart
            // 
            this.chstart.Text = "Start";
            this.chstart.Width = 120;
            // 
            // chend
            // 
            this.chend.Text = "End";
            this.chend.Width = 120;
            // 
            // chcategory
            // 
            this.chcategory.Text = "Category";
            // 
            // chlocation
            // 
            this.chlocation.Text = "Location";
            this.chlocation.Width = 100;
            // 
            // chid
            // 
            this.chid.Text = "Id";
            this.chid.Width = 200;
            // 
            // rbnew
            // 
            this.rbnew.AutoSize = true;
            this.rbnew.Checked = true;
            this.rbnew.Location = new System.Drawing.Point(6, 229);
            this.rbnew.Name = "rbnew";
            this.rbnew.Size = new System.Drawing.Size(84, 17);
            this.rbnew.TabIndex = 11;
            this.rbnew.TabStop = true;
            this.rbnew.Text = "Add As New";
            this.rbnew.UseVisualStyleBackColor = true;
            // 
            // rbupdate
            // 
            this.rbupdate.AutoSize = true;
            this.rbupdate.Location = new System.Drawing.Point(6, 252);
            this.rbupdate.Name = "rbupdate";
            this.rbupdate.Size = new System.Drawing.Size(105, 17);
            this.rbupdate.TabIndex = 12;
            this.rbupdate.Text = "Update Selected";
            this.rbupdate.UseVisualStyleBackColor = true;
            // 
            // tbid
            // 
            this.tbid.Location = new System.Drawing.Point(61, 19);
            this.tbid.Name = "tbid";
            this.tbid.Size = new System.Drawing.Size(216, 20);
            this.tbid.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "ID";
            // 
            // cbduration
            // 
            this.cbduration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbduration.FormattingEnabled = true;
            this.cbduration.Location = new System.Drawing.Point(61, 189);
            this.cbduration.Name = "cbduration";
            this.cbduration.Size = new System.Drawing.Size(71, 21);
            this.cbduration.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Duration";
            // 
            // tbtitle
            // 
            this.tbtitle.Location = new System.Drawing.Point(61, 69);
            this.tbtitle.Name = "tbtitle";
            this.tbtitle.Size = new System.Drawing.Size(216, 20);
            this.tbtitle.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Title";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 524);
            this.Controls.Add(this.lvevents);
            this.Controls.Add(this.gbevent);
            this.Controls.Add(this.bstart);
            this.Controls.Add(this.btest);
            this.Controls.Add(this.tblog);
            this.Name = "Form1";
            this.Text = "TBC";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbevent.ResumeLayout(false);
            this.gbevent.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tblog;
        private System.Windows.Forms.Button btest;
        private System.Windows.Forms.Button bstart;
        private System.Windows.Forms.GroupBox gbevent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpstartdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tblocation;
        private System.Windows.Forms.ComboBox cbcategory;
        private System.Windows.Forms.Button bsave;
        private System.Windows.Forms.ListView lvevents;
        private System.Windows.Forms.ColumnHeader chtitle;
        private System.Windows.Forms.ColumnHeader chstart;
        private System.Windows.Forms.ColumnHeader chend;
        private System.Windows.Forms.ColumnHeader chcategory;
        private System.Windows.Forms.ColumnHeader chlocation;
        private System.Windows.Forms.ColumnHeader chid;
        private System.Windows.Forms.RadioButton rbupdate;
        private System.Windows.Forms.RadioButton rbnew;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbduration;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbtitle;
    }
}

