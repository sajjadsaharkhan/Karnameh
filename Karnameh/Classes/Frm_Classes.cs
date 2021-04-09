using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karnameh.Classes
{
    public partial class Frm_Classes : DevComponents.DotNetBar.Metro.MetroForm
    {
        Models.KarnameDBEntities db = new Models.KarnameDBEntities();
        public Frm_Classes()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
            try
            {
                List<Models.viw_Classes> Q = new List<Models.viw_Classes>();
                if (string.IsNullOrWhiteSpace(txtName.Text))
                    Q = (from a in db.viw_Classes where a.School_id_FK == Frm_Main.School_id select a).ToList();
                else
                    Q = (from a in db.viw_Classes where a.Name == txtName.Text && a.School_id_FK == Frm_Main.School_id select a).ToList();
                bindingSource1.DataSource = Q;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            try
            {
                long TeacherPersonal_id = long.Parse(cmbTeachers.SelectedValue.ToString());
                var Q = (from a in db.viw_Classes where a.Teachers_PersonalCode_FK == TeacherPersonal_id && a.School_id_FK == Frm_Main.School_id select a).ToList();
                bindingSource1.DataSource = Q;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_Classes_Load(object sender, EventArgs e)
        {
            try
            {
                var Q = (from a in db.viw_Classes where a.School_id_FK == Frm_Main.School_id select a).ToList();
                bindingSource1.DataSource = Q;
                var Q1 = (from a in db.viw_TeachersName where a.Schools_id_FK == Frm_Main.School_id select a).ToList();
                tblTeachersBindingSource.DataSource = Q1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_Add_Class.IsEdit = false;
                new Frm_Add_Class().ShowDialog(this);
                bindingSource1.DataSource = (from a in db.viw_Classes where a.School_id_FK == Frm_Main.School_id select a).ToList();
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
                if (dgvClasses.SelectedRows.Count == 1)
                {
                    long Class_id = long.Parse(dgvClasses.CurrentRow.Cells["idDataGridViewTextBoxColumn"].Value.ToString());
                    var Q = (from a in db.tbl_Classes where a.id == Class_id select a).FirstOrDefault();
                    db.tbl_Classes.Remove(Q);
                    db.SaveChanges();
                    MessageBox.Show("عملیات مورد نظر با موفقیت انجام شد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bindingSource1.DataSource = (from a in db.viw_Classes where a.School_id_FK == Frm_Main.School_id select a).ToList();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvClasses.SelectedRows.Count == 1)
                {
                    long Class_id = long.Parse(dgvClasses.CurrentRow.Cells["idDataGridViewTextBoxColumn"].Value.ToString());
                    Frm_Add_Class.Class_id = Class_id;
                    Frm_Add_Class.IsEdit = true;
                    new Frm_Add_Class().ShowDialog(this);
                    bindingSource1.DataSource = (from a in db.viw_Classes where a.School_id_FK == Frm_Main.School_id select a).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {
                Stimulsoft.Report.StiReport Sti = new Stimulsoft.Report.StiReport();
                Sti.Load(Application.StartupPath + "\\Reports\\rptClasses.mrt");
                Sti.Compile();
                Sti["lng_School_id"] = Frm_Main.School_id;
                Sti.ShowWithRibbonGUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            try
            {
                Stimulsoft.Report.StiReport Sti = new Stimulsoft.Report.StiReport();
                Sti.Load(Application.StartupPath + "\\Reports\\rptClasses.mrt");
                Sti.Compile();
                Sti["lng_School_id"] = Frm_Main.School_id;
                Sti.ShowWithRibbonGUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
