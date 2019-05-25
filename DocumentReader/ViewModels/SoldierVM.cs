using DocumentReader.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Threading.Tasks;

namespace DocumentReader.ViewModels
{
    class SoldierVM : INotifyPropertyChanged
    {
        DocumentReaderEntities context = new DocumentReaderEntities();
        //static String connectionString = @"Data Source=vibes\sqlexpress;Initial Catalog=ParallelCodes;User ID=sa;Password=789;";
        //SqlConnection con;
        //SqlCommand cmd;
        //SqlDataAdapter adapter;
        //DataSet ds;
        public ObservableCollection<Soldier> Soldiers { get; set; }
        //public String txtSelectedItem { get; set; }

        public SoldierVM()
        {
            Soldiers = new ObservableCollection<Soldier>();
            //txtSelectedItem = "Please select a country";
        }

        public async void LoadSoldiers()
        {
            try
            {
                List<Soldier> soldiersFromDb = context.Soldiers.ToListAsync().Result;
                foreach (Soldier soldier in soldiersFromDb)
                {
                    Soldiers.Add(soldier);
                }
            }
            catch (Exception ex)
            {
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
