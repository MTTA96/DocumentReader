using DocumentReader.Models;
using DocumentReader.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DocumentReader.ViewModels
{
    class CreateSoldierViewModel : INotifyPropertyChanged
    {
        DocumentReaderEntities context = new DocumentReaderEntities();
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                this.MutateVerbose(ref _name, value, RaisePropertyChanged());
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        private Action<PropertyChangedEventArgs> RaisePropertyChanged()
        {
            return args => PropertyChanged?.Invoke(this, args);
        }

        public async Task<bool> AddSoldier(Soldier soldier)
        {
            try
            {
                context.Soldiers.Add(new Soldier()
                {
                    Id = 0,
                    Name = soldier.Name,
                    DOB = soldier.DOB
                });
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm thất bại, vui lòng thử lại!");
                return false;
            }
        }

    }
}
