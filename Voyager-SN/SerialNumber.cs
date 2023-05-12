using Seagull.BarTender.Print;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Zero_SN
{
    public partial class SerialNumber : Form
    {
        WorkOrder wo = new WorkOrder();
        PN pn = new PN();
        Inprocess inprocess = new Inprocess();
        User user = new User();
        Config config = new Config();
        int id_conse;

        public SerialNumber()
        {
            InitializeComponent();
        }

        private void RefreshWOInfo()
        {
            wo.Id_wo = int.Parse(wo.ReturnID("select id_wo from tb_wo where wo = '" + wo.Wo + "'"));

            dg_SN.DataSource = wo.LlenarDG("select SerialNumber, wo.wo, RegSN as 'Print Date', replace(Printed,1,'Printed') AS 'Print', replace(PrintAgain,1,'2do-Print') AS 'Print Again' from tb_Inprocess inp join tb_WO wo on inp.id_wo = wo.id_wo where Scrap = 0 or Scrap is null and wo.id_wo = '" + wo.Id_wo + "'").Tables[0];
            //label1.Text = DateTime.Now.ToString("yy" + WeekNumber());
            lbl_print.Text = wo.ReturnValue("select count(*) from tb_Inprocess where id_wo = '" + wo.Id_wo + "' and Printed != 0 and Scrap is null or Scrap = 0");
            wo.Qty = int.Parse(wo.ReturnValue("select qty from tb_WO where id_wo = '" + wo.Id_wo + "' "));
            //wo.Qty = int.Parse(wo.ReturnValue("select qty from tb_WO where id_wo = 8 "));
            //wo.QtyReq = int.Parse(this.wo.ReturnValue("select qtyReq from tb_WO where id_wo = '" + wo.Id_wo + "' "));
            wo.QtyReq = int.Parse(lbl_print.Text);
            wo.Crud("update tb_WO set qtyReq = '" + wo.QtyReq + "' where id_wo = '" + wo.Id_wo + "'");

            lbl_Records.Text = wo.ReturnValue("select count(*) from tb_Inprocess where id_wo = '" + wo.Id_wo + "'");
            lbl_WO.Text = wo.Wo.ToString();
            //lbl_LP.Text = wo.ReturnValue("select count(*) from tb_Inprocess where Printed = 0 or Printed is null and id_wo = '" + wo.Id_wo + "'");
            lbl_LP.Text = wo.Qty.ToString();
            lbl_Idemploy.Text = user.ReturnValue("select nemploy from tb_User where id_user = '" + user.Id_user + "'");
            pn.Pn = wo.ReturnValue("select pn from tb_WO wo join tb_PN pn on wo.id_pn = pn.id_pn where id_wo = '" + wo.Id_wo + "'");
            pn.Rev = wo.ReturnValue("select rev from tb_WO wo join tb_PN pn on wo.id_pn = pn.id_pn where id_wo = '" + wo.Id_wo + "'");

            lbl_pn.Text = pn.Pn;

            config.Printer = config.ReturnValue("select printer from tb_Config");

            if (wo.Qty == int.Parse(inprocess.ReturnValue("select count(*) from tb_Inprocess where Printed is not null and id_wo = '" + wo.Id_wo + "'")) && wo.Qty != int.Parse(inprocess.ReturnValue("select count(*) from tb_Inprocess where PrintAgain is not null and id_wo = '" + wo.Id_wo + "'")))
            {
                btn_PrintAgain.Visible = true;
                btn_Generate.Enabled = false;
            }
            else
                btn_PrintAgain.Visible = false;
        }

        public static Form IsFormAlreadyOpen(Type formType)
        {
            return Application.OpenForms.Cast<Form>().FirstOrDefault(openForm => openForm.GetType() == formType);
        }

        private void SerialNumber_Load(object sender, EventArgs e)
        {

            RefreshWOInfo();

        }

        public string GetIso8601WeekOfYear(DateTime time)
        {
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).ToString().PadLeft(2, '0');
        }


        private void btn_Generate_Click(object sender, EventArgs e)
        {
            this.btn_Generate.Enabled = false;

            try
            {
                Thread threadInput = new Thread(DisplayData);
                threadInput.Start();

                //SerialNumber_Load(sender, e);
                //txt_Qty.Text = "";
            }
            catch (Exception ex)
            {

                DisplayError(ex);
            }

        }

        private void SP_GenerateSN(string wo, int top)
        {
            Conexion con = new Conexion();

            //string dateToday = DateTime.Now.ToString("yy" + GetIso8601WeekOfYear(DateTime.Now));
            //string date = DateTime.Now.ToString("yy" + WeekNumber());

            if (pn.Pn == "46-08453")
                id_conse = 2;
            else
                id_conse = 1;

            try
            {
                con.Abrir();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("sp_SnLabels", con.Con1);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@WO", wo);
                cmd.Parameters.AddWithValue("@top", top);
                cmd.Parameters.AddWithValue("@date", (DateTime.Now.ToString("yy" + GetIso8601WeekOfYear(DateTime.Now))));
                cmd.Parameters.AddWithValue("@id_user", user.Id_user);
                cmd.Parameters.AddWithValue("@id_conse", id_conse);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Cerrar();
                this.wo.QtyReq = int.Parse(this.wo.ReturnValue("select qtyReq from tb_WO where id_wo = '" + this.wo.Id_wo + "'"));
            }
        }

        private void PrintLabels()
        {
            inprocess.SerialNumber = inprocess.ReturnValue("select top 1 SerialNumber from tb_Inprocess where Printed is null and id_wo = '" + wo.Id_wo + "' ORDER BY id_inprocess ASC");
            DefaultPrinter();


            //SerialNumber_Load(sender, e);
            //txt_ToPrint.Text = "";
            MessageBox.Show("Printing labels completed!");
            //MessageBox.Show(count.ToString());
        }



        private void btn_Reprint_Click(object sender, EventArgs e)
        {
            Authenticate_Reprint no = new Authenticate_Reprint();

            Form sn;
            if ((sn = IsFormAlreadyOpen(typeof(Authenticate_Reprint))) == null)
            {
                no.ShowDialog(this);
            }

            else
            {
                sn.WindowState = FormWindowState.Normal;
                sn.BringToFront();
            }
        }


        private void DefaultPrinter()
        {
            using (Engine engine = new Engine())
            {
                engine.Start();
                LabelFormatDocument format = engine.ActiveDocument;


                if (pn.Pn == "40-08238")
                    format = engine.Documents.Open(@"\\mex-fss-001\labels$\Zero Motocycle\40-08238.btw");
                else if (pn.Pn == "40-08238")
                    format = engine.Documents.Open(@"\\mex-fss-001\labels$\Zero Motocycle\40-08238-01.btw");
                else
                    format = engine.Documents.Open(@"\\mex-fss-001\labels$\Zero Motocycle\Zero.btw");



                //format.PrintSetup.PrinterName = @"Microsoft Print to PDF";

                format.PrintSetup.PrinterName = @"\\MEX-BAR-001\" + config.Printer;



                int Toprint = int.Parse(txt_Qty.Text);
                format.PrintSetup.NumberOfSerializedLabels = Toprint;
                //format.SubStrings["MFG"].Value = "MEM";
                //format.SubStrings["DC"].Value = (DateTime.Now.ToString("yy" + GetIso8601WeekOfYear(DateTime.Now);
                inprocess.SerialNumber = inprocess.ReturnValue("select top 1 SerialNumber from tb_Inprocess where Printed is null and id_wo = '" + wo.Id_wo + "' ORDER BY id_inprocess ASC");
                format.SubStrings["SN"].Value = inprocess.SerialNumber;

                for (int i = 0; i < Toprint; i++)
                {
                    inprocess.SerialNumber = inprocess.ReturnValue("select top 1 SerialNumber from tb_Inprocess where Printed is null and id_wo = '" + wo.Id_wo + "' ORDER BY id_inprocess ASC");
                    inprocess.Id_inprocess = int.Parse(inprocess.ReturnValue("select top 1 id_inprocess from tb_Inprocess where Printed is null and id_wo = '" + wo.Id_wo + "' ORDER BY id_inprocess ASC"));

                    inprocess.Crud("update tb_Inprocess set Printed = 1 where id_inprocess = '" + inprocess.Id_inprocess + "'");
                }

                //format.Print();

                engine.Stop();

            }
            btn_Generate.Invoke((Action)delegate
            {
                btn_Generate.Enabled = true;
            });
        }

        private void PrintAgain()
        {
            using (Engine engine = new Engine())
            {
                engine.Start();
                LabelFormatDocument format = engine.ActiveDocument;

                if (pn.Pn == "40-08238")
                    format = engine.Documents.Open(@"\\mex-fss-001\labels$\Zero Motocycle\40-08238.btw");
                else if (pn.Pn == "40-08238")
                    format = engine.Documents.Open(@"\\mex-fss-001\labels$\Zero Motocycle\40-08238-01.btw");
                else
                    format = engine.Documents.Open(@"\\mex-fss-001\labels$\Zero Motocycle\Zero.btw");



                //format.PrintSetup.PrinterName = @"Microsoft Print to PDF";
                format.PrintSetup.PrinterName = @"\\MEX-BAR-001\" + config.Printer;



                int Toprint = int.Parse(txt_Qty.Text);
                format.PrintSetup.NumberOfSerializedLabels = Toprint;
                //format.SubStrings["MFG"].Value = "MEM";
                //format.SubStrings["DC"].Value = (DateTime.Now.ToString("yy" + GetIso8601WeekOfYear(DateTime.Now);
                //inprocess.SerialNumber = inprocess.ReturnValue("select top 1 SerialNumber from tb_Inprocess where Printed is not null and id_wo = '" + wo.Id_wo + "' ORDER BY id_inprocess ASC");
                inprocess.SerialNumber = inprocess.ReturnValue("select top 1 SerialNumber from tb_Inprocess where PrintAgain is null and id_wo = '" + wo.Id_wo + "' ORDER BY id_inprocess ASC");

                format.SubStrings["SN"].Value = inprocess.SerialNumber;

                for (int i = 0; i < Toprint; i++)
                {

                    inprocess.SerialNumber = inprocess.ReturnValue("select top 1 SerialNumber from tb_Inprocess where PrintAgain is null and id_wo = '" + wo.Id_wo + "' ORDER BY id_inprocess ASC");
                    inprocess.Id_inprocess = int.Parse(inprocess.ReturnValue("select top 1 id_inprocess from tb_Inprocess where PrintAgain is null and id_wo = '" + wo.Id_wo + "' ORDER BY id_inprocess ASC"));

                    inprocess.Crud("update tb_Inprocess set PrintAgain = 1 where id_inprocess = '" + inprocess.Id_inprocess + "'");

                }

                format.Print();

                engine.Stop();

            }
            btn_PrintAgain.Invoke((Action)delegate
            {
                btn_PrintAgain.Enabled = true;
            });
        }

        private void ValidateSN()
        {

            //YYWWSSXnnnnn
            List<Inprocess> listSN = new List<Inprocess>();
            DataTable dtSN = new DataTable();

            dtSN = inprocess.LlenarDG("select top 1 SerialNumber from tb_Inprocess where id_wo = '" + wo.Id_wo + "' ORDER BY id_inprocess ASC").Tables[0];

            foreach (var sn in dtSN.Rows)
            {



            }

            if (inprocess.SerialNumber.Length == 12)
            {

            }
        }
        private void lbl_Idemploy_Click(object sender, EventArgs e)
        {

        }

        private void DisplayData()
        {
            SetLoading(true);

            // Added to see the indicator (not required)
            //Thread.Sleep(4000);

            if (wo.QtyReq + int.Parse(txt_Qty.Text) <= wo.Qty && int.Parse(txt_Qty.Text) > 0)
            {

                SP_GenerateSN(wo.Wo, int.Parse(txt_Qty.Text));
                PrintLabels();

                txt_Qty.Invoke((Action)delegate
                {
                    txt_Qty.Text = "";
                    RefreshWOInfo();
                    //SerialNumber_Load(sender, e);
                    txt_Qty.Text = "";
                });


            }
            else
            {
                MessageBox.Show("Cannot generates zero or more Serial number than the WO Quantity!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }


            SetLoading(false);
        }

        private void SetLoading(bool displayLoader)
        {
            if (displayLoader)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    picLoader.Visible = true;
                    this.Cursor = Cursors.WaitCursor;
                });
            }
            else
            {
                this.Invoke((MethodInvoker)delegate
                {
                    picLoader.Visible = false;
                    this.Cursor = Cursors.Default;
                });
            }
        }

        private void DisplayError(Exception ex)
        {
            MessageBox.Show("The below error occurred while processing the request: \n\r \n\r" + ex.Message);
        }

        private void btn_PrintAgain_Click(object sender, EventArgs e)
        {
            PrintAgain();


            txt_Qty.Text = "";
            RefreshWOInfo();
            //this.btn_PrintAgain.Enabled = false;

            //try
            //{
            //    Thread threadInput = new Thread(DisplayData2);
            //    threadInput.Start();

            //    //SerialNumber_Load(sender, e);
            //    //txt_Qty.Text = "";
            //}
            //catch (Exception ex)
            //{

            //    DisplayError(ex);
            //}
        }
        private void DisplayData2()
        {
            SetLoading(true);

            // Added to see the indicator (not required)
            //Thread.Sleep(4000);

            if (wo.QtyReq + int.Parse(txt_Qty.Text) <= wo.Qty && int.Parse(txt_Qty.Text) > 0)
            {

                //SP_GenerateSN(wo.Wo, int.Parse(txt_Qty.Text));
                PrintAgain();

                txt_Qty.Invoke((Action)delegate
                {
                    txt_Qty.Text = "";
                    RefreshWOInfo();
                    //SerialNumber_Load(sender, e);
                    txt_Qty.Text = "";
                });


            }
            else
            {
                MessageBox.Show("Cannot generates zero or more Serial number than the WO Quantity!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }


            SetLoading(false);
        }
    }
}
