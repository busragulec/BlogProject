using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public string BlogThumbnailImage { get; set; } //Küçük görsel
        public string BlogImages { get; set; } //Dosya yolu olacağından string
        public DateTime BlogCreateDate { get; set; }
        public bool BlogStatus { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } // Category ve Blog arasında bağlantıyı kurar
        public int WriterID { get; set; }
        public Writer Writer { get; set; } // Category ve Blog arasında bağlantıyı kurar
        public List<Comment> Comments { get; set; }

    }
}
