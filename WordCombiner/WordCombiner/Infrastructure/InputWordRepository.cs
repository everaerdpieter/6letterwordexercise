using System.Collections.Generic;
using System.IO;
using System.Linq;
using WordCombiner.Application;

namespace WordCombiner.Infrastructure
{
  class InputWordRepository : IInputWordRepository
  {
    private string _inputFilePath;

    public InputWordRepository(string inputFilePath) {
      _inputFilePath = inputFilePath;
    }

    public IEnumerable<string> GetInputWords() {
      return File.ReadAllLines(_inputFilePath).Select(x => x.Trim()).ToList();
    }
  }
}