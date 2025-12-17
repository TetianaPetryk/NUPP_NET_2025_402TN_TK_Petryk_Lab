namespace РГР_ТЗІ
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtInput = new TextBox();
            txtXorKey = new TextBox();
            txtDesKey = new TextBox();
            txtEncrypted = new TextBox();
            txtDecrypted = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnEncrypt = new Button();
            btnDecrypt = new Button();
            label6 = new Label();
            SuspendLayout();
            // 
            // txtInput
            // 
            txtInput.Location = new Point(307, 115);
            txtInput.Multiline = true;
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(350, 44);
            txtInput.TabIndex = 0;
            // 
            // txtXorKey
            // 
            txtXorKey.Location = new Point(307, 165);
            txtXorKey.Multiline = true;
            txtXorKey.Name = "txtXorKey";
            txtXorKey.Size = new Size(350, 36);
            txtXorKey.TabIndex = 1;
            // 
            // txtDesKey
            // 
            txtDesKey.Location = new Point(307, 208);
            txtDesKey.Multiline = true;
            txtDesKey.Name = "txtDesKey";
            txtDesKey.Size = new Size(350, 40);
            txtDesKey.TabIndex = 2;
            // 
            // txtEncrypted
            // 
            txtEncrypted.Location = new Point(307, 260);
            txtEncrypted.Multiline = true;
            txtEncrypted.Name = "txtEncrypted";
            txtEncrypted.Size = new Size(319, 40);
            txtEncrypted.TabIndex = 3;
            txtEncrypted.TextChanged += txtEncrypted_TextChanged;
            // 
            // txtDecrypted
            // 
            txtDecrypted.Location = new Point(307, 324);
            txtDecrypted.Multiline = true;
            txtDecrypted.Name = "txtDecrypted";
            txtDecrypted.Size = new Size(319, 35);
            txtDecrypted.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 122);
            label1.Name = "label1";
            label1.Size = new Size(111, 20);
            label1.TabIndex = 5;
            label1.Text = "Вихідний текст";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 172);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 6;
            label2.Text = "Ключ XOR";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 228);
            label3.Name = "label3";
            label3.Size = new Size(167, 20);
            label3.TabIndex = 7;
            label3.Text = "Ключ DES (8 символів)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(632, 280);
            label4.Name = "label4";
            label4.Size = new Size(155, 20);
            label4.TabIndex = 8;
            label4.Text = "Зашифрований текст";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(632, 327);
            label5.Name = "label5";
            label5.Size = new Size(163, 20);
            label5.TabIndex = 9;
            label5.Text = "Розшифрований текст";
            // 
            // btnEncrypt
            // 
            btnEncrypt.Location = new Point(11, 268);
            btnEncrypt.Name = "btnEncrypt";
            btnEncrypt.Size = new Size(149, 32);
            btnEncrypt.TabIndex = 10;
            btnEncrypt.Text = "Зашифрувати";
            btnEncrypt.UseVisualStyleBackColor = true;
            btnEncrypt.Click += btnEncrypt_Click;
            // 
            // btnDecrypt
            // 
            btnDecrypt.Location = new Point(11, 327);
            btnDecrypt.Name = "btnDecrypt";
            btnDecrypt.Size = new Size(149, 32);
            btnDecrypt.TabIndex = 11;
            btnDecrypt.Text = "Розшифрувати";
            btnDecrypt.UseVisualStyleBackColor = true;
            btnDecrypt.Click += btnDecrypt_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(11, 30);
            label6.Name = "label6";
            label6.Size = new Size(659, 20);
            label6.TabIndex = 12;
            label6.Text = "Розрахунково-графічна робота. Виконала студентка групи 402 - ТН Петрик Тетяна Євгеніївна";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label6);
            Controls.Add(btnDecrypt);
            Controls.Add(btnEncrypt);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtDecrypted);
            Controls.Add(txtEncrypted);
            Controls.Add(txtDesKey);
            Controls.Add(txtXorKey);
            Controls.Add(txtInput);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtInput;
        private TextBox txtXorKey;
        private TextBox txtDesKey;
        private TextBox txtEncrypted;
        private TextBox txtDecrypted;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnEncrypt;
        private Button btnDecrypt;
        private Label label6;
    }
}
