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

namespace WpfApp19
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            asd.ItemsSource = glazyrinDanilEntities.GetContext().Каталог.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window2 add = new Window2(null);
            add.Show();
        }

        private void obnav_Click(object sender, RoutedEventArgs e)
        {

            glazyrinDanilEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            asd.ItemsSource = glazyrinDanilEntities.GetContext().Каталог.ToList();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            var poseshaForRemoving = asd.SelectedItems.Cast<Каталог>().ToList();

            glazyrinDanilEntities.GetContext().Каталог.RemoveRange(poseshaForRemoving);
            glazyrinDanilEntities.GetContext().SaveChanges();
            MessageBox.Show("Данные удалены");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var spectacleForRemoving = asd.SelectedItems.Cast<Каталог>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {spectacleForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    glazyrinDanilEntities.GetContext().Каталог.RemoveRange(spectacleForRemoving);
                    glazyrinDanilEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    asd.ItemsSource = glazyrinDanilEntities.GetContext().Каталог.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
