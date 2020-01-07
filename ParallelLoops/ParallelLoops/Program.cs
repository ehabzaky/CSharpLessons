using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelLoops
{
  class Program
  {
    static void Main(string[] args)
    {
      // Stopwatch object is defined here and used to measure the execution times of all loops.
      Stopwatch sw = new Stopwatch();

      // Standard for loop iteration
      sw.Start();
      for (int n = 0; n < 10000000; n++)
      {
        string converted = n.ToString();
        if (n == 5)
        {
          break;
        }
      }
      Console.WriteLine($"Standard for loop takes {sw.ElapsedMilliseconds} milliseconds");

      // Parallel For loop iteration
      sw.Restart();
      ParallelLoopResult forResult = Parallel.For(0, 10000000, (n, state) => {
        string converted = n.ToString();
        if(n== 5)
        {
          // Break method prevent any new iterations from being created. However, it allows any running iteration to complete.
          state.Break();
          // Stop method immediately stops all running iteration and prevent any new iterations from being created.
          //state.Break();
        }
      });
      Console.WriteLine($"Parallel For loop takes {sw.ElapsedMilliseconds} milliseconds");
      
      // Printing the properties of return value of For mehhod
      Console.WriteLine($"IsCompleted = {forResult.IsCompleted}");
      Console.WriteLine($"LowestBreakIteration = {forResult.LowestBreakIteration}");

      // Defining an array of URLs
      string[] urls = {"https://www.google.com", "https://www.microsoft.com", "https://www.visualstudio.com", "https://www.amazon.com", "https://www.youtube.com", "https://www.fb.com", "https://www.twitter.com" };

      // Parallel Foreach loop
      sw.Restart();
      Parallel.ForEach(urls, url => {
        HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
        myRequest.Method = "GET";
        WebResponse myResponse = myRequest.GetResponse();
        StreamReader sr = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
        string result = sr.ReadToEnd();
        sr.Close();
        myResponse.Close();
        Console.WriteLine($" First 10 characters of '{url}' are \n {result.Substring(0, 10)}");
      });
      Console.WriteLine($"Parallel Foreach loop takes {sw.ElapsedMilliseconds} milliseconds");

      // Standard foreach loop
      sw.Restart();
      foreach (string url in urls)
      {
        HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
        myRequest.Method = "GET";
        WebResponse myResponse = myRequest.GetResponse();
        StreamReader sr = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
        string result = sr.ReadToEnd();
        sr.Close();
        myResponse.Close();
        Console.WriteLine($" First 10 characters of '{url}' are \n {result.Substring(0, 10)}");
      }
      Console.WriteLine($"Standard foreach loop takes {sw.ElapsedMilliseconds} milliseconds");
    }
  }
}
