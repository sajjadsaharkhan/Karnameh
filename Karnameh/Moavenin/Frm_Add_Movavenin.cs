using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karnameh.Moavenin
{
    public partial class Frm_Add_Movavenin : DevComponents.DotNetBar.Metro.MetroForm
    {
        Models.KarnameDBEntities db = new Models.KarnameDBEntities();
        public static bool IsEdit = false;
        public static long PersonalCode = 0;
        public Frm_Add_Movavenin()
        {
            InitializeComponent();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            this.Close();
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
                else if (mskBirthDate.Text.Replace("/", "").Length != 8)
                    IsError = true;
                if (!IsError)
                {
                    var Q = (from a in db.tbl_MoaveninEjraei where a.CodeMelli == txtCodeMelli.Text select a).Count();
                    var Q2 = (from a in db.tbl_MoaveninEjraei where a.PersonalCode == PersonalCode select a).FirstOrDefault();
                    if (Q == 0 || txtCodeMelli.Text == Q2.CodeMelli)
                    {
                        if (IsEdit)
                        {
                            var Q1 = (from a in db.tbl_MoaveninEjraei where a.PersonalCode == PersonalCode select a).FirstOrDefault();
                            Q1.CodeMelli = txtCodeMelli.Text;
                            Q1.Name = txtName.Text;
                            Q1.Lname = txtLname.Text;
                            Q1.Fname = txtFname.Text;
                            Q1.BirthDate = mskBirthDate.Text;
                            db.Entry(Q1).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                        else
                            db.InsertMoavenin(long.Parse(txtPersonalCode.Text), txtCodeMelli.Text, txtName.Text, txtLname.Text, txtFname.Text, mskBirthDate.Text);
                        MessageBox.Show("عملیات مورد نظر با موفقیت انجام شد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                        MessageBox.Show("کدملی وارد شده مربوط به مدیر دیگری است", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("لطفا اطلاعات درخواستی را تکمیل نمایید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Frm_Add_Movavenin_Load(object sender, EventArgs e)
        {
            try
            {
                if(IsEdit)
                {
                    this.Text = "ویرایش معاون اجرایی";
                    txtPersonalCode.DataBindings.Add(new Binding("Text", BnsMoavenin, "PersonalCode"));
                    txtCodeMelli.DataBindings.Add(new Binding("Text", BnsMoavenin, "CodeMelli"));
                    txtName.DataBindings.Add(new Binding("Text", BnsMoavenin, "Name"));
                    txtLname.DataBindings.Add(new Binding("Text", BnsMoavenin, "Lname"));
                    txtFname.DataBindings.Add(new Binding("Text", BnsMoavenin, "Fname"));
                    mskBirthDate.DataBindings.Add(new Binding("Text", BnsMoavenin, "BirthDate"));
                    var Q = (from a in db.tbl_MoaveninEjraei where a.PersonalCode == PersonalCode select a).FirstOrDefault();
                    BnsMoavenin.DataSource = Q;
                }
                else
                {
                    this.Text = "افزودن معاون اجرایی";
                    var Q = (from a in db.tbl_MoaveninEjraei orderby a.PersonalCode descending select a).FirstOrDefault();
                    if (Q != null)
                        txtPersonalCode.Text = Convert.ToString(++Q.PersonalCode);
                    else
                        txtPersonalCode.Text = "4465";
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
