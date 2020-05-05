using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordCombiner.Test
{
    [TestClass]
    public class WordCombineAlgorithmTest
    {
      private WordCombineAlgorithm _sut;

      [TestInitialize]
      public void TestIntialize() {
        var combinationLength = 6;
        _sut = new WordCombineAlgorithm(combinationLength);
      }

      [TestMethod]
      public void GivenOnly1ValidCombinationOf2Words_ItShouldReturnTheCombination() {
        // arrange
        var inputWords = new[] {"foo", "bar", "foobar"};

        // act
        var result = _sut.FindCombinations(inputWords);
        
        // assert
        Assert.AreEqual(1, result.Count());
        Assert.AreEqual("foobar", result.Single());
      }
      
      [TestMethod]
      public void GivenOnly1ValidCombinationOf3Words_ItShouldReturnTheCombination() {
        // arrange
        var inputWords = new[] {"ob", "fo", "ar", "foobar"};

        // act
        var result = _sut.FindCombinations(inputWords);
        
        // assert
        Assert.AreEqual(1, result.Count());
        Assert.AreEqual("foobar", result.Single());
      }

      [TestMethod]
      public void GivenOnly1ValidCombinationOf6Words_ItShouldReturnTheCombination() {
        // arrange
        var inputWords = new[] {"f", "o", "o", "b", "a", "r", "foobar"};

        // act
        var result = _sut.FindCombinations(inputWords);
        
        // assert
        Assert.AreEqual(1, result.Count());
        Assert.AreEqual("foobar", result.Single());
      }

      [TestMethod]
      public void GivenNoValidCombinationOf2Words_ItShouldReturnNoCombination() {
        // arrange
        var inputWords = new[] {"foo", "xxx", "foobar"};

        // act
        var result = _sut.FindCombinations(inputWords);
        
        // assert
        Assert.AreEqual(0, result.Count());
      }

      [TestMethod]
      public void GivenACombinationOfTheWrongLength_ItShouldReturnNoCombination() {
        // arrange
        var inputWords = new[] {"foo", "ba", "fooba"};

        // act
        var result = _sut.FindCombinations(inputWords);
        
        // assert
        Assert.AreEqual(0, result.Count());
      }

      [TestMethod]
      public void GivenAPartialMatch_ItShouldReturnNoCombination() {
        // arrange
        var inputWords = new[] {"foo", "ba", "foobar"};

        // act
        var result = _sut.FindCombinations(inputWords);
        
        // assert
        Assert.AreEqual(0, result.Count());
      }
    }
}
