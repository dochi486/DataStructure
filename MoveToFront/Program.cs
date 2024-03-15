namespace MoveToFront
{
    internal class Program
    {
        // 전진 이동법
        static void MoveToFront(int[] array, int target)
        {
            // 기존의 0번 인덱스에 있던 데이터를 담을 변수
            int temp = 0;
            int[] tempArr = new int[array.Length];

            int i = 0;
            // 배열 전체를 탐색하면서
            for (i = 0; i < array.Length; i++)
            {
                // target과 일치하는 요소가 있다면
                if (array[i] == target)
                {
                    tempArr[0] = array[i];
                }
            }

            int j = 0;

            if (i > 0)
            {
                for (j = 1; j < array.Length; j++)
                {
                    if (j <= i)
                        tempArr[j] = array[j - 1];
                    else
                        tempArr[j] = array[j];
                }
            }

            for (j = 0; j < array.Length; j++)
            {
                array[j] = tempArr[j];
            }
        }



        static void Main(string[] args)
        {
            MoveToFront(new[] { 71, 5, 14, 1, 2, 48, 222, 136, 3, 15 }, 48);
        }
    }
}
