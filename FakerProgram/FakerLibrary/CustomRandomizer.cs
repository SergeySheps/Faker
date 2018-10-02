using System;
using System.Linq;
using System.Text;

namespace FakerLibrary
{
    public class CustomRandomizer
    {
        private Random rnd = new Random();

        public Int32 GetInt32()
        {
            return rnd.Next();
        }

        public Int64 GetInt64()
        {
            return (Int64)(Math.Pow(rnd.Next(),2));
        }

        public Double GetDouble()
        {
            return rnd.NextDouble();
        }

        public Single GetSingle()
        {
            return (float)rnd.NextDouble();
        }

        public string GetString(int length = 15)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[rnd.Next(s.Length)]).ToArray());
        }

        public DateTime GetDateTime()
        {
            return new DateTime(rnd.Next(1990, 2018), rnd.Next(1, 11), rnd.Next(1, 28));
        }

    }
}
