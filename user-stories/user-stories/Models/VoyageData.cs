using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace user_stories.Models
{
    public class VoyageData
    {
        public int Id { get; set; }

        [Display(Name = "Departure bus stop")]
        public BusStop BusStopDeparture { get; set; }

        public int BusStopDepartureId { get; set; }

        [Display(Name = "Arrival bus stop")]
        public BusStop BusStopArrival { get; set; }

        public int BusStopArrivalId { get; set; }

        [Display(Name = "Departure date and time")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy.MM.dd H:mm}")]
        public DateTime DepartureDateAndTime { get; set; }

        [Display(Name = "Arrival date and time")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy.MM.dd H:mm}")]
        public DateTime ArrivalDateAndTime { get; set; }

        [Display(Name = "Travel time")]
        public int TravelTime { get; set; }

        [Display(Name = "Voyage number")]
        public int VoyageNumber { get; set; }

        [Display(Name = "Voyage name")]
        public string VoyageName { get; set; }

        [Display(Name = "Number of seats")]
        public int NumberOfSeats { get; set; }

        [Display(Name = "One ticket cost")]
        public int OneTicketCost { get; set; }
    }
}