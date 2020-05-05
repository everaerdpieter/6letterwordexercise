using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCombiner.Application;
using WordCombiner.Infrastructure;

namespace WordCombiner {
  class Program {
    static void Main(string[] args) {
      if (args.Length == 0) {
        Console.WriteLine("Please provide input file path as first parameter");
      }
      else {
        // in production I would use a DI container like Autofac
        var inputFilePath = args[0];
        var inputWordRepository = new InputWordRepository(inputFilePath);
        var resultPrinter = new ResultPrinter();
        var wordCombineHandler = new WordCombineHandler(inputWordRepository, resultPrinter);

        wordCombineHandler.Handle();
      }

      Console.ReadKey();
    }
  }
}
