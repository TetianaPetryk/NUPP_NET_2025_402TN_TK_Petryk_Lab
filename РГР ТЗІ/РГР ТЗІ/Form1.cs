using System;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace РГР_ТЗІ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(230, 220, 255);
            this.Font = new Font("Times New Roman", 10);
            btnEncrypt.BackColor = Color.White;
;
            btnDecrypt.BackColor = Color.White;

            btnEncrypt.ForeColor = Color.Black;
            btnDecrypt.ForeColor = Color.Black;

        }
        // ======== ПРОСТЕ ГАММУВАННЯ XOR ========

        private byte[] XorEncrypt(byte[] data, byte[] key)
        {
            byte[] result = new byte[data.Length];
            for (int i = 0; i < data.Length; i++)
                result[i] = (byte)(data[i] ^ key[i % key.Length]);
            return result;
        }

        private byte[] XorDecrypt(byte[] data, byte[] key)
        {
            return XorEncrypt(data, key);
        }

        // ======== DES ШИФРУВАННЯ ========

        private byte[] DesEncrypt(byte[] data, string key)
        {
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = Encoding.UTF8.GetBytes(key);
                des.IV = Encoding.UTF8.GetBytes(key);

                using (ICryptoTransform encryptor = des.CreateEncryptor())
                {
                    return encryptor.TransformFinalBlock(data, 0, data.Length);
                }
            }
        }

        // ======== DES ДЕШИФРУВАННЯ ========

        private byte[] DesDecrypt(byte[] data, string key)
        {
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = Encoding.UTF8.GetBytes(key);
                des.IV = Encoding.UTF8.GetBytes(key);

                using (ICryptoTransform decryptor = des.CreateDecryptor())
                {
                    return decryptor.TransformFinalBlock(data, 0, data.Length);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                string input = txtInput.Text;
                string xorKeyStr = txtXorKey.Text;
                string desKey = txtDesKey.Text;

                if (desKey.Length != 8)
                {
                    MessageBox.Show("Ключ DES повинен бути рівно 8 символів.");
                    return;
                }

                byte[] originalData = Encoding.UTF8.GetBytes(input);
                byte[] xorKey = Encoding.UTF8.GetBytes(xorKeyStr);

                // 1) XOR
                byte[] afterXor = XorEncrypt(originalData, xorKey);

                // 2) DES
                byte[] afterDes = DesEncrypt(afterXor, desKey);

                txtEncrypted.Text = Convert.ToBase64String(afterDes);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при шифруванні: " + ex.Message);
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                string encrypted = txtEncrypted.Text;
                string xorKeyStr = txtXorKey.Text;
                string desKey = txtDesKey.Text;

                if (desKey.Length != 8)
                {
                    MessageBox.Show("Ключ DES повинен бути рівно 8 символів.");
                    return;
                }

                byte[] encryptedBytes = Convert.FromBase64String(encrypted);
                byte[] xorKey = Encoding.UTF8.GetBytes(xorKeyStr);

                // 1) DES назад
                byte[] afterDes = DesDecrypt(encryptedBytes, desKey);

                // 2) XOR назад
                byte[] afterXor = XorDecrypt(afterDes, xorKey);

                txtDecrypted.Text = Encoding.UTF8.GetString(afterXor);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при розшифруванні: " + ex.Message);
            }
        }

        private void txtEncrypted_TextChanged(object sender, EventArgs e)
        {
            // Можна нічого не робити, просто щоб дизайнер був задоволений :)
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
