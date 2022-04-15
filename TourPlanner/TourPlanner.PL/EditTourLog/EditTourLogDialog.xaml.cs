using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using TourPlanner.Model;
using TourPlanner.PL.Helper;

namespace TourPlanner.PL.EditTourLog
{
    /// <summary>
    /// Interaktionslogik für EditTourLogDialog.xaml
    /// </summary>
    public partial class EditTourLogDialog : Window, INotifyPropertyChanged
    {
        public EditTourLogDialog()
        {
            InitializeComponent();
        }

        private TourLog? _log = null;
        public TourLog? Log
        {
            get
            {
                return _log;
            }
            set
            {
                _log = value;
                OnPropertyChanged();
            }
        }


        private RelayCommand _applyEdit;
        public ICommand ApplyEdit => _applyEdit ??= new RelayCommand(PerformApplyEdit);

        private void PerformApplyEdit(object commandParameter)
        {
            DialogResult = true;
            Close();
        }


        private RelayCommand _cancelEdit;
        public ICommand CancelEdit => _cancelEdit ??= new RelayCommand(PerformCancelEdit);

        private void PerformCancelEdit(object commandParameter)
        {
            DialogResult = false;
            Close();
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
