namespace WordCombiner.Application {
  public class WordCombineHandler {
    private const int CombinationLength = 6;

    private readonly IInputWordRepository _inputWordRepository;
    private readonly IResultPrinter _resultPrinter;
    private WordCombineAlgorithm _wordCombineAlgorithm;

    public WordCombineHandler(IInputWordRepository inputWordRepository, IResultPrinter resultPrinter) {
      _inputWordRepository = inputWordRepository;
      _resultPrinter = resultPrinter;

      // give handler responsibility to determine algorithm details: 
      _wordCombineAlgorithm = new WordCombineAlgorithm(CombinationLength);
    }

    public void Handle() {
      var inputWords = _inputWordRepository.GetInputWords();
      var results = _wordCombineAlgorithm.FindCombinations(inputWords);
      _resultPrinter.Print(results);
    }
  }
}
