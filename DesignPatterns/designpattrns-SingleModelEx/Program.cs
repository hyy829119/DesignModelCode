using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace designpattrns_SingleModelEx
{

    /// <summary>
    /// cto类负责产生CTO
    /// </summary>

    public class cto
    {
        private static int maxnumofcto = 5; //申明返回的实例数量

        private static List<string> ctolistprop = new List<string>(); //每个cto都有自己的属性,因此用来存储每个对象私有属性

        private static List<cto> ctolist  //默认申请指定数量的CTO对象存储
        {
            get
            {
                List<cto> ctolisttemp = new List<cto>();
                for (int i = 0; i < maxnumofcto; i++)
                {
                    ctolisttemp.Add(new cto($"我是CTO,我的名字是{i}"));
                };
                return ctolisttemp;
            }
        }

        private static int countnumofcto = 0;//申明cto的的序列号,便于后边区分

        //不让用户程序员自己随便new对象,否则容易产生多个CTO 
        //同时把生产指定数量的对象放入数组中
        private cto()
        {

        }

        /// <summary>
        /// 用来存储CTO的姓名
        /// </summary>
        /// <param name="name"></param>
        private cto(string name)
        {
            ctolistprop.Add(name);
        }


        /// <summary>
        /// 单例模式的核心
        /// </summary>
        /// <returns></returns>
        public static cto getInstance()
        {
            /*下面的核心从cto队列中随机返回一个CTO对象*/
            Random random = new Random();
            countnumofcto = random.Next(maxnumofcto);
            return ctolist[countnumofcto];
        }


        public void Say()
        {
            Console.WriteLine($"我是公司的CTO{ctolistprop[countnumofcto]},你们的工作需要想问汇报!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            for (int j = 0; j < 10; j++)
            {
                cto CTO = cto.getInstance(); //获取cto实例,并且每次返回都随机的
                Console.WriteLine($"第{j}次调用的对象为:");
                CTO.Say();
                Thread.Sleep(1000);//暂停目的,不暂停的话,在返回实例的时候有可能每次返回的都是同一个实例，因为时间间隔小的随机数生产可能相同
            }
        }
    }
}
