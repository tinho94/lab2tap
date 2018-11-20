using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public class ExecuteMeAttribute : Attribute
    {
        private List<object> Parameters { get; set; }

        public ExecuteMeAttribute(params object[] parameters)
        {
            foreach (object variable in parameters)
            {
                Parameters.Add(variable);
            }    
        }
    }
}
