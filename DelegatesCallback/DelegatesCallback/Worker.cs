using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DelegatesCallback
{
  class Worker
  {
    public Worker(CallBackDelegate resultCallBack)
    {
      // This time delay represents the action being done
      // In real world application, you will put the code that takes time instead
      Thread.Sleep(5000);
      
      // Invoking the delegate object which will in turn invoke the method associated with it
      resultCallBack(true);
    }
  }
}
