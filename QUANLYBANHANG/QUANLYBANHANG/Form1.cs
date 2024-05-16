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
            UpdateBook();
        }
        private void UpdateBook()
        {
            try
            {
                con.Open();
                string query = "UPDATE [HangHoa] SET TenHang = @TenHang, MaNXB = @MaNXB, GiaMua = @GiaMua, GiaBan = @GiaBan, " +
                               "SoLuongTon = @SoLuongTon, NgayCapNhat = @NgayCapNhat, GhiChu = @GhiChu WHERE MaHang = @MaHang";
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
                MessageBox.Show("Book updated successfully!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating book: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private void dgv_Sach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgv_Sach.CurrentRow.Selected = true;
            txb_MaSach.Text= dgv_Sach.Rows[e.RowIndex].Cells["maHangDataGridViewTextBoxColumn"].Value.ToString();
            txb_TenSach.Text = dgv_Sach.Rows[e.RowIndex].Cells["tenHangDataGridViewTextBoxColumn"].Value.ToString();
            txb_nxb.Text = dgv_Sach.Rows[e.RowIndex].Cells["maNXBDataGridViewTextBoxColumn"].Value.ToString();
            txb_mua.Text = dgv_Sach.Rows[e.RowIndex].Cells["giaMuaDataGridViewTextBoxColumn"].Value.ToString();
            txb_ban.Text = dgv_Sach.Rows[e.RowIndex].Cells["giaBanDataGridViewTextBoxColumn"].Value.ToString();
            txb_sl.Text = dgv_Sach.Rows[e.RowIndex].Cells["soLuongTonDataGridViewTextBoxColumn"].Value.ToString();
            if (dgv_Sach.Rows[e.RowIndex].Cells["ngayCapNhatDataGridViewTextBoxColumn"].Value != null)
            {
                dateTimePicker1.Value = Convert.ToDateTime(dgv_Sach.Rows[e.RowIndex].Cells["ngayCapNhatDataGridViewTextBoxColumn"].Value);
            }
            else
            {
                dateTimePicker1.Value = DateTime.Now;
            }

            rtb_MoTa.Text = dgv_Sach.Rows[e.RowIndex].Cells["ghiChuDataGridViewTextBoxColumn"].Value.ToString();

        }
    }
}
