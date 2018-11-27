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
           
            /*
            Aggiungete al Main del codice che, sfruttando la reflection, invochi tutti i metodi pubblici 
            (di tutte le classi trovate nella DLL) che siano stati annotati con [ExecuteMe], 
            passando come argomenti gli argomenti dell'annotazione.
            Facendo riferimento alla classe Foo mostrata sopra, M1 dovrà essere invocato senza parametri, 
            il metodo M2 dovrà essere invocato tre volte 
            (con argomenti: 3, 0 e 45) e M3 dovrà essere invocato una volta con argomenti s1="hello" e s2="reflection".
            Notate che per invocare i metodi d'istanza dovrete prima creare degli oggetti 
            (motivo per cui abbiamo detto di inserire classi con costruttori pubblici senza argomenti)...Hint: classe Activator...
            In questa prima release assumete che non ci siano errori nelle annotazioni 
            ovvero che numero e tipi degli argomenti di ciascuna annotazione corrispondano 
            a quanto necessario per l'invocazione del metodo annotato.
            Assumete anche che i parametri dei metodi in MyLibrary siano tutti per valore, necessari e non "params".
            */
            foreach (Type _class in a.GetTypes())
            {
                if (_class.IsClass)
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
