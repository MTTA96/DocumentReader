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
        SoldierVM soldierVM = new SoldierVM();
        DocumentReaderContext context = new DocumentReaderContext();
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
            return await soldierVM.AddSoldier(soldier);
        }

    }
}
