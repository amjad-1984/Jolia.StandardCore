namespace Jolia.Core.Logic
{
    public static class Numbers
    {
        public static string GetRandomCode()
        {
            var r = new System.Random();
            return r.Next(1000, 9999).ToString();
        }

        public static string GetRandomPassword()
        {
            var r = new System.Random();
            return r.Next(100000, 999999).ToString();
        }
    }
}
