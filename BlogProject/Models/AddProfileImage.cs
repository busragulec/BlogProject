using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogProject.Models
{
    public class AddProfileImage
    {
        public int WriterID { get; set; }
        public string WriterName { get; set; }
        public string WriterAbout { get; set; }
        public IFormFile WriterImage { get; set; } //Dosyadan veri seçebilmek için kullanılacak image IFromFile türüne çevrildi.
        public string WriterMail { get; set; }
        public string WriterPassword { get; set; }
        public bool WriterStatus { get; set; }
    }
}