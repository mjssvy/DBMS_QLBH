using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QUANLYBANHANG
{
    public partial class Form1 : Form
    {
        private SqlConnection con = new SqlConnection("Data Source=TRAMY_PC;Initial Catalog=LTCS;Integrated Security=True");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeData();
            LoadData();
        }

        private void InitializeData()
        {
            try
            {
                // Gắn sự kiện cho bảng HangHoa
                lAB3DataSet.HangHoa.RowChanged += HangHoaTable_RowChanged;

                // Gắn sự kiện cho bảng ChiTietDonHangBan
                lAB3DataSet.ChiTietDonHangBan.RowChanged += ChiTietDonHangTable_RowChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing data: " + ex.Message);
            }
        }

        private void LoadData()
        {
            try
            {
                this.donHangBanTableAdapter1.Fill(this.lAB3DataSet.DonHangBan);
                this.chiTietDonHangBanTableAdapter.Fill(this.lAB3DataSet.ChiTietDonHangBan);
                this.hangHoaTableAdapter1.Fill(this.lAB3DataSet.HangHoa);
                BindData();
                BindData1();

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
                dgv_Sach.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error binding data: " + ex.Message);
            }
        }
        private void BindData1()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [ChiTietDonHangBan]", con);
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
        private bool updatingData = false;

        private void HangHoaTable_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            try
            {
                if (updatingData)
                    return;

                string maHang = e.Row["MaHang"].ToString();

                foreach (DataRow row in lAB3DataSet.ChiTietDonHangBan.Rows)
                {
                    if (row.RowState != DataRowState.Deleted && row["MaHang"].ToString() == maHang)
                    {
                        updatingData = true; // Đặt biến đánh dấu

                        row["GiaMua"] = e.Row["GiaMua"];
                        row["GiaBan"] = e.Row["GiaBan"];
                        // Cập nhật các cột khác tùy theo cấu trúc của bảng ChiTietDonHangBan

                        updatingData = false; // Đặt lại biến đánh dấu
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating ChiTietDonHangBan: " + ex.Message);
            }
        }
        private void ChiTietDonHangTable_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            try
            {
                if (updatingData)
                    return;

                string maHang = e.Row["MaHang"].ToString();

                foreach (DataRow row in lAB3DataSet.HangHoa.Rows)
                {
                    if (row.RowState != DataRowState.Deleted && row["MaHang"].ToString() == maHang)
                    {
                        updatingData = true; // Đặt biến đánh dấu

                        row["GiaMua"] = e.Row["GiaMua"];
                        row["GiaBan"] = e.Row["GiaBan"];
                        // Cập nhật các cột khác tùy theo cấu trúc của bảng HangHoa

                        updatingData = false; // Đặt lại biến đánh dấu
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating HangHoa: " + ex.Message);
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
        {//UPDATE
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
            txb_MaSach.Text = dgv_Sach.Rows[e.RowIndex].Cells["maHangDataGridViewTextBoxColumn"].Value.ToString();
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

        private void btn_XoaSach_Click(object sender, EventArgs e)
        {//XOA
            if (!string.IsNullOrEmpty(txb_MaSach.Text))
            { // Kiểm tra xem ID có tồn tại trong cơ sở dữ liệu không
                con.Open();
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM [HangHoa] WHERE MaHang = '" + txb_MaSach.Text + "'", con);
                int count = (int)checkCmd.ExecuteScalar();
                con.Close();
                if (count > 0)
                {// ID tồn tại, thực hiện xóa
                    con.Open();
                    SqlCommand deleteCmd = new SqlCommand("DELETE FROM [HangHoa] WHERE MaHang='" + txb_MaSach.Text + "'", con);
                    deleteCmd.ExecuteNonQuery();
                    MessageBox.Show("Delete successfully");
                    con.Close();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("ID không tồn tại trong cơ sở dữ liệu");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bản ghi để xóa");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddBill();
        }
        private void AddBill()
        {
            try
            {
                con.Open();
                string query = "INSERT INTO [ChiTietDonHangBan] (MaChiTiet, MaDH, MaHang, GiaMua, GiaBan, SoLuong, ThanhTien) " +
                               "VALUES (@MaChiTiet, @MaDH, @MaHang,  @GiaMua, @GiaBan, @SoLuong,  @ThanhTien)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@MaChiTiet", txb_bdid.Text);
                cmd.Parameters.AddWithValue("@MaDH", textBox7.Text);
                cmd.Parameters.AddWithValue("@MaHang", textBox8.Text);
                cmd.Parameters.AddWithValue("@GiaMua", txb_muab.Text);
                cmd.Parameters.AddWithValue("@GiaBan", txb_banb.Text);
                cmd.Parameters.AddWithValue("@SoLuong", txb_num.Text);
                cmd.Parameters.AddWithValue("@ThanhTien", textBox2.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Bill detail added successfully!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding bill: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            txb_bdid.Text = dataGridView1.Rows[e.RowIndex].Cells["maChiTietDataGridViewTextBoxColumn"].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells["maDHDataGridViewTextBoxColumn"].Value.ToString();
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells["maHangDataGridViewTextBoxColumn1"].Value.ToString();
            txb_muab.Text = dataGridView1.Rows[e.RowIndex].Cells["giaMuaDataGridViewTextBoxColumn1"].Value.ToString();
            txb_banb.Text = dataGridView1.Rows[e.RowIndex].Cells["giaBanDataGridViewTextBoxColumn1"].Value.ToString();
            txb_num.Text = dataGridView1.Rows[e.RowIndex].Cells["soLuongDataGridViewTextBoxColumn"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["thanhTienDataGridViewTextBoxColumn"].Value.ToString();

        }
        private void UpdateBill()
        {//UPDATE
            try
            {
                con.Open();
                string query = "UPDATE [ChiTietDonHangBan] SET MaChiTiet = @MaChiTiet, MaDH = @MaDH, MaHang = @MaHang, GiaMua = @GiaMua, " +
                               "GiaBan = @GiaBan, SoLuong = @SoLuong, ThanhTien = @ThanhTien WHERE MaChiTiet = @MaChiTiet";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@MaChiTiet", txb_bdid.Text);
                cmd.Parameters.AddWithValue("@MaDH", textBox7.Text);
                cmd.Parameters.AddWithValue("@MaHang", textBox8.Text);
                cmd.Parameters.AddWithValue("@GiaMua", txb_muab.Text);
                cmd.Parameters.AddWithValue("@GiaBan", txb_banb.Text);
                cmd.Parameters.AddWithValue("@SoLuong", txb_num.Text);
                cmd.Parameters.AddWithValue("@ThanhTien", textBox2.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Bill updated successfully!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating bill: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateBill();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //XOA
            if (!string.IsNullOrEmpty(txb_bdid.Text))
            { // Kiểm tra xem ID có tồn tại trong cơ sở dữ liệu không
                con.Open();
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM [ChiTietDonHangBan] WHERE MaChiTiet = '" + txb_bdid.Text + "'", con);
                int count = (int)checkCmd.ExecuteScalar();
                con.Close();
                if (count > 0)
                {// ID tồn tại, thực hiện xóa
                    con.Open();
                    SqlCommand deleteCmd = new SqlCommand("DELETE FROM [ChiTietDonHangBan] WHERE MaChiTiet='" + txb_bdid.Text + "'", con);
                    deleteCmd.ExecuteNonQuery();
                    MessageBox.Show("Delete successfully");
                    con.Close();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("ID không tồn tại trong cơ sở dữ liệu");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bản ghi để xóa");
            }
        }
    }
}
