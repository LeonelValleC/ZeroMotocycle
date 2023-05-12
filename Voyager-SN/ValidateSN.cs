using System;
using System.Drawing;
using System.Windows.Forms;

namespace Zero_SN
{
    public partial class ValidateSN : Form
    {
        WorkOrder wo = new WorkOrder();
        Inprocess inprocess = new Inprocess();
        User user = new User();

        public ValidateSN()
        {
            InitializeComponent();
        }
        private void ValidateSN_Load(object sender, EventArgs e)
        {
            wo.Id_wo = int.Parse(wo.ReturnID("select id_wo from tb_wo where wo = '" + wo.Wo + "'"));
            dg_Validate.DataSource = wo.LlenarDG("select inp.id_inprocess, inp.SerialNumber, CONCAT(SerialNumber,',',pn,'-',Rev) as 'QR', Validated from tb_Inprocess inp join tb_WO wo on inp.id_wo = wo.id_wo join tb_PN pn on wo.id_pn = pn.id_pn where Scrap = 0 or Scrap is null and wo.id_wo = " + wo.Id_wo).Tables[0];
            dg_Validate.Columns[0].Visible = false;
            lbl_Records.Text = wo.ReturnValue("select qty from tb_WO where id_wo = '" + wo.Id_wo + "'");
            lbl_Validated.Text = inprocess.ReturnValue("select count(*) from tb_Inprocess where id_wo = '" + wo.Id_wo + "' and Validated = 1 ");
            PaintCells();
        }

        private void btn_Check_Click(object sender, EventArgs e)
        {
            SNValidation();
            ValidateSN_Load(sender, e);
            txt_Validate.Focus();
            txt_Validate.Text = "";
        }

        private bool SNValidation()
        {
            bool isValid = false;

            foreach (DataGridViewRow row in dg_Validate.Rows)
            {
                if (row.Cells[2].Value.ToString().Equals(txt_Validate.Text))
                {
                    inprocess.Crud("update tb_Inprocess set Validated = 1 where id_inprocess = " + row.Cells[0].Value.ToString());

                    inprocess.Crud("insert into tb_LogValidates values('" + user.Id_user + "','" + DateTime.Now + "','" + row.Cells[0].Value.ToString() + "')");
                    //dg_Validate.Rows[row.Index].Selected = true;
                    //this.dg_Validate.CurrentCell = row.Cells[1];
                    isValid = true;
                    break;
                }
                //row.DefaultCellStyle.BackColor = Color.LightGreen;
                isValid = false;
            }
            return isValid;
        }


        private void PaintCells()
        {
            bool validate = false;
            //int isValidated = 1;
            foreach (DataGridViewRow row in dg_Validate.Rows)
            {

                if (bool.TryParse(row.Cells[3].Value.ToString(), out validate) == true)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;

                }
            }

        }

        private void txt_Validate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Check_Click(this, new EventArgs());
            }
        }
    }
}
