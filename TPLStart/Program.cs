Task task1 = new Task(() => Console.WriteLine("Hello world 1"));
task1.Start();
Task task2 = Task.Factory.StartNew(()=> Console.WriteLine("Hello world 2"));
Task task3 = Task.Run(() => Console.WriteLine("Hello world 3"));

task1.Wait();
task2.Wait();
task3.Wait();

