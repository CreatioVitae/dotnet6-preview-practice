using System;
using System.Linq;

//https://docs.microsoft.com/ja-jp/dotnet/visual-basic/language-reference/data-types/date-data-type
Date date;
TimeOfDay timeOfDay;

date = new Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
timeOfDay = new TimeOfDay(DateTime.Now.TimeOfDay.Ticks);

Console.WriteLine($"{nameof(date)}:{date}");
Console.WriteLine($"{nameof(date.DayNumber)}:{date.DayNumber}");
Console.WriteLine($"{nameof(date.DayOfWeek)}:{date.DayOfWeek}");
Console.WriteLine($"{nameof(date.DayOfYear)}:{date.DayOfYear}");
Console.WriteLine($"{nameof(timeOfDay)}:{timeOfDay}");
Console.WriteLine($"{nameof(timeOfDay.Second)}:{timeOfDay.Second}");
Console.WriteLine($"{nameof(timeOfDay)}ValidFormatCase:{timeOfDay:HH:mm:ss.ffff}");
//Console.WriteLine($"{timeOfDay:yyyy/MM}"); //Format例外

//var useToDateTime = default(Date).ToDateTime(default); // default(DateOnly).ToDateTime(default) == default(DateTime)...use Local Time.
//DateTimeOffset dateTimeOffset = useToDateTime; Out Of Range Exception...

var collectionForMinByAndMaxBy = new[] {
    (7, "g-9"),
    (7, "g"),
    (2, "b"),
    (4, "d"),
    (1, "a"),
    (1, "a-2"),
    (1, "a-4"),
    (6, "f")
};

Console.WriteLine("OrderBy + FirstOrDefault == MinBy");
Console.WriteLine(collectionForMinByAndMaxBy.OrderBy(m => m.Item1).FirstOrDefault());
Console.WriteLine(collectionForMinByAndMaxBy.MinBy(m => m.Item1));

Console.WriteLine("OrderByDescending + FirstOrDefault == MaxBy");
Console.WriteLine(collectionForMinByAndMaxBy.OrderByDescending(m => m.Item1).FirstOrDefault());
Console.WriteLine(collectionForMinByAndMaxBy.MaxBy(m => m.Item1));

var collectionForChunk = new[] { 1, 2, 3, 4, 5, 6, 7 };

foreach (var chunk in collectionForChunk.Chunk(2)){
    Console.WriteLine(string.Join(",", chunk));
} 