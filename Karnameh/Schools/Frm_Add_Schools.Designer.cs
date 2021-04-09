namespace Karnameh.Schools
{
    partial class Frm_Add_Schools
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
            this.txtId = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonX4 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.txtName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cmbManagers = new System.Windows.Forms.ComboBox();
            this.viwManagersSchoolsLessBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbMoavenEjraei = new System.Windows.Forms.ComboBox();
            this.viwMovanenEjraeiSchoolsLessBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.BnsSchools = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.viwManagersSchoolsLessBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viwMovanenEjraeiSchoolsLessBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BnsSchools)).BeginInit();
            this.SuspendLayout();
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtId.Border.Class = "TextBoxBorder";
            this.txtId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtId.DisabledBackColor = System.Drawing.Color.White;
            this.txtId.ForeColor = System.Drawing.Color.Black;
            this.txtId.Location = new System.Drawing.Point(12, 12);
            this.txtId.Name = "txtId";
            this.txtId.PreventEnterBeep = true;
            this.txtId.ReadOnly = true;
            this.txtId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtId.Size = new System.Drawing.Size(253, 22);
            this.txtId.TabIndex = 8;
            this.txtId.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonX4
            // 
            this.buttonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX4.Image = global::Karnameh.Properties.Resources.Devices_media_floppy_icon;
            this.buttonX4.ImageTextSpacing = 5;
            this.buttonX4.Location = new System.Drawing.Point(271, 161);
            this.buttonX4.Name = "buttonX4";
            this.buttonX4.Size = new System.Drawing.Size(72, 23);
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
            this.buttonX3.Location = new System.Drawing.Point(12, 161);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(78, 23);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.TabIndex = 9;
            this.buttonX3.Text = "بازگشت";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
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
            this.txtName.Location = new System.Drawing.Point(12, 40);
            this.txtName.Name = "txtName";
            this.txtName.PreventEnterBeep = true;
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtName.Size = new System.Drawing.Size(253, 22);
            this.txtName.TabIndex = 8;
            this.txtName.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtName.WatermarkText = "الزامی...";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtPassword.Border.Class = "TextBoxBorder";
            this.txtPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPassword.DisabledBackColor = System.Drawing.Color.White;
            this.txtPassword.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.Location = new System.Drawing.Point(12, 68);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PreventEnterBeep = true;
            this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPassword.Size = new System.Drawing.Size(253, 22);
            this.txtPassword.TabIndex = 8;
            this.txtPassword.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtPassword.WatermarkText = "الزامی...";
            // 
            // cmbManagers
            // 
            this.cmbManagers.DataSource = this.viwManagersSchoolsLessBindingSource;
            this.cmbManagers.DisplayMember = "FullName";
            this.cmbManagers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbManagers.FormattingEnabled = true;
            this.cmbManagers.Location = new System.Drawing.Point(12, 96);
            this.cmbManagers.Name = "cmbManagers";
            this.cmbManagers.Size = new System.Drawing.Size(253, 22);
            this.cmbManagers.TabIndex = 11;
            this.cmbManagers.ValueMember = "PersonalCode";
            // 
            // viwManagersSchoolsLessBindingSource
            // 
            this.viwManagersSchoolsLessBindingSource.DataSource = typeof(Karnameh.Models.viw_Managers_SchoolsLess);
            // 
            // cmbMoavenEjraei
            // 
            this.cmbMoavenEjraei.DataSource = this.viwMovanenEjraeiSchoolsLessBindingSource;
            this.cmbMoavenEjraei.DisplayMember = "FullName";
            this.cmbMoavenEjraei.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMoavenEjraei.FormattingEnabled = true;
            this.cmbMoavenEjraei.Location = new System.Drawing.Point(12, 124);
            this.cmbMoavenEjraei.Name = "cmbMoavenEjraei";
            this.cmbMoavenEjraei.Size = new System.Drawing.Size(253, 22);
            this.cmbMoavenEjraei.TabIndex = 11;
            this.cmbMoavenEjraei.ValueMember = "PersonalCode";
            // 
            // viwMovanenEjraeiSchoolsLessBindingSource
            // 
            this.viwMovanenEjraeiSchoolsLessBindingSource.DataSource = typeof(Karnameh.Models.viw_MovanenEjraeiSchoolsLess);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(271, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 12;
            this.labelX1.Text = ":کد مدرسه";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(271, 37);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 12;
            this.labelX2.Text = ":نام مدرسه";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(271, 68);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(85, 23);
            this.labelX3.TabIndex = 12;
            this.labelX3.Text = ":رمز عبور مدرسه";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(271, 95);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 12;
            this.labelX4.Text = ":مدیر";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(271, 124);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(75, 23);
            this.labelX5.TabIndex = 12;
            this.labelX5.Text = ":معاون اجرایی";
            // 
            // BnsSchools
            // 
            this.BnsSchools.DataSource = typeof(Karnameh.Models.tbl_Schools);
            // 
            // Frm_Add_Schools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 196);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.cmbMoavenEjraei);
            this.Controls.Add(this.cmbManagers);
            this.Controls.Add(this.buttonX4);
            this.Controls.Add(this.buttonX3);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtId);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Add_Schools";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "افزودن مدرسه";
            this.Load += new System.EventHandler(this.Frm_Add_Schools_Load);
            ((System.ComponentModel.ISupportInitialize)(this.viwManagersSchoolsLessBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viwMovanenEjraeiSchoolsLessBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BnsSchools)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX buttonX4;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtId;
        private DevComponents.DotNetBar.Controls.TextBoxX txtName;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPassword;
        private System.Windows.Forms.ComboBox cmbManagers;
        private System.Windows.Forms.ComboBox cmbMoavenEjraei;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX5;
        private System.Windows.Forms.BindingSource viwManagersSchoolsLessBindingSource;
        private System.Windows.Forms.BindingSource viwMovanenEjraeiSchoolsLessBindingSource;
        private System.Windows.Forms.BindingSource BnsSchools;
    }
}