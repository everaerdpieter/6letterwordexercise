using System;
using System.Collections.Generic;
using System.Linq;

namespace WordCombiner {
  public class WordCombineAlgorithm {
    private readonly int _combinationLength;

    public WordCombineAlgorithm(int combinationLength) {
      _combinationLength = combinationLength;
    }

    public IEnumerable<Combination> FindCombinations(IEnumerable<string> inputWords) {
      var completeMatches = new HashSet<string>(inputWords.Where(x => x.Length == _combinationLength).Distinct());
      var partialMatches = new HashSet<string>(completeMatches.SelectMany(completeMatch => GetParialMatchesForWord(completeMatch)).Distinct());
      var wordsToCombine = inputWords.Where(x => x.Length < _combinationLength).Distinct().ToList();

      var partialMatchingCombinations = wordsToCombine
        .Select(x => new Combination(new[] { x }))
        .Where(x => partialMatches.Contains(x.Combined))
        .ToList();
      var matchingCombinations = FindMatchesByAddingInputWords(inputWords, partialMatchingCombinations, partialMatches, completeMatches);
      foreach (var matchingCombination in matchingCombinations) {
        yield return matchingCombination;
      }
    }

    private IEnumerable<string> GetParialMatchesForWord(string completeMatch) {
      for (int partialMatchLength = 1; partialMatchLength < completeMatch.Length; partialMatchLength++) {
        yield return completeMatch.Substring(0, partialMatchLength);
      }
    }

    private IEnumerable<Combination> FindMatchesByAddingInputWords(
      IEnumerable<string> inputWords,
      List<Combination> partialMatchingCombinations,
      HashSet<string> partialMatches,
      HashSet<string> completeMatches) {
      if (!partialMatchingCombinations.Any()) {
        return Enumerable.Empty<Combination>();
      }

      var combinationsWithOneWordExtra = partialMatchingCombinations.SelectMany(
          partialMatch => inputWords.Select(inputWord => new Combination(partialMatch.Words.Concat(new[] {inputWord}))))
        .Distinct()
        .ToList();
      var completeMatchesAfterAddingOneWord = combinationsWithOneWordExtra.Where(x => completeMatches.Contains(x.Combined)).ToList();
      var partialMatchesAfterAddingOneWord = combinationsWithOneWordExtra.Where(x => partialMatches.Contains(x.Combined)).ToList();
      var matchesAfterAddingMoreThanOneWord = FindMatchesByAddingInputWords(inputWords, partialMatchesAfterAddingOneWord, partialMatches, completeMatches);
      return completeMatchesAfterAddingOneWord.Concat(matchesAfterAddingMoreThanOneWord).ToList();
    }
  }
}

