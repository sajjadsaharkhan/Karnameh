using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karnameh.Lessons
{
    public partial class Frm_Add_Lessons : DevComponents.DotNetBar.Metro.MetroForm
    {
        public static bool IsEdit = false;
        public static int Id = 0;
        Models.KarnameDBEntities db = new Models.KarnameDBEntities();
        public Frm_Add_Lessons()
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
                if (!string.IsNullOrWhiteSpace(txtName.Text))
                {
                    if (IsEdit)
                    {
                        var Q = (from a in db.tbl_Lessons where a.id == Id select a).FirstOrDefault();
                        Q.Name = txtName.Text;
                        Q.Payeh_id_FK = int.Parse(CmbPayeh.SelectedValue.ToString());
                        db.Entry(Q).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                        db.InsertLessons(int.Parse(txtId.Text), txtName.Text, int.Parse(CmbPayeh.SelectedValue.ToString()));
                    MessageBox.Show("عملیات مورد نظر با موفقیت انجام شد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    MessageBox.Show("لطفا اطلاعات درخواستی را کامل نمایید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Frm_Add_Lessons_Load(object sender, EventArgs e)
        {
            try
            {
                var Q1 = (from a in db.tbl_Payeh select a).ToList();
                tblPayehBindingSource.DataSource = Q1;
                if (IsEdit)
                {
                    this.Text = "ویرایش درس";
                    txtId.DataBindings.Add(new Binding("Text", BnsLessons, "id", true));
                    txtName.DataBindings.Add(new Binding("Text", BnsLessons, "Name", true));
                    CmbPayeh.DataBindings.Add(new Binding("SelectedValue", BnsLessons, "Payeh_id_FK", true));
                    var Q = (from a in db.tbl_Lessons where a.id == Id select a).FirstOrDefault();
                    BnsLessons.DataSource = Q;
                }
                else
                {
                    this.Text = "افزودن درس";
                    var Q = (from a in db.tbl_Lessons orderby a.id descending select a).FirstOrDefault();
                    if (Q != null)
                        txtId.Text = Convert.ToString(++Q.id);
                    else
                        txtId.Text = "1";

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
