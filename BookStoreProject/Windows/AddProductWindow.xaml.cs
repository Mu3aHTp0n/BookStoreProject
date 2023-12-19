using BookStoreProject.Infrastructure;
using BookStoreProject.Infrastructure.Database;
using BookStoreProject.Infrastructure.ViewModels;
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
using System.Windows.Shapes;

namespace BookStoreProject.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        private BookViewModel _selectedItem = null;
        private BookRepository _repository = new BookRepository();

        private AuthorRepository _author = new AuthorRepository();
        private GenreRepository _genre = new GenreRepository();
        private PublisherRepository _publisher = new PublisherRepository();
        private BookViewModel _book = null;
        private PublisherViewModel _publisher2 = null;
        private GenreViewModel _genre2 = null;

        public AddProductWindow()
        {
            InitializeComponent();
            authorList.ItemsSource = _author.GetList();
            publisherList.ItemsSource = _publisher.GetList();
            genreList.ItemsSource = _genre.GetList();
        }

        public AddProductWindow(BookViewModel selectedItem)
        {
            InitializeComponent();
            _selectedItem = selectedItem;
            FillFormFields();
        }

        private void FillFormFields()
        {
            if (_selectedItem != null)
            {
                authorList.ItemsSource = _author.GetList();
                publisherList.ItemsSource = _publisher.GetList();
                genreList.ItemsSource = _genre.GetList();
                titleField.Text = _selectedItem.Title;
                costField.Text = _selectedItem.Cost;
                quantityField.Text = _selectedItem.Quantity;

                #region unlimited forEach work
                var authorVM = new List<AuthorViewModel>();
                foreach (AuthorViewModel author in authorList.ItemsSource)
                {
                    if (_book.Author.Name == author.Name && _book.Author.SurName == author.SurName)
                    {
                        authorList.SelectedItem = author;
                        break;
                    }
                    else
                    {
                        authorVM.Add(author);
                    }
                    authorList.SelectedItem = authorVM[0];
                }

                var publisherVM = new List<PublisherViewModel>();
                foreach (PublisherViewModel publisher in publisherList.ItemsSource)
                {
                    if (_publisher2.Title == publisher.Title)
                    {
                        publisherList.SelectedItem = publisher;
                        break;
                    }
                    else
                    {
                        publisherVM.Add(publisher);
                    }
                    publisherList.SelectedItem = publisherVM[0];
                }

                var genreVM = new List<GenreViewModel>();
                foreach (GenreViewModel genre in genreList.ItemsSource)
                {
                    if (_genre2.Title == genre.Title)
                    {
                        genreList.SelectedItem = genre;
                        break;
                    }
                    else
                    {
                        genreVM.Add(genre);
                    }
                    genreList.SelectedItem = genreVM[0];
                }
                #endregion
            }
        }


        private void AddProduct(object sender, RoutedEventArgs e)
        {
            try
            {
                AuthorViewModel selectedAuthor = authorList.SelectedItem as AuthorViewModel;
                PublisherViewModel selectedPublisher = publisherList.SelectedItem as PublisherViewModel;
                GenreViewModel selectedGenre = genreList.SelectedItem as GenreViewModel;
                BookEntity entity = new BookEntity
                {
                    AuthorId = selectedAuthor.ID,
                    PublisherId = selectedPublisher.ID,
                    GenreId = selectedGenre.ID,
                    Title = titleField.Text,
                    Cost = costField.Text,
                    Quantity = quantityField.Text,
                };

                if (_book != null)
                {
                    entity.ID = _book.ID;
                    _repository.Update(entity);
                }
                else
                {
                    _repository.AddBook(entity);
                }

                MessageBox.Show("Книга добавлена в каталог");

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
