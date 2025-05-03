using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.BaseModel
{
    public class StatisticBookModel
    {
        public int UserName { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int TotalChapter { get; set; }
        public int ViewNo { get; set; }
        public float RatingNo { get; set; }
        public int FavouriteNo { get; set; }
        public int Revenue { get; set; }
    }
}
