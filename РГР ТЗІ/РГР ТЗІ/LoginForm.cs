using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace РГР_ТЗІ
{
    public partial class LoginForm : Form
    {
        private readonly Dictionary<string, string> users = new Dictionary<string, string>
        {
            { "ViddProd1", "1viddilprodaziv1" },
            { "ViddProd2", "2viddilprodaziv2" },
            { "ViddProd3", "3viddilprodaziv3" },
            { "ViddProd4", "4viddilprodaziv4" },

            { "Ych1", "1ychen1" },
            { "Ych2", "2ychen2" },
            { "Ych3", "3ychen3" },
            { "Ych4", "4ychen4" },
            { "Ych5", "5ychen5" },

            { "StOp1", "1StarshuiOperator1" },
            { "StOp2", "2StarshuiOperator2" },
            { "StOp3", "3StarshuiOperator3" },
            { "StOp4", "4StarshuiOperator4" },

            { "Operator1",  "1Operator1" },
            { "Operator2",  "1Operator2" },
            { "Operator3",  "1Operator3" },
            { "Operator4",  "1Operator4" },
            { "Operator5",  "1Operator5" },
            { "Operator6",  "1Operator6" },
            { "Operator7",  "1Operator7" },
            { "Operator8",  "1Operator8" },
            { "Operator9",  "1Operator9" },
            { "Operator10", "1Operator10" },
            { "Operator11", "2Operator1" },
            { "Operator12", "2Operator2" },
            { "Operator13", "2Operator3" },
            { "Operator14", "2Operator4" },
            { "Operator15", "2Operator5" },
            { "Operator16", "2Operator6" },

            { "ViddKadriv1", "1viddilkadriv1" },
            { "ViddKadriv2", "2viddilkadriv2" },

            { "TehVidd1", "1server1" },
            { "TehVidd2", "2server2" },
            { "TehVidd3", "3server3" },

            { "Buh",      "*Buhalter*" },
            { "Sekretar", "*secretar*" },
            { "Dyrector", "*1director1*" },
            { "Sequirty1", "*Sequirty1*" },
            { "Sequirty2", "*Sequirty2*" }
        };
        public LoginForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            // При натисканні Enter спрацьовує кнопка Увійти
            this.AcceptButton = btnLogin;
            this.BackColor = Color.FromArgb(230, 220, 255); // світло-фіолетовий фон
            this.Font = new Font("Times New Roman", 10);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введіть логін і пароль.",
                                "Попередження",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // Перевірка логіна й пароля по словнику
            if (users.TryGetValue(login, out string expectedPassword) &&
                expectedPassword == password)
            {
                // Успішний вхід – відкриваємо головну форму з шифруванням
                Form1 mainForm = new Form1();
                mainForm.StartPosition = FormStartPosition.CenterScreen;

                // Коли основне вікно закриють – закриваємо й LoginForm, щоб завершити програму
                mainForm.FormClosed += (s, args) => this.Close();

                mainForm.Show();
                this.Hide();
            }
            else
            {
                // Невірний логін або пароль
                MessageBox.Show("Невірний логін або пароль.",
                                "Помилка авторизації",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                txtPassword.Clear();
                txtPassword.Focus();
            }
        }
    }
}
   
