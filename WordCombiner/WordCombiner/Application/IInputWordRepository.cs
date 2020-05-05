using System.Collections.Generic;

namespace WordCombiner.Application
{
  public interface IInputWordRepository {
    IEnumerable<string> GetInputWords();
  }
}