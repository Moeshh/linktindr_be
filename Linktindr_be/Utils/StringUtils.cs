namespace Linktindr_be.Utils
{
    public class StringUtils
    {
        public static string RandomToken()
        {
            return RandomString(100);
        }

        public static string RandomString(int length)
        {
            Random rand = new Random();
            string charbase = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Range(0, length)
                   .Select(_ => charbase[rand.Next(charbase.Length)])
                   .ToArray());
        }
    }
}
