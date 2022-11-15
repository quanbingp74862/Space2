using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ClassTestDll
{
    public class Class1
    {
        Class2 c2=new Class2();
        public const Class2 conA=null ;
        public Class1()
        {
            
           
        }
        public static void TestStatic()
        {
            File.AppendAllText(@"C:\Users\xianzhi.li\Desktop\1221\UIH\Mcsf\1.txt", "dll test");
        }
        
    }
    public interface TestPartial
    {
        void Play(string str);
        void Plan(string str);
    }
    public partial class PartialClass1 : TestPartial
    {
        public void Play(string str) { }
    }
}
