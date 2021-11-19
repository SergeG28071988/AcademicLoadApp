using System.Windows;
using System.Windows.Media;

namespace LoadUI
{
    /// <summary>
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        AppContext db;
        public RegWindow()
        {
            InitializeComponent();
            db = new AppContext();

            //List<User> users = db.Users.ToList();
            //string str = "";
            //foreach (User user in users)
            //    str += "Login: " + user.Login + " | ";
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();
            string pass_2 = passBox_2.Password.Trim();
            string email = textBoxEmail.Text.Trim().ToLower();

            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Это поле заполнено неверно!";
                textBoxLogin.Background = Brushes.Gray;
            }

            else if (pass.Length < 5)
            {
                passBox.ToolTip = "Это поле заполнено неверно!";
                passBox.Background = Brushes.Gray;
            }
            else if (pass != pass_2)
            {
                passBox_2.ToolTip = "Это поле заполнено неверно!";
                passBox_2.Background = Brushes.Gray;
            }
            else if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                textBoxEmail.ToolTip = "Это поле заполнено неверно!";
                textBoxEmail.Background = Brushes.Gray;
            }

            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;

                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;

                passBox_2.ToolTip = "";
                passBox_2.Background = Brushes.Transparent;

                textBoxEmail.ToolTip = "";
                textBoxEmail.Background = Brushes.Transparent;

                MessageBox.Show("Всё хорошо!");

                User user = new User(login, pass, email);

                _ = db.Users.Add(user);
                _ = db.SaveChanges();

                AuthWindow authWindow = new AuthWindow();
                authWindow.Show();
                Hide();
            }
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Hide();
        }
    }
}
