namespace Transpose
{
    internal class Program
    {
        static void Transpose(int[] array, int target)
        {
            int temp = 0;

            for (int i = 0; i < array.Length; i++)
            {
                // 일치하면 앞의 요소와 교환
                if (array[i] == target)
                {
                    temp = array[i - 1];
                    array[i - 1] = target;
                    array[i] = temp;
                }
            }
        }



        static void Main(string[] args)
        {
            Transpose(new []{ 71, 5, 13, 1, 2, 48, 222, 136, 3, 15}, 48);
        }
    }
}
