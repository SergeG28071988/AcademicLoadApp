using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace LoadUI
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
            AppContext db = new AppContext();
            List<User> users = db.Users.ToList();

            listofUsers.ItemsSource = users;
        }

        private void Button_Menu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
    }
}
