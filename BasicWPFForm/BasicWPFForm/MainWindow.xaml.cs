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
using System.IO;

namespace BasicWPFForm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string textLine;
        int i = 0;

        List<person> people = new List<person>();
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tBoxName.Text = "";
            tBoxAge.Text = "";
            tBoxAdd.Text = "";
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string name;
            int age = 0;
            string address;


            name = tBoxName.Text;

            address = tBoxAdd.Text;

            if (name == "")
            {
                MessageBox.Show("Name field cannot be left blank!");
            }

            try
            {
                age = int.Parse(tBoxAge.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Age must contain numbersonly and not be blank!");
            }

            if (address == "")
            {
                MessageBox.Show("Address field cannot be left blank!");
            }

            if (age < 0 || age > 100)
            {
                MessageBox.Show("Age can only be between 0 & 100!");
            }

            textLine = name + "," + age.ToString() + "," + address;

            StreamWriter file = new StreamWriter("D:\\test.txt", true);
            file.WriteLine(textLine);
            file.Close();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            string[] textFile;

            using (StreamReader file = new StreamReader("D:\\test.txt"))
            {
                while (file.Peek() >= 0)
                {
                    string line = file.ReadLine();

                    textFile = line.Split(',');

                    person currentPerson = new person();
                    currentPerson.Name = textFile[0];
                    currentPerson.Age = int.Parse(textFile[1]);
                    currentPerson.Address = textFile[2];

                    people.Add(currentPerson);
                }

            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            for(int x = i; x < people.Count(); x++)
            {
                tBoxName.Text = people[x].Name;
                tBoxAge.Text = people[x].Age.ToString();
                tBoxAdd.Text = people[x].Address;
                i++;
                break;                
            }
                           
        }
    }
}
