using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab02_02
{
    public partial class frmQLSV : Form
    {
        public frmQLSV()
        {
            InitializeComponent();
        }
        private int GetSelectedRow(string studentID)
        {
            for (int i = 0; i < dgvStudent.Rows.Count; i++)
            {
                if (dgvStudent.Rows[i].Cells[0].Value != null &&
                    dgvStudent.Rows[i].Cells[0].Value.ToString() == studentID)
                {
                    return i;
                }
            }
            return -1;
        }
        private void InsertUpdate(int selectedRow)
        {
            dgvStudent.Rows[selectedRow].Cells[0].Value = txtStudentID.Text;
            dgvStudent.Rows[selectedRow].Cells[1].Value = txtFullName.Text;
            dgvStudent.Rows[selectedRow].Cells[2].Value = optFemale.Checked ? "Nữ" : "Nam";
            dgvStudent.Rows[selectedRow].Cells[3].Value = float.Parse(txtAverageScore.Text);
            dgvStudent.Rows[selectedRow].Cells[4].Value = cmbFaculty.Text;
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void frmQLSV_Load(object sender, EventArgs e)
        {
            cmbFaculty.Items.Add("QTKD");
            cmbFaculty.Items.Add("CNTT");
            cmbFaculty.Items.Add("NNA");
            cmbFaculty.SelectedIndex = 0;

            optFemale.Checked = true;

            dgvStudent.ColumnCount = 5;
            dgvStudent.Columns[0].Name = "MSSV";
            dgvStudent.Columns[1].Name = "Họ Tên";
            dgvStudent.Columns[2].Name = "Giới Tính";
            dgvStudent.Columns[3].Name = "ĐTB";
            dgvStudent.Columns[4].Name = "Khoa";

            dgvStudent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudent.CellClick += dgvStudent_CellClick;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtStudentID.Text == "" || txtFullName.Text == "" || txtAverageScore.Text == "")
                    throw new Exception("Vui lòng nhập đầy đủ thông tin sinh viên!");

                // Kiểm tra điểm hợp lệ
                if (!float.TryParse(txtAverageScore.Text, out float avg))
                    throw new Exception("Điểm trung bình phải là số!");

                int selectedRow = GetSelectedRow(txtStudentID.Text);

                if (selectedRow == -1)
                {
                    selectedRow = dgvStudent.Rows.Add();
                    InsertUpdate(selectedRow);
                    MessageBox.Show("Thêm mới dữ liệu thành công!", "Thông Báo");
                }
                else
                {
                    InsertUpdate(selectedRow);
                    MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông Báo");
                }

                UpdateGenderCount(); // 🔥 Đếm lại nam – nữ
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedRow = GetSelectedRow(txtStudentID.Text);

                if (selectedRow == -1)
                    throw new Exception("Không tìm thấy MSSV cần xóa!");

                DialogResult dr = MessageBox.Show("Bạn có muốn xóa?", "YES/NO", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    dgvStudent.Rows.RemoveAt(selectedRow);
                    MessageBox.Show("Xóa sinh viên thành công!", "Thông Báo");

                    UpdateGenderCount(); // 🔥 Đếm lại số Nam – Nữ
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // đảm bảo click không phải header
            {
                txtStudentID.Text = dgvStudent.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtFullName.Text = dgvStudent.Rows[e.RowIndex].Cells[1].Value.ToString();

                string gender = dgvStudent.Rows[e.RowIndex].Cells[2].Value.ToString();
                if (gender == "Nữ")
                    optFemale.Checked = true;
                else
                    optMale.Checked = true;

                txtAverageScore.Text = dgvStudent.Rows[e.RowIndex].Cells[3].Value.ToString();
                cmbFaculty.Text = dgvStudent.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }
       private void UpdateGenderCount()
{
    int male = 0, female = 0;

    for (int i = 0; i < dgvStudent.Rows.Count; i++)
    {
        var value = dgvStudent.Rows[i].Cells[2].Value;
        if (value != null)
        {
            if (value.ToString() == "Nam")
                male++;
            else if (value.ToString() == "Nữ")
                female++;
        }
    }

    txtMale.Text = male.ToString();
    txtFeMale.Text = female.ToString();
}
    }
}
