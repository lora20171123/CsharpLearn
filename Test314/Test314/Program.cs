using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test314
{
    class Program
    {
        private string name;
        private string id;

        //只读和只写属性
        public string Name//省略set访问器，默认创建只读属性
        {
            get
            {
                return Name;
            }
        }
        //属性的访问修饰符
        public string Id//get和set访问器可设置不同的访问修饰符。
        {
            //在get和set这两个访问器中必须有一个具备属性的访问级别
            get//没有访问修饰符，表明和属性Id具有相同的访问级别
            {
                return Id;
            }
            private set
            {
                Id = name;
            }
        }
        //3 自动实现的属性
        public  int Age { get; set; }//默认会创建private int age
        //使用自动实现的属性，就不能在属性设置中验证属性的有效性。所以无法检测是否设置了无效的年龄。
        //但必须有两个访问器。尝试将该属性设置为只读，会出错:public int Age{get;}
        //然而，每个访问器的访问级别可以不同，因此 public int Age(get;private set;}是合法的
        static void Main(string[] args)
        {
            //匿名类
            var caption = new { FirstName = "james", MiddleName = "T", LastName = "Kirk" };

            var doctor = new { FirstName = "Leonard", MiddleName = "", LastName = "McCoy" };

            caption = doctor;
            
            Console.WriteLine("User-preferences: BackColor is: " + UserPreferences.BackColor.ToString());
        }




        
    }
    public class UserPreferences
    {
        public static readonly Color BackColor;
        static UserPreferences()
        {
            DateTime now = DateTime.Now;
            if (now.DayOfWeek == DayOfWeek.Sunday || now.DayOfWeek == DayOfWeek.Saturday)
                BackColor = BackColor.Green;
            else
                BackColor = BackColor.Red;
        }
        private UserPreferences()
        {

        }
        

    }
    class Car
    {
        private string description;
        private uint nWheels;
        public Car(string description,uint nWheels)
        {
            this.description = description;
            this.nWheels = nWheels;
        }
        /*public Car(string description)
        {
            this.description = description;
            this.nWheels = 4;
        }*/
        public Car(string description):this(description,4)
        {

        }
        static void Main(string[] args)
        {
            Car myCar = new Car("Proton Persona");
        }
        
    }
    //--------------------------结构类型
    /*class Dimensions
    {
        public double Length;
        public double Width;
    }*/
    //简化数据结构，减小不必要的消耗，可以将class类型定义为struct结构类型
    //需要注意的是为结构定义函数与为类定义函数完全相同
    struct Dimensions//结构是值类型，不是引用类型
    {
        //结构一般存储在栈中或者存储为内联（如果它们是存储在堆中的另一个对象的一部分）
        public double Length;
        public double Width;
        public Dimensions(double length,double width)
        {
            Length = length;
            Width = width;
        }
        public double Diagonal
        {
            get
            {
                return Math.Sqrt(Length * Length + Width * Width);
            }

        }
        //结构的继承链是： 每个结构派生自System.ValueType类，System.ValueType派生自System.Object。
        static void Main(string[] args)
        {
            Dimensions point = new Dimensions();//new 运算符并不分配堆中的内存，只是调用相应的构造函数
            //上面的一句话完全等效于Dimansions point;但是如果这是一个类的话就会产生一个编译错误
            point.Length = 3;
            point.Width = 6;
            //需要注意的是，如果Dimansions point;Double D=point.Length;会报错，引用了未初始化的值

        }

    }


    //-------------------静态类
    static class StaticUtilities
    {
        public static void  HelperMethod()
        {

        }

        static void Main(string[] args)
        {
            //调用HelperMethod()不需要StaticUtilities类型的对象。使用类型名即可进行该调用
            StaticUtilities.HelperMethod();
        }
    }






}
