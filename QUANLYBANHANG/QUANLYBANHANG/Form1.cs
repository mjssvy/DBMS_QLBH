using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYBANHANG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qTHCSDLDataSet.DonHangBan' table. You can move, or remove it, as needed.
            this.donHangBanTableAdapter.Fill(this.qTHCSDLDataSet.DonHangBan);
            // TODO: This line of code loads data into the 'qTHCSDLDataSet.ChiTietDonHang' table. You can move, or remove it, as needed.
            this.chiTietDonHangTableAdapter.Fill(this.qTHCSDLDataSet.ChiTietDonHang);
            // TODO: This line of code loads data into the 'qTHCSDLDataSet.HangHoa' table. You can move, or remove it, as needed.
            this.hangHoaTableAdapter.Fill(this.qTHCSDLDataSet.HangHoa);

        }
    }
}
