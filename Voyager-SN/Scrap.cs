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
    public partial class Scrap : Form
    {
        WorkOrder wo = new WorkOrder();
        PN pn = new PN();
        Inprocess inprocess = new Inprocess();
        User user = new User();

        public Scrap()
        {
            InitializeComponent();
        }

        private void Scrap_Load(object sender, EventArgs e)
        {
            wo.Id_wo = int.Parse(wo.ReturnID("select id_wo from tb_WO where wo = '" + wo.Wo + "'"));
            lbl_WO.Text = wo.Wo;
            dg_Reprint.DataSource = wo.LlenarDG("select id_inprocess,SerialNumber from tb_Inprocess where Scrap = 0 or Scrap is null and id_wo = '" + wo.Id_wo + "'").Tables[0];
            dg_Reprint.Columns[1].Visible = false;

        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Are you sure?", "Warning", MessageBoxButtons.YesNo);
            if (MessageBox.Show("Are you sure?", "WARNING", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                List<string> list = new List<string>();

                foreach (DataGridViewRow row in this.dg_Reprint.Rows)
                {
                    // if a cell has never choosed so it is null 
                    if ((row.Cells[0].Value) == null)
                        continue;

                    if (((bool)row.Cells[0].Value == true))
                    {

                        list.Add(row.Cells[1].Value.ToString());

                        //inprocess.SerialNumber = row.Cells[1].Value.ToString();
                        inprocess.Id_inprocess = int.Parse(row.Cells[1].Value.ToString());
                        Scraping();
                        //list.Add(new Customer()
                        //{
                        //    FirstName = (string)row.Cells["FirstName"].Value,
                        //    LastName = (string)row.Cells["LastName"].Value
                        //};
                    }
                }
            }
        }

        private void Scraping()
        {
            inprocess.Crud("update tb_Inprocess set Scrap = 1 where id_inprocess = '" + inprocess.Id_inprocess + "'");
            inprocess.Crud("insert into tb_LogScrap values('" + user.Id_user + "','" + DateTime.Now + "','" + inprocess.Id_inprocess + "')");
        }
    }
}
