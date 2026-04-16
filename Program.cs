using System.Data.SqlTypes;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

ScriptEngine engine = Python.CreateEngine();
ScriptScope scope = engine.CreateScope();

List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

scope.SetVariable("input_data", numbers);

string script = @"# Получаем данные из C#
                numbers = input_data

                # Обработка на Python
                squared = [x * x for x in numbers]
                total = sum(numbers)

                # Результат для C#
                output = {
                     ""squared"": squared,
                     ""sum"": total,
                     ""count"": len(numbers)
                }
";

engine.ExecuteFile(@"C:\Temp\!ispp31\Practs\FileManager\CallIronPython\script.py", scope);

dynamic output = scope.GetVariable("output");
Console.WriteLine($"Входные данные {string.Join(", ", numbers)}");
Console.WriteLine($"Квадраты {string.Join(", ", output["squared"])}");
Console.WriteLine($"Сумма {string.Join(", ", output["sum"])}");
Console.WriteLine($"Количество {string.Join(", ", output["count"])}");