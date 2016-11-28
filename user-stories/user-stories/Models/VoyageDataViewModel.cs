using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace user_stories.Models
{

    public class VoyagesInfoViewModels
    {
        public VoyageData VoyageData { get; set; }

        public IEnumerable<VoyageData> VoyageDatas { get; set; }
    }



    public class BusStopsViewModels
    {
        public int Id { get; set; }

        [Display(Name = "Name of the bus stop")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Status")]
        public int Status { get; set; }

        public ICollection<VoyageData> VoyageDatas { get; set; }
    }

    public class VoyageWithOrders
    {
        public IEnumerable<Order> orders { get; set; }
    }
}