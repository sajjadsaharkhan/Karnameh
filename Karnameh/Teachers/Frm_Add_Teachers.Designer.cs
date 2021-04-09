namespace Karnameh.Teachers
{
    partial class Frm_Add_Teachers
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
            this.components = new System.ComponentModel.Container();
            this.txtPersonalCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonX4 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.txtCodeMelli = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cmbPayeh = new System.Windows.Forms.ComboBox();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtLname = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtFname = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cmbSchools = new System.Windows.Forms.ComboBox();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.BnsSchools = new System.Windows.Forms.BindingSource(this.components);
            this.BnsPayeh = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.BnsSchools)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BnsPayeh)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPersonalCode
            // 
            this.txtPersonalCode.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtPersonalCode.Border.Class = "TextBoxBorder";
            this.txtPersonalCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPersonalCode.DisabledBackColor = System.Drawing.Color.White;
            this.txtPersonalCode.ForeColor = System.Drawing.Color.Black;
            this.txtPersonalCode.Location = new System.Drawing.Point(12, 12);
            this.txtPersonalCode.Name = "txtPersonalCode";
            this.txtPersonalCode.PreventEnterBeep = true;
            this.txtPersonalCode.ReadOnly = true;
            this.txtPersonalCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPersonalCode.Size = new System.Drawing.Size(239, 22);
            this.txtPersonalCode.TabIndex = 8;
            this.txtPersonalCode.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonX4
            // 
            this.buttonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX4.Image = global::Karnameh.Properties.Resources.Devices_media_floppy_icon;
            this.buttonX4.ImageTextSpacing = 5;
            this.buttonX4.Location = new System.Drawing.Point(240, 214);
            this.buttonX4.Name = "buttonX4";
            this.buttonX4.Size = new System.Drawing.Size(79, 23);
            this.buttonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX4.TabIndex = 10;
            this.buttonX4.Text = "ذخیره";
            this.buttonX4.Click += new System.EventHandler(this.buttonX4_Click);
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX3.Image = global::Karnameh.Properties.Resources.arrow_left_icon;
            this.buttonX3.ImageTextSpacing = 2;
            this.buttonX3.Location = new System.Drawing.Point(12, 214);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(79, 23);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.TabIndex = 9;
            this.buttonX3.Text = "بازگشت";
            // 
            // txtCodeMelli
            // 
            this.txtCodeMelli.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtCodeMelli.Border.Class = "TextBoxBorder";
            this.txtCodeMelli.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCodeMelli.DisabledBackColor = System.Drawing.Color.White;
            this.txtCodeMelli.ForeColor = System.Drawing.Color.Black;
            this.txtCodeMelli.Location = new System.Drawing.Point(12, 40);
            this.txtCodeMelli.Name = "txtCodeMelli";
            this.txtCodeMelli.PreventEnterBeep = true;
            this.txtCodeMelli.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCodeMelli.Size = new System.Drawing.Size(239, 22);
            this.txtCodeMelli.TabIndex = 8;
            this.txtCodeMelli.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtCodeMelli.WatermarkText = "الزامی...";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtName.Border.Class = "TextBoxBorder";
            this.txtName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtName.DisabledBackColor = System.Drawing.Color.White;
            this.txtName.ForeColor = System.Drawing.Color.Black;
            this.txtName.Location = new System.Drawing.Point(12, 68);
            this.txtName.Name = "txtName";
            this.txtName.PreventEnterBeep = true;
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtName.Size = new System.Drawing.Size(239, 22);
            this.txtName.TabIndex = 8;
            this.txtName.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtName.WatermarkText = "الزامی...";
            // 
            // cmbPayeh
            // 
            this.cmbPayeh.DataSource = this.BnsPayeh;
            this.cmbPayeh.DisplayMember = "Name";
            this.cmbPayeh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPayeh.FormattingEnabled = true;
            this.cmbPayeh.Location = new System.Drawing.Point(12, 181);
            this.cmbPayeh.Name = "cmbPayeh";
            this.cmbPayeh.Size = new System.Drawing.Size(239, 22);
            this.cmbPayeh.TabIndex = 11;
            this.cmbPayeh.ValueMember = "id";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(257, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 12;
            this.labelX1.Text = ":کد پرسنلی";
            // 
            // txtLname
            // 
            this.txtLname.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtLname.Border.Class = "TextBoxBorder";
            this.txtLname.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLname.DisabledBackColor = System.Drawing.Color.White;
            this.txtLname.ForeColor = System.Drawing.Color.Black;
            this.txtLname.Location = new System.Drawing.Point(12, 96);
            this.txtLname.Name = "txtLname";
            this.txtLname.PreventEnterBeep = true;
            this.txtLname.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLname.Size = new System.Drawing.Size(239, 22);
            this.txtLname.TabIndex = 8;
            this.txtLname.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtLname.WatermarkText = "الزامی...";
            // 
            // txtFname
            // 
            this.txtFname.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtFname.Border.Class = "TextBoxBorder";
            this.txtFname.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFname.DisabledBackColor = System.Drawing.Color.White;
            this.txtFname.ForeColor = System.Drawing.Color.Black;
            this.txtFname.Location = new System.Drawing.Point(12, 124);
            this.txtFname.Name = "txtFname";
            this.txtFname.PreventEnterBeep = true;
            this.txtFname.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFname.Size = new System.Drawing.Size(239, 22);
            this.txtFname.TabIndex = 8;
            this.txtFname.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtFname.WatermarkText = "الزامی...";
            // 
            // cmbSchools
            // 
            this.cmbSchools.DataSource = this.BnsSchools;
            this.cmbSchools.DisplayMember = "Name";
            this.cmbSchools.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSchools.FormattingEnabled = true;
            this.cmbSchools.Location = new System.Drawing.Point(12, 153);
            this.cmbSchools.Name = "cmbSchools";
            this.cmbSchools.Size = new System.Drawing.Size(239, 22);
            this.cmbSchools.TabIndex = 11;
            this.cmbSchools.ValueMember = "id";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(257, 69);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 12;
            this.labelX2.Text = ":نام";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(257, 96);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 12;
            this.labelX3.Text = ":نام خانوادگی";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(257, 124);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 12;
            this.labelX4.Text = ":نام پدر";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(257, 41);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(75, 23);
            this.labelX5.TabIndex = 12;
            this.labelX5.Text = ":کد ملی";
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(257, 153);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(75, 23);
            this.labelX6.TabIndex = 12;
            this.labelX6.Text = ":مدرسه";
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(257, 179);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(75, 23);
            this.labelX7.TabIndex = 12;
            this.labelX7.Text = ":پایه تدریسی";
            // 
            // BnsSchools
            // 
            this.BnsSchools.DataSource = typeof(Karnameh.Models.tbl_Schools);
            // 
            // BnsPayeh
            // 
            this.BnsPayeh.DataSource = typeof(Karnameh.Models.tbl_Payeh);
            // 
            // Frm_Add_Teachers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 249);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.cmbSchools);
            this.Controls.Add(this.cmbPayeh);
            this.Controls.Add(this.buttonX4);
            this.Controls.Add(this.buttonX3);
            this.Controls.Add(this.txtFname);
            this.Controls.Add(this.txtLname);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCodeMelli);
            this.Controls.Add(this.txtPersonalCode);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Add_Teachers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "افزودن معلم";
            this.Load += new System.EventHandler(this.Frm_Add_Teachers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BnsSchools)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BnsPayeh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX buttonX4;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPersonalCode;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCodeMelli;
        private DevComponents.DotNetBar.Controls.TextBoxX txtName;
        private System.Windows.Forms.ComboBox cmbPayeh;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtLname;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFname;
        private System.Windows.Forms.ComboBox cmbSchools;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX7;
        private System.Windows.Forms.BindingSource BnsPayeh;
        private System.Windows.Forms.BindingSource BnsSchools;
    }
}