namespace Karnameh.Payeh
{
    partial class Frm_Add_Payeh
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
            this.buttonX4 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.txtId = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.ChkMark = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cmbTosifAmalkard = new System.Windows.Forms.ComboBox();
            this.tblTosifAmalkardBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BnsPayeh = new System.Windows.Forms.BindingSource(this.components);
            this.chkStatus = new DevComponents.DotNetBar.Controls.CheckBoxX();
            ((System.ComponentModel.ISupportInitialize)(this.tblTosifAmalkardBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BnsPayeh)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonX4
            // 
            this.buttonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX4.Image = global::Karnameh.Properties.Resources.Devices_media_floppy_icon;
            this.buttonX4.ImageTextSpacing = 5;
            this.buttonX4.Location = new System.Drawing.Point(202, 132);
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
            this.buttonX3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX3.Image = global::Karnameh.Properties.Resources.arrow_left_icon;
            this.buttonX3.ImageTextSpacing = 2;
            this.buttonX3.Location = new System.Drawing.Point(34, 132);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(79, 23);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.TabIndex = 9;
            this.buttonX3.Text = "بازگشت";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
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
            this.txtId.Size = new System.Drawing.Size(216, 22);
            this.txtId.TabIndex = 8;
            this.txtId.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtId.WatermarkText = "الزامی...";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(234, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(64, 23);
            this.labelX1.TabIndex = 11;
            this.labelX1.Text = ":شماره";
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
            this.txtName.Location = new System.Drawing.Point(12, 41);
            this.txtName.Name = "txtName";
            this.txtName.PreventEnterBeep = true;
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtName.Size = new System.Drawing.Size(216, 22);
            this.txtName.TabIndex = 8;
            this.txtName.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtName.WatermarkText = "الزامی...";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(234, 41);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(64, 23);
            this.labelX2.TabIndex = 11;
            this.labelX2.Text = ":نام پایه";
            // 
            // ChkMark
            // 
            // 
            // 
            // 
            this.ChkMark.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ChkMark.Location = new System.Drawing.Point(204, 68);
            this.ChkMark.Name = "ChkMark";
            this.ChkMark.Size = new System.Drawing.Size(126, 23);
            this.ChkMark.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ChkMark.TabIndex = 12;
            this.ChkMark.Text = "    :وضعیت ارزیابی";
            this.ChkMark.CheckedChanged += new System.EventHandler(this.checkBoxX1_CheckedChanged);
            // 
            // cmbTosifAmalkard
            // 
            this.cmbTosifAmalkard.DataSource = this.tblTosifAmalkardBindingSource;
            this.cmbTosifAmalkard.DisplayMember = "Name";
            this.cmbTosifAmalkard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTosifAmalkard.FormattingEnabled = true;
            this.cmbTosifAmalkard.Location = new System.Drawing.Point(12, 68);
            this.cmbTosifAmalkard.Name = "cmbTosifAmalkard";
            this.cmbTosifAmalkard.Size = new System.Drawing.Size(186, 22);
            this.cmbTosifAmalkard.TabIndex = 13;
            this.cmbTosifAmalkard.ValueMember = "id";
            // 
            // tblTosifAmalkardBindingSource
            // 
            this.tblTosifAmalkardBindingSource.DataSource = typeof(Karnameh.Models.tbl_TosifAmalkard);
            // 
            // BnsPayeh
            // 
            this.BnsPayeh.DataSource = typeof(Karnameh.Models.tbl_Payeh);
            // 
            // chkStatus
            // 
            // 
            // 
            // 
            this.chkStatus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkStatus.Checked = true;
            this.chkStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStatus.CheckValue = "Y";
            this.chkStatus.Location = new System.Drawing.Point(219, 97);
            this.chkStatus.Name = "chkStatus";
            this.chkStatus.Size = new System.Drawing.Size(62, 23);
            this.chkStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkStatus.TabIndex = 14;
            this.chkStatus.Text = ":وضعیت ";
            // 
            // Frm_Add_Payeh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 167);
            this.Controls.Add(this.chkStatus);
            this.Controls.Add(this.cmbTosifAmalkard);
            this.Controls.Add(this.ChkMark);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.buttonX4);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.buttonX3);
            this.Controls.Add(this.txtId);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Add_Payeh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "افزودن پایه";
            this.Load += new System.EventHandler(this.Frm_Add_Payeh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblTosifAmalkardBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BnsPayeh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX buttonX4;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtId;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtName;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.CheckBoxX ChkMark;
        private System.Windows.Forms.ComboBox cmbTosifAmalkard;
        private System.Windows.Forms.BindingSource BnsPayeh;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkStatus;
        private System.Windows.Forms.BindingSource tblTosifAmalkardBindingSource;
    }
}