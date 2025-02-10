using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Category
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Name { get; set; }
    }
}
