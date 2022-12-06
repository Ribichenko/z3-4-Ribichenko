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
using z3_4_Ribichenko.AppDataFile;

namespace z3_4_Ribichenko
{
    /// <summary>
    /// Логика взаимодействия для MaterialPage.xaml
    /// </summary>
    public partial class MaterialPage : Page
    {
        public MaterialPage()
        {
            InitializeComponent();
            var currentGarage = RibichenkoEntities.GetContext().material.ToList(); 
            LV.ItemsSource = currentGarage;
        }

        private void LV_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                RibichenkoEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                LV.ItemsSource = RibichenkoEntities.GetContext().garage.ToList();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
