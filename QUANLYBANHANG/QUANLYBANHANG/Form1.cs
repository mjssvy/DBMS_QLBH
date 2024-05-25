using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QUANLYBANHANG
{
    public partial class Form1 : Form
    {
        private SqlConnection con = new SqlConnection("Data Source=KA\\SQLEXPRESS;Initial Catalog=QTHCSDL;Integrated Security=True;");

        public Form1()
        {
            InitializeComponent();
            dgv_Sach.CellEndEdit += dgv_Sach_CellEndEdit;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qTHCSDLDataSet1.DonHangBan' table. You can move, or remove it, as needed.
            this.donHangBanTableAdapter3.Fill(this.qTHCSDLDataSet1.DonHangBan);
            // TODO: This line of code loads data into the 'qTHCSDLDataSet1.ChiTietDonHang' table. You can move, or remove it, as needed.
            this.chiTietDonHangTableAdapter1.Fill(this.qTHCSDLDataSet1.ChiTietDonHang);
            // TODO: This line of code loads data into the 'qTHCSDLDataSet1.HangHoa' table. You can move, or remove it, as needed.
            this.hangHoaTableAdapter3.Fill(this.qTHCSDLDataSet1.HangHoa);
            // TODO: This line of code loads data into the 'qTHCSDLDataSet1.KhachHang' table. You can move, or remove it, as needed.
            this.khachHangTableAdapter.Fill(this.qTHCSDLDataSet1.KhachHang);

            LoadData();
        }
        private void dgv_Sach_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && (e.ColumnIndex == dgv_Sach.Columns["GiaBan"].Index ||
                                    e.ColumnIndex == dgv_Sach.Columns["GiaMua"].Index))
            {
                try
                {
                    string maHang = dgv_Sach.Rows[e.RowIndex].Cells["MaHang"].Value.ToString();
                    decimal giaBan = Convert.ToDecimal(dgv_Sach.Rows[e.RowIndex].Cells["GiaBan"].Value);
                    decimal giaMua = Convert.ToDecimal(dgv_Sach.Rows[e.RowIndex].Cells["GiaMua"].Value);

                    con.Open();

                    // Update HangHoa table
                    string queryHangHoa = "UPDATE [HangHoa] SET GiaBan = @GiaBan, GiaMua = @GiaMua WHERE MaHang = @MaHang";
                    SqlCommand cmdHangHoa = new SqlCommand(queryHangHoa, con);
                    cmdHangHoa.Parameters.AddWithValue("@GiaBan", giaBan);
                    cmdHangHoa.Parameters.AddWithValue("@GiaMua", giaMua);
                    cmdHangHoa.Parameters.AddWithValue("@MaHang", maHang);

                    cmdHangHoa.ExecuteNonQuery();

                    // Update ChiTietDonHangBan table
                    string queryChiTiet = "UPDATE [ChiTietDonHang] SET GiaBan = @GiaBan, GiaMua = @GiaMua WHERE MaHang = @MaHang";
                    SqlCommand cmdChiTiet = new SqlCommand(queryChiTiet, con);
                    cmdChiTiet.Parameters.AddWithValue("@GiaBan", giaBan);
                    cmdChiTiet.Parameters.AddWithValue("@GiaMua", giaMua);
                    cmdChiTiet.Parameters.AddWithValue("@MaHang", maHang);

                    cmdChiTiet.ExecuteNonQuery();

                    LoadData(); // Load lại dữ liệu sau khi cập nhật
                }
                catch (SqlException ex)
                {
                    LoadData(); // Load lại dữ liệu nếu có lỗi
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && (e.ColumnIndex == dataGridView1.Columns["GiaBang"].Index ||
                                    e.ColumnIndex == dataGridView1.Columns["giaMuaDataGridViewTextBoxColumn1"].Index))
            {
                try
                {
                    string maHang = dataGridView1.Rows[e.RowIndex].Cells["maHangDataGridViewTextBoxColumn1"].Value.ToString();
                    decimal giaBan = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["GiaBang"].Value);
                    decimal giaMua = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["giaMuaDataGridViewTextBoxColumn1"].Value);

                    con.Open();

                    // Update HangHoa table
                    string queryHangHoa = "UPDATE [HangHoa] SET GiaBan = @GiaBan, GiaMua = @GiaMua WHERE MaHang = @MaHang";
                    SqlCommand cmdHangHoa = new SqlCommand(queryHangHoa, con);
                    cmdHangHoa.Parameters.AddWithValue("@GiaBan", giaBan);
                    cmdHangHoa.Parameters.AddWithValue("@GiaMua", giaMua);
                    cmdHangHoa.Parameters.AddWithValue("@MaHang", maHang);

                    cmdHangHoa.ExecuteNonQuery();

                    // Update ChiTietDonHangBan table
                    string queryChiTiet = "UPDATE [ChiTietDonHang] SET GiaBan = @GiaBan, GiaMua = @GiaMua WHERE MaHang = @MaHang";
                    SqlCommand cmdChiTiet = new SqlCommand(queryChiTiet, con);
                    cmdChiTiet.Parameters.AddWithValue("@GiaBan", giaBan);
                    cmdChiTiet.Parameters.AddWithValue("@GiaMua", giaMua);
                    cmdChiTiet.Parameters.AddWithValue("@MaHang", maHang);

                    cmdChiTiet.ExecuteNonQuery();

                    LoadData(); // Load lại dữ liệu sau khi cập nhật
                }
                catch (SqlException ex)
                {
                    LoadData(); // Load lại dữ liệu nếu có lỗi
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void LoadData()
        {
            try
            {
                // TODO: This line of code loads data into the 'lTCSDataSet.DonHangBan' table. You can move, or remove it, as needed.
                //this.donHangBanTableAdapter2.Fill(this.lTCSDataSet.DonHangBan);
                // TODO: This line of code loads data into the 'lTCSDataSet.ChiTietDonHangBan' table. You can move, or remove it, as needed.
                //this.chiTietDonHangBanTableAdapter1.Fill(this.lTCSDataSet.ChiTietDonHangBan);
                // TODO: This line of code loads data into the 'lTCSDataSet.HangHoa' table. You can move, or remove it, as needed.
                //this.hangHoaTableAdapter2.Fill(this.lTCSDataSet.HangHoa);
                BindData();
                BindData1();
                BindData3();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }
        private void BindData3()
        {
            try {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [DonHangBan]", con);
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            catch (Exception ex) { }
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
               
            }
        }
        private void BindData1()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [ChiTietDonHang]", con);
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
            Clear();
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
            Clear();
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
                    Clear();
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
            Clear();
        }
        private void AddBill()
        {
            try
            {
                con.Open();
                string query = "INSERT INTO [ChiTietDonHang] (MaChiTiet, MaDH, MaHang, GiaMua, GiaBang, SoLuong, ThanhTien) " +
                               "VALUES (@MaChiTiet, @MaDH, @MaHang,  @GiaMua, @GiaBang, @SoLuong,  @ThanhTien)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@MaChiTiet", txb_bdid.Text);
                cmd.Parameters.AddWithValue("@MaDH", textBox7.Text);
                cmd.Parameters.AddWithValue("@MaHang", textBox8.Text);
                cmd.Parameters.AddWithValue("@GiaMua", txb_muab.Text);
                cmd.Parameters.AddWithValue("@GiaBang", txb_banb.Text);
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
            txb_banb.Text = dataGridView1.Rows[e.RowIndex].Cells["GiaBang"].Value.ToString();
            txb_num.Text = dataGridView1.Rows[e.RowIndex].Cells["soLuongDataGridViewTextBoxColumn"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["thanhTienDataGridViewTextBoxColumn"].Value.ToString();

        }
        private void UpdateBill()
        {//UPDATE
            try
            {
                con.Open();
                string query = "UPDATE [ChiTietDonHang] SET MaChiTiet = @MaChiTiet, MaDH = @MaDH, MaHang = @MaHang, GiaMua = @GiaMua, " +
                               "GiaBang = @GiaBang, SoLuong = @SoLuong, ThanhTien = @ThanhTien WHERE MaChiTiet = @MaChiTiet";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@MaChiTiet", txb_bdid.Text);
                cmd.Parameters.AddWithValue("@MaDH", textBox7.Text);
                cmd.Parameters.AddWithValue("@MaHang", textBox8.Text);
                cmd.Parameters.AddWithValue("@GiaMua", txb_muab.Text);
                cmd.Parameters.AddWithValue("@GiaBang", txb_banb.Text);
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
        private void Clear()
        {
            txb_MaSach.Text = "";
            txb_TenSach.Text = "";
            txb_nxb.Text = "";
            txb_mua.Text = "";
            txb_ban.Text = "";
            txb_sl.Text = "";
            rtb_MoTa.Text = "";
            txb_bdid.Text="";
            textBox7.Text = "";
            textBox8.Text = "";
            txb_muab.Text = "";
            txb_banb.Text = "";
            txb_num.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            UpdateBill();
            Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //XOA
            if (!string.IsNullOrEmpty(txb_bdid.Text))
            { // Kiểm tra xem ID có tồn tại trong cơ sở dữ liệu không
                con.Open();
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM [ChiTietDonHang] WHERE MaChiTiet = '" + txb_bdid.Text + "'", con);
                int count = (int)checkCmd.ExecuteScalar();
                con.Close();
                if (count > 0)
                {// ID tồn tại, thực hiện xóa
                    con.Open();
                    SqlCommand deleteCmd = new SqlCommand("DELETE FROM [ChiTietDonHang] WHERE MaChiTiet='" + txb_bdid.Text + "'", con);
                    deleteCmd.ExecuteNonQuery();
                    MessageBox.Show("Delete successfully");
                    con.Close();
                    LoadData();
                    Clear();
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

        private void dgv_Sach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgv_Hanghoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgv_Sach.CurrentRow.Selected = true;
            txb_MaSach.Text = dgv_Sach.Rows[e.RowIndex].Cells["MaHang"].Value.ToString();
            txb_TenSach.Text = dgv_Sach.Rows[e.RowIndex].Cells["TenHang"].Value.ToString();
            txb_nxb.Text = dgv_Sach.Rows[e.RowIndex].Cells["MaNXB"].Value.ToString();
            txb_mua.Text = dgv_Sach.Rows[e.RowIndex].Cells["GiaMua"].Value.ToString();
            txb_ban.Text = dgv_Sach.Rows[e.RowIndex].Cells["GiaBan"].Value.ToString();
            txb_sl.Text = dgv_Sach.Rows[e.RowIndex].Cells["SoLuongTon"].Value.ToString();
            if (dgv_Sach.Rows[e.RowIndex].Cells["NgayCapNhat"].Value != null)
            {
                dateTimePicker1.Value = Convert.ToDateTime(dgv_Sach.Rows[e.RowIndex].Cells["NgayCapNhat"].Value);
            }
            else
            {
                dateTimePicker1.Value = DateTime.Now;
            }

            rtb_MoTa.Text = dgv_Sach.Rows[e.RowIndex].Cells["GhiChu"].Value.ToString();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.CurrentRow.Selected = true;
            textBox3.Text = dataGridView2.Rows[e.RowIndex].Cells["maDHDataGridViewTextBoxColumn1"].Value.ToString();
            textBox4.Text = dataGridView2.Rows[e.RowIndex].Cells["maNVDataGridViewTextBoxColumn"].Value.ToString();
            textBox5.Text = dataGridView2.Rows[e.RowIndex].Cells["maKHDataGridViewTextBoxColumn"].Value.ToString();
            textBox6.Text = dataGridView2.Rows[e.RowIndex].Cells["tongGiaTriDataGridViewTextBoxColumn"].Value.ToString();
            if (dataGridView2.Rows[e.RowIndex].Cells["ngayDHDataGridViewTextBoxColumn"].Value != null)
            {
                dateTimePicker2.Value = Convert.ToDateTime(dataGridView2.Rows[e.RowIndex].Cells["ngayDHDataGridViewTextBoxColumn"].Value);
            }
            else
            {
                dateTimePicker2.Value = DateTime.Now;
            }
            LoadBillDetail(textBox3.Text);

        }
        private void LoadBillDetail(string maDH)
        {
            // Chuỗi kết nối tới cơ sở dữ liệu
            string connectionString = "Data Source=KA\\SQLEXPRESS;Initial Catalog=QTHCSDL;Integrated Security=True;";

            // Truy vấn lấy dữ liệu từ bảng BillDetail dựa trên maDH
            string query = "SELECT * FROM ChiTietDonHang WHERE maDH = @maDH";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@maDH", maDH);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txb_bdid.Text = reader["maChiTiet"].ToString();
                        textBox7.Text = reader["maDH"].ToString();
                        textBox8.Text = reader["maHang"].ToString();
                        txb_muab.Text = reader["giaMua"].ToString();
                        txb_banb.Text = reader["GiaBang"].ToString();
                        txb_num.Text = reader["soLuong"].ToString();
                        textBox2.Text = reader["thanhTien"].ToString();
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
