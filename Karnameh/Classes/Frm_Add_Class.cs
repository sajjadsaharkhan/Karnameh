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
    public partial class Frm_Add_Class : DevComponents.DotNetBar.Metro.MetroForm
    {
        Models.KarnameDBEntities db = new Models.KarnameDBEntities();
        public static bool IsEdit = false;
        public static long Class_id = 0;
        public Frm_Add_Class()
        {
            InitializeComponent();
        }

        private void Frm_Add_Class_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsEdit)
                {
                    this.cmbTeachers.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSource1, "Teachers_PersonalCode_FK", true));
                    this.txtClassName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource1, "Name", true));
                    this.cmbPayeh.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSource1, "Payeh_id_FK", true));
                    this.txtClassid.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource1, "id", true));
                    var Q1 = (from a in db.tbl_Payeh select a).ToList();
                    tblPayehBindingSource.DataSource = Q1;
                    var Q3 = (from a in db.tbl_Classes where a.id == Class_id select a).FirstOrDefault().Teachers_PersonalCode_FK;
                    var Q2 = (from a in db.FillTeachersNoClassWhitOwn(Frm_Main.School_id, Q3) select a).ToList();
                    viwTeachersNameBindingSource.DataSource = Q2;
                    bindingSource1.DataSource = (from a in db.tbl_Classes where a.id == Class_id select a).FirstOrDefault();
                }
                else
                {
                    var Q = (from a in db.tbl_Classes select a).OrderByDescending(a => a.id).FirstOrDefault();
                    if (Q != null)
                        txtClassid.Text = Convert.ToString(Q.id + 1);
                    else
                        txtClassid.Text = "1";
                    var Q1 = (from a in db.tbl_Payeh select a).ToList();
                    tblPayehBindingSource.DataSource = Q1;
                    var Q2 = (from a in db.FillTechersNoClass(Frm_Main.School_id) select a).ToList();
                    viwTeachersNameBindingSource.DataSource = Q2;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtClassName.Text))
                {
                    if (IsEdit)
                    {
                        var Q = (from a in db.tbl_Classes where a.id == Class_id select a).FirstOrDefault();
                        Q.Name = txtClassName.Text;
                        Q.Payeh_id_FK = int.Parse(cmbPayeh.SelectedValue.ToString());
                        Q.Teachers_PersonalCode_FK = long.Parse(cmbTeachers.SelectedValue.ToString());
                        db.tbl_Classes.Attach(Q);
                        db.Entry(Q).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        Models.tbl_Classes Tbl = new Models.tbl_Classes() { id = long.Parse(txtClassid.Text), Name = txtClassName.Text, Teachers_PersonalCode_FK = long.Parse(cmbTeachers.SelectedValue.ToString()), Payeh_id_FK = int.Parse(cmbPayeh.SelectedValue.ToString()), School_id_FK = Frm_Main.School_id };
                        db.tbl_Classes.Add(Tbl);
                        db.SaveChanges();
                    }
                    MessageBox.Show("عملیات مورد نظر با موفقیت انجام شد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    MessageBox.Show("لطفا نام کلاس را وارد نمایید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
