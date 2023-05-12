using System;
using System.Windows.Forms;

namespace Zero_SN
{
    public partial class Login : Form
    {
        User user = new User();

        public Login()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_User.Text == "" || txt_Password.Text == "")
                {
                    MessageBox.Show("Por favor ingrese toda la informacion");
                    return;
                }
                user.Id_user = user.Login(txt_User.Text, txt_Password.Text);
                if (user.Id_user >= 0)
                {

                    user.Id_level = int.Parse(user.ReturnValue("select tu.id_level from tb_User u join tb_level tu on u.id_level = tu.id_level where u.id_user = " + user.Id_user));
                    //planta.Id_planta = int.Parse(cb_planta.SelectedValue.ToString());
                    //MessageBox.Show("Login Successful!");
                    Log();


                }
                else
                {
                    user.Cerrar();
                    MessageBox.Show("Login Failed!");
                }

            }
            catch (NullReferenceException)
            {
                user.Cerrar();

                MessageBox.Show("User & Password incorrect!", "Error!");

            }
           
        }

        private void Log()
        {
            this.Hide();
            Form1 fm = new Form1();
            fm.Show();
        }

        private void txt_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Login_Click(this, new EventArgs());
            }
        }
    }
}
