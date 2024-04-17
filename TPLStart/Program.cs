//Task task1 = new Task(() => Console.WriteLine("Hello world 1"));
//task1.Start();
//Task task2 = Task.Factory.StartNew(()=> Console.WriteLine("Hello world 2"));
//Task task3 = Task.Run(() => Console.WriteLine("Hello world 3"));

//task1.RunSynchronously();
//task1.Wait();
//task2.Wait();
//task3.Wait();
//Task task = new Task(()=>
//{
//    Console.WriteLine($"{Task.CurrentId}");
//    Thread.Sleep(1000);
//    Console.WriteLine($"{Task.CurrentId}");
//});
//task.Start();
//Console.WriteLine($"{task.Id}");
//Console.WriteLine($"{task.IsCompleted}");
//Console.WriteLine($"{task.Status}");
//task.Wait();


//var outer = Task.Factory.StartNew(()=>
//{
//    Console.WriteLine("Outer task starting...");
//    var inner = Task.Factory.StartNew(() =>
//    {
//        Console.WriteLine("Inner task starting...");
//        Thread.Sleep(1000);
//        Console.WriteLine("Inner task finished...");
//    },TaskCreationOptions.AttachedToParent);
//});
//outer.Wait();
//Console.WriteLine("Outer task stop...");

//запуск нескольких задач
//Task[] tasks = new Task[3]
//{
//    new Task(() => Console.WriteLine("First")),
//    new Task(() => Console.WriteLine("Second")),
//    new Task(() => Console.WriteLine("Third"))
//};
//foreach (var t in tasks)
//{
//    t.Start();
//   // t.Wait();
//}
//Task.WaitAll(tasks);

//возвращение результатов из задач
//int Sum(int a, int b) => a + b;

//int x = 6, y = 9;
//Task<int> sumTask = new Task<int>(() => Sum(x, y));
//sumTask.Start();
//int result = sumTask.Result;
//Console.WriteLine($"{x}+{y}={result}");

//Задачи продолжения
//int Sum(int a, int b) => a + b;
//void PrintResult(int sum) => Console.WriteLine($"Sum:{sum}");
//Task<int> task1 = new Task<int>(() => Sum(5, 9));
//Task task2 = task1.ContinueWith(task => PrintResult(task.Result));
//task1.Start();
//task2.Wait();

//Класс Parallel
//Parallel.Invoke(
//    Print,
//    () =>
//    {
//        Console.WriteLine($"Выполняется задача {Task.CurrentId}");
//        Thread.Sleep(3000);
//    },
//    () => Square(5)
//);

//Parallel.For(1, 5, Square);
//ParallelLoopResult result=Parallel.ForEach<int>(
//    new List<int> { 3,1,7,4,2},
//    Square);
//if (!result.IsCompleted)
//{
//    Console.WriteLine($"Номер итерации завершения {result.LowestBreakIteration}");
//}

//void Print()
//{
//    Console.WriteLine($"Выполняется задача {Task.CurrentId}");
//    Thread.Sleep(1000);
//}
//void Square(int n, ParallelLoopState pls)
//{
//    if (n == 4) pls.Break();
//    Console.WriteLine($"Выполняется задача {Task.CurrentId}");
//    Thread.Sleep(1000);
//    Console.WriteLine($"Result {n*n}");
//}

//CancellationToken

CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
CancellationToken token = cancelTokenSource.Token;
Task task = new Task(() =>
{
	for (int i = 1; i < 10; i++)
	{
		if (token.IsCancellationRequested)
		{
			Console.WriteLine("Операция прервана");
			return;
		}
		Console.WriteLine($"Квадрат числа {i} равен {i*i}");
		Thread.Sleep(1000);
	}
},token);
task.Start();
Thread.Sleep(3000);
cancelTokenSource.Cancel();
Thread.Sleep(1000);
Console.WriteLine($"Статус:{task.Status}");
cancelTokenSource.Dispose();







