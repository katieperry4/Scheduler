using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WGUSchedule.Models
{
    public class CustomerDetails
    {
        public int customerId { get; set; }
        public string customerName { get; set; }
        public int addressId { get; set; }
        public string address {  get; set; }
        public int cityId { get; set; }
        public string city { get; set; }
        public int countryId { get; set; }
        public string country { get; set; }
        public string postalCode { get; set; }
        public string phone {  get; set; }

    }
}
