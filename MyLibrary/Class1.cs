using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyAttribute;

namespace MyLibrary
{
    public class Class1
    {
        public Class1() { }
        [ExecuteMe]
        public void M1()
        {
            Console.WriteLine("M1");
        }

        [ExecuteMe(45)]
        [ExecuteMe(0)]
        [ExecuteMe(3)]
        public void M2(int a)
        {
            Console.WriteLine("M2 a={0}", a);
        }

        [ExecuteMe("hello", "reflection")]
        public void M3(string s1, string s2)
        {
            Console.WriteLine("M3 s1={0} s2={1}", s1, s2);
        }
    }

    public class Class2
    {
        public Class2() { }
        [ExecuteMe]
        public void N1()
        {
            Console.WriteLine("N1");
        }

        [ExecuteMe(105)]
        [ExecuteMe(104)]
        [ExecuteMe(103)]
        public void N2(int a)
        {
            Console.WriteLine("N2 a={0}", a);
        }

        [ExecuteMe("hello", "reflection")]
        public void N3(string s1, string s2)
        {
            Console.WriteLine("N3 s1={0} s2={1}", s1, s2);
        }
    }

}
