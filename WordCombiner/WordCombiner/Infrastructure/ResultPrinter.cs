using System;
using System.Collections.Generic;
using WordCombiner.Application;

namespace WordCombiner.Infrastructure
{
  class ResultPrinter : IResultPrinter
  {
    public void Print(IEnumerable<string> results) {
      Console.WriteLine("Results:");
      foreach (var result in results) {
        Console.WriteLine(result);
      }
    }
  }
}