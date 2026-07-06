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

        var startInfo = new ProcessStartInfo
        {
            FileName = args[0],
            UseShellExecute = false,
            KillOnParentExit = true
        };

        foreach (var argument in args.Skip(1))
        {
            startInfo.ArgumentList.Add(argument);
        }

        try
        {
            using var process = Process.Start(startInfo);
            if (process is null)
            {
                Console.Error.WriteLine($"Failed to start '{args[0]}'.");
                return 1;
            }

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
