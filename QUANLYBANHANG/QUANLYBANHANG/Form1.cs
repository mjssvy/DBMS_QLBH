using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QUANLYBANHANG
{
    public partial class Form1 : Form
    {
        private SqlConnection con = new SqlConnection("Data Source=msi;Initial Catalog=LAB3;Integrated Security=True");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                this.donHangBanTableAdapter1.Fill(this.lAB3DataSet.DonHangBan);
                this.chiTietDonHangBanTableAdapter.Fill(this.lAB3DataSet.ChiTietDonHangBan);
                this.hangHoaTableAdapter1.Fill(this.lAB3DataSet.HangHoa);
                BindData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void BindData()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [HangHoa]", con);
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error binding data: " + ex.Message);
            }
        }

        private void btn_ThemSach_Click(object sender, EventArgs e)
        {
            AddNewBook();
        }

        private void AddNewBook()
        {
            try
            {
                con.Open();
                string query = "INSERT INTO [HangHoa] (MaHang, TenHang, MaNXB, GiaMua, GiaBan, SoLuongTon, NgayCapNhat, GhiChu) " +
                               "VALUES (@MaHang, @TenHang, @MaNXB,  @GiaMua, @GiaBan, @SoLuongTon, @NgayCapNhat, @GhiChu)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@MaHang", txb_MaSach.Text);
                cmd.Parameters.AddWithValue("@TenHang", txb_TenSach.Text);
                cmd.Parameters.AddWithValue("@MaNXB", txb_nxb.Text);
                cmd.Parameters.AddWithValue("@GiaMua", txb_mua.Text); 
                cmd.Parameters.AddWithValue("@GiaBan", txb_ban.Text);
                cmd.Parameters.AddWithValue("@SoLuongTon", txb_sl.Text);
                cmd.Parameters.AddWithValue("@NgayCapNhat", dateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@GhiChu", rtb_MoTa.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Book added successfully!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding book: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btn_SuaSach_Click(object sender, EventArgs e)
        {

        }
    }
}
