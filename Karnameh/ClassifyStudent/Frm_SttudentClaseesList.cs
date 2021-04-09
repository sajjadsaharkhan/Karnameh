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
    public partial class Frm_SttudentClaseesList : DevComponents.DotNetBar.Metro.MetroForm
    {
        public static long Classid = 0;
        Models.KarnameDBEntities db = new Models.KarnameDBEntities();
        public Frm_SttudentClaseesList()
        {
            InitializeComponent();
        }

        private void Frm_SttudentClaseesList_Load(object sender, EventArgs e)
        {
            try
            {
                var Q = (from a in db.tbl_Years orderby a.id descending select a).FirstOrDefault();
                int YearsId = 0;
                if (Q != null)
                    YearsId = Q.id;
                var Q1 = (from a in db.tbl_StudentClasses where a.Class_id_FK == Classid && a.Years_id_K == YearsId select a);
                if (Q1 != null && Q1.Count() > 0)
                {
                    List<Models.tbl_Students> ListStudent = new List<Models.tbl_Students>();
                    foreach (var item in Q1.ToList())
                        ListStudent.Add(item.tbl_Students);
                    tblStudentsBindingSource.DataSource = ListStudent;
                }
                else
                {
                    MessageBox.Show("این کلاس هنوز کلاسبندی نشده است", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
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
                var Q = (from a in db.tbl_Students where a.Schools_id_FK == Frm_Main.School_id && a.Class_id_FK == Classid select a).ToList();
                if (!string.IsNullOrWhiteSpace(txtTeacherName.Text))
                    Q = (from a in db.tbl_Students where (a.Name + " " + a.Lname).Contains(txtTeacherName.Text) && a.Schools_id_FK == Frm_Main.School_id && a.Class_id_FK == Classid select a).ToList();
                tblStudentsBindingSource.DataSource = Q;
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
                var Q = (from a in db.tbl_Years orderby a.id descending select a).FirstOrDefault();
                int YearsId = 0;
                if (Q != null)
                    YearsId = Q.id;
                Stimulsoft.Report.StiReport Sti = new Stimulsoft.Report.StiReport();
                Sti.Load(Application.StartupPath + "\\Reports\\rptStudentClasses.mrt");
                Sti.Compile();
                Sti["int_Yearsid"] = YearsId;
                Sti["lng_Classid"] = Classid;
                Sti.ShowWithRibbonGUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void نوبتاولToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv1.RowCount > 0 && dgv1.SelectedRows.Count == 1)
                {
                    string Student_id = dgv1.CurrentRow.Cells["codeMelliDataGridViewTextBoxColumn"].Value.ToString();
                    int Years_id_FK = (from a in db.tbl_Years orderby a.id descending select a).FirstOrDefault().id;
                    var Q = (from a in db.tbl_Karnameh where a.Student_id_FK == Student_id && a.Nobat == 1 && a.Years_id_FK == Years_id_FK select a).FirstOrDefault();
                    if (Q != null)
                    {
                        int? TosifAmalkard = (from a in db.tbl_Classes where a.id == Classid select a).FirstOrDefault().tbl_Payeh.TosifAmalkard_id_FK;
                        Stimulsoft.Report.StiReport Sti = new Stimulsoft.Report.StiReport();
                        if (TosifAmalkard != null)
                        {
                            Sti.Load(Application.StartupPath + "\\Reports\\rptNobat1TosifKarnameh.mrt");
                            Sti.Compile();
                            Sti["str_Student_id"] = Student_id;
                            Sti["lng_Karnameh_id"] = Q.id;
                            Sti.ShowWithRibbonGUI();
                        }
                        else
                        {
                            Sti.Load(Application.StartupPath + "\\Reports\\rptNobat1MarkKarnameh.mrt");
                            Sti.Compile();
                            Sti["str_Student_id"] = Student_id;
                            Sti["lng_Karnameh_id_1"] = Q.id;
                            Sti.ShowWithRibbonGUI();
                        }
                    }
                    else
                        MessageBox.Show("کارنامه نوبت اول ثبت نهایی نشده است", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("لطفا یک سطر را انتخاب نمایید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void نوبتدومToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv1.RowCount > 0 && dgv1.SelectedRows.Count == 1)
                {
                    string Student_id = dgv1.CurrentRow.Cells["codeMelliDataGridViewTextBoxColumn"].Value.ToString();
                    int Years_id_FK = (from a in db.tbl_Years orderby a.id descending select a).FirstOrDefault().id;
                    var N2 = (from a in db.tbl_Karnameh where a.Student_id_FK == Student_id && a.Nobat == 2 && a.Years_id_FK == Years_id_FK select a).FirstOrDefault();
                    var N1 = (from a in db.tbl_Karnameh where a.Student_id_FK == Student_id && a.Nobat == 1 && a.Years_id_FK == Years_id_FK select a).FirstOrDefault();
                    if (N2 != null)
                    {
                        int? TosifAmalkard = (from a in db.tbl_Classes where a.id == Classid select a).FirstOrDefault().tbl_Payeh.TosifAmalkard_id_FK;
                        Stimulsoft.Report.StiReport Sti = new Stimulsoft.Report.StiReport();
                        if (TosifAmalkard != null)
                        {
                            Sti.Load(Application.StartupPath + "\\Reports\\rptNobat2TosifKarnameh.mrt");
                            Sti.Compile();
                            Sti["str_Student_id"] = Student_id;
                            Sti["lng_Karnameh_id_1"] = N1.id;
                            Sti["lng_Karnameh_id_2"] = N2.id;
                            Sti.ShowWithRibbonGUI();
                        }
                        else
                        {
                            Sti.Load(Application.StartupPath + "\\Reports\\rptNobat2MarkKarnameh.mrt");
                            Sti.Compile();
                            Sti["str_Student_id"] = Student_id;
                            Sti["lng_Karnameh_id_1"] = N1.id;
                            Sti["lng_Karnameh_id_2"] = N2.id;
                            Sti.ShowWithRibbonGUI();
                        }
                    }
                    else
                        MessageBox.Show("کارنامه نوبت دوم ثبت نهایی نشده است", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("لطفا یک سطر را انتخاب نمایید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
