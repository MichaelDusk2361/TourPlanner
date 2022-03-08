using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace TourPlanner.Model {

    public interface ITEntity {
        public Guid Id { get; set; }
        public int Version { get; set; }

    }
}
