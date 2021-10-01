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
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
        }

        private void cbKullanici_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ckullanici p = (ckullanici)cbKullanici.SelectedItem;
            cGenel._kullaniciId = p.kullaniciId;
        }

        private void txtSifre_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            cGenel gnl = new cGenel();
            ckullanici p = new ckullanici();
            bool result = p.PersonelEntryControl(txtSifre.Text, cGenel._kullaniciId);
            if (result)
            {
                this.Hide();
                frmKullaniciGiris menu = new frmKullaniciGiris();
                menu.Show();
            }
            else
            {
                MessageBox.Show("Şifreniz Yanlış", "Uyarı !!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void frmGiris_Load(object sender, EventArgs e)
        {

            ckullanici p = new ckullanici();
            p.kullaniciGetbyInformation(cbKullanici);
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 menu = new Form1();
            menu.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                //karakteri göster.
                txtSifre.PasswordChar = '*';
            }
            //değilse karakterlerin yerine * koy.
            else
            {
                txtSifre.PasswordChar = '\0';
            }
        }

       
    }
    }

