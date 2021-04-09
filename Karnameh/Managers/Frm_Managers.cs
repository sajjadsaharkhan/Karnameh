using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karnameh.Managers
{
    public partial class Frm_Managers : DevComponents.DotNetBar.Metro.MetroForm
    {
        Models.KarnameDBEntities db = new Models.KarnameDBEntities();
        public Frm_Managers()
        {
            InitializeComponent();
        }

        private void Frm_Managers_Load(object sender, EventArgs e)
        {
            try
            {
                var Q = (from a in db.tbl_Managers select a).ToList();
                BnsManagers.DataSource = Q;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void txtSearchManagers_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var Q = (from a in db.tbl_Managers select a).ToList();
                if (!string.IsNullOrWhiteSpace(txtSearchManagers.Text))
                    Q = (from a in db.tbl_Managers where (a.Name + " " + a.Lname).Contains(txtSearchManagers.Text) select a).ToList();
                BnsManagers.DataSource = Q;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv.RowCount > 0 && dgv.SelectedRows.Count == 1)
                {
                    long PersonalCode = long.Parse(dgv.CurrentRow.Cells["personalCodeDataGridViewTextBoxColumn"].Value.ToString());
                    var Q1 = (from a in db.tbl_Managers where a.PersonalCode == PersonalCode select a).FirstOrDefault();
                    db.tbl_Managers.Remove(Q1);
                    db.SaveChanges();
                    MessageBox.Show("مدیر مورد نظر با موفقیت حذف شد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var Q = (from a in db.tbl_Managers select a).ToList();
                    BnsManagers.DataSource = Q;
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
                    Frm_Add_Managers.IsEdit = true;
                    Frm_Add_Managers.PersonalCode = PersonalCode;
                    new Frm_Add_Managers().ShowDialog(this);
                    db = new Models.KarnameDBEntities();
                    var Q = (from a in db.tbl_Managers select a).ToList();
                    BnsManagers.DataSource = Q;
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
                Frm_Add_Managers.IsEdit = false;
                new Frm_Add_Managers().ShowDialog(this);
                var Q = (from a in db.tbl_Managers select a).ToList();
                BnsManagers.DataSource = Q;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {
                Stimulsoft.Report.StiReport Sti = new Stimulsoft.Report.StiReport();
                Sti.Load(Application.StartupPath + "\\Reports\\rptManagers.mrt");
                Sti.Compile();
                Sti.ShowWithRibbonGUI();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
