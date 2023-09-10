# Pattern Matching

```csharp
static bool IsWorkDay(DateTime date)  
{  
    // var holidays = new List<DateTime>  
    // {    //     new DateTime(1969, 4, 20), // Jeff's Birthday    //     new DateTime(1969, 12, 25), // christmas    // };  
    var holidays2 = new List<(int, int)> {(4, 20), (12, 25), (7, 4)};  
    return date switch  
    {  
        var d when holidays2.Any(h => h == (d.Day, d.Month)) => false,  
        _ => date.DayOfWeek switch  
        {  
            DayOfWeek.Saturday => false,  
            DayOfWeek.Sunday => false,  
            _ => true  
        }  
    };}

```