using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karnameh.Schools
{
    public partial class Frm_Add_Schools : DevComponents.DotNetBar.Metro.MetroForm
    {
        public static bool ISEdit = false;
        public static long SchoolsId = 0;
        Models.KarnameDBEntities db = new Models.KarnameDBEntities();
        public Frm_Add_Schools()
        {
            InitializeComponent();
        }

        private void Frm_Add_Schools_Load(object sender, EventArgs e)
        {
            try
            {
                var Q1 = (from a in db.viw_Managers_SchoolsLess select a).ToList();
                var Q2 = (from a in db.viw_MovanenEjraeiSchoolsLess select a).ToList();
                if (ISEdit)
                {
                    var Q3 = (from a in db.viw_Schools where a.id == SchoolsId select a).FirstOrDefault();
                    this.Text = "ویرایش مدرسه";
                    txtId.DataBindings.Add(new Binding("Text", BnsSchools, "id"));
                    txtName.DataBindings.Add(new Binding("Text", BnsSchools, "Name"));
                    txtPassword.DataBindings.Add(new Binding("Text", BnsSchools, "Password"));
                    Q1.Add(new Models.viw_Managers_SchoolsLess() { FullName = Q3.ManagerFullName, PersonalCode = Q3.Manager_PersonalCode_FK.Value });
                    Q2.Add(new Models.viw_MovanenEjraeiSchoolsLess() { FullName = Q3.MoavenFullName, PersonalCode = Q3.MoavenEjraei_PersonalCode_FK.Value });
                    viwMovanenEjraeiSchoolsLessBindingSource.DataSource = Q2;
                    viwManagersSchoolsLessBindingSource.DataSource = Q1;
                    cmbManagers.DataBindings.Add(new Binding("SelectedValue", BnsSchools, "Manager_PersonalCode_FK"));
                    cmbMoavenEjraei.DataBindings.Add(new Binding("SelectedValue", BnsSchools, "MoavenEjraei_PersonalCode_FK"));
                    var Q = (from a in db.tbl_Schools where a.id == SchoolsId select a).FirstOrDefault();
                    BnsSchools.DataSource = Q;

                }
                else
                {
                    viwMovanenEjraeiSchoolsLessBindingSource.DataSource = Q2;
                    viwManagersSchoolsLessBindingSource.DataSource = Q1;
                    this.Text = "افزودن مدرسه";
                    var Q = (from a in db.tbl_Schools orderby a.id descending select a).FirstOrDefault();
                    if (Q != null)
                        txtId.Text = "1264";
                    else
                        txtId.Text = Convert.ToString(++Q.id);
                }
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
                bool IsError = false;
                if (string.IsNullOrWhiteSpace(txtName.Text))
                    IsError = true;
                else if (string.IsNullOrWhiteSpace(txtPassword.Text))
                    IsError = true;
                if (!IsError)
                {
                    if (ISEdit)
                    {
                        var Q = (from a in db.tbl_Schools where a.id == SchoolsId select a).FirstOrDefault();
                        Q.Manager_PersonalCode_FK = long.Parse(cmbManagers.SelectedValue.ToString());
                        Q.MoavenEjraei_PersonalCode_FK = long.Parse(cmbMoavenEjraei.SelectedValue.ToString());
                        Q.Name = txtName.Text;
                        Q.Password = txtPassword.Text;
                        db.Entry(Q).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                        db.InsertSchools(long.Parse(txtId.Text), txtName.Text, long.Parse(cmbManagers.SelectedValue.ToString()), long.Parse(cmbMoavenEjraei.SelectedValue.ToString()), txtPassword.Text);
                    MessageBox.Show("عملیات مورد نظر با موفقیت انجام شد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    MessageBox.Show("لطفا اطلاعات درخواستی را تکمیل کنید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
