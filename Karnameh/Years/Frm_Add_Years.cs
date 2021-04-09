using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karnameh.Years
{
    public partial class Frm_Add_Years : DevComponents.DotNetBar.Metro.MetroForm
    {
        public static bool IsEdit = false;
        public static int ID = 0;
        Models.KarnameDBEntities db = new Models.KarnameDBEntities();
        public Frm_Add_Years()
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
                if (!string.IsNullOrWhiteSpace(txtYears.Text))
                {
                    if (IsEdit)
                    {
                        var Q = (from a in db.tbl_Years where a.id == ID select a).FirstOrDefault();
                        Q.Years = txtYears.Text;
                        db.Entry(Q).State = EntityState.Modified;
                    }
                    else
                    {
                        int YersId = int.Parse(txtId.Text);
                        Models.tbl_Years Tbl = new Models.tbl_Years()
                        {
                            id = YersId,
                            Years = txtYears.Text
                        };
                        db.tbl_Years.Add(Tbl);
                    }
                    db.SaveChanges();
                    MessageBox.Show("عملیات مورد نظر باموفقیت انجام شد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("لطفا سال تحصیلی را وارد نمایدید ", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_Add_Years_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsEdit)
                {
                    txtYears.DataBindings.Add(new Binding("Text", BsnYears, "Years", true));
                    txtId.DataBindings.Add(new Binding("Text", this.BsnYears, "id", true));
                    var Q = (from a in db.tbl_Years where a.id == ID select a).FirstOrDefault();
                    BsnYears.DataSource = Q;
                    this.Text = "ویرایش سال تحصیلی";
                }
                else
                {
                    this.Text = "افزودن سال تحصیلی";
                    var Q = (from a in db.tbl_Years orderby a.id descending select a).FirstOrDefault();
                    if (Q != null)
                        txtId.Text = Convert.ToString(++Q.id);
                    else
                        txtId.Text = "1";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
