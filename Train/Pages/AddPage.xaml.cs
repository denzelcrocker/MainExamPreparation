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
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        public AddPage()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e) // добавление
        {
            List<Children> childrens = new List<Children> { new Children()}; // сложно объяснить, но нам нужно создать лист, чтобы к его нулевому элементу прировнять тектстовые поля с данными, которые необходимо добавить в базу
            childrens[0].Name = Name.Text; // приравнивание к первому элементу списка
            childrens[0].Birthday = Birthday.Text;
            childrens[0].Gender = Gender.Text;
            db.Childrens.Add(childrens[0]); // добавление первого элемента списка в базу
            db.SaveChanges(); // сохранение изменений
            Manager.frame.Navigate(new MainPage());
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.frame.GoBack();
        }
    }
}
