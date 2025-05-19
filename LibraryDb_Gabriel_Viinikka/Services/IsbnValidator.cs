using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace LibraryDb_Gabriel_Viinikka.Services
{
    public class IsbnValidator
    {

        public IsbnValidator()
        {
            
        }

        public bool Validate(string isbn)
        {
            bool valid = false;

            if (IsbnLenghtValid(isbn))
            {
                if(isbn.Length == 13)
                {
                    valid = ThirteenValidator(isbn);
                }
                else
                {
                    valid = TenValidator(isbn);
                }
            }

            return valid;
        }

        private bool IsbnLenghtValid(string isbn)
        {
            bool valid = false;

            Debug.WriteLine($"{isbn} Length: {isbn.Length}");

            if (isbn == null)
            {
                return valid;
            }
            else if (isbn == string.Empty)
            {
                return valid;
            }
            else if (isbn.Length != 10 && isbn.Length != 13)
            {
                return valid;
            }

            return true;
        }

        private bool TenValidator(string isbn)
        {
            bool valid = false;



            return valid;
        }
        private bool ThirteenValidator(string isbn)
        {
            bool valid = false;


            int checkSum = 0;
            int counter = 1;
            foreach (char number in isbn)
            {
                bool parsed = int.TryParse(number.ToString(), out int parsedNumber);

                bool even = counter % 2 == 0 ? true : false;

                if (even) checkSum += parsedNumber * 3;
                if (!even) checkSum += parsedNumber * 1;

                counter++;
            }

            Math.DivRem(checkSum, 10,out int remainder);

            if(remainder == 0)
            {
                valid = true;
            }

            return valid;
        }

    }
}
