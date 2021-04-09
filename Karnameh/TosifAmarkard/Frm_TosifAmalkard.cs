using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karnameh.TosifAmarkard
{
    public partial class Frm_TosifAmalkard : DevComponents.DotNetBar.Metro.MetroForm
    {
        Models.KarnameDBEntities db = new Models.KarnameDBEntities();
        public Frm_TosifAmalkard()
        {
            InitializeComponent();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_TosifAmalkard_Load(object sender, EventArgs e)
        {
            try
            {
                var Q = (from a in db.tbl_TosifAmalkard select a).ToList();
                BnsTosifAmarkard.DataSource = Q;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv.RowCount > 0 && dgv.SelectedRows.Count == 1)
                {
                    int TosifAmalkard_id = int.Parse(dgv.CurrentRow.Cells["idDataGridViewTextBoxColumn"].Value.ToString());
                    var Q = (from a in db.tbl_TosifAmalkard where a.id == TosifAmalkard_id select a).FirstOrDefault();
                    db.tbl_TosifAmalkard.Remove(Q);
                    db.SaveChanges();
                    MessageBox.Show("توصیف عملکرد مورد نظر با موفقیت حذف شد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var Q1 = (from a in db.tbl_TosifAmalkard select a).ToList();
                    BnsTosifAmarkard.DataSource = Q1;
                }
                else
                    MessageBox.Show("لطف یک مورد را انتخاب نمایید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv.RowCount > 0 && dgv.SelectedRows.Count == 1)
                {
                    int TosifAmalkard_id = int.Parse(dgv.CurrentRow.Cells["idDataGridViewTextBoxColumn"].Value.ToString());
                    Frm_Add_TosifAmalkard.IsEdit = true;
                    Frm_Add_TosifAmalkard.id = TosifAmalkard_id;
                    new Frm_Add_TosifAmalkard().ShowDialog(this);
                    db = new Models.KarnameDBEntities();
                    var Q1 = (from a in db.tbl_TosifAmalkard select a).ToList();
                    BnsTosifAmarkard.DataSource = Q1;
                }
                else
                    MessageBox.Show("لطف یک مورد را انتخاب نمایید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_Add_TosifAmalkard.IsEdit = false;
                new Frm_Add_TosifAmalkard().ShowDialog(this);
                var Q1 = (from a in db.tbl_TosifAmalkard select a).ToList();
                BnsTosifAmarkard.DataSource = Q1;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
