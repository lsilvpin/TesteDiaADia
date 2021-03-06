using Microsoft.Extensions.DependencyInjection;
using System;

namespace TesteDiaADia
{
    public static class Program
    {
        private static readonly ServiceCollection services = new ServiceCollection();

        public static void Main()
        {
            Injector.Initialize(services);

            DateTimeAndOffset();
        }

        private static void DateTimeAndOffset()
        {
            DateTime nowHere = DateTime.Now;
            DateTimeOffset nowHereOffset = DateTimeOffset.Now;
            TimeSpan offset = TimeZoneInfo.Local.GetUtcOffset(nowHere);
            DateTime NowGreenwitch = nowHere - offset;
            DateTime utcNow = DateTime.UtcNow;
            DateTime nowHereFromUtc = utcNow.Add(offset);

            Console.Write(Environment.NewLine);
            Console.WriteLine($"nowHere: {nowHere}");
            Console.WriteLine($"nowHereOffset: {nowHereOffset}");
            Console.WriteLine($"offset: {offset}");
            Console.WriteLine($"nowGreenwitch: {NowGreenwitch} as (nowHere - offset)");
            Console.WriteLine($"utcNow: {utcNow} as (DateTime.UtcNow)");
            Console.WriteLine($"nowHereFromUtc: {nowHereFromUtc} as (utcNow.Add(offset))");
            Console.WriteLine("Formule: timeHere = timeUTC + offset");
            Console.Write(Environment.NewLine);
        }
    }
}
