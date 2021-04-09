using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karnameh.Years
{
    public partial class Frm_Years : DevComponents.DotNetBar.Metro.MetroForm
    {
        Models.KarnameDBEntities db = new Models.KarnameDBEntities();
        public Frm_Years()
        {
            InitializeComponent();
        }

        private void Frm_Years_Load(object sender, EventArgs e)
        {
            try
            {
                var Q = (from a in db.tbl_Years orderby a.id descending select a).ToList();
                BnsYears.DataSource = Q;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Frm_Add_Years.IsEdit = false;
            new Frm_Add_Years().ShowDialog(this);
            var Q = (from a in db.tbl_Years orderby a.id descending select a).ToList();
            BnsYears.DataSource = Q;
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
                    int id = int.Parse(dgv.CurrentRow.Cells["idDataGridViewTextBoxColumn"].Value.ToString());
                    var Q = (from a in db.tbl_Years where a.id == id select a).FirstOrDefault();
                    db.tbl_Years.Remove(Q);
                    db.SaveChanges();
                    var Q1 = (from a in db.tbl_Years orderby a.id descending select a).ToList();
                    BnsYears.DataSource = Q1;
                    MessageBox.Show("سال تحصیلی مورد نظر با موفقیت حذف شد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("لطفا یک مورد را انتخاب نمایید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv.RowCount > 0 && dgv.SelectedRows.Count == 1)
            {
                int id = int.Parse(dgv.CurrentRow.Cells["idDataGridViewTextBoxColumn"].Value.ToString());
                Frm_Add_Years.IsEdit = true;
                Frm_Add_Years.ID = id;
                new Frm_Add_Years().ShowDialog(this);
                Models.KarnameDBEntities db1 = new Models.KarnameDBEntities();
                var Q = (from a in db1.tbl_Years orderby a.id descending select a).ToList();
                BnsYears.DataSource = Q;
            }
            else
                MessageBox.Show("لطفا یک مورد را انتخاب نمایید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
