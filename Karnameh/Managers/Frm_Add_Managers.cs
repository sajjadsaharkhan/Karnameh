using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karnameh.Managers
{
    public partial class Frm_Add_Managers : DevComponents.DotNetBar.Metro.MetroForm
    {
        public static bool IsEdit = false;
        public static long PersonalCode = 0;
        Models.KarnameDBEntities db = new Models.KarnameDBEntities();
        public Frm_Add_Managers()
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
                    var Q = (from a in db.tbl_Managers where a.CodeMelli == txtCodeMelli.Text select a).Count();
                    var Q2 = (from a in db.tbl_Managers where a.PersonalCode == PersonalCode select a).FirstOrDefault();
                    if (Q == 0 || txtCodeMelli.Text == Q2.CodeMelli)
                    {
                        if (IsEdit)
                        {
                            var Q1 = (from a in db.tbl_Managers where a.PersonalCode == PersonalCode select a).FirstOrDefault();
                            Q1.CodeMelli = txtCodeMelli.Text;
                            Q1.Name = txtName.Text;
                            Q1.Lname = txtLname.Text;
                            Q1.Fname = txtFname.Text;
                            Q1.BirthDate = mskBirthDate.Text;
                            db.Entry(Q1).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                        else
                            db.InsertManagers(long.Parse(txtPersonalCode.Text), txtCodeMelli.Text, txtName.Text, txtLname.Text, txtFname.Text, mskBirthDate.Text);
                        MessageBox.Show("عملیات مورد نظر با موفقیت انجام شد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                        MessageBox.Show("کدملی وارد شده مربوط به مدیر دیگری است", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("لطفا اطلاعات درخواستی را تکمیل نمایید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_Add_Managers_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsEdit)
                {
                    this.Text = "ویرایش مدیر";
                    txtPersonalCode.DataBindings.Add(new Binding("Text", BnsManagers, "PersonalCode", true));
                    mskBirthDate.DataBindings.Add(new Binding("Text", BnsManagers, "BirthDate", true));
                    txtCodeMelli.DataBindings.Add(new Binding("Text", BnsManagers, "CodeMelli", true));
                    txtName.DataBindings.Add(new Binding("Text", BnsManagers, "Name", true));
                    txtLname.DataBindings.Add(new Binding("Text", BnsManagers, "Lname", true));
                    txtFname.DataBindings.Add(new Binding("Text", BnsManagers, "Fname", true));
                    var Q = (from a in db.tbl_Managers where a.PersonalCode == PersonalCode select a).FirstOrDefault();
                    BnsManagers.DataSource = Q;
                }
                else
                {
                    this.Text = "افزودن مدیر";
                    var Q = (from a in db.tbl_Managers orderby a.PersonalCode descending select a).FirstOrDefault();
                    if (Q != null)
                        txtPersonalCode.Text = Convert.ToString(++Q.PersonalCode);
                    else
                        txtPersonalCode.Text = "9632";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
