﻿using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityStudy.Unity
{
    public class MyInterception : IInterceptionBehavior
    {
        bool IInterceptionBehavior.WillExecute
        {
            get
            {
                return true;
            }
        }

        IEnumerable<Type> IInterceptionBehavior.GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        IMethodReturn IInterceptionBehavior.Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Console.WriteLine("Interception: Here are the inputs:");
            foreach (var i in input.Arguments)
            {
                Console.WriteLine(" --> " + i.ToString());
            }

            var returnValue = getNext()(input, getNext);

            Console.Write("Interception: Here is the output:");
            Console.WriteLine(returnValue.ReturnValue.ToString());
            Console.WriteLine();

            return returnValue;
        }
    }
}
