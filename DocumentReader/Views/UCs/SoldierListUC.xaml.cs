﻿using DocumentReader.Utils;
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
                //Load your data here and assign the result to the CollectionViewSource.
                //System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
                //myCollectionViewSource.Source = your data
                soldierVM.LoadSoldiers();
            }
        }

        private async void BtnCreateSoldier_Click(object sender, RoutedEventArgs e)
        {
            var view = new CreateSoldierDialog();

            //show the dialog
            DialogHelper.showCreateSoldier(view, action: isCancel => {
                if(!isCancel)
                    soldierVM.LoadSoldiers();
            });
        }

        private void BtnEditSoldier_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDeleteSoldier_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnViewDocument_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
