using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test314
{
    class MyBaseClass
    {
        
        public virtual string VirtualMethod()
        {
            return "This method is virtual and defined in MyBaseClass";
        }
        public virtual string ForeName
        {
            get { return foreName; }
            set { foreName = value; }
        }
        private string foreName;

    }
    //-----------------------继承之后重写方法Override
    class MyDerivedClass:MyBaseClass
    {
        //重写方法的语法避免了，在C++中由于手误写错的话，无法重写基类中的方法，而在C#中将会出现一个编译错误，因为编译器会认为函数已经标记为override,但没有重写其基类的方法
        public override string VirtualMethod()
        {
            return "This method is an override defined in MyDerivedClass";
        }
    }
    //---------------------隐藏方法:new关键字的使用

    class HisBaseClass
    {
        public int MyGroovyMethod()
        {
            //some groovy implemention
            return 0;
        }
    }
    class MyDerivedClass1:HisBaseClass
    {
        public new int MyGroovyMethod()
        {
            //some groovy implemention
            return 0;
        }
    }



    //调用函数的基类版本
    class CustomerAccount
    {
        public virtual  decimal CalculatePrice()
        {
            return 0.0M;
        }
    }

    class GoldAccount:CustomerAccount
    {
        public override decimal CalculatePrice()
        {
            return base.CalculatePrice()*0.9M;//调用基类方法的语法：base.<MethodName>()
        }
    }
    class InheritClass
    {
    }
    //抽象类和抽象方法

    //1.抽象函数本身也是虚的，不需要提供virtual关键字
    //2.如果类包含抽象函数，则该类也是抽象的，也必须申明为抽象的
    //3.抽象类不能实例化，抽象函数不能直接实现，必须在非抽象的派生类中重写
    abstract class Building
    {
        public abstract decimal CalculateHeatingCost();//abstract method
    }


    //------------------密封类和密封方法：sealed
    //密封类不能被继承，密封方法不能被重写
    sealed class FInalClass
    {

    }
    class DerivedClass:FInalClass
    {

    }

    class MyClassBase
    {
        virtual public void FinalMethod()
        {

        }
    }
    class Myclass:MyClassBase
    {
        public sealed override void FinalMethod()
        { }

    }
    class DerivedClass1:Myclass
    {
        public override void FinalMethod()
        {

        }
    }
    

}
