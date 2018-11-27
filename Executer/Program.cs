using MyAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Executer
{
    class Program
    {
        static void Main()
        {
            var a = Assembly.LoadFrom("../../../MyLibrary/bin/Debug/MyLibrary.dll");
           
            foreach (Type _class in a.GetTypes())
            {
                if (_class.IsClass && _class.GetConstructor(new Type[]{})!=null)
                {
                    //Console.WriteLine("class:'"+_class+"'");
                    object instanceOfClass = Activator.CreateInstance(_class);
                    
                    foreach (MethodInfo method in _class.GetMethods())
                    {
                        //Console.WriteLine("     method:'" + method.Name + "'");
                        ExecuteMeAttribute[] executeMeAttributes = (ExecuteMeAttribute[])method.GetCustomAttributes(typeof(ExecuteMeAttribute), true);

                        foreach (ExecuteMeAttribute aa in executeMeAttributes)
                        {
                            var stringRepresentationOfParameters = string.Join(", ", aa.Parameters);
                            //Console.WriteLine("             parameters:'"+stringRepresentationOfParameters+"'");
                            method.Invoke(instanceOfClass, aa.Parameters);
                        }
                    }
                }
            }
        }
    }
}
