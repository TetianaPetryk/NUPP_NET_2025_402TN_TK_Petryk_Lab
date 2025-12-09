using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrykLibrary.models
{
    public class DriverModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string LicenseNumber { get; set; } = string.Empty;

        // 🔗 Навігаційна властивість назад до автобуса
        public BusModel Bus { get; set; } = null!;

    }
}
