using DocumentReader.Models;
using DocumentReader.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DocumentReader.ViewModels
{
    class SoldierVM : INotifyPropertyChanged
    {
        DocumentReaderContext context = new DocumentReaderContext();

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
                if(Soldiers.Count > 0)
                    Soldiers.Clear();

                List<Soldier> soldiersFromDb = context.Soldiers.ToListAsync().Result;
                int serial = 0;
                foreach (Soldier soldier in soldiersFromDb)
                {
                    serial++;
                    soldier.serial = serial;
                    Soldiers.Add(soldier);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lấy dữ liệu thất bại, vui lòng thử lại!");
            }
        }

        public async Task<bool> AddSoldier(Soldier soldier)
        {
            try
            {
                context.Soldiers.Add(soldier);
                await context.SaveChangesAsync();
                bool isSuccess = FilerHelper.createExcelFile(soldier, soldier.Name + "_" + soldier.Dob.Replace(@"/", ""));
                if (!isSuccess)
                {
                   await DeleteSoldier(-2);
                   return false;
                }
                LoadSoldiers();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm thất bại, vui lòng thử lại!");
                return false;
            }
        }

        /// <summary>
        /// PASS POSITION -2 TO REMOVE THE LAST RECORD
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public async Task<bool> DeleteSoldier(int position)
        {
            try
            {
                Soldier soldier = position == -2 ? context.Soldiers.OrderByDescending(p => p.Id).FirstOrDefault() : Soldiers[position];
                if (soldier != null) { 
                    context.Soldiers.Remove(soldier);
                    await context.SaveChangesAsync();
                    return true;
                }

                MessageBox.Show("Chiến sĩ {0} không tồn tại, vui lòng thử lại!", soldier.Name);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa thất bại, vui lòng thử lại!");
                return false;
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
