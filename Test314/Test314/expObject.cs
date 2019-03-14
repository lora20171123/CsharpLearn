using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test314
{
    //----------------扩展类
    public static class MoneyExtension
    {
        //扩展方法中，第一个参数是要扩展的类型，放在this关键字的后面。目的是告诉编译器，这个方法是Money类型的一部分
        public static void AddToAmount(this Money money, decimal amountToAdd)
        {
            money.Amount += amountToAdd;
        }
        //若扩展方法与类中的某个方法同名，就从来不会调用扩展方法，类中已有的任何势力方法优先
    }
    class MainEntryPoint
    {
        static void Main(string[] args)
        {
            Money cash1 = new Money();
            cash1.Amount = 40M;
            cash1.AddToAmount(10M);//调用扩展方法时，没有显示第一个参数，也不能对它进行任何处理
            Console.WriteLine("cash1.ToString() returns:" + cash1.ToString());
            Console.ReadLine();
        }
        //输出结果为： cash1.ToString() returns:$40
    }
    public class Money
    {
        private decimal amount;
        public decimal Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
            }
        }
        public override string ToString()
        {
            return "$" + Amount.ToString();
        }
    }
    class expObject
    {
       /* enum Colors { Red, Orange, Yellow };
        public void meth()
        {
           
            Colors favoriteColor = Colors.Orange;
            string str = favoriteColor.ToString();
        }
        static void Main()
        {
            int i = 50;
            string str = i.ToString();
            
            Console.WriteLine(str);
            Console.ReadKey();

            
        }*/
       

        
    }
}
