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
using BookStoreProject.Infrastructure;
using BookStoreProject.Infrastructure.Database;
using BookStoreProject.Infrastructure.ViewModels;
using BookStoreProject.Pages;

namespace BookStoreProject.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddPeopleWindow.xaml
    /// </summary>
    public partial class AddPeopleWindow : Window
    {
        private PeopleViewModel _selectedItem = null;
        private PeopleRepository _repository = new PeopleRepository();
        private UserViewModel _user = null;
        private UserRepository user = new UserRepository();
        private RoleRepository repository = new RoleRepository();
        public AddPeopleWindow()
        {
            InitializeComponent();
            roleList.ItemsSource = repository.GetList();
        }
        public AddPeopleWindow(PeopleViewModel selectedItem)
        {
            InitializeComponent();
            _selectedItem = selectedItem;
            FillFormFields();
        }
        private void FillFormFields()
        {
            if (_selectedItem != null)
            {
                secondName__Field.Text = _selectedItem.SecondName;
                name__Field.Text = _selectedItem.Name;
                surName__Field.Text = _selectedItem.SurName;
                dateOfBirth__Field.Text = _selectedItem.DateOfBirth;
                sex__Field.Text = _selectedItem.Sex;
                userLogin__Field.Text = _selectedItem.UserLogin;
                roleList.ItemsSource = repository.GetList();
                var result = new List<RoleViewModel>();
                foreach (RoleViewModel role in roleList.ItemsSource)
                {
                    if (_user.Role.Name == role.Name)
                    {
                        roleList.SelectedItem = role;
                        break;
                    }
                    else
                    {
                        result.Add(role);
                    }
                    roleList.SelectedItem = result[0];
                }
            }
        }

        private void AddPeoples(object sender, RoutedEventArgs e)
        {
            try
            {
                RoleViewModel selected = roleList.SelectedItem as RoleViewModel;
                PeopleEntity entity = new PeopleEntity
                {
                    SecondName = secondName__Field.Text, 
                    Name = name__Field.Text,
                    SurName = surName__Field.Text,
                    DateOfBirth = dateOfBirth__Field.Text,
                    Sex = sex__Field.Text,
                    UserLogin = userLogin__Field.Text,
                };
                UserEntity entity1 = new UserEntity
                {
                    Login = userLogin__Field.Text,
                    Password = password__Field.Password,
                    RoleId = selected.ID
                };

                if (_selectedItem != null && _user != null)
                {
                    entity.ID = _selectedItem.ID;
                    _repository.Update(entity);
                }
                else
                {
                    _repository.AddPeople(entity);
                    user.AddUser(entity1);
                }

                MessageBox.Show("Access! Запись сохранена");

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
