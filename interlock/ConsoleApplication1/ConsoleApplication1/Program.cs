using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;

namespace ConsoleApplication1
{
    delegate void EventHandler();

    class MyClass
    {
        //声明一个成员变量来保存事件句柄（事件被激发时被调用的delegate）
        private EventHandler m_Handler = null;

        public event EventHandler AEvent;
        //激发事件
        public void FireAEvent()
        {
            if (AEvent != null)
            {
                AEvent();
            }
            //if (m_Handler != null)
            //{
            //    m_Handler();
            //}
        }

        //声明事件
        //public event EventHandler AEvent
        //{
        //    //添加访问器
        //    add
        //    {
        //        //注意,访问器中实际包含了一个名为value的隐含参数
        //        //该参数的值即为客户程序调用+=时传递过来的delegate
        //        Console.WriteLine("AEvent add被调用,value的HashCode为:" + value.GetHashCode());
        //        if (value != null)
        //        {
        //            //设置m_Handler域保存新的handler
        //            m_Handler = value;
        //        }
        //    }

        //    //删除访问器
        //    remove
        //    {
        //        Console.WriteLine("AEvent remove被调用,value的HashCode为:" + value.GetHashCode());
        //        if (value == m_Handler)
        //        {
        //            //设置m_Handler为null,该事件将不再被激发
        //            m_Handler = null;
        //        }
        //    }

        //}

    }
    class TestInitial : ParTest
    {
        public TestInitial():base()
        {
            int a = 1;
            planner();
        }

        protected override void planner()
        {
            int a = 1;
        }
    }
    class ParTest : PParTest
    {
        public ParTest()
        {
            int a = 1;
            planner();
        }
        protected override void planner()
        {
            int a = 1;
        }
    }
    class BaseClass
    {

    }
    class PParTest
    {
        public int a = 1;
        protected virtual void planner()
        {
            a = 2;
        }
    }
    struct st1
    {
        char a;
        int b; 
        short c;
    }
    struct st2
    {
        short c;
        char a;
        int b;       
    }
    struct str
    {
        public int a;
        public int b;
        public static int c = 0;
        public const int d = 1;
        public int[] arr;
  
        public str(int a1, int b1,int[]c1)
        {
            a = a1;
            b = b1;
            arr = c1;
        }
        public int AddTest(int a, int b)
        {
            return a + b;
        }
    }
    class Program
    {
        
        private static int _result;
        static readonly object _locker = new object();
        Dictionary<string, PParTest> dic;
        static bool _go;
        public static string Base64Code(string Message)
        {
            byte[] bytes = Encoding.Default.GetBytes(Message);
            return Convert.ToBase64String(bytes);
        }
        static void ArrayTest(str tem)
        {
            tem.b = 10;
        }

        //事件处理程序
        static void MyEventHandler()
        {
            Console.WriteLine("This is a Event!");
        }

        //事件处理程序
        static void MyEventHandle2()
        {
            Console.WriteLine("This is a Event2!");
        }
       
        static void Main(string[] args)
        {
            string str = "123";
            str.ToUpper();
            str.Insert(0, "111");
            Console.WriteLine(str);
            int con = 2;
            if (con < 3)
            {
                Console.WriteLine("This is a Event1");
            }
            if (con < 1)
            {
                Console.WriteLine("This is a Event3");
            }
           
            else
            {
                Console.WriteLine("This is a Event2");
            }
            TestInitial t = new TestInitial();
            MyClass obj = new MyClass();
            //创建委托
            EventHandler MyHandler = new EventHandler(MyEventHandler);
            MyHandler += MyEventHandle2;
            MyHandler = MyEventHandle2;
            //将委托注册到事件
            obj.AEvent += MyHandler;
            ////激发事件
            //obj.FireAEvent();
            ////将委托从事件中撤销
            //obj.AEvent -= MyHandler;
            //再次激发事件
            obj.FireAEvent();

            
            try
            {
                int []source=new int [5];
                int []dest=new int [5];
                for (int i = 0; i < 5; i++)
                {
                    source[i] = i;
                }
                Buffer.BlockCopy(source, 0, dest, 0, 20);
                str strsour0 = new str(1, 2, source);
                unsafe
                {
                    int l1 = Marshal.SizeOf(strsour0);
                    int l2 = sizeof(st2);
                }
                str strsour, strsour2;
                strsour.a = 1;
                strsour.b = 2;
                strsour.arr = source;
                strsour2 = strsour;
                strsour.arr[0] = 12;
                
                //strsour.AddTest(1, 2);
                ArrayTest(strsour);
                string studyInstanceUid = "0123333";
                string ssss=string.Format("StudyInstanceUIDFK='{0}'", studyInstanceUid);
                ulong playCode = 4;
                if (ulong.TryParse("4611686087146864710", out playCode))
                {

                }
               
            }
            catch (System.Exception ex)
            {
                string s = ex.Message;
                string s2 = ex.ToString();
            }
            
            string instr = "021Abc9000021";
            string[] spl = instr.Split(new string[] { "021" }, System.StringSplitOptions.None);

            string inputStr = Console.ReadLine();
            string[] splitInput = inputStr.Split(' ');
            string[] inputNums = splitInput[1].Split(',');
            int minNum = 0;
            if (splitInput[0] == "DESC")
            {
                inputNums[0] = OrderInputStr(inputNums[0], false);
                minNum = Convert.ToInt32(inputNums[0]);
                for (int i = 1; i < inputNums.Length; i++)
                {
                    inputNums[i] = OrderInputStr(inputNums[i], false);
                    if (Convert.ToInt32(inputNums[i]) < minNum)
                    {
                        minNum = Convert.ToInt32(inputNums[i]);
                    }
                }
            }
            else
            {
                inputNums[0] = OrderInputStr(inputNums[0], true);
                minNum = Convert.ToInt32(inputNums[0]);
                for (int i = 1; i < inputNums.Length; i++)
                {
                    inputNums[i] = OrderInputStr(inputNums[i], true);
                    if (Convert.ToInt32(inputNums[i]) < minNum)
                    {
                        minNum = Convert.ToInt32(inputNums[i]);
                    }
                }
            }
            Console.WriteLine(minNum);
            for (int i = 0; i < inputNums.Length; i++)
            {
                Console.WriteLine(inputNums[i]);
            }


            int strNum = 0;
            string tem = "";
            strNum = Convert.ToInt32(Console.ReadLine());
            string utstr = "MGDa aha BDTmfV ShOBHM QqFdcsFk WeSj YDyBY RldCiGFB h gLmLEXW pWOJywCx eFcUlSfaH krFjsPC Vv viYTX bhkHwulzFC Ya R EEhgyd zM IHp pSDmVZ oAeSLWTtd bZO F kD TqPZ hI ITwU BMpsBRkQ ZQhOGB LCvYTEqHqA flp Bcc VDEtYbz uprsKe zJYEEPiVkL KYUwgtJfL vVZp AmnaxgeA QwDXJQOxNU thkhsKEMBr zM DxnWRwnfh PDYaSCbwmR n kG KfDD tLpaLPqBaj oXBLTJGo pnEwvEHhic WzMfONKYG CiFcccEh vfKRxZbLhq";
            string[] outstr = utstr.Split(' ');
            //for (int i = 0; i < strNum; i++)
            //{
            //    outstr[i] = Console.ReadLine();
            //}
            for (int i = 0; i < strNum; i++)
            {
                for (int j = i + 1; j < strNum; j++)
                {
                    if (Compare(outstr[i], outstr[j]))
                    {
                        tem = outstr[i];
                        outstr[i] = outstr[j];
                        outstr[j] = tem;
                    }
                }
            }
            for (int i = 0; i < strNum; i++)
            { Console.WriteLine(outstr[i]); }

            int[] intArray1 = { 1, 2 };
            int[] intArray2 = (int[])intArray1.Clone();
            intArray1[1] = 5;
            int a=intArray2[1];


            Parallel.For(0, 1000, (i, X) =>
            {
                if (_result == 300)
                {
                    X.Break();
                    return;
                }
                
            });
            //Func<int, int> fun = delegate(int x) { return x; };
            //Func<int, int> lam = x=>{ return x; };
            //Func<int, int> fu = Add;
            //Action<int> ac = delegate(int x) { ; };
            //new Thread(Work).Start(); //新线程会被阻塞，因为_go == false
            //Console.ReadLine(); //等待用户输入
            //lock (_locker)
            //{
            //    _go = true; //改变阻塞条件
            //    Monitor.Pulse(_locker); //通知等待的队列。
            //}
            //Thread.Sleep(1000);

            while (true)
            {
                Task[] _tasks = new Task[20];
                int i = 0;

                for (i = 0; i < _tasks.Length; i++)
                {
                    _tasks[i] = Task.Factory.StartNew((num) =>
                    {
                        var taskid = (int)num;
                        Work(taskid);
                    }, i);
                }

                Task.WaitAll(_tasks);
                Console.WriteLine(_result);

                Console.ReadKey();
            }
        }
        static string OrderInputStr(string inputStr,bool isAesc)
        {
            char []convertChar=inputStr.ToCharArray();
            char tem;
            for (int i = 0; i < inputStr.Length; i++)
            {
                for (int j = i + 1; j < inputStr.Length; j++)
                {
                    if(isAesc)
                    {
                        if(convertChar[i]>convertChar[j])
                        {
                            tem = convertChar[i];
                            convertChar[i] = convertChar[j];
                            convertChar[j] = tem;
                        }
                    }
                    else
                    {
                        if (convertChar[i] < convertChar[j])
                        {
                            tem = convertChar[i];
                            convertChar[i] = convertChar[j];
                            convertChar[j] = tem;
                        }
                    }
                    
                }
            }
            return new string(convertChar);
        }
        static bool Compare(string str1, string str2)
        {
            bool res = true;
            int loop = str1.Length;
            if (str1.Length > str2.Length)
            { loop = str2.Length; }
            for (int i = 0; i < loop; i++)
            {
                if (str1[i] > str2[i])
                {
                    res = true;
                    break;
                }
                if (str1[i] < str2[i])
                {
                    res = false;
                    break;
                }
            }
            return res;
        }
        private static int Add(int x)
        {
            return x;
        }
        static void Work()
        {
            lock (_locker)
            {
                while (!_go) //只要_go字段是false，就等待。
                    Monitor.Wait(_locker); //在等待的时候，锁已经被释放了。
            }
            Console.WriteLine("被唤醒了");
        }
        //线程调用方法
        private static void Work(int TaskID)
        {
            for (int i = 0; i < 10; i++)
            {
               // _result++;
                Interlocked.Increment(ref _result);
            }
        }
        ~Program()
        {

        }
    }

}
