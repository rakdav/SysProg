using System.Diagnostics;

//Process process = Process.GetCurrentProcess();
////свойства класса process
//Console.WriteLine(process.ProcessName);
//Console.WriteLine(process.BasePriority);
//Console.WriteLine(process.Handle);
//Console.WriteLine(process.Id);
//Console.WriteLine(process.MachineName);
//Console.WriteLine(process.MainModule);
//Console.WriteLine(process.VirtualMemorySize64);
//Console.WriteLine(process.PagedMemorySize64);
//Console.WriteLine(process.StartTime);

//foreach(Process i in Process.GetProcesses())
//{
//    Console.WriteLine($"{i.Id} {i.ProcessName}");
//}
//Console.Write("Введите PID процесса:");
//int pid = int.Parse(Console.ReadLine()!);
//Console.WriteLine(Process.GetProcessById(pid));
//Process proc = Process.GetProcessesByName("WebViewHost")[0];
//ProcessThreadCollection threads = proc.Threads;
//foreach(ProcessThread i in threads)
//{
//    Console.WriteLine(i.Id);
//}
//proc.Kill();
Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome");




