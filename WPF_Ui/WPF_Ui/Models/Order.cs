using System;
using System.Collections.Generic;

namespace WPF_Ui.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Position> Positions { get; set; }
        public bool IsInvoiceGenerated { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}
