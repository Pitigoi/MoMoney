﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand
        {
            get;
            set;
        }

        public RelayCommand EntriesViewCommand
        {
            get;
            set;
        }


        public HomeViewModel HomeVM
        {
            get;
            set;
        }
        public EntriesViewModel EntriesVM
        {
            get;
            set;
        }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value;
                OnPropertyChanged();
            }
        }
        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            EntriesVM = new EntriesViewModel();
            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
          {
              CurrentView = HomeVM;
          });

            EntriesViewCommand = new RelayCommand(o =>
            {
                CurrentView = EntriesVM;
            });
        }
    }
}