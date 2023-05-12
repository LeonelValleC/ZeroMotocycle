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
    public partial class WO_ValidateSN : Form
    {
        private readonly WorkOrder wo = new WorkOrder();
        User user = new User();

        public static Form IsFormAlreadyOpen(Type formType)
        {
            return Application.OpenForms.Cast<Form>().FirstOrDefault(openForm => openForm.GetType() == formType);
        }

        public WO_ValidateSN()
        {
            InitializeComponent();
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {

            if (wo.Existe("select count(*) from tb_WO where wo = '" + txt_WO.Text + "'") && wo.Existe("select count(*) from tb_User where id_user = '" + user.Id_user + "'"))
            {
                wo.Wo = txt_WO.Text;

                //user.Nemploy = int.Parse(txt_Employ.Text);

                ValidateSN sn = new ValidateSN();

                Form NuevaOrden;
                if ((NuevaOrden = IsFormAlreadyOpen(typeof(ValidateSN))) == null)
                {
                    sn.ShowDialog(this);
                }
                else
                {
                    NuevaOrden.WindowState = FormWindowState.Normal;
                    NuevaOrden.BringToFront();
                }
            }
            else
            {
                MessageBox.Show("Not found!", "ERROR");
            }
        }

        private void txt_WO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Submit_Click(this, new EventArgs());
            }
        }
    }
}
