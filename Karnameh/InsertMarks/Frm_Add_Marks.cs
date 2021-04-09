using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karnameh.InsertMarks
{
    public partial class Frm_Add_Marks : DevComponents.DotNetBar.Metro.MetroForm
    {
        Models.KarnameDBEntities db = new Models.KarnameDBEntities();
        public static long Class_id = 0;
        public static List<Models.tbl_Karnameh> KarnamehList;
        int Payeh_id_FK = 0;
        int Years_id_FK = 0;
        bool IsAval = true;
        public Frm_Add_Marks()
        {
            InitializeComponent();
        }

        private void Frm_Add_Marks_Load(object sender, EventArgs e)
        {
            try
            {
                var Q = (from a in db.tbl_Classes where a.School_id_FK == Frm_Main.School_id && a.id == Class_id select a).FirstOrDefault();
                var Q1 = (from a in db.tbl_Lessons where a.Payeh_id_FK == Q.Payeh_id_FK select a).ToList();
                if (Q.tbl_Payeh.TosifAmalkard_id_FK != null)
                {
                    TosifAmalkard.Visible = true;
                    Mark.Visible = false;
                    tblTosifAmalkardBindingSource.DataSource = (from a in db.tbl_TosifAmalkard select a).ToList();
                }
                else
                {
                    TosifAmalkard.Visible = false;
                    Mark.Visible = true;
                }
                Payeh_id_FK = Q.Payeh_id_FK.Value;
                tblLessonsBindingSource.DataSource = Q1;
                /////////////////////////
                comboBox1.SelectedIndex = 0;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            try
            {
                bool IsEmpty = false;
                int g;
                for (int i = 0; i < dgv.RowCount; i++)
                    if (Mark.Visible)
                        if (!int.TryParse(dgv.Rows[i].Cells["Mark"].Value.ToString(), out g))
                            IsEmpty = true;
                        else
                            ;
                    else if (TosifAmalkard.Visible)
                        if (!int.TryParse(dgv.Rows[i].Cells["TosifAmalkard"].Value.ToString(), out g))
                            IsEmpty = true;
                if (!IsEmpty)
                {
                    for (int i = 0; i < dgv.RowCount; i++)
                    {
                        string CodeMelli = dgv.Rows[i].Cells["StudentCode"].Value.ToString();
                        int? Marks = null;
                        int? TosifAmalkards = null;
                        if (Mark.Visible)
                            Marks = int.Parse(dgv.Rows[i].Cells["Mark"].Value.ToString());
                        else
                            TosifAmalkards = int.Parse(dgv.Rows[i].Cells["TosifAmalkard"].Value.ToString());
                        Models.tbl_Marks Tbl = new Models.tbl_Marks()
                        {
                            Lesson_id_FK = int.Parse(comboBox1.SelectedValue.ToString()),
                            Mark = Marks.Value,
                            TosifAmalkard_id_FK = TosifAmalkards,
                            Payeh_id_FK = Payeh_id_FK,
                            Student_id_FK = CodeMelli,
                            Years_id_FK = Years_id_FK,
                            Nobat = Frm_ShowClasses.Nobat
                        };
                        db.tbl_Marks.Add(Tbl);
                        db.SaveChanges();
                    }
                    MessageBox.Show("نمرات دانش آموزان این کلاس ثبت شد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("لطفا نمرات را برا تمام دانش آموزان ثبت نمایید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsAval)
                {
                    bool IsEmpty = false;
                    double g;
                    int h;
                    for (int i = 0; i < dgv.RowCount; i++)
                        if (Mark.Visible)
                            if (!double.TryParse(dgv.Rows[i].Cells["Mark"].Value.ToString(), out g))
                                IsEmpty = true;
                            else
                                ;
                        else if (TosifAmalkard.Visible)
                            if (!int.TryParse(dgv.Rows[i].Cells["TosifAmalkard"].Value.ToString(), out h))
                                IsEmpty = true;
                    if (!IsEmpty)
                    {
                        if (KarnamehList != null)
                        {
                            for (int i = 0; i < dgv.RowCount; i++)
                            {
                                int Mark_id = int.Parse(dgv.Rows[i].Cells["MarkId"].Value.ToString());
                                var Q6 = (from a in db.tbl_Marks where a.id == Mark_id select a).FirstOrDefault();
                                if (Mark.Visible)
                                    Q6.Mark = double.Parse(dgv.Rows[i].Cells["Mark"].Value.ToString());
                                else if (TosifAmalkard.Visible)
                                    Q6.TosifAmalkard_id_FK = int.Parse(dgv.Rows[i].Cells["TosifAmalkard"].Value.ToString());
                                db.Entry(Q6).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                        }
                        else
                        {
                            for (int i = 0; i < dgv.RowCount; i++)
                            {
                                string CodeMelli = dgv.Rows[i].Cells["StudentCode"].Value.ToString();
                                double? Marks = null;
                                int? TosifAmalkards = null;
                                if (Mark.Visible)
                                    Marks = double.Parse(dgv.Rows[i].Cells["Mark"].Value.ToString());
                                else
                                    TosifAmalkards = int.Parse(dgv.Rows[i].Cells["TosifAmalkard"].Value.ToString());
                                Models.tbl_Marks Tbl = new Models.tbl_Marks();
                                Tbl.Lesson_id_FK = int.Parse(comboBox1.SelectedValue.ToString());
                                Tbl.Mark = Marks;
                                Tbl.TosifAmalkard_id_FK = TosifAmalkards;
                                Tbl.Payeh_id_FK = Payeh_id_FK;
                                Tbl.Student_id_FK = CodeMelli;
                                Tbl.Years_id_FK = Years_id_FK;
                                var Q = (from a in db.tbl_Karnameh where a.Years_id_FK == Years_id_FK && a.Student_id_FK == CodeMelli select a).FirstOrDefault();
                                Tbl.Karnameh_id_FK = Q.id;
                                Tbl.Nobat = Frm_ShowClasses.Nobat;
                                db.tbl_Marks.Add(Tbl);
                                db.SaveChanges();
                            }
                        }
                        MessageBox.Show("نمرات یک درس دانش آموزان این کلاس ثبت شد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        int k = dgv.RowCount;
                        for (int i = 0; i <= k - i; i++)
                        {
                            dgv.Rows[0].Selected = true;
                            dgv.Rows.Remove(dgv.CurrentRow);
                        }
                    }
                    else
                        MessageBox.Show("لطفا نمرات را برا تمام دانش آموزان ثبت نمایید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ////////////////////////////////// FillDGV Student
                if (KarnamehList != null)
                {
                    int l = 1;
                    int Lesson_id = int.Parse(comboBox1.SelectedValue.ToString());
                    bool Flag = false;
                    foreach (var item in KarnamehList)
                    {
                        var Q5 = (from a in db.tbl_Marks where a.Lesson_id_FK == Lesson_id && a.Karnameh_id_FK == item.id select a).FirstOrDefault();
                        if (Q5 != null && Q5.Mark != null)
                            dgv.Rows.Add(l, item.tbl_Students.CodeMelli, item.tbl_Students.Name + " " + item.tbl_Students.Lname, Q5.Mark, null, Q5.id);
                        else if (Q5 != null && Q5.TosifAmalkard_id_FK != null)
                            dgv.Rows.Add(l, item.tbl_Students.CodeMelli, item.tbl_Students.Name + " " + item.tbl_Students.Lname, "", Q5.tbl_TosifAmalkard.id, Q5.id);
                        else
                            Flag = true;
                        l++;
                    }
                    if (Flag)
                    {
                        var Q2 = (from a in db.tbl_StudentClasses where a.Class_id_FK == Class_id select a);
                        int j = 1;
                        foreach (var item1 in Q2.ToList())
                        {
                            Years_id_FK = (from a in db.tbl_Years orderby a.id descending select a).FirstOrDefault().id;
                            var Q0 = (from a in db.tbl_Karnameh where a.Student_id_FK == item1.Student_id_FK && a.Nobat == Frm_ShowClasses.Nobat && a.Years_id_FK == Years_id_FK select a).FirstOrDefault();
                            Models.tbl_Marks Tbl = new Models.tbl_Marks()
                            {
                                Student_id_FK = item1.Student_id_FK,
                                Karnameh_id_FK = Q0.id,
                                Years_id_FK = Years_id_FK,
                                Lesson_id_FK = Lesson_id,
                                Nobat = Frm_ShowClasses.Nobat
                            };
                            db.tbl_Marks.Add(Tbl);
                            db.SaveChanges();
                            var Q = (from a in db.tbl_Marks where a.Lesson_id_FK == Lesson_id && a.Karnameh_id_FK == Q0.id && a.Student_id_FK == item1.Student_id_FK select a).FirstOrDefault();
                            dgv.Rows.Add(j, item1.tbl_Students.CodeMelli, item1.tbl_Students.Name + " " + item1.tbl_Students.Lname, "", null, Q.id);
                            j++;
                        }
                        if (Q2.FirstOrDefault() != null)
                            Years_id_FK = Q2.FirstOrDefault().tbl_Years.id;
                    }
                }
                else
                {
                    ////////////////////////
                    var Q2 = (from a in db.tbl_StudentClasses where a.Class_id_FK == Class_id select a);
                    int j = 1;
                    foreach (var item in Q2.ToList())
                    {
                        dgv.Rows.Add(j, item.tbl_Students.CodeMelli, item.tbl_Students.Name + " " + item.tbl_Students.Lname);
                        j++;
                    }
                    if (Q2.FirstOrDefault() != null)
                        Years_id_FK = Q2.FirstOrDefault().tbl_Years.id;
                }
                IsAval = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
