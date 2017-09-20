using Hyoka.Process;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Hyoka
{
    public sealed class Consumer
    {
        private Hyoka hyoka;
        private int workers;
        private double initial_delay;
        private double max_delay;
        private double scheduler_interval;
        private Thread scheduler;
        private List<Thread> worker_list;
        private bool flag_of_stop = false;
        public Consumer(Hyoka hyoka, int workers=1, double initial_delay=0.1, double max_delay=10.0, double scheduler_interval=1.0)
        {
            this.hyoka = hyoka ?? throw new Exception("Hyoka instance can not be null.");
            this.workers = workers;
            this.initial_delay = initial_delay;
            this.max_delay = max_delay;
            this.scheduler_interval = scheduler_interval;
            //this.scheduler = 
        }

        private Thread CreateThread(BaseProcess base_process, string name)
        {
            return new Thread(() =>
            {
                try
                {
                    while (!flag_of_stop)
                    {
                        ;
                    }
                }
                catch (ThreadInterruptedException e)
                {
                    Console.WriteLine("Stop run");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error");
                }
            })
            {
                Name = name,
                IsBackground = true
            };
        }
    }
}
