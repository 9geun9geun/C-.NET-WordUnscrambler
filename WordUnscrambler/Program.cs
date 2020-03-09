using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordUnscrambler.Data;
using WordUnscrambler.Workers;


namespace WordUnscrambler
{
    class Program
    {
        private static readonly FileReader _fileReader = new FileReader(); //static because of static method
        private static readonly WordMatcher _wordMatcher = new WordMatcher();
        

        static void Main(string[] args)
        {
            try
            {
                bool continueWordUnscramble = true;
                do
                {
                    Console.WriteLine(Constants.OptionsOnHowToEnterScrambledWords);
                    var option = Console.ReadLine() ?? string.Empty;

                    switch (option.ToUpper())
                    {
                        case Constants.File:
                            Console.Write(Constants.EnterScrambledWordsViaFile);
                            ExecuteScrambledWordsInFile();
                            break;
                        case Constants.Manual:
                            Console.Write(Constants.EnterScrambledWordsManually);
                            ExecuteScrambledWordsManualEntry();
                            break;
                        default:
                            Console.Write(Constants.EnterScrambledWordsOptionNotRecognized);
                            break;
                    }

                    var continueDecision = string.Empty;
                    do
                    {
                        Console.Write(Constants.OptionsOnContinuingTheProgram);
                        continueDecision = (Console.ReadLine() ?? string.Empty);
                    } while (!continueDecision.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase) &&
                    !continueDecision.Equals(Constants.No, StringComparison.OrdinalIgnoreCase));

                    continueWordUnscramble = continueDecision.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase);
                } while (continueWordUnscramble);
            }
            catch(Exception ex)
            {
                Console.WriteLine(Constants.ErrorProgramWillBeTerminated + ex.Message);
            }
            
        }
        private static void ExecuteScrambledWordsManualEntry()
        {
            try
            {
                var manualInput = Console.ReadLine() ?? string.Empty;  //string empty if user not give anything
                string[] scrambledWords = manualInput.Split(',');   //words split with a comma
                DisplayMatchedUnscrambledWords(scrambledWords);
            }
            catch(Exception ex)
            {
                Console.WriteLine(Constants.ErrorScrambledWordsCannotBeLoaded + ex.Message);
            }
          
            
        }

        

        private static void ExecuteScrambledWordsInFile()
        {
            try
            {
                var fileName = Console.ReadLine() ?? string.Empty;
                string[] scrambledWords = _fileReader.Read(fileName);
                DisplayMatchedUnscrambledWords(scrambledWords);
            }
            catch(Exception ex)
            {
                Console.WriteLine(Constants.ErrorScrambledWordsCannotBeLoaded + ex.Message);
            }
           
        }

        private static void DisplayMatchedUnscrambledWords(string[] scrambledWords)
        {
            string[] wordList = _fileReader.Read(Constants.wordListFileName);

            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);
            
            if (matchedWords.Any())  //if list has anything in it...
            {
                foreach (var matchedWord in matchedWords)
                {
                    Console.WriteLine(Constants.MatchFound, matchedWord.ScrambledWord, matchedWord.Word);
                }
            }
            else
            {
                Console.WriteLine(Constants.MatchNotFound);
            }
        }
    }
}



