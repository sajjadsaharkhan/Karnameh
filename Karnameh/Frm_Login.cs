using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karnameh
{
    public partial class Frm_Login : DevComponents.DotNetBar.Metro.MetroForm
    {
        bool Q = false;
        Karnameh.Models.KarnameDBEntities db = new Karnameh.Models.KarnameDBEntities();
        public Frm_Login()
        {
            InitializeComponent();
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            try
            {
                long School_id;
                if (!string.IsNullOrWhiteSpace(txtPassword.Text) && !string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    if (long.TryParse(txtUsername.Text, out School_id))
                    {
                        School_id = long.Parse(txtUsername.Text);
                        Q = Convert.ToBoolean((from a in db.tbl_Schools where a.id == School_id && a.Password == txtPassword.Text select a).Count());
                        if (Q)
                        {
                            Frm_Main.IsAdmin = false;
                            Frm_Main.School_id = School_id;
                            this.Close();
                        }
                        else
                            MessageBox.Show("لطفا نام کاربری و رمز عبور را صحیح وارد نمایید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        var Q = (from a in db.tbl_Users where a.Username == txtUsername.Text && a.Password == txtPassword.Text select a).Count();
                        if (Q == 1)
                        {
                            Frm_Main.IsAdmin = true;
                            this.Hide();
                        }
                        else
                            MessageBox.Show("لطفا نام کاربری و رمز عبور را صحیح وارد نمایید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("لطفا نام کاربری و رمز عبور را وارد نمایید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!Q)
                Application.Exit();
        }
    }
}
