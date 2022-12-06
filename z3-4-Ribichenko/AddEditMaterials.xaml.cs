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
    /// Логика взаимодействия для AddEditMaterials.xaml
    /// </summary>
    public partial class AddEditMaterials : Page
    {
        private material _currentMaterial = new material();
        public AddEditMaterials()
        {
            InitializeComponent();
            DataContext = _currentMaterial;
            comboUnitTB.ItemsSource = RibichenkoEntities.GetContext().units.Select(a => a).Distinct().ToList();
            comboUnitTB.SelectedItem = 0;

            comboNumberTB.ItemsSource = RibichenkoEntities.GetContext().garage.Select(a => a).Distinct().ToList();
            comboNumberTB.SelectedItem = 0;
        }


        private void Onlynum_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[^0-9]+$");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            _currentMaterial.name = nameTB.Text;



            if (nameTB.Text.Length == 0)
            {
                errors.AppendLine("Укажите наименование материала");
            }
            if (numberTB.Text.Length < 4 || numberTB.Text.Length > 4)
            {

                errors.AppendLine("Номер материала состоит из 4 символов");
            }
            else
            {
                int ph = Convert.ToInt32(numberTB.Text);
                _currentMaterial.number_material = ph;
            }
            if (comboUnitTB.SelectedItem == null)
            {
                errors.AppendLine("Выберите единицу измерения");
            }
            else
            {
                _currentMaterial.id_unit = (comboUnitTB.SelectedItem as units).id;
            }

            if (ostatokTB.Text.Length == 0)
            {
                errors.AppendLine("Укажите остаток на складе");
            }
            else
            {
                int prior = Convert.ToInt32(ostatokTB.Text);
                _currentMaterial.ostatok = prior;
            }

            if (comboNumberTB.SelectedItem == null)
            {
                errors.AppendLine("Выберите склад");
            }
            else
            {
                _currentMaterial.id_garage = (comboNumberTB.SelectedItem as garage).id;
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentMaterial.id == 0)
            {
                RibichenkoEntities.GetContext().material.Add(_currentMaterial);

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
    }
}
