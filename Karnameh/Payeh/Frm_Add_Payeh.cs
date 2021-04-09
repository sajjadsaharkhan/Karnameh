using Karnameh.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karnameh.Payeh
{
    public partial class Frm_Add_Payeh : DevComponents.DotNetBar.Metro.MetroForm
    {
        public static bool IsEdit = false;
        public static int Id = 0;
        Models.KarnameDBEntities db = new Models.KarnameDBEntities();
        public Frm_Add_Payeh()
        {
            InitializeComponent();
        }

        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            cmbTosifAmalkard.Enabled = !ChkMark.Checked;
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtName.Text))
                {
                    if (IsEdit)
                    {
                        var Q = (from a in db.tbl_Payeh where a.id == Id select a).FirstOrDefault();
                        Q.Status = chkStatus.Checked;
                        Q.Name = txtName.Text;
                        if (ChkMark.Checked)
                            Q.TosifAmalkard_id_FK = null;
                        else
                            Q.TosifAmalkard_id_FK = int.Parse(cmbTosifAmalkard.SelectedValue.ToString());
                        db.Entry(Q).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        int? TosifAmalkard;
                        if (ChkMark.Checked)
                            TosifAmalkard = null;
                        else
                            TosifAmalkard = int.Parse(cmbTosifAmalkard.SelectedValue.ToString());
                        db.InseertPayeh(int.Parse(txtId.Text), txtName.Text, chkStatus.Checked, TosifAmalkard);
                    }
                    MessageBox.Show("عملیات مورد نظر با موفقیت انجام شد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    MessageBox.Show("لطفا اطلاعات درخواستی را کامل نمایید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Frm_Add_Payeh_Load(object sender, EventArgs e)
        {
            try
            {
                var Q1 = (from a in db.tbl_TosifAmalkard select a).ToList();
                tblTosifAmalkardBindingSource.DataSource = Q1;
                if (cmbTosifAmalkard.Items.Count > 0)
                    cmbTosifAmalkard.SelectedIndex = 0;
                if (IsEdit)
                {
                    this.txtId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BnsPayeh, "id", true));
                    this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BnsPayeh, "Name", true));
                    this.chkStatus.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.BnsPayeh, "Status", true));
                    var Q = (from a in db.tbl_Payeh where a.id == Id select a).FirstOrDefault();
                    if (Q.TosifAmalkard_id_FK != null)
                    {
                        cmbTosifAmalkard.SelectedValue = Q.TosifAmalkard_id_FK;
                        ChkMark.Checked = false;
                    }
                    else
                        ChkMark.Checked = true;
                    BnsPayeh.DataSource = Q;
                    this.Text = "ویرایش پایه";
                }
                else
                {
                    this.Text = "افزودن پایه";
                    var Q = (from a in db.tbl_Payeh orderby a.id descending select a).FirstOrDefault();
                    if (Q == null)
                        txtId.Text = "1";
                    else
                        txtId.Text = Convert.ToString(++Q.id);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
