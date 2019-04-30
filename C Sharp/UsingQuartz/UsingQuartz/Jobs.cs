using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingQuartz
{
    public class SendUserEmailsJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
            return Task.CompletedTask;
        }
    }
}
