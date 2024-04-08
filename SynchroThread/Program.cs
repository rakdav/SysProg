//int x = 1;

//object locker = new();
//AutoResetEvent arev = new AutoResetEvent(true);
//Mutex mutexObj = new();

//for (int i = 0; i < 6; i++)
//{
//    Thread myThread = new Thread(Print);
//    myThread.Name = $"Thread:{i}";
//    myThread.Start();
//}

//void Print()
//{
//    lock (locker)
//    {
//        x = 1;
//        for (int i = 1; i < 6; i++)
//        {
//            Console.WriteLine($"{Thread.CurrentThread.Name}:{x}");
//            x++;
//            Thread.Sleep(100);
//        }
//    }
//}

//void Print()
//{
//    bool acquiredLock = false;
//    try
//    {
//        Monitor.Enter(locker, ref acquiredLock);
//        int x = 1;
//        for (int i = 1; i < 6; i++)
//        {
//            Console.WriteLine($"{Thread.CurrentThread.Name}:{x}");
//            x++;
//            Thread.Sleep(100);
//        }
//    }
//    finally
//    {
//        if (acquiredLock) Monitor.Exit(locker);
//    }
//}

//AutoResetEvent
//void Print()
//{
//    arev.WaitOne();
//        int x = 1;
//        for (int i = 1; i < 6; i++)
//        {
//            Console.WriteLine($"{Thread.CurrentThread.Name}:{x}");
//            x++;
//            Thread.Sleep(100);
//        }
//    arev.Set();
//}


//Mutex
//void Print()
//{
//    mutexObj.WaitOne();
//    int x = 1;
//    for (int i = 1; i < 6; i++)
//    {
//        Console.WriteLine($"{Thread.CurrentThread.Name}:{x}");
//        x++;
//        Thread.Sleep(100);
//    }
//    mutexObj.ReleaseMutex();
//}
for (int i = 1; i < 6; i++)
{
    Reader reader = new Reader(i);
}
class Reader
{
    static Semaphore sem = new Semaphore(3, 3);
    Thread thread;
    int count = 3;
    public Reader(int i)
    {
        thread = new Thread(Read);
        thread.Name = $"Читатель {i}";
        thread.Start();
    }
    public void Read()
    {
        while (count > 0)
        {
            sem.WaitOne();
            Console.WriteLine($"{Thread.CurrentThread.Name} входит библиотеку");
            Console.WriteLine($"{Thread.CurrentThread.Name} читает");
            Thread.Sleep(1000);
            Console.WriteLine($"{Thread.CurrentThread.Name} уходит");
            sem.Release();
            count--;
            Thread.Sleep(1000);
        }
    }
}