using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DesktopApp_Practice3.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Media.Media3D;


namespace DesktopApp_Practice3
{
    public partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Student> users;
       
        [ObservableProperty]
        public Student? selectedStudent = null;

        public void CloseMainWindow()
        {
            if (MessageBox.Show("Are you sure you want to close the application?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                
                System.Windows.Application.Current.Shutdown();
            }
        }
       











        [RelayCommand]
        public void messeag()
        {
            MessageBox.Show($"{SelectedStudent.FirstName} GPA value must be between 0 and 4.", "Error");
        }

        [RelayCommand]
        public void AddStudent()
        {
            var vm = new AddStudentWindowVM();
            vm.title = "ADD STUDENT";
            AddStudentWindow window = new AddStudentWindow(vm);
            window.ShowDialog();

            if (vm.Person.FirstName != null)
            {
                users.Add(vm.Person);
            }
        }






        [RelayCommand]
        public void Delete()
        {
            if (SelectedStudent != null)
            {
        
                string name = SelectedStudent.FirstName;
                users.Remove(SelectedStudent);
                MessageBox.Show($"{name} is Deleted successfuly.", "DELETED \a ");


            }
            else
            {
                MessageBox.Show("Plese Select Student before Delete.", "Error");

                
            }

        }

        [RelayCommand]
        public void ExcuteEditStudent()
        {
            if (SelectedStudent != null)
            {
                var vm = new AddStudentWindowVM(SelectedStudent);
                vm.title = "EDIT USER";
                var window = new AddStudentWindow(vm);

                window.ShowDialog();


                int index = users.IndexOf(SelectedStudent);
                users.RemoveAt(index);
                users.Insert(index, vm.Person);



            }
            else
            {
                MessageBox.Show("Please Select the student", "Warning!");
            }
        }









        public MainWindowVM()
        {
            users = new ObservableCollection<Student>();
            BitmapImage image1 = new BitmapImage(new Uri("/Model/Icons/1.png", UriKind.Relative));
            users.Add(new Student("Tom", "Boby", "EG/2020/4038", "31/03/1999", image1, 3.1));
            BitmapImage image2 = new BitmapImage(new Uri("/Model/Icons/2.png", UriKind.Relative));
            users.Add(new Student("Marco", "Luis", "EG/2020/4037", "01/02/2000", image2, 2.87));
            BitmapImage image3 = new BitmapImage(new Uri("/Model/Icons/3.png", UriKind.Relative));
            users.Add(new Student("Jonny", "Wick", "EG/2020/4039", "01/03/1998", image3, 3.35));
            BitmapImage image4 = new BitmapImage(new Uri("/Model/Icons/4.png", UriKind.Relative));
            users.Add(new Student("Sara", "Vinz", "EG/2020/4040", "13/07/1999", image4, 2.91));
            BitmapImage image5 = new BitmapImage(new Uri("/Model/Icons/5.png", UriKind.Relative));
            users.Add(new Student("Kiara", "Rooz", "EG/2020/4041", "31/03/2000", image5, 3.08));




        }
    }

}
