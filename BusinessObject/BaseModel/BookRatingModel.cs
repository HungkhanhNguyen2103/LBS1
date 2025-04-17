using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.BaseModel
{
    public class BookRatingModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Poster { get; set; }
        public double Rating { get; set; }
    }
}
