using System;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeWork_05.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        private static string RunCalculator(string input)
        {
            var executablePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "HomeWork_05.exe");
            Assert.IsTrue(File.Exists(executablePath), $"Application executable was not copied to the test output: {executablePath}");

            var startInfo = new ProcessStartInfo
            {
                FileName = executablePath,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = new Process { StartInfo = startInfo })
            {
                process.Start();
                process.StandardInput.Write(input);
                process.StandardInput.Close();

                var output = process.StandardOutput.ReadToEnd();
                var error = process.StandardError.ReadToEnd();

                process.WaitForExit();

                Assert.AreEqual(0, process.ExitCode, $"Calculator exited with code {process.ExitCode}. Error: {error}");

                return output;
            }
        }

        [TestMethod]
        public void Main_WhenAdditionRequested_PrintsAdditionResultTwice()
        {
            var output = RunCalculator("10\n5\n+\n");

            StringAssert.Contains(output, "Результат сложения: 15");
            Assert.AreEqual(2, CountOccurrences(output, "Результат сложения: 15"), "Expected both switch and if/else branches to print the addition result.");
        }

        [TestMethod]
        public void Main_WhenDivisionByZeroRequested_PrintsDivisionByZeroErrorTwice()
        {
            var output = RunCalculator("12\n0\n/\n");

            StringAssert.Contains(output, "Ошибка: деление на ноль.");
            Assert.AreEqual(2, CountOccurrences(output, "Ошибка: деление на ноль."), "Expected both switch and if/else branches to print the division by zero error.");
        }

        private static int CountOccurrences(string text, string value)
        {
            var count = 0;
            var index = 0;

            while ((index = text.IndexOf(value, index, StringComparison.Ordinal)) >= 0)
            {
                count++;
                index += value.Length;
            }

            return count;
        }
    }
}
