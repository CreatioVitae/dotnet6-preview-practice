//https://docs.microsoft.com/ja-jp/dotnet/visual-basic/language-reference/data-types/date-data-type
DateOnly date;
TimeOnly timeOfDay;

date = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
timeOfDay = new TimeOnly(DateTime.Now.TimeOfDay.Ticks);

Console.WriteLine($"{nameof(date)}:{date}");
Console.WriteLine($"{nameof(date.DayNumber)}:{date.DayNumber}");
Console.WriteLine($"{nameof(date.DayOfWeek)}:{date.DayOfWeek}");
Console.WriteLine($"{nameof(date.DayOfYear)}:{date.DayOfYear}");
Console.WriteLine($"{nameof(timeOfDay)}:{timeOfDay}");
Console.WriteLine($"{nameof(timeOfDay.Second)}:{timeOfDay.Second}");
Console.WriteLine($"{nameof(timeOfDay)}ValidFormatCase:{timeOfDay:HH:mm:ss.ffff}");

//Console.WriteLine($"{timeOfDay:yyyy/MM}"); //Format例外

//var useToDateTime = default(DateOnly).ToDateTime(default); // default(DateOnly).ToDateTime(default) == default(DateTime)...use Local Time.

DateTimeOffset dateTimeOffset = default(DateOnly).ToDateTime(default, DateTimeKind.Utc); //Out Of Range Exception...

dateTimeOffset = default(DateOnly).ToDateTime(default); //Out Of Range Exception...



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

var collectionForRange = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

Console.WriteLine("chunk");
foreach (var chunk in collectionForRange.Chunk(2)){
    Console.WriteLine($"chunk:{string.Join(",", chunk)}");
}

Console.WriteLine("Take...Use Range");
foreach (var item in collectionForRange.Take(1..7)) {
    Console.WriteLine($"Take...Use Range:{string.Join(",", item)}");
}

Console.WriteLine("FirstOrDefault Use Default Value Injection...");
Console.WriteLine($"FirstOrDefault:{collectionForRange.FirstOrDefault(i => i > 8)}");
//https://github.com/microsoft/referencesource/blob/master/System.Core/System/Linq/Enumerable.cs#L1038 Boxing...
Console.WriteLine($"FirstOrDefault And Cast To Nullable:{collectionForRange.Cast<int?>().FirstOrDefault(i => i > 8) is null}");
Console.WriteLine($"FirstOrDefault And Cast To Nullable And Nullish coalescing:{collectionForRange.Cast<int?>().FirstOrDefault(i => i > 8) ?? -1}");
Console.WriteLine($"FirstOrDefault Use Default Value Injection:{collectionForRange.FirstOrDefault(i => i > 8, -1)}");

