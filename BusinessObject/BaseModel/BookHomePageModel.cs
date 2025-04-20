using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.BaseModel
{
    public class BookHomePageModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<BookModel> Books { get; set; } = new List<BookModel>();
    }
}
