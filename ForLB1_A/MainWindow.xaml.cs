using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ForLB1_A
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void sendPostReq(object sender, RoutedEventArgs e)
        {
            string firstParam = "", secondParam = "", address = "";
            try
            {
                address = url.Text;
                firstParam = paramX.Text;
                secondParam = paramY.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bad params!" + ex.Message);
                address = "http://localhost:55972/task4/";
                firstParam = "1";
                secondParam = "2";
            }

            using (var webClient = new WebClient())
            {
                var pars = new NameValueCollection();

                pars.Add("x", firstParam);
                pars.Add("y", secondParam);

                var response = webClient.UploadValues(address, pars);
                string str = Encoding.UTF8.GetString(response);
                MessageBox.Show(str);
            }
        }
    }
}
