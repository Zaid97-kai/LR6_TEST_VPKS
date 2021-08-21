using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для StudentsWindow.xaml
    /// </summary>
    public partial class StudentsWindow : Window
    {
        private static ImageConverter converter = new ImageConverter();
    
        private List<Student> _students = new List<Student>()
        {
            new Student("Рахимов Ранис Рамилевич", 4232, (byte[])converter.ConvertTo(WpfApp1.Properties.Resources._234, typeof(byte[]))),
            new Student("Зарипов Шамиль Дамирович", 4232, (byte[])converter.ConvertTo(WpfApp1.Properties.Resources.cats, typeof(byte[]))),
            new Student("Карнаух Алексей Леонидович", 4238, (byte[])converter.ConvertTo(WpfApp1.Properties.Resources.windowcat, typeof(byte[])))
        };
        private List<Student> _viewStudents = new List<Student>();
        private string _findedName = "";
        private int _findedNumberGroup = 0;
        public StudentsWindow()
        {
            InitializeComponent();
            StudentsGrid.ItemsSource = _students;
        }

        private void SearchNumberGroupTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _findedNumberGroup = Convert.ToInt32(SearchNumberGroupTextBox.Text);
            RefreshStudents();
        }

        private void RefreshStudents()
        {
            if (SearchNameTextBox.Text != "")
            {
                _viewStudents = _students.Where(student => student.Name.Contains(_findedName)).ToList();
            }
            else
            {
                _viewStudents = _students;
            }
            if(SearchNumberGroupTextBox.Text != "")
            {
                _viewStudents = _students.Where(student => student.NumberGroup == _findedNumberGroup).ToList();
            }
            else
            {
                _viewStudents = _students;
            }
            StudentsGrid.ItemsSource = _viewStudents;
        }
        private void SearchNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _findedName = SearchNameTextBox.Text;
            RefreshStudents();
        }
    }
}
