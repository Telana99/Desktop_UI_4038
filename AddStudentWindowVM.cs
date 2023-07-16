using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media.Imaging;
using DesktopApp_Practice3.Model;
using System.Security.Cryptography.X509Certificates;
using System.IO.Pipes;

namespace DesktopApp_Practice3
{
    public partial class AddStudentWindowVM : ObservableObject
    {
        [ObservableProperty]
        public string firstname;

        [ObservableProperty]
        public string lastname;

       
       [ObservableProperty]
        public string regNo;

        [ObservableProperty]
        public string dateofbirth;


        [ObservableProperty]
        public double gpa;

        [ObservableProperty]
        public string title;

        [ObservableProperty]
        public BitmapImage? selectedImage;

        public AddStudentWindowVM(Student s)
        {
            Person = s;

            firstname = Person.FirstName;
            lastname = Person.LastName;
            regNo = Person.RegNo;
            gpa = Person.GPA;
            dateofbirth = Person.DateOfBirth;
            SelectedImage = Person.Image;
        }

        public AddStudentWindowVM()
        {

        }

        [RelayCommand]
        public void UploadPhoto()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.bmp; *.png; *.jpg";
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == true)
            {
                SelectedImage = new BitmapImage(new Uri(dialog.FileName));

                MessageBox.Show("Imgae successfuly uploded!", "successfull");
            }
        }

        public Student Person { get; private set; }

        public Action CloseAction { get; internal set; }

        [RelayCommand]
        public void Save()
        {



            if (gpa < 0 || gpa > 4)
            {
                MessageBox.Show("GPA value must be between 0 and 4.", "Error");
                return;
            }
            if (Person == null)
            {

                Person = new Student()
                {
                    FirstName = firstname,
                    LastName = lastname,
                    RegNo = regNo,
                    DateOfBirth = dateofbirth,
                    Image = selectedImage,

                    GPA = gpa

                };


            }
            else
            {

                Person.FirstName = firstname;
                Person.LastName = lastname;
                Person.RegNo = regNo;
                Person.GPA = gpa;
                Person.Image = selectedImage;
                Person.DateOfBirth = dateofbirth;



            }

            if (Person.FirstName != null)
            {

                CloseAction();
            }
            Application.Current.MainWindow.Show();


        }
    }
}

