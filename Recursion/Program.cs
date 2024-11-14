class Program
{
    const int SIZE = 5;
    static int[,] array = new int[SIZE, SIZE];
    static bool[,] visited = new bool[SIZE, SIZE];
    static int maxLength = 0;

    static void Main()
    {
        // Создаём и заполняем массив случайными 0 и 1
        Random rand = new Random();
        for (int i = 0; i < SIZE; i++)
        {
            for (int j = 0; j < SIZE; j++)
            {
                array[i, j] = rand.Next(2);
                Console.Write(array[i, j] + " ");
            }
            Console.WriteLine();
        }

        // Ищем самую длинную цепочку
        for (int i = 0; i < SIZE; i++)
        {
            for (int j = 0; j < SIZE; j++)
            {
                if (array[i, j] == 1)
                {
                    int length = FindChainLength(i, j);
                    maxLength = Math.Max(maxLength, length);
                }
            }
        }

        Console.WriteLine($"Самая длинная цепочка из 1: {maxLength}");
    }

    //Метод для поиска длины цепочки
    static int FindChainLength(int x, int y)
    {
        // Проверка границ массива и условия выхода
        if (x < 0 || x >= SIZE || y < 0 || y >= SIZE || array[x, y] == 0 || visited[x, y])
        {
            return 0;
        }

        // Помечаем текущий элемент как посещённый
        visited[x, y] = true;

        // Инициализируем длину цепочки
        int length = 1;

        // Все 4 направления: вверх, вниз, влево, вправо
        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        // Ищем максимальную длину цепочки в каждом направлении
        for (int i = 0; i < 4; i++)
        {
            int newX = x + dx[i];
            int newY = y + dy[i];
            length = Math.Max(length, 1 + FindChainLength(newX, newY));
        }

        // Сбрасываем отметку посещения
        visited[x, y] = false;

        return length;
    }

}






