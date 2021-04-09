using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karnameh.Teachers
{
    public partial class Frm_Teachers : DevComponents.DotNetBar.Metro.MetroForm
    {
        Models.KarnameDBEntities db = new Models.KarnameDBEntities();
        public Frm_Teachers()
        {
            InitializeComponent();
        }

        private void Frm_Teachers_Load(object sender, EventArgs e)
        {
            try
            {
                var Q = (from a in db.viw_Teachers select a).ToList();
                BnsTeachers.DataSource = Q;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var Q = (from a in db.viw_Teachers select a).ToList();
                if (!string.IsNullOrWhiteSpace(txtSearchName.Text))
                    Q = (from a in db.viw_Teachers where (a.Name + " " + a.Lname).Contains(txtSearchName.Text) select a).ToList();
                BnsTeachers.DataSource = Q;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void txtPersonalCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var Q = (from a in db.viw_Teachers select a).ToList();
                if (!string.IsNullOrWhiteSpace(txtPersonalCode.Text))
                    Q = (from a in db.viw_Teachers where a.PersonalCode.ToString().Contains(txtPersonalCode.Text) select a).ToList();
                BnsTeachers.DataSource = Q;
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
                    var Q = (from a in db.tbl_Teachers where a.PersonalCode == PersonalCode select a).FirstOrDefault();
                    db.tbl_Teachers.Remove(Q);
                    db.SaveChanges();
                    MessageBox.Show("معلم موردنظر با موفقیت حذف شد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var Q1 = (from a in db.viw_Teachers select a).ToList();
                    BnsTeachers.DataSource = Q1;
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
                    Frm_Add_Teachers.IsEdit = true;
                    Frm_Add_Teachers.PersonalCode = PersonalCode;
                    new Frm_Add_Teachers().ShowDialog(this);
                    db = new Models.KarnameDBEntities();
                    var Q1 = (from a in db.viw_Teachers select a).ToList();
                    BnsTeachers.DataSource = Q1;
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
                Frm_Add_Teachers.IsEdit = false;
                new Frm_Add_Teachers().ShowDialog(this);
                var Q1 = (from a in db.viw_Teachers select a).ToList();
                BnsTeachers.DataSource = Q1;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {
                Stimulsoft.Report.StiReport Sti = new Stimulsoft.Report.StiReport();
                Sti.Load(Application.StartupPath + "\\Reports\\rptTeachers.mrt");
                Sti.Compile();
                Sti.ShowWithRibbonGUI();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
