using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karnameh.Students
{
    public partial class Frm_Student : DevComponents.DotNetBar.Metro.MetroForm
    {
        Models.KarnameDBEntities db = new Models.KarnameDBEntities();
        public Frm_Student()
        {
            InitializeComponent();
        }


        private void buttonX5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_Student_Load(object sender, EventArgs e)
        {
            try
            {
                var Q = (from a in db.tbl_Students where a.tbl_Classes.tbl_Schools.id == Frm_Main.School_id select a).ToList();
                bnsStudent.DataSource = Q;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSearchCodeMelli.Text))
                {
                    var Q = (from a in db.tbl_Students where a.tbl_Classes.tbl_Schools.id == Frm_Main.School_id select a).ToList();
                    bnsStudent.DataSource = Q;
                }
                else
                {
                    var Q = (from a in db.tbl_Students where a.tbl_Classes.tbl_Schools.id == Frm_Main.School_id && a.CodeMelli == txtSearchCodeMelli.Text select a).ToList();
                    bnsStudent.DataSource = Q;
                }

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
                if (string.IsNullOrWhiteSpace(txtSearchFullName.Text))
                {
                    var Q = (from a in db.tbl_Students where a.tbl_Classes.tbl_Schools.id == Frm_Main.School_id select a).ToList();
                    bnsStudent.DataSource = Q;
                }
                else
                {
                    var Q = (from a in db.tbl_Students where a.tbl_Classes.tbl_Schools.id == Frm_Main.School_id && a.Name + " " + a.Lname == txtSearchFullName.Text select a).ToList();
                    bnsStudent.DataSource = Q;
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
                Sti.Load(Application.StartupPath + "\\Reports\\rptStudents.mrt");
                Sti.Compile();
                Sti["lng_SchoolID"] = Frm_Main.School_id;
                Sti.ShowWithRibbonGUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
