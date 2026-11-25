using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        string folderPath = @"C:\CSharpTest";
        Directory.CreateDirectory(folderPath);

        string fileName = "Test_" + new Random().Next(100, 999) + ".cs";
        string fullFilePath = Path.Combine(folderPath, fileName);

        string codeToCompile = "using System; class App { static void Main() { Console.WriteLine(\"Успешно скомпилировано!\"); } }";
        File.WriteAllText(fullFilePath, codeToCompile);

        Console.WriteLine("Создан файл: " + fileName);

        ProcessStartInfo psi = new ProcessStartInfo();
        psi.FileName = "cmd.exe";
        psi.Arguments = $"/c csc \"{fullFilePath}\"";
        psi.WorkingDirectory = folderPath;
        psi.RedirectStandardOutput = true;
        psi.UseShellExecute = false;

        Process process = Process.Start(psi);
        string output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();

        Console.WriteLine("Результат компиляции:");
        Console.WriteLine(output);
    }
}
