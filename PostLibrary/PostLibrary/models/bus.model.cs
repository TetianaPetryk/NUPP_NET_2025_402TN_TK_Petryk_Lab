using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrykLibrary.models
{
    public class bus
    {
        public int Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public int Capacity { get; set; }

        // 🔗 Один-до-одного: кожен автобус має одного водія
        public DriverModel Driver { get; set; } = null!;

        // 🔗 Один-до-багатьох: один автобус має багато рейсів
        public ICollection<RouteModel> Routes { get; set; } = new List<RouteModel>();
    }

}
