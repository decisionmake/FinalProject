using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace FinalProject.BLL
{
    public class RandomNumberGenerator
    {
        public static int[] GetNumber(int maximum)
        {
            var numberGenerator = new Random();

            int numberOne = numberGenerator.Next(0, maximum);
            int numberTwo;
            do
            {
                numberTwo = numberGenerator.Next(0, maximum);
            } while (numberOne == numberTwo);


            int[] results =  {numberOne, numberTwo};

            return results;
        }

        internal static int GetNumberApiPage(int maximum)
        {
            var numberGenerator = new Random();
            int numberOne = numberGenerator.Next(1, maximum);

            return numberOne;

        }
    }
}