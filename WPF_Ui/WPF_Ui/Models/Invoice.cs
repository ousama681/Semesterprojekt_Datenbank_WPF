using System;

namespace WPF_Ui.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal NetPrice { get; set; }
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
