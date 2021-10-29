using System;
using System.IO;

namespace LibMas
{
    public class ArrOperations
    {
        public static void FillMas(int[] arr, int fillValue)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = fillValue;
            }
        }
        public static void FillMasRandom(int[] arr, int minValue, int maxValue)
        {
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(minValue, maxValue + 1);
            }
        }
        public static void ClearMas(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = 0;
            }
        }
        public static void SaveMas(int[] arr, string path)
        {
            StreamWriter save = new StreamWriter(path);
            save.WriteLine(arr.Length);
            for (int i = 0; i < arr.Length; i++)
            {
                save.WriteLine(arr[i]);
            }
            save.Close();
        }
        public static void OpenMas(out int[] arr, string path)
        {
            StreamReader open = new StreamReader(path);
            arr = new int[Convert.ToInt32(open.ReadLine())];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Convert.ToInt32(open.ReadLine());
            }
            open.Close();
        }
    }
}
