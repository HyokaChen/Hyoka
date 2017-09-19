using Hyoka.Tasks;
using Hyoka.Utils;
using System;
using System.IO;
using System.Reflection;

namespace Hyoka
{
    /// <summary>
    /// Hyoka消息队列启动主函数
    /// </summary>
    public sealed class HyokaStart
    {
        public static void Main(string[] args)
        {
            var arguments = CommandLineArgumentParser.Parse(args);
            int workers = 0;
            if (arguments.Has("-w"))
            {
                Console.WriteLine("Workers：{0}", arguments.Get("-w").Next);
                int.TryParse(arguments.Get("-w").Next.ToString(), out workers);
            }
            // 获取第一个参数为编译使用Hyoka的项目生成的dll，从中获取Hyoka实例。
            // 反射加载这个类，获取其中的方法信息。
            // 例如 Hyoka.exe Sample -w 4
            if (arguments.Get(0) != null && ! arguments.Get(0).ToString().Contains("-"))
            {
                // 仅需要输入编译生成的dll名称，例如Sample
                var hyoka_str = arguments.Get(0).ToString();
                Console.WriteLine($"===>>{ hyoka_str}");
                // 需将Hyoka.exe和Hyoka.dll放置在项目生成运行目录下
                if (File.Exists($".\\{ hyoka_str }.dll"))
                {
                    string path = System.Environment.CurrentDirectory;
                    Assembly hyoka_assem = Assembly.LoadFile($"{ path }\\{ hyoka_str }.dll");
                    Type[] hyoka_types = hyoka_assem.GetTypes();
                    Hyoka hyoka_instance = null;
                    foreach (var type in hyoka_types)
                    {
                        if(type.BaseType.Name.Equals(nameof(Config)))
                        {
                            //var instance = Activator.CreateInstance(type);
                            var property =  type.GetField("Hyoka").GetValue(null);
                            if(property != null)
                            {
                                hyoka_instance = property as Hyoka;
                            }
                        }
                    }
                    if(hyoka_instance == null)
                    {
                        throw new Exception("Hyoka instance is not initialize");
                    }
                    // 测试一下
                    hyoka_instance.Loop();
                }
                else
                {
                    throw new Exception("The task class dll file or hyoka instance file is not exist.");
                }
            }
            else
            {
                throw new Exception("Please set a correct command parameter with position zero.");
            }
        }
    }
}
