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
    public partial class frmYonetici : Form
    {
        public frmYonetici()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cGenel gnl = new cGenel();
            cyonetici p = new cyonetici();
            bool result = p.PersonelEntryControl(txtSifre.Text, cGenel._yoneticiId);
            if (result)
            {
                this.Hide();
                frmAyarlar menu = new frmAyarlar();
                menu.Show();
            }
            else
            {
                MessageBox.Show("Şifreniz Yanlış", "Uyarı !!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void cbKullanici_SelectedIndexChanged(object sender, EventArgs e)
        {
            cyonetici p = (cyonetici)cbKullanici.SelectedItem;
            cGenel._yoneticiId = p.yoneticiId;
        }

        private void frmYonetici_Load(object sender, EventArgs e)
        {
            cyonetici p = new cyonetici();
            p.yoneticiGetbyInformation(cbKullanici);
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 menu = new Form1();
            menu.Show();
        }

        private void txtSifre_TextChanged(object sender, EventArgs e)
        {

        }


        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            {
                //checkBox işaretli ise
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
    }
