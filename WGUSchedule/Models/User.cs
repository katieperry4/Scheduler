using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WGUSchedule.Models
{
    internal class User
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public int active {  get; set; }
        public DateTime createDate { get; set; }
        public string createdBy { get; set; }
        public DateTime lastUpdate {  get; set; }
        public string lastupdateBy { get; set; }
    }
}
