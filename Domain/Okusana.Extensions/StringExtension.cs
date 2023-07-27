using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Okusana.Extensions
{
    static public class StringExtension
    {
        /// <summary>
        /// string içindeki verinin boş olmasını ve  telefon numarası doğruluğunu kontrol eder ve bool döner. 5 ile başlayan ve yanında 9 adet rakam olan sayı diye kontrol eder.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static public bool IsPhoneNumber(this string? str)
            => !string.IsNullOrEmpty(str) && Regex.IsMatch(str, @"^5\d{9}$");
        //regex gpt den alma yanlış olabilir testi yapılacak
        // nullable olduğu için önce null kontrol edilirki burada null ise direk false döner regex işlemci yormaz cube e notlar.
   
        static public bool IsIdentityNumber(this string? str)
        {//gpt ye yazdırıldı burası geçici zaten ilerde gerekir ise apiden doğrulama alıınır.
            if (string.IsNullOrWhiteSpace(str) || str.Length != 11)
            {
                return false;
            }

            int[] digits = str.Select(c => int.Parse(c.ToString())).ToArray();

            int sumEvenDigits = digits[0] + digits[2] + digits[4] + digits[6] + digits[8];
            int sumOddDigits = digits[1] + digits[3] + digits[5] + digits[7];

            int tenthDigit = (sumEvenDigits * 7 - sumOddDigits) % 10;
            if (tenthDigit < 0) tenthDigit += 10;

            int eleventhDigit = (sumEvenDigits + sumOddDigits + digits[9]) % 10;
            if (eleventhDigit < 0) eleventhDigit += 10;

            return digits[9] == tenthDigit && digits[10] == eleventhDigit;
        }
    
    
    }
}
