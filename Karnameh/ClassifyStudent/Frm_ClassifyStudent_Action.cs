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
    public partial class Frm_ClassifyStudent_Action : DevComponents.DotNetBar.Metro.MetroForm
    {
        public static int Classid = 0;
        Models.KarnameDBEntities db = new Models.KarnameDBEntities();
        public Frm_ClassifyStudent_Action()
        {
            InitializeComponent();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            byte Zarfiat;
            if (!string.IsNullOrWhiteSpace(textBoxX1.Text) && byte.TryParse(textBoxX1.Text, out Zarfiat) && byte.Parse(textBoxX1.Text) >= 1 && byte.Parse(textBoxX1.Text) <= 50)
            {
                var Q1 = (from a in db.tbl_Years orderby a.id descending select a).FirstOrDefault();
                var Q3 = (from a in db.tbl_Classes where a.id == Classid select a).FirstOrDefault();
                int YearsId = 0;
                if (Q1 != null)
                    YearsId = Q1.id;
                    var Q = (from a in db.tbl_StudentClasses where a.Class_id_FK == Classid && a.Years_id_K == YearsId select a).Count();
                if (Q == 0)
                {
                    List<Models.tbl_Students> StudentList = new List<Models.tbl_Students>();
                    var Q2 = (from a in db.tbl_Students where a.Schools_id_FK == Frm_Main.School_id && a.Payeh_id_FK == Q3.Payeh_id_FK select a).ToList();
                    foreach (var item in Q2)
                    {
                        var Q4 = (from a in db.tbl_StudentClasses where a.Years_id_K == Q1.id && a.Student_id_FK == item.CodeMelli select a).Count();
                        if (Q4 == 0)
                            StudentList.Add(item);
                    }
                    byte i = 1;
                    foreach (var item in StudentList)
                    {
                        if (i <= Zarfiat)
                        {
                            Models.tbl_StudentClasses Tbl = new Models.tbl_StudentClasses()
                            {
                                Class_id_FK = Classid,
                                Years_id_K = Q1.id,
                                Student_id_FK = item.CodeMelli
                            };
                            db.tbl_StudentClasses.Add(Tbl);
                            item.Class_id_FK = Classid;
                            db.Entry(item).State = EntityState.Modified;
                            db.SaveChanges();
                            i++;
                        }
                        else
                            break;
                    }
                    i--;
                    MessageBox.Show("تعداد دانش آموزی که در این کلاس قرارگرفتند" + i + "میباشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("این کلاس، کلاسبندی شده است", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("لطفا ظرفیت کلاس را صحیح وارد نمایید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
