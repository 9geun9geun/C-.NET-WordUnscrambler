using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordUnscrambler.Workers;

namespace WordUnscrambler.Test.Unit
{
    [TestClass]
    public class WordMatcherTest
    {
        private readonly WordMatcher _wordMatcher = new WordMatcher();

        [TestMethod]
        public void ScrambledWordMatchesGivenWordInTheList()
        {
            string[] words = { "cat", "chair", "more"};       //loaded word list
            string[] scrambledWords = { "omre" };             //loaded scrambled Words
            
            var matchedWords = _wordMatcher.Match(scrambledWords, words);  
            //then passing it to wordMatcher 

            Assert.IsTrue(matchedWords.Count == 1); //then expecting the Matcher will have one match exactly
            Assert.IsTrue(matchedWords[0].ScrambledWord.Equals("omre"));
            Assert.IsTrue(matchedWords[0].Word.Equals("more"));
        }   /*on the struct we will have the scrambledword and word and if scrambled word is omre and word is more
            then that is the correct match*/

        [TestMethod]
        public void ScrambledWordMatchesGivenWordsInTheList()
        {
            string[] words = { "cat", "chair", "more" };       
            string[] scrambledWords = { "omre", "act" };             

            var matchedWords = _wordMatcher.Match(scrambledWords, words);
            
            Assert.IsTrue(matchedWords.Count == 2); 
            Assert.IsTrue(matchedWords[0].ScrambledWord.Equals("omre"));
            Assert.IsTrue(matchedWords[0].Word.Equals("more"));
            Assert.IsTrue(matchedWords[1].ScrambledWord.Equals("act"));
            Assert.IsTrue(matchedWords[1].Word.Equals("cat"));
        }   
    
    }

}
