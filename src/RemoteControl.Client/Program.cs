using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RemoteControl.Client
{
    class Program
    {
        private static Timeout _timeout;
        private static bool _keepRunning = true;

        static void Main(string[] args)
        {
            var process = StartPowershell();

            ReadOutput(process);
            while (_keepRunning)
            {
            }
        }

        private static void ReadOutput(Process process)
        {
            process.BeginOutputReadLine();
            process.OutputDataReceived += (sender, outputLine) =>
            {
                if (outputLine.Data == null) return;

                Console.WriteLine(outputLine.Data);
                DebounceReadInput(process);
            };
        }

        private static void ReadInput(ref Process process)
        {
            var standardInput = process.StandardInput;
        readData:
            Console.Write("## > ");
            var input = Console.ReadLine();
            if (input == "exit")
            {
                process.Close();
                _keepRunning = false;
                return;
            }
            if (input == "cls")
            {
                Console.Clear();
                goto readData;
            }
            standardInput.WriteLine(input);
        }

        private static void DebounceReadInput(Process process)
        {
            if (_timeout == null || _timeout.Value == 0)
                _timeout = SetTimeout(() => ReadInput(ref process), 200);
            else
                _timeout.Clear();
        }

        public static ref Timeout SetTimeout(Action func, int timeout)
        {
            _timeout = new Timeout(timeout);
            Task.Run(() =>
            {
                while (DateTime.Now.Ticks < _timeout.Value) { }
                _timeout.Renew();
                func();
            });
            return ref _timeout;
        }

        private static Process StartPowershell()
        {
            var process = new Process
            {
                StartInfo =
                {
                    FileName = "powershell",
                    RedirectStandardInput = true,
                    ErrorDialog = false,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true
                }
            };

            process.Start();
            return process;
        }
    }
}
