using DocumentReader.Utils;
using DocumentReader.ViewModels;
using MaterialDesignThemes.Wpf;
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

namespace DocumentReader.Views.UCs
{
    /// <summary>
    /// Interaction logic for CreateSoldierDialog.xaml
    /// </summary>
    public partial class CreateSoldierDialog : UserControl
    {
        private CreateSoldierViewModel viewModel;
        
        public CreateSoldierDialog()
        {
            InitializeComponent();
            viewModel = new CreateSoldierViewModel();
            DataContext = viewModel;
        }

        private void BtnUpdateSoldier_Click(object sender, RoutedEventArgs e)
        {
            addSoldier();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogHelper.dismiss();
        }

        private async void addSoldier()
        {
            if(dobPicker.SelectedDate == null)
            {
                return;
            }
            var selectedDob = dobPicker.SelectedDate ?? DateTime.Now;
            var result = await viewModel.AddSoldier(new Models.Soldier()
            {
                Name = txbName.Text,
                Dob = selectedDob.ToString("dd/MM/yyyy")
            });

            if (result)
                DialogHelper.dismiss();
        }
    }
}
