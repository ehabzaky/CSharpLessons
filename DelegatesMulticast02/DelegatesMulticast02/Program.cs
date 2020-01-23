using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesMulticast02
{
  // declaration of delegate type used in multiple classes
  public delegate void ProgressDelegate(int progress);

  class Program
  {
    static void Main(string[] args)
    {
      // Creating the delegate object as link it to ShowStatus method
      ProgressDelegate statusDelegate = ShowStatus;
      
      // Adding OperationCompleted method to the delegate call list
      statusDelegate += OperationCompleted;
      
      // Starting the worker object
      Worker myWorker = new Worker(statusDelegate);
    }

    // This method will display work progress to user
    static void ShowStatus(int status)
    {
      Console.Write($"\r{status}% ");
    }

    // This method will take some action upon work completed
    static void OperationCompleted(int status)
    {
      if (status == 100)
      {
        Console.WriteLine("Job completed successfully!");
      }
    }
  }
}