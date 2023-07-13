using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Ui.Models;

namespace WPF_Ui.Models
{
    public class Town
    {
        public int Id { get; set; }
        public string ZipCode { get; set; }
        public string City  { get; set; }
        public string Country { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
