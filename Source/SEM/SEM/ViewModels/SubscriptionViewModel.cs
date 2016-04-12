using SEM.Core.Models;
using SEM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEM.ViewModels
{
    class SubscriptionViewModel
    {
        [Key]
        public int Id { get; set; }

        public virtual Journal Journal { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string Title { get; set; }
    }
}
