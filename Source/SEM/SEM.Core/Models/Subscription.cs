namespace SEM.Core.Models
{
    using SEM.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;
    using System.Runtime.Serialization;

    [DataContract]
    public class Subscription
    {
        [Key]
        public int Id { get; set; }

        [DataMember]
        public int JournalId { get; set; }
        public virtual Journal Journal { get; set; }
        public virtual ApplicationUser User { get; set; }

        [DataMember]
        public string Title { get; set; }

    }
}