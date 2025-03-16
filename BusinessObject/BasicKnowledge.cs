using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class BasicKnowledge
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Title { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Content { get; set; }
        public CategoryKnowledgeType Category { get; set; }
    }

    public enum CategoryKnowledgeType
    {
        BasicInstructions = 0,
        CreativeSupport = 1,
        IncomeandPayments = 2,
        UsingIReading = 3
    }

    //Hướng Dẫn Cơ Bản
    //Trợ Lực Sáng Tác
    //Thu Nhập Và Thanh Toán
    //Sử dụng IReading
}
