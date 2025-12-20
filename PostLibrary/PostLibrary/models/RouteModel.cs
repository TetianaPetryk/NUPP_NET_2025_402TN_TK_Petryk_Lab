using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrykLibrary.models
{
    public class RouteModel
    {
        public int Id { get; set; }
        public string Destination { get; set; } = string.Empty;
        public DateTime DepartureTime { get; set; }

        // 🔗 Зв’язок назад до автобуса
        public int BusModelId { get; set; }
        public BusModel Bus { get; set; } = null!;

    }
}
