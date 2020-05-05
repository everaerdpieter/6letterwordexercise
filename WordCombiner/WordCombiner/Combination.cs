using System.Collections.Generic;
using System.Linq;

namespace WordCombiner
{
  public class Combination{
    public IEnumerable<string> Words { get; }

    public Combination(IEnumerable<string> words) {
      Words = words.ToList();
    }

    public string Combined => Words.Aggregate((s1, s2) => s1 + s2);

    public bool IsPartialMatch(string wordToMach) {
      return wordToMach != Combined && wordToMach.StartsWith(Combined);
    }

    public bool IsMatch(string wordToMach) {
      return wordToMach == Combined;
    }

    protected bool Equals(Combination other)
    {
      return Equals(Words, other.Words);
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj))
        return false;
      if (ReferenceEquals(this, obj))
        return true;
      if (obj.GetType() != this.GetType())
        return false;
      return Enumerable.SequenceEqual(Words, ((Combination)obj).Words);
    }

    public override int GetHashCode() {
      if (Words != null) {
        var hashCode = 0;
        foreach (var word in Words) {
          hashCode = (hashCode * 397) ^ (word != null ? word.GetHashCode() : 0);
        }

        return hashCode;
      }
      else {
        return 0;
      }
    }
  }
}