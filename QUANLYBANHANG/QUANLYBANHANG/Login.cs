using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYBANHANG
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Chuỗi kết nối tới cơ sở dữ liệu
            string connectionString = "Data Source=KA\\SQLEXPRESS;Initial Catalog=QTHCSDL;Integrated Security=True;";

            // Lấy thông tin từ các input box
            string username = textBox1.Text;
            string password = textBox2.Text;

            // Kiểm tra xem các input box có trống hay không
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.");
                return;
            }

            // Truy vấn cơ sở dữ liệu để kiểm tra thông tin đăng nhập
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM NhanVien WHERE TaiKhoan = @Username AND MatKhau = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                try
                {
                    connection.Open();
                    int userCount = (int)command.ExecuteScalar();

                    if (userCount > 0)
                    {
                        // Thông tin đăng nhập hợp lệ
                        MessageBox.Show("Đăng nhập thành công!");
                        Form1 form1 = new Form1();

                        form1.ShowDialog();
               
                        // Chuyển đến form chính hoặc thực hiện các hành động khác sau khi đăng nhập thành công
                    }
                    else
                    {
                        // Thông tin đăng nhập không hợp lệ
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                }
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hãy liên hệ với Phòng quản lý");
        }

        private void trợGiúpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hãy liên hệ với Phòng quản lý");
        }

        private void tácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TG tg = new TG();
            tg.ShowDialog();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
