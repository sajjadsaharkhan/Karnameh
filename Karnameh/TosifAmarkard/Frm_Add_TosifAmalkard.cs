using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karnameh.TosifAmarkard
{
    public partial class Frm_Add_TosifAmalkard : DevComponents.DotNetBar.Metro.MetroForm
    {
        Models.KarnameDBEntities db = new Models.KarnameDBEntities();
        public static bool IsEdit = false;
        public static int id = 0;
        public Frm_Add_TosifAmalkard()
        {
            InitializeComponent();
        }

        private void Frm_Add_TosifAmalkard_Load(object sender, EventArgs e)
        {
            try
            {
                if(IsEdit)
                {
                    this.Text = "ویرایش توصیف عملکرد";
                    var Q = (from a in db.tbl_TosifAmalkard where a.id == id select a).FirstOrDefault();
                    txtId.Text = Q.id.ToString();
                    txtName.Text = Q.Name.ToString();
                    mskMaxMark.Text = Q.MaxMark.Value.ToString();
                }
                else
                {
                    this.Text = "افزودن توصیف عملکرد";
                    var Q = (from a in db.tbl_TosifAmalkard orderby a.id descending select a).FirstOrDefault();
                    if (Q != null)
                        txtId.Text = Convert.ToString(++Q.id);
                    else
                        txtId.Text = "1";
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
                else if (mskMaxMark.Text.Replace(" ", "").Length != 2)
                    IsError = true;
                if (!IsError)
                {
                    if (IsEdit)
                    {
                        var Q = (from a in db.tbl_TosifAmalkard where a.id == id select a).FirstOrDefault();
                        Q.MaxMark = int.Parse(mskMaxMark.Text);
                        Q.Name = txtName.Text;
                        db.Entry(Q).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                        db.InsertTosifAmalkard(int.Parse(txtId.Text), txtName.Text, int.Parse(mskMaxMark.Text));
                    MessageBox.Show("عملیات مورد نظر با موفقیت انجام شد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    MessageBox.Show("لطفا مقادیر درخواستی را کامل وارد نمایید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
