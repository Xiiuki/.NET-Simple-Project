using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp_pres.Core;

namespace WpfApp_pres.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }

        public RelayCommand PlaneteViewCommand { get; set; }

        public RelayCommand EtoileViewCommand { get; set; }

        public HomeViewModel Home { get; set; }

        public PlaneteViewModel Planete { get; set; }

        public EtoileViewModel Etoile { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnpropertyChanged();
            }
        }

        public MainViewModel()
        { 
            Home = new HomeViewModel();
            Planete = new PlaneteViewModel();
            Etoile = new EtoileViewModel(); 

            CurrentView = Home;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = Home;
            });
            PlaneteViewCommand = new RelayCommand(o =>
            {
                CurrentView = Planete;
            });
            EtoileViewCommand = new RelayCommand(o =>
            {
                CurrentView = Etoile;
            });
        }
    }
}
