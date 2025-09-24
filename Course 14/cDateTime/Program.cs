using System;

namespace cDateTime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime Start = DateTime.Now;

            ///////////////////////////////////////////////////////
            
            DateTime DefaultDate = new DateTime();

            Console.WriteLine(DefaultDate);

            DateTime Date = new DateTime(2024, 08, 20, 08, 30, 00, DateTimeKind.Utc);
            Console.WriteLine(Date);

            DateTime NowDateTime = DateTime.Now;
            Console.WriteLine(NowDateTime);

            Console.WriteLine(DateTime.MinValue.Ticks);
            Console.WriteLine(DateTime.MaxValue.Ticks);
            DateTime End = DateTime.Now;

            ///////////////////////////////////////////////////////

            long Duration = End.Ticks - Start.Ticks;

            Console.WriteLine("how many ticks to run this function: " + Duration);

            ///////////////////////////////////////////////////////

            //TimeSpan tsDuration = NowDateTime - Date;
            TimeSpan tsDuration = NowDateTime.Subtract(Date);

            Console.WriteLine($"Now DateTime - 8/20/2024 = {tsDuration.Days} Days - {tsDuration.Hours} Hours {tsDuration.Minutes} Minutes {tsDuration.Seconds} Seconds");


            TimeSpan Ts = new TimeSpan(49, 25, 34);

            DateTime NewDate = Date.Add(Ts);
            Console.WriteLine(NewDate);

            ///////////////////////////////////////////////////////

            //var strDate = "2024/66/20"; // Not Valid
            var strDate = "2024/12/20";
            //DateTime Dt;

            //var isValidDateStr = DateTime.TryParse(strDate, out DateTime Dt);

            if (DateTime.TryParse(strDate, out DateTime Dt))
                Console.WriteLine(Dt);
            else
                Console.WriteLine($"{strDate} is not a valid date string");

        }
    }
}
