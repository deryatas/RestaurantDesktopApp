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
    public partial class frmAyarlar : Form
    {
        public frmAyarlar()
        {
            InitializeComponent();
        }

        private void btnMasa_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMasalar menu = new frmMasalar();
            menu.Show();
        }

        private void btnMusteri_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMusteriler menu = new frmMusteriler();
            menu.Show();
        }

        private void btnRezervasyon_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmRezervasyon menu = new frmRezervasyon();
            menu.Show();
        }

        private void btnKasa_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmKasa menu = new frmKasa();
            menu.Show();
        }

        private void btnMutfak_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMutfak menu = new frmMutfak();
            menu.Show();
        }

        private void btnPersonelDurum_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmPersonelDurum menu = new frmPersonelDurum();
            menu.Show();
        }

        private void btnPaketSiparis_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMusteriSiparis menu = new frmMusteriSiparis();
            menu.Show();
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
    }
}
