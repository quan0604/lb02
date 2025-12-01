using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab02_01
{
    public partial class frmMayTinh : Form
    {
        public frmMayTinh()
        {
            InitializeComponent();
        }
        private double GetNumber(string text)
        {
            return double.Parse(text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!KiemTraSoHopLe(txtNum1, "Number 1", out double a)) return;
                if (!KiemTraSoHopLe(txtNum2, "Number 2", out double b)) return;

                txtAnswer.Text = (a + b).ToString();
            }
            finally
            {
                txtAnswer.BackColor = Color.LightYellow;
            }
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            try
            {
                if (!KiemTraSoHopLe(txtNum1, "Number 1", out double a)) return;
                if (!KiemTraSoHopLe(txtNum2, "Number 2", out double b)) return;

                txtAnswer.Text = (a - b).ToString();
            }
            finally
            {
                txtAnswer.BackColor = Color.LightYellow;
            }
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            try
            {
                if (!KiemTraSoHopLe(txtNum1, "Number 1", out double a)) return;
                if (!KiemTraSoHopLe(txtNum2, "Number 2", out double b)) return;

                txtAnswer.Text = (a * b).ToString();
            }
            finally
            {
                txtAnswer.BackColor = Color.LightYellow;
            }
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            try
            {
                if (!KiemTraSoHopLe(txtNum1, "Number 1", out double a)) return;
                if (!KiemTraSoHopLe(txtNum2, "Number 2", out double b)) return;

                if (b == 0)
                {
                    MessageBox.Show("Không thể chia cho 0!", "Lỗi tính toán");
                    txtNum2.Focus();
                    return;
                }

                txtAnswer.Text = (a / b).ToString();
            }
            finally
            {
                txtAnswer.BackColor = Color.LightYellow;
            }
        }
        private bool KiemTraSoHopLe(TextBox txt, string tenTruong, out double giaTri)
        {
            giaTri = 0;

            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                MessageBox.Show($"{tenTruong} không được để trống!", "Lỗi nhập liệu");
                txt.Focus();
                return false;
            }
            if (!double.TryParse(txt.Text, out giaTri))
            {
                MessageBox.Show($"{tenTruong} phải là số nguyên, số âm, hoặc số thập phân hợp lệ!", "Lỗi nhập liệu");
                txt.Focus();
                return false;
            }

            return true;
        }
    }
}
