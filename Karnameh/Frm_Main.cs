using Karnameh.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karnameh
{
    public partial class Frm_Main : DevComponents.DotNetBar.Metro.MetroAppForm
    {
        Models.KarnameDBEntities db = new Models.KarnameDBEntities();
        public static long School_id = 0;
        public static bool IsAdmin = false;
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            try
            {
                new Frm_Login().ShowDialog(this);
                ///////////////////////////////////////
                System.Globalization.PersianCalendar PerCal = new System.Globalization.PersianCalendar();
                string Date = PerCal.GetYear(DateTime.Now).ToString("0000/") + PerCal.GetMonth(DateTime.Now).ToString("00/") + PerCal.GetDayOfMonth(DateTime.Now).ToString("00");
                string Time = DateTime.Now.Hour + ":" + DateTime.Now.Minute;
                lblDateTime.Text = Time + "   " + Date;
                ////////////////////////////////////////
                if (IsAdmin)
                {
                    RbnClasses.Visible = false;
                    RbnStudent.Visible = false;
                    RbnSchools.Select();
                    lblWelcome.Text = "مدیر محترم نرم افزار؛خوش آمدید ";
                }
                else
                {
                    var Q = (from a in db.tbl_Schools where a.id == School_id select a).FirstOrDefault();
                    lblWelcome.Text = "کاربر گرامی؛" + Q.tbl_MoaveninEjraei.Name + " " + Q.tbl_MoaveninEjraei.Lname + " خوش آمدید ";
                    RbnEduManager.Visible = false;
                    RbnSchools.Visible = false;
                    RbnPersonelManager.Visible = false;
                    RbnStudent.Select();
                }
                ////////////////////////////////////////                        

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                System.Globalization.PersianCalendar PerCal = new System.Globalization.PersianCalendar();
                string Date = PerCal.GetYear(DateTime.Now).ToString("0000/") + PerCal.GetMonth(DateTime.Now).ToString("00/") + PerCal.GetDayOfMonth(DateTime.Now).ToString("00");
                string Time = DateTime.Now.Hour + ":" + DateTime.Now.Minute;
                lblDateTime.Text = Time + "   " + Date;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            new Students.Frm_Student().ShowDialog(this);
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            new Classes.Frm_Classes().ShowDialog(this);
        }

        private void applicationButton1_Click(object sender, EventArgs e)
        {

        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem14_Click(object sender, EventArgs e)
        {
            new ClassifyStudent.Frm_ClassifyStudent().ShowDialog(this);
        }

        private void buttonItem15_Click(object sender, EventArgs e)
        {
            new Years.Frm_Years().ShowDialog(this);
        }

        private void buttonItem16_Click(object sender, EventArgs e)
        {
            new Payeh.Frm_Payeh().ShowDialog(this);
        }

        private void buttonItem17_Click(object sender, EventArgs e)
        {
            new Lessons.Frm_Lessons().ShowDialog();
        }

        private void buttonItem18_Click(object sender, EventArgs e)
        {
            new Managers.Frm_Managers().ShowDialog(this);
        }

        private void buttonItem19_Click(object sender, EventArgs e)
        {
            new Moavenin.Frm_Moavenin().ShowDialog(this);
        }

        private void buttonItem20_Click(object sender, EventArgs e)
        {
            new Schools.Frm_Schools().ShowDialog(this);
        }

        private void buttonItem21_Click(object sender, EventArgs e)
        {
            new TosifAmarkard.Frm_TosifAmalkard().ShowDialog(this);
        }

        private void buttonItem22_Click(object sender, EventArgs e)
        {
            new Teachers.Frm_Teachers().ShowDialog(this);
        }

        private void buttonItem24_Click(object sender, EventArgs e)
        {
            InsertMarks.Frm_ShowClasses.Nobat = 1;
            new InsertMarks.Frm_ShowClasses().ShowDialog(this);
        }

        private void buttonItem25_Click(object sender, EventArgs e)
        {
            InsertMarks.Frm_ShowClasses.Nobat = 2;
            new InsertMarks.Frm_ShowClasses().ShowDialog(this);
        }

        private void buttonItem27_Click(object sender, EventArgs e)
        {
            try
            {
                bool IsInserted = true;
                var ClassesList = (from a in db.tbl_Classes where a.School_id_FK == School_id select a).ToList();
                int Years_id_FK = (from a in db.tbl_Years orderby a.id descending select a).FirstOrDefault().id;
                ///////// Nomre
                foreach (var item in ClassesList)
                {
                    var StudentClassesList = (from a in db.tbl_StudentClasses where a.Class_id_FK == item.id && a.tbl_Classes.tbl_Payeh.TosifAmalkard_id_FK == null select a).ToList();
                    foreach (var item1 in StudentClassesList)
                    {
                        var Karnameh = (from a in db.tbl_Karnameh where a.Years_id_FK == Years_id_FK && a.Student_id_FK == item1.Student_id_FK && a.Nobat == 2 && a.IsOk == false select a).FirstOrDefault();
                        int Karnameh_Count = (from a in db.tbl_Karnameh where a.Years_id_FK == Years_id_FK && a.Student_id_FK == item1.Student_id_FK && a.Nobat == 2 && a.IsOk == false select a).Count();
                        if (Karnameh == null || Karnameh_Count == 0)
                            IsInserted = false;
                        else
                        {
                            var Marks = (from a in db.tbl_Marks where a.Karnameh_id_FK == Karnameh.id && a.Mark != null select a).ToList();
                            float Sum = 0;
                            int Count = 0;
                            byte CountLowerTen = 0;
                            foreach (var item2 in Marks)
                            {
                                Sum += (float)item2.Mark.Value;
                                Count++;
                                if (item2.Mark.Value < 10)
                                    CountLowerTen++;
                            }
                            var Student = (from a in db.tbl_Students where a.CodeMelli == item1.Student_id_FK select a).FirstOrDefault();
                            bool IsRespect = false;
                            string Comment = "";
                            if (CountLowerTen == 0 && (Sum / Count) >= 10)
                            {
                                IsRespect = true;
                                Comment = "ارتقاء خرداد" + Environment.NewLine + "میتواند به پایه بالاتر ارتقاءپیدا کنید";
                            }
                            else
                            {
                                IsRespect = false;
                                Comment = "رد خرداد" + Environment.NewLine + "نیتواند به پایه بالاتر ارتقاءپیدا کنید";
                            }
                            db.EditStudent(Student.CodeMelli);
                            System.Globalization.PersianCalendar PerCal = new System.Globalization.PersianCalendar();
                            long MoavenEjraei_id_FK = (from a in db.tbl_Schools where a.id == School_id select a).FirstOrDefault().MoavenEjraei_PersonalCode_FK.Value;
                            string DateSabt = PerCal.GetYear(DateTime.Now).ToString("0000/") + PerCal.GetMonth(DateTime.Now).ToString("00/") + PerCal.GetDayOfMonth(DateTime.Now).ToString("00");
                            db.EditKarnameh(Karnameh.id, Comment, IsRespect, (Sum / Count).ToString(), DateSabt, true, MoavenEjraei_id_FK);
                        }
                    }
                }
                if (!IsInserted)
                    MessageBox.Show("کارنامه دانش آموزان این مدرسه یا ثبت نهایی شده اند یا هنوز نمره ای ندارند", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                IsInserted = true;
                ///////// TosifAmalkard
                foreach (var item in ClassesList)
                {
                    var StudentClassesList = (from a in db.tbl_StudentClasses where a.Class_id_FK == item.id && a.tbl_Classes.tbl_Payeh.TosifAmalkard_id_FK != null select a).ToList();
                    foreach (var item1 in StudentClassesList)
                    {
                        var Karnameh = (from a in db.tbl_Karnameh where a.Years_id_FK == Years_id_FK && a.Student_id_FK == item1.Student_id_FK && a.Nobat == 2 && a.IsOk == false select a).FirstOrDefault();
                        int Karnameh_Count = (from a in db.tbl_Karnameh where a.Years_id_FK == Years_id_FK && a.Student_id_FK == item1.Student_id_FK && a.Nobat == 2 && a.IsOk == false select a).Count();
                        if (Karnameh == null || Karnameh_Count == 0)
                            IsInserted = false;
                        else
                        {
                            var Marks = (from a in db.tbl_Marks where a.Karnameh_id_FK == Karnameh.id && a.TosifAmalkard_id_FK != null select a).ToList();
                            float Sum = 0;
                            int Count = 0;
                            byte CountLowerTen = 0;
                            foreach (var item2 in Marks)
                            {
                                Sum += (float)item2.tbl_TosifAmalkard.MaxMark.Value;
                                Count++;
                                if (item2.tbl_TosifAmalkard.MaxMark < 10)
                                    CountLowerTen++;
                            }
                            var Student = (from a in db.tbl_Students where a.CodeMelli == item1.Student_id_FK select a).FirstOrDefault();
                            bool IsRespect = false;
                            string Comment = "";
                            if (CountLowerTen == 0 && (Sum / Count) >= 10)
                            {
                                IsRespect = true;
                                Comment = "ارتقاء خرداد" + Environment.NewLine + "میتواند به پایه بالاتر ارتقاءپیدا کنید";
                            }
                            else
                            {
                                IsRespect = false;
                                Comment = "رد خرداد" + Environment.NewLine + "نمیتواند به پایه بالاتر ارتقاءپیدا کنید";
                            }
                            db.EditStudent(Student.CodeMelli);
                            System.Globalization.PersianCalendar PerCal = new System.Globalization.PersianCalendar();
                            string Avg = "";
                            double AvgDigit = Sum / Count;
                            if (AvgDigit > 10)
                                Avg = "نیازمند تلاش بیشتر";
                            else if (AvgDigit >= 10 && AvgDigit <= 15)
                                Avg = "قابل قبول";
                            else if (AvgDigit < 15 && AvgDigit <= 18)
                                Avg = "خوب";
                            else if (AvgDigit > 18 && AvgDigit <= 20)
                                Avg = "خیلی خوب";
                            long MoavenEjraei_id_FK = (from a in db.tbl_Schools where a.id == School_id select a).FirstOrDefault().MoavenEjraei_PersonalCode_FK.Value;
                            string DateSabt = PerCal.GetYear(DateTime.Now).ToString("0000/") + PerCal.GetMonth(DateTime.Now).ToString("00/") + PerCal.GetDayOfMonth(DateTime.Now).ToString("00");
                            db.EditKarnameh(Karnameh.id, Comment, IsRespect, Avg, DateSabt, true, MoavenEjraei_id_FK);
                        }
                    }
                }
                if (!IsInserted)
                    MessageBox.Show("کارنامه دانش آموزان این مدرسه یا ثبت نهایی شده اند یا هنوز نمره ای ندارند", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void buttonItem26_Click(object sender, EventArgs e)
        {
            try
            {
                bool IsInserted = true;
                var ClassesList = (from a in db.tbl_Classes where a.School_id_FK == School_id select a).ToList();
                int Years_id_FK = (from a in db.tbl_Years orderby a.id descending select a).FirstOrDefault().id;
                ///////// Nomre
                foreach (var item in ClassesList)
                {
                    var StudentClassesList = (from a in db.tbl_StudentClasses where a.Class_id_FK == item.id && a.tbl_Classes.tbl_Payeh.TosifAmalkard_id_FK == null select a).ToList();
                    foreach (var item1 in StudentClassesList)
                    {
                        var Karnameh = (from a in db.tbl_Karnameh where a.Years_id_FK == Years_id_FK && a.Student_id_FK == item1.Student_id_FK && a.Nobat == 1 && a.IsOk == false select a).FirstOrDefault();
                        int Karnameh_Count = (from a in db.tbl_Karnameh where a.Years_id_FK == Years_id_FK && a.Student_id_FK == item1.Student_id_FK && a.Nobat == 1 && a.IsOk == false select a).Count();
                        if (Karnameh == null || Karnameh_Count == 0)
                            IsInserted = false;
                        else
                        {
                            var Marks = (from a in db.tbl_Marks where a.Karnameh_id_FK == Karnameh.id && a.Mark != null select a).ToList();
                            float Sum = 0;
                            int Count = 0;
                            byte CountLowerTen = 0;
                            foreach (var item2 in Marks)
                            {
                                Sum += (float)item2.Mark.Value;
                                Count++;
                                if (item2.Mark.Value < 10)
                                    CountLowerTen++;
                            }
                            System.Globalization.PersianCalendar PerCal = new System.Globalization.PersianCalendar();
                            Karnameh.Avarage = (Sum / Count).ToString();
                            Karnameh.MoavenEjraei_id_FK = (from a in db.tbl_Schools where a.id == School_id select a).FirstOrDefault().MoavenEjraei_PersonalCode_FK;
                            Karnameh.DateSabt = PerCal.GetYear(DateTime.Now).ToString("0000/") + PerCal.GetMonth(DateTime.Now).ToString("00/") + PerCal.GetDayOfMonth(DateTime.Now).ToString("00");
                            Karnameh.IsOk = true;
                            db.Entry(Karnameh).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                }
                if (!IsInserted)
                    MessageBox.Show("کارنامه دانش آموزان این مدرسه یا ثبت نهایی شده اند یا هنوز نمره ای ندارند", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                IsInserted = true;
                ///////// TosifAmalkard
                foreach (var item in ClassesList)
                {
                    var StudentClassesList = (from a in db.tbl_StudentClasses where a.Class_id_FK == item.id && a.tbl_Classes.tbl_Payeh.TosifAmalkard_id_FK != null select a).ToList();
                    foreach (var item1 in StudentClassesList)
                    {
                        var Karnameh = (from a in db.tbl_Karnameh where a.Years_id_FK == Years_id_FK && a.Student_id_FK == item1.Student_id_FK && a.Nobat == 1 && a.IsOk == false select a).FirstOrDefault();
                        int Karnameh_Count = (from a in db.tbl_Karnameh where a.Years_id_FK == Years_id_FK && a.Student_id_FK == item1.Student_id_FK && a.Nobat == 1 && a.IsOk == false select a).Count();
                        if (Karnameh == null || Karnameh_Count == 0)
                            IsInserted = false;
                        else
                        {
                            var Marks = (from a in db.tbl_Marks where a.Karnameh_id_FK == Karnameh.id && a.TosifAmalkard_id_FK != null select a).ToList();
                            float Sum = 0;
                            int Count = 0;
                            byte CountLowerTen = 0;
                            foreach (var item2 in Marks)
                            {
                                Sum += (float)item2.tbl_TosifAmalkard.MaxMark.Value;
                                Count++;
                                if (item2.tbl_TosifAmalkard.MaxMark < 10)
                                    CountLowerTen++;
                            }
                            System.Globalization.PersianCalendar PerCal = new System.Globalization.PersianCalendar();
                            string Avg = "";
                            double AvgDigit = Sum / Count;
                            if (AvgDigit > 10)
                                Avg = "نیازمند تلاش بیشتر";
                            else if (AvgDigit >= 10 && AvgDigit <= 15)
                                Avg = "قابل قبول";
                            else if (AvgDigit < 15 && AvgDigit <= 18)
                                Avg = "خوب";
                            else if (AvgDigit > 18 && AvgDigit <= 20)
                                Avg = "خیلی خوب";
                            Karnameh.Avarage = Avg;
                            Karnameh.MoavenEjraei_id_FK = (from a in db.tbl_Schools where a.id == School_id select a).FirstOrDefault().MoavenEjraei_PersonalCode_FK;
                            Karnameh.DateSabt = PerCal.GetYear(DateTime.Now).ToString("0000/") + PerCal.GetMonth(DateTime.Now).ToString("00/") + PerCal.GetDayOfMonth(DateTime.Now).ToString("00");
                            Karnameh.IsOk = true;
                            db.Entry(Karnameh).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                }
                if (!IsInserted)
                    MessageBox.Show("کارنامه دانش آموزان این مدرسه یا ثبت نهایی شده اند یا هنوز نمره ای ندارند", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
