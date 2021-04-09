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
    public partial class Frm_ShowClasses : DevComponents.DotNetBar.Metro.MetroForm
    {
        Models.KarnameDBEntities db = new Models.KarnameDBEntities();
        public static byte Nobat = 1;
        public Frm_ShowClasses()
        {
            InitializeComponent();
        }

        private void Frm_ShowClasses_Load(object sender, EventArgs e)
        {
            try
            {
                var Q = (from a in db.viw_Classes where a.School_id_FK == Frm_Main.School_id select a).ToList();
                BnsClasses.DataSource = Q;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv.RowCount > 0 && dgv.SelectedRows.Count == 1)
                {
                    long Class_id = long.Parse(dgv.Rows[e.RowIndex].Cells["idDataGridViewTextBoxColumn"].Value.ToString());
                    System.Globalization.PersianCalendar PerCal = new System.Globalization.PersianCalendar();
                    var Q2 = (from a in db.tbl_Years orderby a.id descending select a).FirstOrDefault();
                    var Q1 = (from a in db.tbl_Karnameh where a.Years_id_FK == Q2.id && a.tbl_Students.Schools_id_FK == Frm_Main.School_id && a.tbl_Students.Class_id_FK == Class_id && a.Nobat == Nobat select a);
                    if (Q1.Count() > 0)
                    {
                        Frm_Add_Marks.KarnamehList = Q1.ToList();
                        Frm_Add_Marks.Class_id = Class_id;
                        new Frm_Add_Marks().ShowDialog();
                    }
                    else
                    {
                        var Q3 = (from a in db.tbl_Students where a.Schools_id_FK == Frm_Main.School_id && a.Class_id_FK == Class_id select a).ToList();
                        foreach (var item in Q3)
                        {
                            Models.tbl_Karnameh Tbl = new Models.tbl_Karnameh();
                            Tbl.Nobat = Nobat;
                            Tbl.Student_id_FK = item.CodeMelli;
                            Tbl.Years_id_FK = Q2.id;
                            Tbl.IsOk = false;
                            Tbl.DateSabt = PerCal.GetYear(DateTime.Now).ToString("0000/") + PerCal.GetMonth(DateTime.Now).ToString("00/") + PerCal.GetDayOfMonth(DateTime.Now).ToString("00");
                            db.tbl_Karnameh.Add(Tbl);
                            db.SaveChanges();
                        }
                        Frm_Add_Marks.Class_id = Class_id;
                        new Frm_Add_Marks().ShowDialog();
                    }
                }
                else
                    MessageBox.Show("لطفا یک خط را انتخاب نمایید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
