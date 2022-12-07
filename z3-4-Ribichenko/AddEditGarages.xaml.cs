using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AddEditGarages.xaml
    /// </summary>
    public partial class AddEditGarages : Page
    {
        private garage _currentGarage = new garage();
        public AddEditGarages()
        {
            InitializeComponent();
            DataContext = _currentGarage;
            combotypeTB.ItemsSource = RibichenkoEntities.GetContext().type_material.Select(a => a).Distinct().ToList();
            combotypeTB.SelectedItem = 0;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            int numTB = Convert.ToInt32(numberTB.Text);
            _currentGarage.number_garage = numTB;



            if (numberTB.Text.Length < 1)
            {
                errors.AppendLine("Укажите номер склада");
            }
            if (addressTB.Text.Length == 0)
            {

                errors.AppendLine("Укажите адрес склада");
            }
            //else
            //{
            //    int ph = Convert.ToInt32(numberTB.Text);
            //    _currentMaterial.number_material = ph;
            //}
            if (combotypeTB.SelectedItem == null)
            {
                errors.AppendLine("Выберите тип материалов");
            }
            else
            {
                _currentGarage.id_type_material = (combotypeTB.SelectedItem as type_material).id;
            }

            if (distanceTB.Text.Length == 0)
            {
                errors.AppendLine("Укажите расстояние до города");
            }
            //else
            //{
            //    int prior = Convert.ToInt32(ostatokTB.Text);
            //    _currentMaterial.ostatok = prior;
            //}

            //if (comboNumberTB.SelectedItem == null)
            //{
            //    errors.AppendLine("Выберите склад");
            //}
            //else
            //{
            //    _currentMaterial.id_garage = (comboNumberTB.SelectedItem as garage).id;
            //}

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            else
            {

            }

            if (_currentGarage.id == 0)
            {
                RibichenkoEntities.GetContext().garage.Add(_currentGarage);

            }
            try
            {
                RibichenkoEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void Onlynum_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[^0-9]+$");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
