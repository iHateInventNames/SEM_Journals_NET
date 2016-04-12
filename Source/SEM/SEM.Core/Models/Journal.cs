namespace SEM.Core.Models
{
    using System;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public class Journal
    {
        [Key]
        public int Id { get; set; }

        public Guid AspNetUserId { get; set; }
        public virtual Guid AspNetUser { get; set; }

        public string Title { get; set; }

        public byte[] File { get; set; }
    }
}