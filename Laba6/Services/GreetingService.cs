using System.Data;

namespace Laba6.Services
{
    public class GreetingService : IGreetingService
    {
        public string GetGreeting()
        {
            var hour = DateTime.Now.Hour;

            if (hour >= 0 && hour < 6)
                return "Good night";
            if (hour >= 6 && hour < 12)
                return "Good morning";
            if (hour >= 12 && hour < 18)
                return "Good day";
            return "Good evening";
        }
    }
}
