using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Hyoka
{
    /// <summary>
    /// 项目需要在Config中实例化静态对象，并且传入继承QueueTask等的实例化对象
    /// </summary>
    public sealed class Hyoka
    {
        private object task_object;

        public object TaskObject
        {
            get { return task_object; }
        }

        private int workers;

        public int Workers
        {
            get { return workers; }
        }

        private int interval;

        public int Interval
        {
            get { return interval; }
        }


        public Hyoka(object taskObject, int workers=1, int interval=5000)
        {
            this.task_object = taskObject;
            this.workers = workers;
            this.interval = interval;
            this.Initialize();
        }

        private void Initialize()
        {

        }

        public void Loop()
        {
            Console.WriteLine("You are in loop...");
            if(this.task_object != null)
            {
                Console.WriteLine("Task in Hyoka...");
            }
            while (true)
            {
                Thread.Sleep(interval);
                Console.WriteLine("Thread sleep 5 sec ...");
            }
        }
    }
}
