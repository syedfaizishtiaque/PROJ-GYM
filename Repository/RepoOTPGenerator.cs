using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.Repository
{
    public static class RepoOTPGenerator 
    {
        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string GenerateOTP(string otp_type, string otp_length, string otp_prefix)
        {
            try
            {
                //string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                //string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
                //string numbers = DateTime.Now.ToString("ddMMyyhhmmssff");//"1234567890";

                //string characters = numbers;
                //if (otp_type == "1")
                //{
                //    characters += alphabets + small_alphabets + numbers;
                //}

                //int length = int.Parse(otp_length);

                //string otp = string.Empty;

                //for (int i = 0; i < length; i++)
                //{
                //    string character = string.Empty;
                //    do
                //    {
                //        int index = new Random().Next(0, characters.Length);
                //        character = characters.ToCharArray()[index].ToString();
                //    } while (otp.IndexOf(character) != -1);
                //    otp += character;
                //}
                string otp = RandomString(int.Parse(otp_length));
                return otp_prefix.ToUpper() + "-" + otp;
            }
            catch (Exception ex)
            {

                throw ex;
            }
         
        }

        public static string GenerateRandomString(int Length)
        {
            string _allowedChars = "#@$&*abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            Random randNum = new Random();
            char[] chars = new char[Length];

            for (int i = 0; i < Length; i++)
            {
                chars[i] = _allowedChars[Convert.ToInt32((_allowedChars.Length - 1) * randNum.NextDouble())];
            }
            return new string(chars);
        }

    }
}
