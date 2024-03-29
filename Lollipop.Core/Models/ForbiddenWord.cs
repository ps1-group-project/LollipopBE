﻿namespace Lollipop.Core.Models
{
    public class ForbiddenWord : Base
    {


        /// <summary>
        /// Forbidden Word.
        /// </summary>
        public string Word { get; set; }

        private ForbiddenWord(){}

        private ForbiddenWord(string word)
        {
            Word = word;
        }

        /// <summary>
        /// Create new forbidden word
        /// </summary>
        /// <param name="word">Word</param>
        /// <returns>New forbidden word</returns>
        public static ForbiddenWord Create(string word)
        {
            return new(word);
        }
    }
}
