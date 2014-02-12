using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Web;
using PumpsProjectWebsite.Models;


namespace PumpsProjectWebsite.Repository
{
    public class TimeLogRepository : BaseRepository
    {
        public TimeLogRepository(IPrincipal user) : base(user) { }

        public TimeLog LoadTimeLog()
        {
            var ActiveTimeLog = (from logs in context.TimeLogs
                                 where logs.User == user.Identity.Name && logs.EndTime == null
                                 select logs).ToList();
            if (ActiveTimeLog.Count() != 1)
            {
                return new TimeLog();
            }
            else
            {
                return ActiveTimeLog.First();
            }
        }

        public bool ClockIn()
        {
            try
            {
                var model = new TimeLog() { User = user.Identity.Name, Date = DateTime.Today, StartTime = DateTime.Now };
                context.TimeLogs.Add(model);
                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool ClockOut()
        {
            try
            {
                var ActiveTimeLog = (from logs in context.TimeLogs
                                     where logs.User == user.Identity.Name && logs.EndTime == null
                                     select logs).ToList();
                if (ActiveTimeLog.Count() > 1)
                {
                    return false;
                }
                var model = ActiveTimeLog.First();
                model.EndTime = DateTime.Now;
                TimeSpan elapsed = ((DateTime)model.EndTime - (DateTime) model.StartTime);
                model.TimeElapsed = elapsed.Ticks;
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}