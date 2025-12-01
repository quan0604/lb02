using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab02_03
{
    public partial class frmFilm : Form
    {
        public frmFilm()
        {
            InitializeComponent();
        }

        private void frmFilm_Load(object sender, EventArgs e)
        {
            int seatNumber = 1;
            int x = 20, y = 30;

            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    Button btn = new Button();
                    btn.Width = 50;
                    btn.Height = 40;
                    btn.Left = x + col * 55;
                    btn.Top = y + row * 45;
                    btn.Text = seatNumber.ToString();
                    btn.BackColor = Color.White;
                    btn.Click += btnChooseASeat;

                    grpSeats.Controls.Add(btn);
                    seatNumber++;
                }
            }
        }
        private void btnChooseASeat(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn.BackColor == Color.White)
                btn.BackColor = Color.Blue;     // chọn ghế
            else if (btn.BackColor == Color.Blue)
                btn.BackColor = Color.White;    // bỏ chọn
            else if (btn.BackColor == Color.Yellow)
                MessageBox.Show("Ghế đã được bán!");
        }
        private int GetSeatPrice(int seatNum)
        {
            if (seatNum <= 5) return 30000;
            if (seatNum <= 10) return 40000;
            if (seatNum <= 15) return 50000;
            return 80000;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Button btn in grpSeats.Controls)
            {
                if (btn.BackColor == Color.Blue)
                    btn.BackColor = Color.White;
            }

            txtThanhTien.Text = "Thành tiền: 0 đ";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
