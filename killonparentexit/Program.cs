using System.ComponentModel;
using System.Diagnostics;

namespace killonparentexit;

internal static class Program
{
    public static int Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.Error.WriteLine("Usage: killonparentexit <application> [arguments...]");
            return 1;
        }

        if (!OperatingSystem.IsLinux() && !OperatingSystem.IsWindows())
        {
            Console.Error.WriteLine("ProcessStartInfo.KillOnParentExit is only supported on Linux and Windows for this utility.");
            return 1;
        }

        ProcessStartInfo startInfo = new()
        {
            FileName = args[0],
            KillOnParentExit = true
        };

        for (int i = 1; i < args.Length; i++)
        {
            startInfo.ArgumentList.Add(args[i]);
        }

        try
        {
            using Process process = Process.Start(startInfo)!;
            process.WaitForExit();
            return process.ExitCode;
        }
        catch (Win32Exception ex)
        {
            Console.Error.WriteLine(ex.Message);
            return 1;
        }
    }
}
