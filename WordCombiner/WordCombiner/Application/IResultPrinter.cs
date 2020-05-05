using System.Collections.Generic;

namespace WordCombiner.Application
{
  public interface IResultPrinter {
    void Print(IEnumerable<string> results);
  }
}