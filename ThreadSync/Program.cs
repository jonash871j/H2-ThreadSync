using System;
using System.Threading;

class Counter
{
    public int Value { get; set; }
}

class Program
{
    static Counter counter = new Counter();

    static void ThreadMethod(string name, int amount)
    {
        while(true)
        {
            Monitor.Enter(counter);

            Console.WriteLine(name + "<Before>: " + counter.Value);
            counter.Value += amount;
            Thread.Sleep(1000);
            Console.WriteLine(name + "<After>: " + counter.Value);

            Monitor.Pulse(counter);
            Monitor.Wait(counter);
            Monitor.Exit(counter);
        }
    }

    static void Main(string[] args)
    {
        Thread incrementThread = new Thread(() => ThreadMethod("Incrementer", 2));
        Thread decrementThread = new Thread(() => ThreadMethod("Decrementer", -1));

        incrementThread.Start();
        decrementThread.Start();
    }
}