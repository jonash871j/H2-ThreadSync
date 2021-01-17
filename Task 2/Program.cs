using System;
using System.Threading;
 
class Program
{
    static int counter = 0;
    static int activeId = 1;

    static void ThreadMethod(int id, char character)
    {
        while (true)
        {
            if (id == activeId)
            {
                counter += 60;

                for (int i = 0; i < 60; i++)
                    Console.Write(character);
                Console.WriteLine(" " + counter);

                if (activeId == 1)
                    activeId = 2;
                else if (activeId == 2)
                    activeId = 1;
            }
        }
    }

    static void Main(string[] args)
    {
        Thread incrementThread = new Thread(() => ThreadMethod(1, '*'));
        Thread decrementThread = new Thread(() => ThreadMethod(2, '#'));

        incrementThread.Start();
        decrementThread.Start();
    }
}