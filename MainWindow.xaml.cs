using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Async_await
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Generate_Click(object sender, RoutedEventArgs e)
        {
            //int value = GenerateValue();
            //list.Items.Add(value);

            //Task<int> task = Task.Run(GenerateValue);
            //task.Wait(); // Freeze
            //list.Items.Add(task.Result); // freeze
            //async => alow method to use await keywords
            // await => wait task without freezing
            //int value = await task;
            //list.Items.Add(value);

            //list.Items.Add(await GenerateValueAsync());


            int value;
            if(int.TryParse(number.Text, out value))
            {
                list.Items.Add(await GenerateValueAsync(value));
            }
            else
            {
                MessageBox.Show("Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        Task<int> GenerateValueAsync(int value)
        {
            return Task.Run(() =>
            {
                Thread.Sleep(rnd.Next(1000));
                return Factorial(value);
            });
        }


        static int Factorial(int number)
        {
            int res = 1;
            for (int i = 2; i <= number; i++)
            {
                res *= i;
            }
            return res;
        }

    }
}
