using BookStoreProject.Infrastructure;
using BookStoreProject.Infrastructure.Database;
using BookStoreProject.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BookStoreProject.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddOrderingWindow.xaml
    /// </summary>
    public partial class AddOrderingWindow : Window
    {
        private OrderingRepository _repository = new OrderingRepository();
        private OrderingViewModel _order = null;
        private OrderingViewModel _selectedItem = null;
        private BookViewModel _bookVM = null;
        private PeopleRepository _people = new PeopleRepository();
        private BookRepository _book = new BookRepository();

        public AddOrderingWindow()
        {
            InitializeComponent();
            peopleList.ItemsSource = _people.GetList();
            mangaList.ItemsSource = _book.GetList();
        }

        public AddOrderingWindow(OrderingViewModel selectedItem)
        {
            InitializeComponent();
            _selectedItem = selectedItem;
            FillFormFields();
        }

        private void FillFormFields()
        {
            if (_selectedItem != null)
            {
                peopleList.ItemsSource = _people.GetList();
                mangaList.ItemsSource = _book.GetList();
                countField.Text = _selectedItem.Count;
                dateField.Text = _selectedItem.Date;

                var peopleVM = new List<PeopleViewModel>();
                var bookVM = new List<BookViewModel>();
                foreach (PeopleViewModel people in peopleList.ItemsSource)
                {
                    if (_order.People.SecondName == people.SecondName &&
                        _order.People.Name == people.Name && 
                        _order.People.SurName == people.SurName)
                    {
                        peopleList.SelectedItem = people;
                        break;
                    }
                    else
                    {
                        peopleVM.Add(people);
                    }
                    peopleList.SelectedItem = peopleVM[0];
                }
                foreach (BookViewModel book in mangaList.ItemsSource)
                {
                    if (_bookVM.Title == book.Title)
                    {
                        mangaList.SelectedItem = book;
                        break;
                    }
                    else
                    {
                        bookVM.Add(book);
                    }
                    mangaList.SelectedItem = bookVM[0];
                }
            }
        }

        private void AddOrdering(object sender, RoutedEventArgs e)
        {
            try
            {   
                PeopleViewModel selectedPeople = peopleList.SelectedItem as PeopleViewModel;
                BookViewModel selectedBook = mangaList.SelectedItem as BookViewModel;
                OrderingEntity entity = new OrderingEntity
                {
                    PeopleId = selectedPeople.ID,
                    BookId = selectedBook.ID,
                    Count = countField.Text,
                    Date = dateField.Text,
                };

                if (_order != null)
                {
                    entity.ID = _order.ID;
                    _repository.Update(entity);
                }
                else
                {
                    _repository.AddOrder(entity);
                }

                MessageBox.Show("Заказ добавлен в очередь");

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Exit(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
