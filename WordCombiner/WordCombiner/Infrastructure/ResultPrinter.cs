using System;
using System.Collections.Generic;
using WordCombiner.Application;

namespace WordCombiner.Infrastructure
{
  class ResultPrinter : IResultPrinter
  {
    public void Print(IEnumerable<Combination> combinations) {
      Console.WriteLine("--Combinations");
      foreach (var combination in combinations) {
        var sumString = string.Join("+", combination.Words);
        Console.WriteLine($"{sumString}={combination.Combined}");
      }
      Console.WriteLine("--End of combinations");
    }
  }
}