using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCombiner {
  public class WordCombineAlgorithm {
    private readonly int _combinationLength;

    public WordCombineAlgorithm(int combinationLength) {
      _combinationLength = combinationLength;
    }

    public IEnumerable<string> FindCombinations(IEnumerable<string> inputWords) {
      var inputWordsOfCorrectLength = inputWords.Where(x => x.Length == _combinationLength).ToList();
      var combinationsOfCorrectLength = GetCombinationsOfCorrectLength(inputWords);

      return inputWordsOfCorrectLength.Where(inputWord => combinationsOfCorrectLength.Contains(inputWord));
    }

    private IEnumerable<string> GetCombinationsOfCorrectLength(IEnumerable<string> inputWords)
    {
      foreach (var inputWord in inputWords)
      {
        var combinations = CreateCombinationWith1ExtraWords(inputWord, inputWords);
        var combinationsWithCorrectLength = combinations.Where(x => x.Length == _combinationLength).ToList();
        foreach (var c in combinationsWithCorrectLength) {
          yield return c;
        }
      }
    }

    private IEnumerable<string> CreateCombinationWith1ExtraWords(string inputWord, IEnumerable<string> inputWords) {
      return inputWords.Select(x => $"{inputWord}{x}");
    }
  }
}
