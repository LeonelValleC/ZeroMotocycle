using NPOI.HSSF.Record.AutoFilter;
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
    public partial class WO : Form
    {
        WorkOrder wo = new WorkOrder();
        PN pn = new PN();

        public WO()
        {
            InitializeComponent();
        }

        private void WO_Load(object sender, EventArgs e)
        {
            cb_PN.DataSource = pn.LlenarComboBox("select id_pn, pn from tb_PN");
            cb_PN.DisplayMember = "pn";
            cb_PN.ValueMember = "id_pn";
            cb_PN.SelectedValue = -1;


        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            if (cb_PN.SelectedValue != null)
            {
                if (!wo.Existe("select count(*) from tb_WO where wo = '" + txt_WO.Text.Trim() + "'"))
                {
                    wo.Crud("insert into tb_WO(wo,qty,dateReg,id_pn) values('" + txt_WO.Text + "','" + txt_QTY.Text + "','" + DateTime.Now + "','" + cb_PN.SelectedValue + "')");
                    txt_QTY.Text = "";
                    txt_Rev.Text = "";
                    txt_WO.Text = "";
                    cb_PN.SelectedValue = -1;

                    MessageBox.Show("WO Saved!");

                }
                else
                {
                    MessageBox.Show("Already Exist!");
                }
            }
            else
            {
                MessageBox.Show("Don't Found!");
            }

        }

        private void txt_WO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txt_QTY.Text = wo.ReturnFromROI("SELECT * FROM OPENQUERY([VOYAGER], 'select Qty_To_Mfg from WO_v_1 where Wo_Nbr = ''" + txt_WO.Text + "''')");
                txt_Rev.Text = wo.ReturnFromROI("SELECT * FROM OPENQUERY([VOYAGER], 'select Bom_Rev_Level from WO_v_1 where Wo_Nbr = ''" + txt_WO.Text + "''')");
                cb_PN.Text = wo.ReturnFromROI("SELECT left(Part_Nbr,len(Part_Nbr)-3) FROM OPENQUERY([VOYAGER], 'select Part_Nbr from WO_v_1 where Wo_Nbr = ''" + txt_WO.Text + "''')");
            }
        }

        private void btn_Check_Click(object sender, EventArgs e)
        {
            txt_QTY.Text = wo.ReturnFromROI("SELECT * FROM OPENQUERY([VOYAGER], 'select Qty_To_Mfg from WO_v_1 where Wo_Nbr = ''" + txt_WO.Text + "''')");
            txt_Rev.Text = wo.ReturnFromROI("SELECT * FROM OPENQUERY([VOYAGER], 'select Bom_Rev_Level from WO_v_1 where Wo_Nbr = ''" + txt_WO.Text + "''')");
            cb_PN.Text = wo.ReturnFromROI("SELECT left(Part_Nbr,len(Part_Nbr)-3) FROM OPENQUERY([VOYAGER], 'select Part_Nbr from WO_v_1 where Wo_Nbr = ''" + txt_WO.Text + "''')");
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            txt_QTY.Text = "";
            txt_Rev.Text = "";
            txt_WO.Text = "";
            cb_PN.SelectedValue = -1;
        }

        private void WO_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }
    }
}
