using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace CoolCSharpFeatures;

// 1. 箭头表达式
public static class ArrowExpressions
{
    public static int Sum(int a, int b) => a + b;
    public static int SumLegacy(int a, int b)
    {
        return a + b;
    }
}

// 2. 模式匹配
public static class PatternMatching
{
    public enum AirQuality
    {
        Good,
        Moderate,
        Poor,
        EasterEgg,
    }
    public static AirQuality GetAirQuality(int aqi) => aqi switch
    {
        392 => AirQuality.EasterEgg,
        < 50 => AirQuality.Good,
        < 100 => AirQuality.Moderate,
        < 0 or > 500 => throw new ArgumentOutOfRangeException(nameof(aqi)),
        _ => AirQuality.Poor,
    };
    public static AirQuality GetAirQualityLegacy(int aqi)
    {
        if (aqi == 392) return AirQuality.EasterEgg;
        if (aqi < 50) return AirQuality.Good;
        if (aqi < 100) return AirQuality.Moderate;
        if (aqi < 0 || aqi > 500) throw new ArgumentOutOfRangeException(nameof(aqi));
        return AirQuality.Poor;
    }
}



// 3. 非常离谱的 await 语法
public static class MyExtensions
{
    public static TaskAwaiter GetAwaiter(this TimeSpan timeSpan) => Task.Delay(timeSpan).GetAwaiter();
    public static TaskAwaiter GetAwaiter(this int seconds) => Task.Delay(seconds * 1000).GetAwaiter();
    public static TaskAwaiter GetAwaiter(this Message message)
        => message.NeedsWaiting
           ? Task.Delay(message.WaitDuration!.Value * 1000).GetAwaiter()
           : Task.CompletedTask.GetAwaiter();
}
public class Message
{
    public string? MessageText { get; set; }
    public bool NeedsWaiting { get; set; }
    public int? WaitDuration { get; set; }
}
public static class WaitingForSomethingStrange
{
    public static async void Wait()
    {
        await new TimeSpan(0, 0, 5);
        await 5;
        await new Message { MessageText = "Hello", NeedsWaiting = true, WaitDuration = 10 };
    }
}

// 4. COALESCE 表达式
public static class COALESCEExpression
{
    public static string Foo(string? s) => s?.ToLower() ?? throw new Exception();
    public static string FooLegacy(string s)
    {
        var b = s?.ToLower();
        if (b is null) throw new Exception();
        return b;
    }
}

// 5. 主构造器
public class Score(int baseScore, int bonus)
{
    public int CalculatedScore { get => baseScore * bonus; }
    // To provide a default value with bonus = 1.
    public Score() : this(0, 1) { }
}

public class ScoreLegacy
{
    private int _baseScore;
    private int _bonus;
    public int CalculatedScore { get => _baseScore * _bonus; }
    public ScoreLegacy(int baseScore, int bonus)
    {
        _baseScore = baseScore;
        _bonus = bonus;
    }
    public ScoreLegacy() : this(0, 1) { }
}

// 6. 集合表达式
public static class TerseExpression
{
    public static void Foo()
    {
        int[] a = [1, 2, 3];
        int[] b = [4, 5, 6];
        int[] c = [.. a, .. b];
        int[] d = [.. Enumerable.Range(0, 100)];
    }
    public static void FooLegacy()
    {
        int[] a = new int[] { 1, 2, 3 };
        int[] b = new int[] { 4, 5, 6 };
        int[] c = new int[a.Length + b.Length];
        Array.Copy(a, c, a.Length);
        Array.Copy(b, 0, c, a.Length, b.Length);
        var d = Enumerable.Range(0, 100).ToArray();
    }
}

// 7. required 修饰符
public class Person
{
    required public string Name { get; set; }
    required public int Age { get; set; }
}

public class PersonLegacy
{
    public string Name { get; set; }
    public int Age { get; set; }
    public PersonLegacy(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

// 8. Deconstruct
public class Point(int X, int Y)
{
    public void Deconstruct(out int x, out int y)
    {
        x = X;
        y = Y;
    }
}

public static class StringExtensions
{
    public static void Deconstruct(this string name, out string firstName, out string middleName, out string lastName)
    {
        var parts = name.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length < 2) throw new ArgumentException("Name must have at least 2 parts.");
        firstName = parts[0];
        middleName = string.Join(' ', parts[1..^1]);
        lastName = parts[^1];
    }
}

public class Bar
{
    public void FooBar()
    {
        var p = new Point(1, 2);
        (int x, int y) = p;
        var name = "John F. B. Doe";
        (string firstName, string middleName, string lastName) = name;
    }
}

// 9. 预处理器指令
public class Foo
{
#if DEBUG
    private void InternalDebuggingMethod() => throw new NotImplementedException();
#endif
    private void InternalOperationalMethod() => throw new NotImplementedException();
    public void PublicOperationalMethod()
    {
#if DEBUG
        InternalDebuggingMethod();
#endif
        InternalOperationalMethod();
    }
}

//10. Linq GroupBy
public class Student
{
    public int Grade { get; set; }
    public string? Name { get; set; }
    public double GPA { get; set; }
}

public class GradeStatistics
{
    public int Grade { get; set; }
    public double AverageGPA { get; set; }
}

public static class StudentExtensions
{
    public static IEnumerable<GradeStatistics> GroupByGrade(this IEnumerable<Student> students)
    {
        return students.GroupBy(s => s.Grade, s => s, (grade, s) => new GradeStatistics
        {
            Grade = grade,
            AverageGPA = s.Select(s => s.GPA).Average(),
        });
    }

    public static IEnumerable<GradeStatistics> GroupByGradeLegacy(this IEnumerable<Student> students)
    {
        var result = new Dictionary<int, List<double>>();
        foreach (var student in students)
        {
            if (!result.ContainsKey(student.Grade))
                result[student.Grade] = new List<double>();
            result[student.Grade].Add(student.GPA);
        }
        var statistics = new List<GradeStatistics>(result.Count);
        foreach (var grade in result)
        {
            var averageGPA = grade.Value.Average();
            statistics.Add(new GradeStatistics { Grade = grade.Key, AverageGPA = averageGPA });
        }
        return statistics;
    }
}