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
    /// Interaction logic for SoldierListUC.xaml
    /// </summary>
    public partial class SoldierListUC : UserControl
    {
        SoldierVM soldierVM;

        public SoldierListUC()
        {
            InitializeComponent();
            soldierVM = new SoldierVM();
            DataContext = soldierVM;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Do not load your data at design time.
             if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                soldierVM.LoadSoldiers();
            }
        }

        private void BtnCreateSoldier_Click(object sender, RoutedEventArgs e)
        {
            var view = new CreateSoldierDialog();

            //show the dialog
            DialogHelper.showCreateSoldier(view, action: isCancel => {

            });
        }

        private void BtnEditSoldier_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDeleteSoldier_Click(object sender, RoutedEventArgs e)
        {
            deleteSoldier();
        }

        private void BtnViewDocument_Click(object sender, RoutedEventArgs e)
        {

        }

        #region SUPPORT FUNC

        private async void deleteSoldier()
        {
            if (lvSoldierList.SelectedIndex != -1)
            {
                DialogHelper.show(string.Format("Xóa chiến sĩ {0}?", soldierVM.Soldiers[lvSoldierList.SelectedIndex].Name),
                    positiveButtonTitle: "Xóa",
                    negativeButtonTitle: "Hủy",
                    type: DialogType.WARNING,
                    action:async confirmed =>
                        {
                            if (confirmed)
                            {
                                bool isSuccess = await soldierVM.DeleteSoldier(lvSoldierList.SelectedIndex);
                                if (isSuccess)
                                {
                                    soldierVM.LoadSoldiers();
                                }
                            }
                        }
                );
            }
        }

        #endregion
    }
}
