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
    public partial class Frm_Payeh : DevComponents.DotNetBar.Metro.MetroForm
    {
        Models.KarnameDBEntities db = new Models.KarnameDBEntities();
        public Frm_Payeh()
        {
            InitializeComponent();
        }

        private void Frm_Payeh_Load(object sender, EventArgs e)
        {
            try
            {
                var Q = (from a in db.tbl_Payeh select a).ToList();
                BnsPayeh.DataSource = Q;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_Add_Payeh.IsEdit = false;
                new Frm_Add_Payeh().ShowDialog(this);
                var Q = (from a in db.tbl_Payeh select a).ToList();
                BnsPayeh.DataSource = Q;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv.SelectedRows.Count == 1 && dgv.RowCount > 0)
                {
                    int id = int.Parse(dgv.CurrentRow.Cells["idDataGridViewTextBoxColumn"].Value.ToString());
                    var Q = (from a in db.tbl_Payeh where a.id == id select a).FirstOrDefault();
                    db.tbl_Payeh.Remove(Q);
                    db.SaveChanges();
                    var Q1 = (from a in db.tbl_Payeh select a).ToList();
                    BnsPayeh.DataSource = Q1;
                    MessageBox.Show("عملیات مورد نظر با موفقیت انجام شد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("لطفا یک مورد را انتخاب نمایید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv.SelectedRows.Count == 1 && dgv.RowCount > 0)
                {
                    int id = int.Parse(dgv.CurrentRow.Cells["idDataGridViewTextBoxColumn"].Value.ToString());
                    Frm_Add_Payeh.IsEdit = true;
                    Frm_Add_Payeh.Id = id;
                    new Frm_Add_Payeh().ShowDialog(this);
                    Models.KarnameDBEntities db1 = new Models.KarnameDBEntities();
                    var Q = (from a in db1.tbl_Payeh select a).ToList();
                    BnsPayeh.DataSource = Q;
                }
                else
                    MessageBox.Show("لطفا یک مورد را انتخاب نمایید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
