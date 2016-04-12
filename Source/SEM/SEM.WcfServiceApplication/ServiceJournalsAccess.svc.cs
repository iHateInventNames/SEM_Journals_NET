using SEM.Models;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using SEM.Core.Models;
using System.Linq;
using System;
using System.Diagnostics.Contracts;
using System.Runtime.Serialization;

namespace SEM.WcfServiceApplication
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ServiceJournalsAccess : IServiceJournalsAccess
    {
        private readonly ApplicationDbContext db = ApplicationDbContext.Create();

        private ApplicationUser Auth(string login, string password)
        {
            if (login == null || password == null) return null;

            var passwordHasher = new PasswordHasher();
            var user = db.Users.SingleOrDefault(u => u.Email == login);
            var result = passwordHasher.VerifyHashedPassword(user.PasswordHash, password);
            return result != PasswordVerificationResult.Failed ? user : null;
        }

        public byte[] GetJournal(string login, string password, int value)
        {
            var user = Auth(login, password);
            var subscription = user?.Subscriptions.Where(s => s.JournalId == value).FirstOrDefault();
            return subscription?.Journal.File;
        }


        public IEnumerable<Subscription> GetMySubscriptions(string login, string password)
        {
            var user = Auth(login, password);
            List<Subscription> list = new List<Subscription>();

            return user?.Subscriptions.Select(x=> { var s = new Subscription();
                s.JournalId = x.JournalId;
                s.Title = x.Title;
                return s;
            });

            //if (ServiceSecurityContext.Current?.PrimaryIdentity != null
            //    && ServiceSecurityContext.Current.PrimaryIdentity.IsAuthenticated)
            //    return db.Users?.Find(ServiceSecurityContext.Current.PrimaryIdentity.GetUserId())?.PasswordHash Subscriptions;
            //else
            //    throw new UnauthorizedAccessException();
        }
    }
}
