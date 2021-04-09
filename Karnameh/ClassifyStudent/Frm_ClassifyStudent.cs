using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karnameh.ClassifyStudent
{
    public partial class Frm_ClassifyStudent : DevComponents.DotNetBar.Metro.MetroForm
    {
        Models.KarnameDBEntities db = new Models.KarnameDBEntities();
        public Frm_ClassifyStudent()
        {
            InitializeComponent();
        }

        private void Frm_ClassifyStudent_Load(object sender, EventArgs e)
        {
            try
            {
                var Q = (from a in db.viw_Classes where a.School_id_FK == Frm_Main.School_id select a).ToList();
                var Q1 = (from a in db.tbl_Payeh select a).ToList();
                viwClassesBindingSource.DataSource = Q;
                tblPayehBindingSource.DataSource = Q1;
                if (cmbPayeh.Items.Count > 0)
                    cmbPayeh.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTeacherName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var Q = (from a in db.viw_Classes where a.School_id_FK == Frm_Main.School_id select a).ToList();
                if (!string.IsNullOrWhiteSpace(txtTeacherName.Text))
                    Q = (from a in db.viw_Classes where a.TeachersName.Contains(txtTeacherName.Text) && a.School_id_FK == Frm_Main.School_id select a).ToList();
                viwClassesBindingSource.DataSource = Q;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbPayeh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var Q = (from a in db.viw_Classes where a.PayehName == cmbPayeh.Text && a.School_id_FK == Frm_Main.School_id select a).ToList();
                viwClassesBindingSource.DataSource = Q;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void کلاسبندیToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv1.RowCount > 0 && dgv1.SelectedRows.Count == 1)
                {
                    Frm_ClassifyStudent_Action.Classid = Convert.ToInt32(dgv1.CurrentRow.Cells["idDataGridViewTextBoxColumn"].Value.ToString());
                    new Frm_ClassifyStudent_Action().ShowDialog(this);
                }
                else
                    MessageBox.Show("لطفا یک گزینه را انتخاب نمایید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void مشاهدهلیستدانشآموزانToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv1.RowCount > 0 && dgv1.SelectedRows.Count == 1)
                {
                    Frm_SttudentClaseesList.Classid = Convert.ToInt32(dgv1.CurrentRow.Cells["idDataGridViewTextBoxColumn"].Value.ToString());
                    new Frm_SttudentClaseesList().ShowDialog(this);
                }
                else
                    MessageBox.Show("لطفا یک گزینه را انتخاب نمایید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
