using System;
using System.Windows.Forms;

namespace CompareSN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            if (txt_lblBox.Text.Trim() == txt_lblProduct.Text.Trim())
            {
                pictureBox1.Image = CompareSN.Properties.Resources.great;
                txt_lblBox.Text = "";
                txt_lblProduct.Text = "";
                txt_lblBox.Focus();
            }
            else
            {
                pictureBox1.Image = CompareSN.Properties.Resources.bad;
                MessageBox.Show("Check Labels!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Submit_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{ENTER}");
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            txt_lblProduct.Text = "";
            txt_lblBox.Text = "";
        }
    }
}
