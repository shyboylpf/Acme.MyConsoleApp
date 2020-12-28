using System;
using System.Threading.Tasks;
using System.Timers;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Threading;

namespace Acme.MyConsoleApp
{
    public class PeriodWorkerService : ITransientDependency
    {
        private AbpTimer timer = null;

        public PeriodWorkerService()
        {
            timer = new AbpTimer();
            timer.Period = (int)TimeSpan.FromSeconds(5).TotalMilliseconds;
            
            //timer.Elapsed += async (sender, e) => await Worker();
            timer.Elapsed += Worker;
        }

        public void Start()
        {
            timer.Start();
        }
        public void Stop()
        {
            timer.Stop();
        }
        //private void Worker()
        private void Worker(Object sender, EventArgs e)
        {
            Console.WriteLine("hello from period worker service.");
        }
    }
}
