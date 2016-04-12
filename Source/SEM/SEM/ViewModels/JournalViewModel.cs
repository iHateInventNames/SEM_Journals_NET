using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using System.Web.Mvc;

namespace SEM.ViewModels
{
    public class JournalViewModel
    {
        [Key]
        [HiddenInput]
        public int Id { get; set; }

        [Editable(false)]
        [EmailAddress]
        public string Author { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [DataType(DataType.Upload)]
        //[FileExtensions(Extensions = "pdf")]
        [Display(Name = "Your journal")]
        public HttpPostedFileBase PdfUpload { get; set; }
    }
}
