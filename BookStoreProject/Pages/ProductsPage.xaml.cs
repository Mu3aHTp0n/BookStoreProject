using BookStoreProject.Infrastructure.Database;
using BookStoreProject.Infrastructure.ViewModels;
using BookStoreProject.Windows;
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

namespace BookStoreProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        private BookRepository _repository;
        public ProductsPage()
        {
            InitializeComponent();
            // Источник данных для таблицы с книгами
            _repository = new BookRepository();
            ProductsGrid.ItemsSource = _repository.GetList();
        }

        // Вернуться на главную страницу
        private void ToMenu(object sender, RoutedEventArgs e)
        {
            MenuPage menuPage = new MenuPage();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Title = menuPage.Title;
            mainWindow.MainFrame.Navigate(menuPage);
        }

        private void AddProduct(object sender, RoutedEventArgs e)
        {
            AddProductWindow addProduct = new AddProductWindow();
            addProduct.Show();
            Window.GetWindow(this).Close();
        }

        private void UpdateGrid()
        {
            ProductsGrid.ItemsSource = _repository.GetList();
        }

        private void DeleteProduct(object sender, RoutedEventArgs e)
        {
            if (ProductsGrid.SelectedItem == null)
            {
                MessageBox.Show("Ничего не выбрано для удаления");
                return;
            }

            var item = ProductsGrid.SelectedItem as BookViewModel;
            if (item == null)
            {
                MessageBox.Show("Не удалось получить данные");
                return;
            }
            _repository.DeleteBook(item.ID);
            UpdateGrid();
        }

        private void FindProd(object sender, RoutedEventArgs e)
        {
            string search = find.Text;
            if (string.IsNullOrEmpty(search))
            {
                ProductsGrid.ItemsSource = _repository.GetList();
            }
            else
            {
                List<BookViewModel> result = _repository.Search(search);
                ProductsGrid.ItemsSource = result;
            }
        }
    }
}
