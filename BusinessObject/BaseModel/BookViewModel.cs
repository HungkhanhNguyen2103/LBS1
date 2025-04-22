using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.BaseModel
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Poster { get; set; }
        public string BookStatus { get; set; }
        public BookStatus Status { get; set; }
        public BookTypePrice BookTypePrice { get; set; }
        public int Price { get; set; }
        public BookType BookType { get; set; }
        public string ChapterId { get; set; }
        public string NewPulished { get; set; }
        public string NewPulishedDateTime { get; set; }
        public DateTime NewPulishedDateTimeFormat { get; set; }
    }
}
