
namespace Proje
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnKullanici = new System.Windows.Forms.Button();
            this.btnYonetici = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnKullanici
            // 
            this.btnKullanici.BackgroundImage = global::Proje.Properties.Resources.MÜŞTERİ__10_;
            this.btnKullanici.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKullanici.Font = new System.Drawing.Font("Elephant", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKullanici.ForeColor = System.Drawing.Color.Black;
            this.btnKullanici.Location = new System.Drawing.Point(377, 358);
            this.btnKullanici.Name = "btnKullanici";
            this.btnKullanici.Size = new System.Drawing.Size(248, 184);
            this.btnKullanici.TabIndex = 1;
            this.btnKullanici.Text = "KULLANICI";
            this.btnKullanici.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnKullanici.UseVisualStyleBackColor = true;
            this.btnKullanici.Click += new System.EventHandler(this.btnKullanici_Click);
            // 
            // btnYonetici
            // 
            this.btnYonetici.BackgroundImage = global::Proje.Properties.Resources.MÜŞTERİ__10_;
            this.btnYonetici.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnYonetici.Font = new System.Drawing.Font("Elephant", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYonetici.ForeColor = System.Drawing.Color.Black;
            this.btnYonetici.Location = new System.Drawing.Point(631, 358);
            this.btnYonetici.Name = "btnYonetici";
            this.btnYonetici.Size = new System.Drawing.Size(259, 184);
            this.btnYonetici.TabIndex = 0;
            this.btnYonetici.Text = "YÖNETİCİ";
            this.btnYonetici.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnYonetici.UseVisualStyleBackColor = true;
            this.btnYonetici.Click += new System.EventHandler(this.btnYonetici_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Proje.Properties.Resources.AKDENİZ_RESTORAN;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(446, 87);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(369, 265);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Proje.Properties.Resources.pexels_min_an_1454794;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1280, 545);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnKullanici);
            this.Controls.Add(this.btnYonetici);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnYonetici;
        private System.Windows.Forms.Button btnKullanici;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

