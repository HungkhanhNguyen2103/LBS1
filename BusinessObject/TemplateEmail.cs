using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class TemplateEmail
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? Name { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? Subject { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Body { get; set; }
    }
}
