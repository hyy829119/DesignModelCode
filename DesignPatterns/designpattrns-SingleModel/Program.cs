using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static designpattrns_SingleModel.cto;

namespace designpattrns_SingleModel
{

    /*单例模式：用大白话的理解，程序员与CTO的关系,一个公司的CTO只有一个,每个程序员每天都面对的是同一个CTO
               在代码的世界里,CTO是cto类的一个实例，每个程序员调用cto类获取CTO对象的时候，肯定要求是同一个
               人,这是公司组织架构决定的,因此我们需要保证每个程序员来向CTO汇报工作的时候(调用CTO类),都是同一个
               CTO对象,所以cto类需要保证的是每次返回的实例（CTO）必须一样，不然,就容易产生多个CTO,既违背组织原则,
               也容易导致管理混乱,关键是一个公司也不能存在多个CTO....*/

    /// <summary>
    /// 该类相当于老板
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            ///现在老板说开始工作,不要扯写没用的 
            ///干活的都是程序员,因此通知程序员吧,公司程序员就3个人.....
            for (int i = 0; i < 3; i++)
            {
                cto leader = cto.getInstance();  //领导出场
                leader.Say();                    //讲话了
                programer pg = new programer(leader, i.ToString());//程序员心中应该随时把CTO的话记在心里,我时刻就是把我们CTO的话记在心里的.....
                pg.report();
            }

            //此代码是用来防止程序退出的(Net程序员您懂的)
            Console.ReadKey();
        }
    }

    /// <summary>
    /// cto类负责产生CTO
    /// </summary>

    public class cto
    {
        //private static cto CTO = new cto(); //生产一个CTO

        ////不让用户程序员自己随便new对象,否则容易产生多个CTO 
        //private cto()
        //{

        //}

        ///// <summary>
        ///// 单例模式的核心
        ///// </summary>
        ///// <returns></returns>
        //public static cto getInstance() { return CTO; }


        //public void Say()
        //{
        //    /*程序的屌丝内心,现实中不是CTO,只能在程序世界里面自我封官了哈。。。。*/
        //    Console.WriteLine("我是公司的CTO,你们的工作需要想问汇报!");
        //}


        private static cto CTO = null; //生产一个CTO

        //不让用户程序员自己随便new对象,否则容易产生多个CTO 
        private cto()
        {

        }

        /// <summary>
        /// 单例模式的核心
        /// </summary>
        /// <returns></returns>
        public static cto getInstance()
        {
            if (CTO == null) CTO = new cto();
            return CTO;
        }


        public void Say()
        {
            /*程序的屌丝内心,现实中不是CTO,只能在程序世界里面自我封官了哈。。。。*/
            Console.WriteLine("我是公司的CTO,你们的工作需要想问汇报!");
        }
    }

    /// <summary>
    /// 程序员
    /// </summary>
    public class programer
    {
        /// <summary>
        /// 把cto通过构造的方式传入,相当于程序员也时刻知道自己归谁领导... pmp也很重要......
        /// </summary>
        private cto ctoLeader;
        private string Name;
        public programer(cto CTOLeader, string name)
        {
            this.ctoLeader = CTOLeader;
            this.Name = name;
        }

        /// <summary>
        /// 开始汇报
        /// </summary>
        public void report()
        {
            Console.WriteLine($"我是公司的Java程序员-{Name},请你检阅我的工作!");
        }
    }

}
