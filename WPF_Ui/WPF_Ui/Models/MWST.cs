using System.Collections.Generic;

namespace WPF_Ui.Models
{
    public class MWST
    {
        public int Id { get; set; }
        public double TaxValue { get; set; } = 7.7;
        public virtual ICollection<Article> Articles { get; set; }
    }
}
