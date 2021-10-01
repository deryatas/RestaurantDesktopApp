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
    public partial class frmKullaniciGiris : Form
    {
        public frmKullaniciGiris()
        {
            InitializeComponent();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak istediğinizden eminmisiniz?", "Uyarı..!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 menu = new Form1();
            menu.Show();
        }

        private void btnRezervasyon_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmKullaniciRezervasyon menu = new frmKullaniciRezervasyon();
            menu.Show();
        }

        private void btnSiparis_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmPaketSiparis menu = new frmPaketSiparis();
            menu.Show();
        }
    }
}
