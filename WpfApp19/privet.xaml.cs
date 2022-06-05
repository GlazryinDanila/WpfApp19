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
using System.Windows.Threading;

namespace WpfApp19
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class privet : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        public privet()
        {
            InitializeComponent();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += timer_Tick;

        }
        int intrerv = 10;
        void timer_Tick(object sender, EventArgs e)
        {
            intrerv--;
            if (intrerv == 0)
            {



                timer.Stop();
                intrerv = 10;
                refreshNeGen.Visibility = Visibility.Hidden;
            }

            vxod.Content = "Блокировка авторизации " + intrerv.ToString() + " секунд";


        }

        private void vxod_Click(object sender, RoutedEventArgs e)
        {
            string login = "xd";
            string pass = "xd";

            if (loginn.Text == login)
            {
                if (passwordd.Password == pass)
                {
                    if (refreshGen.Text == refreshNeGen.Text)
                    {
                        Window1 win = new Window1();
                        win.Show();
                    }
                    else
                    {
                        MessageBox.Show("Капча неверная");
                    }

                }
                else
                {
                    MessageBox.Show("Пароль неверная");
                }
            }
            else
            {
                MessageBox.Show("логин неверная");
            }
        }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            Random rd = new Random();
            int cap = rd.Next(100, 999);
            refreshGen.Text = Convert.ToString(cap);

            timer.Start();
            refreshNeGen.Visibility = Visibility.Visible;
        }
    }
}
