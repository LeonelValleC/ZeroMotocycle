using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zero_SN
{
    public partial class Password : Form
    {
        public Password()
        {
            InitializeComponent();
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            if (txt_Password.Text == "adminmw")
            {
                //Retrabajo r = new Retrabajo();
                Reprint reprint = new Reprint();

                //cs.Usuario = txt_Password.Text;
                //r.Show();
                Form rework;

                if ((rework = IsFormAlreadyOpen(typeof(Reprint))) == null)
                {
                    reprint.ShowDialog(this);
                    this.Close();
                }

                else
                {
                    rework.WindowState = FormWindowState.Normal;
                    rework.BringToFront();
                }
            }
            else
            {
                MessageBox.Show("Password incorrect!", "Error!");
            }
        }

        public static Form IsFormAlreadyOpen(Type formType)
        {
            return Application.OpenForms.Cast<Form>().FirstOrDefault(openForm => openForm.GetType() == formType);
        }

        private void txt_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Submit_Click(this, new EventArgs());
            }
        }
    }
}
