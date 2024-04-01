//Thread currentThread = Thread.CurrentThread;
//Console.WriteLine(currentThread.Name);
//currentThread.Name = "CurrentThread";
//Console.WriteLine(currentThread.Name);
//Console.WriteLine(currentThread.IsAlive);
//Console.WriteLine(currentThread.Priority);
//Console.WriteLine(currentThread.ThreadState);
//Console.WriteLine(currentThread.ManagedThreadId);
//Console.WriteLine(currentThread.IsBackground);
//for (int i = 0; i < 4; i++)
//{
//    Console.Write(i+" ");
//    Thread.Sleep(1000);
//}
//Console.WriteLine();

//Создание потоков
//Console.WriteLine("Main thread start");
//Thread thread1 = new Thread(Print1);
//thread1.Start();
//Thread thread2 = new Thread(Print2);
//thread2.Start();
//Thread thread3 = new Thread(() => Console.WriteLine("Омаров - пивной провокатор"));
//thread3.Start();
//Console.WriteLine("Main thread stop");
//void Print1() => Console.WriteLine("Hello, world");
//void Print2() => Console.WriteLine("Hello, Masha");

//Thread thread = new Thread(Print);
//thread.Start();
//for (int i = 0; i < 5; i++)
//{
//    Console.WriteLine($"main поток {i}");
//    Thread.Sleep(300);
//}
//void Print ()
//{
//	for (int i = 0; i < 5; i++)
//	{
//		Console.WriteLine($"2-ой поток {i}");
//		Thread.Sleep(300);
//	}
//}

//Потоки с параметрами

Thread thread1 = new Thread(new ParameterizedThreadStart(Print));
Thread thread2 = new Thread(Print);
Thread thread3 = new Thread(message => Console.WriteLine(message));
thread1.Start("Hello1");
thread2.Start("Hello2");
thread3.Start("Hello3");
for (int i = 1; i <= 6; i++)
{
    Thread thread4 = new Thread(PrintNumber);
    thread4.Start(i);
}
void Print ( object? message ) => Console.WriteLine(message);
void PrintNumber( object? obj )
{
    if (obj is int n) Console.WriteLine($"{n}*{n}={n*n}");
}