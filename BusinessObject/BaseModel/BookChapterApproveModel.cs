﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.BaseModel
{
    public class BookChapterApproveModel
    {
        public string ChapterId { get; set; }
        public int BookId { get; set; }
        public string ChapterName { get; set; }
        public string Content { get; set; }
        public string AiFeedback { get; set; }
    }
}
