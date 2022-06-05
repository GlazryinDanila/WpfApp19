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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        private Каталог _currentposesha = new Каталог();
        public Window2(Каталог selectedposesha)
        {
            InitializeComponent();

            if (selectedposesha != null)
                _currentposesha = selectedposesha;
            DataContext = _currentposesha;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            glazyrinDanilEntities.GetContext().Каталог.Add(_currentposesha);
            glazyrinDanilEntities.GetContext().SaveChanges();
            MessageBox.Show("Успешно добавлено");
            this.Close();
        }
    }
}
