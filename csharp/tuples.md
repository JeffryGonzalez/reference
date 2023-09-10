# Tuples


```csharp
  
using System.Runtime.InteropServices;  
  
Console.WriteLine("Hello, World!");  
  
var (len, w) = WorkerBee.FormatName("Jeff", "Gonzalez");  
Console.WriteLine($"{w} is {len}");  
  
  
var r = WorkerBee.FormatName("Jeff", "Gonzalez");  
Console.WriteLine($"{r.Item1} is {r.Item2}");  
  
var (_, x) = WorkerBee.FormatName("Jeff", "Gonzalez");  
Console.WriteLine($"{x}");  
  
public static class WorkerBee  
{  
    public static (int, string) FormatName(string first, string last)  
    {        var fullName = $"{last}, {first}";  
        return (fullName.Length, fullName);  
    }
}
```