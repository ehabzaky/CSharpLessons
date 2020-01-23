using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DelegatesMulticast02
{
  public class Worker
  {
    public Worker(ProgressDelegate status)
    {
      for (int counter = 0; counter <= 100; counter++)
      {
        // This bit of time delay represents the action being done
        // In real world application, you will put the code that takes time instead
        Thread.Sleep(50);

        // Invoking the delegate object with the percentage passed which will in turn invoke the methods associated with it
        status(counter);
      }
    }
  }
}