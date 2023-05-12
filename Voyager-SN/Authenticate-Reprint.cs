using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Zero_SN
{
    public partial class Authenticate_Reprint : Form
    {
        User user = new User();

        public Authenticate_Reprint()
        {
            InitializeComponent();
        }

        public static Form IsFormAlreadyOpen(Type formType)
        {
            return Application.OpenForms.Cast<Form>().FirstOrDefault(openForm => openForm.GetType() == formType);
        }


        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (txt_User.Text == "" || txt_Password.Text == "")
            {
                MessageBox.Show("Por favor ingrese toda la informacion");
                return;
            }
            //try
            //{
            user.Id_user = user.LoginReprint(txt_User.Text, txt_Password.Text);
            if (user.Id_user >= 0)
            {

                //user.Id_level = int.Parse(user.ReturnValue("select tu.id_level from tb_User u join tb_level tu on u.id_level = tu.id_level where u.id_user = " + user.Id_user));
                //planta.Id_planta = int.Parse(cb_planta.SelectedValue.ToString());
                //MessageBox.Show("Login Successful!");
                Log();


            }
            else
            {
                MessageBox.Show("Do not has permission!");
            }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }

        private void Log()
        {
            Reprint no = new Reprint();

            Form sn;
            if ((sn = IsFormAlreadyOpen(typeof(Reprint))) == null)
            {
                no.ShowDialog(this);
            }

            else
            {
                sn.WindowState = FormWindowState.Normal;
                sn.BringToFront();
            }
        }
    }
}
