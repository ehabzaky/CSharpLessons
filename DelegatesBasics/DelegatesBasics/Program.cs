using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesBasics
{
  class Program
  {

    // Delegate type declaration used inside this class
    public delegate int MathOperation(int x, int y);

    static void Main(string[] args)
    {
      // Creating a delegate object for AddNumbers method then invoke it
      MathOperation AddOperation = AddNumbers;
      Console.WriteLine($"AddNumbers call result = {AddOperation(5, 10)}");
      
      // Creating a delegate object for SubtractNumbers method then invoke it
      MathOperation SubOperation = SubtractNumbers;
      Console.WriteLine($"SubtractNumbers call result = {SubOperation(20, 10)}");
    }

    static public int AddNumbers(int x, int y)
    {
      return x + y;
    }

    static public int SubtractNumbers(int x, int y)
    {
      return x - y;
    }
  }
}
