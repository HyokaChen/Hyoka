using System;
using System.Collections.Generic;
using System.Text;

namespace Hyoka
{
    /// <summary>
    /// 继承QueueTask等需要用Task特性标注自定义Task的方法，从而获取一些参数
    /// </summary>
    [System.AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public sealed class TaskAttribute : Attribute
    {
        // See the attribute guidelines at 
        //  http://go.microsoft.com/fwlink/?LinkId=85236
        private int retry;

        public int Retry
        {
            get { return retry; }
        }

        private int retry_delay;

        public int RetryDelay
        {
            get { return retry_delay; }
        }

        private string task_name;

        public string TaskName
        {
            get { return task_name; }
        }

        public TaskAttribute(string task_name, int retry = 0, int retry_delay = 0)
        {
            this.task_name = task_name;
            this.retry = retry;
            this.retry_delay = retry_delay;
        }
    }
}
