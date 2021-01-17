using System;
using System.Threading;

class Counter
{
    public int Value { get; set; }
}

class Program
{
    static Counter counter = new Counter();

    static void ThreadMethod(char character)
    {
        while (true)
        {
            Monitor.Enter(counter);

            counter.Value += 60;

            for (int i = 0; i < 60; i++)
                Console.Write(character);
            Console.WriteLine(" " + counter.Value);

            Monitor.Pulse(counter);
            Monitor.Wait(counter);
            Monitor.Exit(counter);
        }
    }

    static void Main(string[] args)
    {
        Thread incrementThread = new Thread(() => ThreadMethod('*'));
        Thread decrementThread = new Thread(() => ThreadMethod('#'));

        incrementThread.Start();
        decrementThread.Start();
    }
}