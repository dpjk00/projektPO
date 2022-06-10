using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjektWPF.Core;

namespace ProjektWPF.ViewStuff.ViewModel
{

    class MainViewModel : ObservableObject
    {

        public RelayCommand UczniowieViewCommand { get; set; }
        public RelayCommand NauczycieleViewCommand { get; set; }

        public UczniowieViewModel UVM { get; set; }

        public NauczycieleViewModel NVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            UVM = new UczniowieViewModel();
            NVM = new NauczycieleViewModel();
            CurrentView = UVM;

            UczniowieViewCommand = new RelayCommand(o =>
            {
                CurrentView = UVM;
            });

            NauczycieleViewCommand = new RelayCommand(o =>
            {
                CurrentView = NVM;
            });
        }
    }
}
