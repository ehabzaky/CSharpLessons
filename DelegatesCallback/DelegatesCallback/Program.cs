using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesCallback
{
  // declaration of delegate type outside the class to be able to use in multiple classes
  public delegate void CallBackDelegate(bool isSuccess);

  class Program
  {
    static void Main(string[] args)
    {
      // Creating a delegate object
      CallBackDelegate caller = CallMeBack;
      Console.WriteLine("Calling worker ...");
      
      // Calling the worker object and pass it a copy of a delegate
      // Worker object will notify me back by calling this delegate
      // Calling the delegate will fire the method CallMeBack
      Worker myWorker = new Worker(caller);
    }

    // The method that will be invoked by the delegate
    public static void CallMeBack(bool result)
    {
      Console.WriteLine($"Callback method called with a result of {result}");
    }
  }
}
