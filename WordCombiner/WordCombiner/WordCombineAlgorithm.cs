using System.Collections.Generic;
using System.Linq;

namespace WordCombiner {
  public class WordCombineAlgorithm {
    private readonly int _combinationLength;

    public WordCombineAlgorithm(int combinationLength) {
      _combinationLength = combinationLength;
    }

    public IEnumerable<string> FindCombinations(IEnumerable<string> inputWords) {
      var inputWordsToMatch = inputWords.Where(x => x.Length == _combinationLength).ToList();
      var inputWordsToCombine = new HashSet<string>(inputWords.Where(x => x.Length < _combinationLength));
      foreach (var inputWordToMatch in inputWordsToMatch) {
        if (CanBeCombined(inputWordToMatch, inputWordsToCombine)) {
          yield return inputWordToMatch;
        }
      }
    }

    private bool CanBeCombined(string wordToMatch, HashSet<string> inputWordsToCombine) {
      if (inputWordsToCombine.Contains(wordToMatch)) {
        return true;
      }

      return inputWordsToCombine.Where(x => wordToMatch.StartsWith(x)).Any(x => CanBeCombined(wordToMatch.Substring(x.Length), inputWordsToCombine));
    }
  }
}
