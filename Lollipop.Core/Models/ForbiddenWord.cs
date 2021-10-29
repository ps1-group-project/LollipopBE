namespace Lollipop.Core.Models
{
    public class ForbiddenWord
    {
        /// <summary>
        /// ForbiddenWord identifier.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Forbidden Word.
        /// </summary>
        public string Word { get; private set; }

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
