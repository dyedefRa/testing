using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace UsingQuartz
{
  public  static  class Helpers
    {
        public static async void InitializeJobs()
        {
            var scheduler = await new StdSchedulerFactory().GetScheduler();
            await scheduler.Start();

            //Sınıfı(SendUserEmailsJob)     Joba ekliyorsun 
            var userEmailJob = JobBuilder.Create<SendUserEmailsJob>()
                .WithIdentity("SendUserEmailsJob")
                .Build();
            //Tetiklenme ayarlarını yapıyosun
            var userEmailsTrigger = TriggerBuilder.Create()
                .WithIdentity("SendUserEmailsCron")
                .StartNow()
                .WithCronSchedule("* * * ? * *")
                .Build();
            //ikisini iliştiriyosun ve bu olay IntiilizaeJob ile tetikleyeceksin.
            var result = await scheduler.ScheduleJob(userEmailJob, userEmailsTrigger);
        }


    }
}
