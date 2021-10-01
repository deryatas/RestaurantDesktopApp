using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnKullanici_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmKullanici menu = new frmKullanici();
            menu.Show();
        }
    

        private void btnYonetici_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmYonetici menu = new frmYonetici();
            menu.Show();
        }
    }
}
