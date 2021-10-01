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
    public partial class frmKullanici : Form
    {
        public frmKullanici()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmGiris menu = new frmGiris();
            menu.Show();
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmKayit menu = new frmKayit();
            menu.Show();
        }
    }
}
