using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.Model
{
    public class TourToTourLogRelation : Tour
    {
        public List<TourLog> TourLogs { get; set; } = new();

        public TourToTourLogRelation()
        {

        }

        public TourToTourLogRelation(Tour tour) : base(tour)
        {

        }

        public TourToTourLogRelation(TourToTourLogRelation origin) : base(origin)
        {
            foreach (var tourLog in origin.TourLogs)
            {
                TourLogs.Add(new(tourLog));
            }
        }
    }
}
