namespace Karnameh.Classes
{
    partial class Frm_Add_Class
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
            this.cmbTeachers = new System.Windows.Forms.ComboBox();
            this.buttonX4 = new DevComponents.DotNetBar.ButtonX();
            this.btnReturn = new DevComponents.DotNetBar.ButtonX();
            this.txtClassName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.cmbPayeh = new System.Windows.Forms.ComboBox();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtClassid = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.tblPayehBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.viwTeachersNameBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tblPayehBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viwTeachersNameBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbTeachers
            // 
            this.cmbTeachers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbTeachers.DataSource = this.viwTeachersNameBindingSource;
            this.cmbTeachers.DisplayMember = "FullName";
            this.cmbTeachers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTeachers.ForeColor = System.Drawing.Color.Black;
            this.cmbTeachers.FormattingEnabled = true;
            this.cmbTeachers.Location = new System.Drawing.Point(12, 68);
            this.cmbTeachers.Name = "cmbTeachers";
            this.cmbTeachers.Size = new System.Drawing.Size(221, 22);
            this.cmbTeachers.TabIndex = 1;
            this.cmbTeachers.ValueMember = "PersonalCode";
            // 
            // buttonX4
            // 
            this.buttonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX4.Image = global::Karnameh.Properties.Resources.Devices_media_floppy_icon;
            this.buttonX4.ImageTextSpacing = 5;
            this.buttonX4.Location = new System.Drawing.Point(199, 129);
            this.buttonX4.Name = "buttonX4";
            this.buttonX4.Size = new System.Drawing.Size(79, 23);
            this.buttonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX4.TabIndex = 10;
            this.buttonX4.Text = "ذخیره";
            this.buttonX4.Click += new System.EventHandler(this.buttonX4_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReturn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReturn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnReturn.Image = global::Karnameh.Properties.Resources.arrow_left_icon;
            this.btnReturn.ImageTextSpacing = 2;
            this.btnReturn.Location = new System.Drawing.Point(12, 129);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(79, 23);
            this.btnReturn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnReturn.TabIndex = 9;
            this.btnReturn.Text = "بازگشت";
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // txtClassName
            // 
            this.txtClassName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtClassName.Border.Class = "TextBoxBorder";
            this.txtClassName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtClassName.DisabledBackColor = System.Drawing.Color.White;
            this.txtClassName.ForeColor = System.Drawing.Color.Black;
            this.txtClassName.Location = new System.Drawing.Point(12, 40);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.PreventEnterBeep = true;
            this.txtClassName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtClassName.Size = new System.Drawing.Size(221, 22);
            this.txtClassName.TabIndex = 8;
            this.txtClassName.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtClassName.WatermarkText = "الزامی...";
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.ForeColor = System.Drawing.Color.Black;
            this.labelX1.Location = new System.Drawing.Point(239, 40);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 11;
            this.labelX1.Text = "نام کلاس";
            // 
            // cmbPayeh
            // 
            this.cmbPayeh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbPayeh.DataSource = this.tblPayehBindingSource;
            this.cmbPayeh.DisplayMember = "Name";
            this.cmbPayeh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPayeh.ForeColor = System.Drawing.Color.Black;
            this.cmbPayeh.FormattingEnabled = true;
            this.cmbPayeh.Location = new System.Drawing.Point(12, 96);
            this.cmbPayeh.Name = "cmbPayeh";
            this.cmbPayeh.Size = new System.Drawing.Size(221, 22);
            this.cmbPayeh.TabIndex = 12;
            this.cmbPayeh.ValueMember = "id";
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.ForeColor = System.Drawing.Color.Black;
            this.labelX2.Location = new System.Drawing.Point(239, 12);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 14;
            this.labelX2.Text = "شماره کلاس";
            // 
            // txtClassid
            // 
            this.txtClassid.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtClassid.Border.Class = "TextBoxBorder";
            this.txtClassid.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtClassid.DisabledBackColor = System.Drawing.Color.White;
            this.txtClassid.Enabled = false;
            this.txtClassid.ForeColor = System.Drawing.Color.Black;
            this.txtClassid.Location = new System.Drawing.Point(12, 12);
            this.txtClassid.Name = "txtClassid";
            this.txtClassid.PreventEnterBeep = true;
            this.txtClassid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtClassid.Size = new System.Drawing.Size(221, 22);
            this.txtClassid.TabIndex = 13;
            this.txtClassid.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.ForeColor = System.Drawing.Color.Black;
            this.labelX3.Location = new System.Drawing.Point(239, 68);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 11;
            this.labelX3.Text = "نام معلم";
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.ForeColor = System.Drawing.Color.Black;
            this.labelX4.Location = new System.Drawing.Point(239, 97);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 11;
            this.labelX4.Text = "پایه";
            // 
            // tblPayehBindingSource
            // 
            this.tblPayehBindingSource.DataSource = typeof(Karnameh.Models.tbl_Payeh);
            // 
            // viwTeachersNameBindingSource
            // 
            this.viwTeachersNameBindingSource.DataSource = typeof(Karnameh.Models.viw_TeachersName);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(Karnameh.Models.tbl_Classes);
            // 
            // Frm_Add_Class
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnReturn;
            this.ClientSize = new System.Drawing.Size(331, 163);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.txtClassid);
            this.Controls.Add(this.cmbPayeh);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.buttonX4);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.txtClassName);
            this.Controls.Add(this.cmbTeachers);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Add_Class";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "افزودن کلاس";
            this.Load += new System.EventHandler(this.Frm_Add_Class_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblPayehBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viwTeachersNameBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbTeachers;
        private DevComponents.DotNetBar.ButtonX buttonX4;
        private DevComponents.DotNetBar.ButtonX btnReturn;
        private DevComponents.DotNetBar.Controls.TextBoxX txtClassName;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.ComboBox cmbPayeh;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtClassid;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource viwTeachersNameBindingSource;
        private System.Windows.Forms.BindingSource tblPayehBindingSource;
    }
}