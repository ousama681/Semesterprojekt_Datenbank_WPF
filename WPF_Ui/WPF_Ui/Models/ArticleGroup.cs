using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WPF_Ui.Models
{
    public class ArticleGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }

        public virtual ArticleGroup Parent { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
        public virtual List<ArticleGroup> Children { get; set; }


        public ArticleGroup() {
        }
    }
}
