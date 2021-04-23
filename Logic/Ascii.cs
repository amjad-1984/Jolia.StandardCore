namespace Jolia.Core.Logic
{
    public static class Ascii
    {
        public static string NumberToLetter(int Number)
        {
            var LastLetterAscii = 64 + Number;
            return (((char)LastLetterAscii).ToString() + " ").Trim();
        }

        public static int CharToNumber(char Char)
        {
            return char.ToUpper(Char) - 64;
        }
    }
}
