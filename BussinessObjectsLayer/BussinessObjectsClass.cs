using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObjectsNamespace
{
    public class BussinessObjectsClass
    {
        // login credentials Properties.
        public string UserName{ get; set; }
        public string Password{ get; set; }

        // Bus details Properties. 
        public string BusNumber{ get; set; }
        public string StartPoint { get; set; }
        public string Destination { get; set; }
        public int Capacity { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public string CompanyName { get; set; }
        public string BusType { get; set; }
        // Bus PickupPoint Properties
        public string PickupId{ get; set; }
        public string PickupLocation { get; set; }
        // Bus Destination(s) Properties
        public string DestinationId { get; set; }
        public string DestinationLocation { get; set; }
    }
}
