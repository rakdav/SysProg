using System.ComponentModel;
using System.Diagnostics;

bool start = true;
do
{
    Console.WriteLine("Меню:\n1.Создать процесс\n" +
        "2.Просмотреть информацию о процессе\n" +
        "3.Удалить процесс\n" +
        "4.Показать все процессы\n" +
        "5.Запустить калькулятор\n"+
        "6.Выход");
    Console.WriteLine("Выберите пункт меню:");
    int n = int.Parse(Console.ReadLine()!);
    switch (n)
    {
        case 1:
            {
                Console.Write("Введите путь до программы");
                string progPath = Console.ReadLine()!;
                Process.Start(@$"{progPath}");
            }
            break;
        case 2:
            {
                Console.Write("Введите id процесса для удаления:");
                int id = int.Parse(Console.ReadLine()!);
                Process infoProcess = Process.GetProcessById(id);
                Console.WriteLine(infoProcess.MainModule+" "+infoProcess.PagedMemorySize);
            }
            break;
        case 3:
            {
                try
                {
                    Console.Write("Введите id процесса для удаления:");
                    int id = int.Parse(Console.ReadLine()!);
                    Process killProcess = Process.GetProcessById(id);
                    killProcess.Kill();
                }
                catch (Win32Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            break;
        case 4: {
                foreach (Process i in Process.GetProcesses())
                {
                    Console.WriteLine($"{i.Id} {i.ProcessName}");
                }
            }
            break;
        case 5:
            {
                Process calcProcess = new Process();
                calcProcess.StartInfo = new ProcessStartInfo("calc.exe");
                calcProcess.Start();
            }
            break;
        case 6: start = false; break;
    }
}
while (start);
