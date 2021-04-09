using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karnameh.Lessons
{
    public partial class Frm_Lessons : DevComponents.DotNetBar.Metro.MetroForm
    {
        Models.KarnameDBEntities db = new Models.KarnameDBEntities();
        public Frm_Lessons()
        {
            InitializeComponent();
        }

        private void Frm_Lessons_Load(object sender, EventArgs e)
        {
            try
            {
                var Q = (from a in db.viw_Lessons select a).ToList();
                var Q1 = (from a in db.tbl_Payeh select a).ToList();
                tblPayehBindingSource.DataSource = Q1;
                BnsLessons.DataSource = Q;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int Payeh_id = int.Parse(comboBox1.SelectedValue.ToString());
                var Q = (from a in db.viw_Lessons where a.Payeh_id_FK == Payeh_id select a).ToList();
                BnsLessons.DataSource = Q;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var Q = (from a in db.viw_Lessons select a).ToList();
                if (!string.IsNullOrWhiteSpace(textBoxX1.Text))
                    Q = (from a in db.viw_Lessons where a.Name.Contains(textBoxX1.Text) select a).ToList();
                BnsLessons.DataSource = Q;
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
                    int id = int.Parse(dgv.CurrentRow.Cells["idDataGridViewTextBoxColumn"].Value.ToString());
                    var Q = (from a in db.tbl_Lessons where a.id == id select a).FirstOrDefault();
                    db.tbl_Lessons.Remove(Q);
                    db.SaveChanges();
                    var Q1 = (from a in db.viw_Lessons select a).ToList();
                    BnsLessons.DataSource = Q1;
                    MessageBox.Show("درس مورد نظر با موفقیت حذف شد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv.RowCount > 0 && dgv.SelectedRows.Count == 1)
                {
                    int id = int.Parse(dgv.CurrentRow.Cells["idDataGridViewTextBoxColumn"].Value.ToString());
                    Frm_Add_Lessons.IsEdit = true;
                    Frm_Add_Lessons.Id = id;
                    new Frm_Add_Lessons().ShowDialog(this);
                    db = new Models.KarnameDBEntities();
                    var Q1 = (from a in db.viw_Lessons select a).ToList();
                    BnsLessons.DataSource = Q1;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_Add_Lessons.IsEdit = false;
                new Frm_Add_Lessons().ShowDialog(this);
                var Q1 = (from a in db.viw_Lessons select a).ToList();
                BnsLessons.DataSource = Q1;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
