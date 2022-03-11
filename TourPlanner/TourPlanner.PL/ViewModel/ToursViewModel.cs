using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.PL.ViewModel
{
    public class ToursViewModel : BaseViewModel
    {
        private string _searchResult;
        public string SearchResult
        {
            set
            {
                _searchResult = value;
                OnPropertyChanged();
            }
            get => _searchResult;
        }

    }
}
