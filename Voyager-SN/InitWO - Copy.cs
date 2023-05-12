using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Zero_SN
{
    public partial class InitWO : Form
    {
        private readonly WorkOrder wo = new WorkOrder();
        User user = new User();

        public InitWO()
        {
            InitializeComponent();
        }

        public static Form IsFormAlreadyOpen(Type formType)
        {
            return Application.OpenForms.Cast<Form>().FirstOrDefault(openForm => openForm.GetType() == formType);
        }

        private void InitWO_Load(object sender, EventArgs e)
        {

        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            
            if (wo.Existe("select count(*) from tb_WO where wo = '" + txt_WO.Text + "'") && wo.Existe("select count(*) from tb_User where id_user = '" + user.Id_user + "'"))
            {
                wo.Wo = txt_WO.Text;
                //user.Nemploy = int.Parse(txt_Employ.Text);

                SerialNumber sn = new SerialNumber();

                Form NuevaOrden;
                if ((NuevaOrden = IsFormAlreadyOpen(typeof(SerialNumber))) == null)
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
                MessageBox.Show("Not found!","ERROR");
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
