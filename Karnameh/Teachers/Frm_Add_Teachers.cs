using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karnameh.Teachers
{
    public partial class Frm_Add_Teachers : DevComponents.DotNetBar.Metro.MetroForm
    {
        Models.KarnameDBEntities db = new Models.KarnameDBEntities();
        public static bool IsEdit = false;
        public static long PersonalCode = 0;
        public Frm_Add_Teachers()
        {
            InitializeComponent();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            try
            {
                bool IsError = false;
                if (string.IsNullOrWhiteSpace(txtCodeMelli.Text))
                    IsError = true;
                else if (string.IsNullOrWhiteSpace(txtName.Text))
                    IsError = true;
                else if (string.IsNullOrWhiteSpace(txtLname.Text))
                    IsError = true;
                else if (string.IsNullOrWhiteSpace(txtFname.Text))
                    IsError = true;
                if (!IsError)
                {
                    if (IsEdit)
                    {
                        var Q = (from a in db.tbl_Teachers where a.PersonalCode == PersonalCode select a).FirstOrDefault();
                        Q.Name = txtName.Text;
                        Q.CodeMelli = txtCodeMelli.Text;
                        Q.Lname = txtLname.Text;
                        Q.Fname = txtFname.Text;
                        Q.Schools_id_FK = long.Parse(cmbSchools.SelectedValue.ToString());
                        Q.Payeh_id_FK = int.Parse(cmbPayeh.SelectedValue.ToString());
                        db.Entry(Q).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                        db.InsertTeachers(long.Parse(txtPersonalCode.Text), txtCodeMelli.Text, txtName.Text, txtLname.Text, txtFname.Text, int.Parse(cmbPayeh.SelectedValue.ToString()), long.Parse(cmbSchools.SelectedValue.ToString()));
                    MessageBox.Show("عملیات مورد نظر با موفقیت انجام شد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    MessageBox.Show("لطفا تمامی فیلد های لازم را پرکنید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Frm_Add_Teachers_Load(object sender, EventArgs e)
        {
            try
            {
                var Q1 = (from a in db.tbl_Payeh select a).ToList();
                var Q2 = (from a in db.tbl_Schools select a).ToList();
                BnsPayeh.DataSource = Q1;
                BnsSchools.DataSource = Q2;
                if(IsEdit)
                {
                    this.Text = "ویرایش معلم";
                    var Q = (from a in db.tbl_Teachers where a.PersonalCode == PersonalCode select a).FirstOrDefault();
                    txtPersonalCode.Text = Q.PersonalCode.ToString();
                    txtName.Text = Q.Name;
                    txtLname.Text = Q.Lname;
                    txtFname.Text = Q.Fname;
                    txtCodeMelli.Text = Q.CodeMelli;
                    cmbPayeh.SelectedValue = Q.Payeh_id_FK;
                    cmbSchools.SelectedValue = Q.Schools_id_FK;
                }
                else
                {
                    this.Text = "افزودن معلم";
                    var Q = (from a in db.tbl_Teachers orderby a.PersonalCode descending select a).FirstOrDefault();
                    if (Q != null)
                        txtPersonalCode.Text = Convert.ToString(++Q.PersonalCode);
                    else
                        txtPersonalCode.Text = "4585";
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
