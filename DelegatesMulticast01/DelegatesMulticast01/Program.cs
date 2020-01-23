using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesMulticast01
{
  class Program
  {
    // Delegate types declaration used inside this class
    public delegate void PrintingDelegate();

    static void Main(string[] args)
    {
      // Creating the delegate object as link it to Method1
      PrintingDelegate myPrinter = Method1;
      Console.WriteLine("Printer delegate first call");
      myPrinter();

      // Add Method2 to the delegate methods call list so it will be invoked as well
      myPrinter += Method2;
      Console.WriteLine("Printer delegate second call");
      myPrinter();
      
      // Removing Method1 from the delegate call list
      myPrinter -= Method1;
      Console.WriteLine("Printer delegate third call");
      myPrinter();
    }

    public static void Method1()
    {
      Console.WriteLine("This is method 1");
    }

    public static void Method2()
    {
      Console.WriteLine("This is method 2");
    }

  }
}
