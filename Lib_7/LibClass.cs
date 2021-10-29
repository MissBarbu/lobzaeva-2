using System;
using LibMas;

namespace Lib_7
{
    public class LibClass
    {
        public static string Func(int[] mas)
        {
            string numbers = "";
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] < 0)
                {
                    numbers  += mas[i].ToString() + " = "  + (mas[i] * mas[i]).ToString();
                    numbers  += "\n";
                }
            }
            return numbers;
        }
    }
}
