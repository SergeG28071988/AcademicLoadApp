using System.Windows;
using LoadBL.Models;

namespace LoadUI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddLoadWindow window = new AddLoadWindow();
            window.ShowDialog();

            // Получаем список нагрузок и передаем его на отображение таблице
            dgLoad.ItemsSource = ProcessFactory.GetLoadProcess().GetList();
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            // Получаем список нагрузок и передаем его на отображение таблице
            dgLoad.ItemsSource = ProcessFactory.GetLoadProcess().GetList();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            // Получаем выделенную строку с объектом нагрузка
            LoadDto item = dgLoad.SelectedItem as LoadDto;
            // если там не нагрузка или пользователь ничего не выбрал сообщаем об этом
            if(item == null)
            {
                MessageBox.Show("Выберите запись для удаления", "Удаление нагрузки");
            }
            // Просим подтвердить удаление
            MessageBoxResult result = MessageBox.Show("Удалить нагрузку" + item.Teacher + "?", 
                "Удаление нагрузки", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            // Если пользователь не подтвердил, выходим
            if (result != MessageBoxResult.Yes)
                return;
            // Если все проверки пройдены и подтверждение получено, удаляем нагрузку
            ProcessFactory.GetLoadProcess().Delete(item.Id);
            // И перезагружаем список нагрузок
            BtnRefresh_Click(sender, e);
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            // Получаем выделенную строку с объектом нагрузка
            LoadDto item = dgLoad.SelectedItem as LoadDto;
            // если там не нагрузка или пользователь ничего не выбрал сообщаем об этом
            if (item == null)
            {
                MessageBox.Show("Выберите запись для редактирования", "Редактирование");
                return;
            }
            // Создаем окно
            AddLoadWindow window = new AddLoadWindow();
            // Gttlftv объект на редактирование
            window.Load(item);
            // Отображаем окно с данными
            window.ShowDialog();
            // Перезагружаем список объектов
            BtnRefresh_Click(sender, e);

        }

        private void File_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            //Справка
            MessageBox.Show("Автор программы Распределение учебной нагрузки: Сергей Галкин., \nДата релиза: 18.11.2021 г., \nEmail: galckinserega@gmail.com", "Внимание!!");
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            RegWindow window = new RegWindow();
            window.Show();
            Hide();
        }
    }
}
