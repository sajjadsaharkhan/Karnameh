using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karnameh.Moavenin
{
    public partial class Frm_Moavenin : DevComponents.DotNetBar.Metro.MetroForm
    {
        Models.KarnameDBEntities db = new Models.KarnameDBEntities();
        public Frm_Moavenin()
        {
            InitializeComponent();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_Moavenin_Load(object sender, EventArgs e)
        {
            try
            {
                var Q = (from a in db.tbl_MoaveninEjraei select a).ToList();
                BnsMoavenin.DataSource = Q;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void txtSearchCodeMelli_TextChanged(object sender, EventArgs e)
        {
            try
            {
                long b;
                var Q = (from a in db.tbl_MoaveninEjraei select a).ToList();
                if (long.TryParse(txtSearchPersonalCode.Text, out b))
                    Q = (from a in db.tbl_MoaveninEjraei where a.PersonalCode == b select a).ToList();
                BnsMoavenin.DataSource = Q;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var Q = (from a in db.tbl_MoaveninEjraei select a).ToList();
                if (!string.IsNullOrWhiteSpace(txtSearchName.Text))
                    Q = (from a in db.tbl_MoaveninEjraei where (a.Name + " " + a.Lname).Contains(txtSearchName.Text) select a).ToList();
                BnsMoavenin.DataSource = Q;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv.RowCount > 0 && dgv.SelectedRows.Count == 1)
                {
                    long PersonalCode = long.Parse(dgv.CurrentRow.Cells["personalCodeDataGridViewTextBoxColumn"].Value.ToString());
                    var Q = (from a in db.tbl_MoaveninEjraei where a.PersonalCode == PersonalCode select a).FirstOrDefault();
                    db.tbl_MoaveninEjraei.Remove(Q);
                    db.SaveChanges();
                    MessageBox.Show("معاون اجرایی مورد نظر باموفقیت حذف گردید", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var Q1 = (from a in db.tbl_MoaveninEjraei select a).ToList();
                    BnsMoavenin.DataSource = Q1;
                }
                else
                    MessageBox.Show("لطفا یک مورد را انتخاب نمایید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv.RowCount > 0 && dgv.SelectedRows.Count == 1)
                {
                    long PersonalCode = long.Parse(dgv.CurrentRow.Cells["personalCodeDataGridViewTextBoxColumn"].Value.ToString());
                    Frm_Add_Movavenin.IsEdit = true;
                    Frm_Add_Movavenin.PersonalCode = PersonalCode;
                    new Frm_Add_Movavenin().ShowDialog(this);
                    db = new Models.KarnameDBEntities();
                    var Q = (from a in db.tbl_MoaveninEjraei select a).ToList();
                    BnsMoavenin.DataSource = Q;
                }
                else
                    MessageBox.Show("لطفا یک مورد را انتخاب نمایید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_Add_Movavenin.IsEdit = false;
                new Frm_Add_Movavenin().ShowDialog(this);
                var Q = (from a in db.tbl_MoaveninEjraei select a).ToList();
                BnsMoavenin.DataSource = Q;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {
                Stimulsoft.Report.StiReport Sti = new Stimulsoft.Report.StiReport();
                Sti.Load(Application.StartupPath + "\\Reports\\rptMoavenEjraei.mrt");
                Sti.Compile();
                Sti.ShowWithRibbonGUI();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
