using System.Text;

namespace SchoolRegister.Services.Services
{
    public static class ExtensionServices
    {
        public static string FirstLetterOfEachWord(this string word)
        {
            var result = new StringBuilder(word.Length);
            bool IsNewSentence = true;
            for (int i = 0; i < word.Length; i++)
            {
                if (IsNewSentence && char.IsLetter(word[i]))
                {
                    result.Append(char.ToUpper(word[i]));
                    IsNewSentence = false;

                }

                if (word[i] == '!' || word[i] == '?' || word[i] == '.' || word[i] == ' ')
                {
                    IsNewSentence = true;
                }
            }
            return result.ToString();
        }
    }
}