using System.Linq;
using WPF_Ui.Services.Data;

namespace WPF_Ui.Models
{
    public class Position
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal PriceNetto { get; set; }
        public int ArticleId { get; set; }
        public int OrderId { get; set; }
        public virtual Article Article { get; set; }
        public virtual Order Order { get; set; }

        public Position(int quantity, decimal priceNetto, decimal priceBrutto, int articleId, int orderId)
        {
            Quantity = quantity;
            PriceNetto = priceNetto;
            ArticleId = articleId;
            OrderId = orderId;
        }

        public Position()
        {

        }


        //// TODO: refactor --> call position repo
        //public override bool Equals(object? obj)
        //{
        //    Position pos;
        //    if (obj == null)
        //    {
        //        return false;
        //    }
        //    pos = (Position)obj;
        //    string posArticleName = "";
        //    string thisArticleName = "";

        //    using (var context = new DataContext())
        //    {
        //        posArticleName = (from p in context.Position
        //                          where p.ArticleId == pos.ArticleId && p.OrderId == pos.OrderId
        //                          select p.Article.Name).SingleOrDefault();
        //        thisArticleName = (from p in context.Position
        //                           where p.ArticleId == pos.ArticleId && p.OrderId == pos.OrderId
        //                           select p.Article.Name).SingleOrDefault();
        //    }

        //    if (posArticleName == null && thisArticleName == null)
        //    {
        //        return false;
        //    }

        //    if (posArticleName.Equals(thisArticleName))
        //    {
        //        return true;
        //    }

        //    return false;
        //}

        public string PositionToString(int positionNr)
        {
            return "Pos Nr: " + positionNr + "   |   Artikel: " + Article.Name + "   |   Anzahl: " + Quantity;
        }
    }
}
