using LoadBL.Interfaces;
using LoadBL.Models;
using System.Linq;
using System.Windows;

namespace LoadUI
{
    /// <summary>
    /// Логика взаимодействия для AddLoadWindow.xaml
    /// </summary>
    public partial class AddLoadWindow : Window
    {
        /// <summary>
        /// Список вида занятий
        /// </summary>
        private static readonly string[] Types = { "Лекции", "Практика" };
        /// <summary>
        ///  Поле хранит идентификатор нагрузки
        /// </summary>
        private int _id;
        public AddLoadWindow()
        {
            InitializeComponent();
            // Передаем допустимые значения
            cbType.ItemsSource = Types;
            // Задаем начальное значение
            cbType.SelectedIndex = 0;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            int plan;
            int? actuality = null;

            if (string.IsNullOrEmpty(tbTeacher.Text))
            {
                MessageBox.Show("Поле Преподаватель не может быть пустым", "Проверка");
                return;
            }

            if (string.IsNullOrEmpty(tbSubject.Text))
            {
                MessageBox.Show("Поле Предмет не может быть пустым", "Проверка");
                return;
            }

            if (string.IsNullOrEmpty(tbGroup.Text))
            {
                MessageBox.Show("Поле Группа не может быть пустым", "Проверка");
                return;
            }

            if (!int.TryParse(tbHousPlan.Text, out plan))
            {
                MessageBox.Show("Часы по плану должны быть целым числом", "Проверка");
                return;
            }

            if (!string.IsNullOrEmpty(tbHousActuality.Text))
            {
                int intActuality;
                if(!int.TryParse(tbHousActuality.Text, out intActuality))
                {
                    MessageBox.Show("Часы по факту должны быть целым числом", "Проверка");
                    return;
                }

                if(intActuality < plan)
                {
                    MessageBox.Show("Часы по факту должны быть больше плана", "Проверка");
                    return;
                }
                actuality = intActuality;
            }

            // Создаем объект для передачи данных
            LoadDto load = new LoadDto()
            {
                // Заполняем объект данными
                Teacher = tbTeacher.Text,
                Subject = tbSubject.Text,
                Group = tbGroup.Text,
                HousPlan = plan,
                HousActuality = actuality,
                Type = cbType.SelectedItem.ToString()
            };
            // Именно тут запрашиваем реализованную раннее задачу по работе с нагрузкой
            ILoadProcess loadProcess = ProcessFactory.GetLoadProcess();
            // если это новый объект -  сохраняем его
            if (_id == 0)
            {
                // Сохраняем нагрузку
                loadProcess.Add(load);
            }
            else // иначе обновляем
            {
                // копируем обратно идентификатор объекта
                load.Id = _id;
                // обновляем
                loadProcess.Update(load);
            }
            // и закрываем форму
            Close();
        }

        public void Load(LoadDto load)
        {
            // если объект не существует или его тип не в списке допустимых, выходим
            if(load == null || !Types.Contains(load.Type))
            {
                return;
            }
            // сохраняем id нагрузки
            _id = load.Id;
            // заполняем визуальные компоненты для отображения данных
            tbTeacher.Text = load.Teacher;
            tbSubject.Text = load.Subject;
            tbGroup.Text = load.Group;
            tbHousPlan.Text = load.HousPlan.ToString();
            if (load.HousActuality.HasValue)
            {
                tbHousActuality.Text = load.HousActuality.Value.ToString();
            }
            cbType.SelectedItem = load.Type;
        }
    }
}
