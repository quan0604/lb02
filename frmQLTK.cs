using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab02_04
{
    public partial class frmQLTK : Form
    {
        public frmQLTK()
        {
            InitializeComponent();
        }
        bool KiemTraNhap()
        {
            if (txtSTK.Text == "" || txtTen.Text == "" || txtDiaChi.Text == "" || txtTien.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return false;
            }
            return true;
        }
        void TinhTong()
        {
            long tong = 0;
            foreach (ListViewItem item in lvTaiKhoan.Items)
            {
                tong += long.Parse(item.SubItems[4].Text);
            }
            txtTongTien.Text = tong.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!KiemTraNhap()) return;

            string stk = txtSTK.Text;
            bool found = false;

            foreach (ListViewItem item in lvTaiKhoan.Items)
            {
                if (item.SubItems[1].Text == stk)
                {
                    // Cập nhật
                    item.SubItems[2].Text = txtTen.Text;
                    item.SubItems[3].Text = txtDiaChi.Text;
                    item.SubItems[4].Text = txtTien.Text;

                    found = true;
                    MessageBox.Show("Cập nhật dữ liệu thành công!");
                    break;
                }
            }

            if (!found)
            {
                ListViewItem item = new ListViewItem((lvTaiKhoan.Items.Count + 1).ToString());
                item.SubItems.Add(txtSTK.Text);
                item.SubItems.Add(txtTen.Text);
                item.SubItems.Add(txtDiaChi.Text);
                item.SubItems.Add(txtTien.Text);

                lvTaiKhoan.Items.Add(item);

                MessageBox.Show("Thêm mới dữ liệu thành công!");
            }

            TinhTong();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string stk = txtSTK.Text;
            bool found = false;

            for (int i = 0; i < lvTaiKhoan.Items.Count; i++)
            {
                if (lvTaiKhoan.Items[i].SubItems[1].Text == stk)
                {
                    DialogResult dr = MessageBox.Show(
                        "Bạn có chắc muốn xoá tài khoản này?",
                        "Xác nhận",
                        MessageBoxButtons.YesNo);

                    if (dr == DialogResult.Yes)
                    {
                        lvTaiKhoan.Items.RemoveAt(i);
                        MessageBox.Show("Xóa tài khoản thành công!");

                        // Đánh lại STT
                        for (int j = 0; j < lvTaiKhoan.Items.Count; j++)
                            lvTaiKhoan.Items[j].SubItems[0].Text = (j + 1).ToString();

                        TinhTong();
                    }

                    found = true;
                    break;
                }
            }

            if (!found)
                MessageBox.Show("Không tìm thấy số tài khoản cần xóa!");
        }

        private void lvTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvTaiKhoan.SelectedItems.Count == 0) return;

            ListViewItem item = lvTaiKhoan.SelectedItems[0];

            txtSTK.Text = item.SubItems[1].Text;
            txtTen.Text = item.SubItems[2].Text;
            txtDiaChi.Text = item.SubItems[3].Text;
            txtTien.Text = item.SubItems[4].Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
