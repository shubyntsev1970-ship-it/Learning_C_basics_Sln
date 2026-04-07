using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Learning_C_basics_App.Tests
{
    [TestClass]
    public class Lesson004Tests
    {
        [TestMethod]
        public void Lesson004_PrintsExpectedConvertedSum()
        {
            var assemblyPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Learning_C_basics_App.exe");
            Assert.IsTrue(File.Exists(assemblyPath), $"Application assembly was not copied to the test output: {assemblyPath}");

            var assembly = Assembly.LoadFrom(assemblyPath);
            var programType = assembly.GetType("Learning_C_basics_App.Program", throwOnError: true);
            var lessonMethod = programType.GetMethod("Lesson_004", BindingFlags.Public | BindingFlags.Static);

            Assert.IsNotNull(lessonMethod, "Method Lesson_004 was not found.");

            var originalOut = Console.Out;

            try
            {
                using (var writer = new StringWriter())
                {
                    Console.SetOut(writer);
                    lessonMethod.Invoke(null, null);

                    var output = writer.ToString();
                    StringAssert.Contains(output, "Hello from Lesson_004");
                    StringAssert.Contains(output, "52");
                    StringAssert.Contains(output, "7");
                    StringAssert.Contains(output, "Сумма: 23");
                }
            }
            finally
            {
                Console.SetOut(originalOut);
            }
        }
    }
}
