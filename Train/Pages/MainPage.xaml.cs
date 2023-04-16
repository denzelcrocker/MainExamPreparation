using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Train.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            childrenList = db.Childrens.ToList();// записываем в общий лист(находится в классе CurrentList, чтобы везде можно было к нему обращаться и он был един) полученные из базы данные
            AllChildrens.ItemsSource = childrenList;// приравниваем содержиое DataGrid к содержимому листа
        }

        private void AllChildrens_MouseDoubleClick(object sender, MouseButtonEventArgs e) // переход к редактированию по двойному клику на элемент DataGrid
        {
            var track = ((DataGrid)sender).SelectedItem as Children; // получаем объект на который кликнули
            if (track != null) // проверяем, получилили что-то в объект
                Manager.frame.Navigate(new EditPage(track)); // если получили, переходим на страницу редактирования, передавая туда объект(экземпляр Children)
        }

        private void AddClick_Click(object sender, RoutedEventArgs e)
        {
            Manager.frame.Navigate(new AddPage());
        }

        private void SaveClick_Click(object sender, RoutedEventArgs e)
        {
            string path = OpenDialog(); // получаем путь через диалоговое окно выбора файла
            WriteChildrens(childrenList, path); // записываем содержимое DataGrid в файл(передаем первым аргументом лист, который нужно записать, а вторым путь, куда нужно записать)
        }
    }
}
