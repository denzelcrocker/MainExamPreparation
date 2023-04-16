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
    /// Логика взаимодействия для EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        Children thisChildren; // вспомогательный экхемпляр, используемый в рамках этой страницы(чтобы везде был доступ к нему) 
        public EditPage(Children children) // в параметрах метода создаем экземпляр класса Children, ведь в это метод мы передаем объект, на который кликнули два раза на главном меню
        {
            InitializeComponent();
            Name.Text = children.Name; // прираыниваем текстбоксы к переменным из параметра, в котором содержатся переменные записи, на которую кликнули два раза
            Birthday.Text = children.Birthday;
            Gender.Text = children.Gender;
            thisChildren = children; // приравниваем вспомогательный экземпляр к основному общему эксепляру с данными, который мы передали в это класс
        }

        private void AddButton_Click(object sender, RoutedEventArgs e) // редактирование
        {
            foreach (Children item in childrenList) // проходимся по всем элементам общего списка данных
            {
                if (item.Id == thisChildren.Id) // смотрим, если айди элемента, который нам нужно изменить, совпадает с текущим айди элемента, который находится в данный момент цикла, то заходим в условие
                {
                    item.Name = Name.Text; // приравниваем измененные данные к соответствующим переменным текущего элемента
                    item.Birthday = Birthday.Text;
                    item.Gender = Gender.Text;
                    db.SaveChanges(); // сохроаняем изменения
                }
            }
            Manager.frame.Navigate(new MainPage());

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e) // удаление
        {
            db.Childrens.Remove(thisChildren); // элемент, который был передан в это класс удаляем через Remove
            db.SaveChanges(); // сохраняем изменения
            Manager.frame.Navigate(new MainPage());
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.frame.GoBack();
        }
    }
}
