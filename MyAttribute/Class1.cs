using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public class ExecuteMeAttribute : Attribute
    {
        public object[] Parameters { get; }
        
        public ExecuteMeAttribute(params object[] parameters)
        {
            Parameters = parameters;
        }
    }
}
