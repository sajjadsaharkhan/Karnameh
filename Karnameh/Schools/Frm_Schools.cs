using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karnameh.Schools
{
    public partial class Frm_Schools : DevComponents.DotNetBar.Metro.MetroForm
    {
        Models.KarnameDBEntities db = new Models.KarnameDBEntities();
        public Frm_Schools()
        {
            InitializeComponent();
        }

        private void Frm_Schools_Load(object sender, EventArgs e)
        {
            try
            {
                var Q = (from a in db.viw_Schools select a).ToList();
                BnsSchools.DataSource = Q;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void txtSearchManager_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var Q = (from a in db.viw_Schools select a).ToList();
                if (!string.IsNullOrWhiteSpace(txtSearchManager.Text))
                    Q = (from a in db.viw_Schools where a.ManagerFullName.Contains(txtSearchManager.Text) select a).ToList();
                BnsSchools.DataSource = Q;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void txtSearchSchoolName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var Q = (from a in db.viw_Schools select a).ToList();
                if (!string.IsNullOrWhiteSpace(txtSearchSchoolName.Text))
                    Q = (from a in db.viw_Schools where a.Name.Contains(txtSearchSchoolName.Text) select a).ToList();
                BnsSchools.DataSource = Q;
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
                    long Schools_id = long.Parse(dgv.CurrentRow.Cells["idDataGridViewTextBoxColumn"].Value.ToString());
                    var Q = (from a in db.tbl_Schools where a.id == Schools_id select a).FirstOrDefault();
                    db.tbl_Schools.Remove(Q);
                    db.SaveChanges();
                    MessageBox.Show("مدرسه مورد نظر با موفقیت حذف گردید", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var Q1 = (from a in db.viw_Schools select a).ToList();
                    BnsSchools.DataSource = Q1;
                }
                else
                    MessageBox.Show("لطفا یک مدرسه را انتخاب نمایید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv.RowCount > 0 && dgv.SelectedRows.Count == 1)
                {
                    long Schools_id = long.Parse(dgv.CurrentRow.Cells["idDataGridViewTextBoxColumn"].Value.ToString());
                    Frm_Add_Schools.ISEdit = true;
                    Frm_Add_Schools.SchoolsId = Schools_id;
                    new Frm_Add_Schools().ShowDialog(this);
                    db = new Models.KarnameDBEntities();
                    var Q1 = (from a in db.viw_Schools select a).ToList();
                    BnsSchools.DataSource = Q1;
                }
                else
                    MessageBox.Show("لطفا یک مدرسه را انتخاب نمایید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_Add_Schools.ISEdit = false;
                new Frm_Add_Schools().ShowDialog(this);
                var Q1 = (from a in db.viw_Schools select a).ToList();
                BnsSchools.DataSource = Q1;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {
                Stimulsoft.Report.StiReport Sti = new Stimulsoft.Report.StiReport();
                Sti.Load(Application.StartupPath + "\\Reports\\rptSchools.mrt");
                Sti.Compile();
                Sti.ShowWithRibbonGUI();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
