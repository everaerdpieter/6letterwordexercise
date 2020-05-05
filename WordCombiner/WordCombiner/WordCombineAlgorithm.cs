using System.Collections.Generic;
using System.Linq;

namespace WordCombiner {
  public class WordCombineAlgorithm {
    private readonly int _combinationLength;

    public WordCombineAlgorithm(int combinationLength) {
      _combinationLength = combinationLength;
    }

    public IEnumerable<Combination> FindCombinations(IEnumerable<string> inputWords) {
      var wordsToMatch = inputWords.Where(x => x.Length == _combinationLength).Take(10).ToList();
      var wordsToCombine = inputWords.Where(x => x.Length < _combinationLength).ToList();

      var combinations = new List<Combination>();
      foreach (var wordToMatch in wordsToMatch) {
        var partialMatchingCombinations = wordsToCombine.Select(x => new Combination(new[] {x})).Where(x => x.IsPartialMatch(wordToMatch)).ToList();
        var matchingCombinationsForCurrentWordToMatch = FindMatchesByAddingInputWords(wordToMatch, inputWords, partialMatchingCombinations);
        combinations.AddRange(matchingCombinationsForCurrentWordToMatch);
      }

      return combinations;
    }

    private IEnumerable<Combination> FindMatchesByAddingInputWords(
      string wordToMatch,
      IEnumerable<string> inputWords,
      IEnumerable<Combination> partialMatches) {
      if (!partialMatches.Any()) {
        return Enumerable.Empty<Combination>();
      }

      var combinationsWithOneWordExtra = partialMatches.SelectMany(
          partialMatch => inputWords.Select(inputWord => new Combination(partialMatch.Words.Concat(new[] {inputWord}))))
        .Distinct()
        .ToList();
      var matchesAfterAdding1Word = combinationsWithOneWordExtra.Where(x => x.IsMatch(wordToMatch)).ToList();
      var partialMatchesAfterAddingOneWord = combinationsWithOneWordExtra.Where(x => x.IsPartialMatch(wordToMatch)).ToList();
      var matchesAfterAddingMoreThenOneWord = FindMatchesByAddingInputWords(wordToMatch, inputWords, partialMatchesAfterAddingOneWord);
      return matchesAfterAdding1Word.Concat(matchesAfterAddingMoreThenOneWord).ToList();
    }
  }
}

