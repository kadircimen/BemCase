namespace Core.CrossCuttingConcerns.Utils;
public static class CronExpGenerator
{
    public static string CreateCronExpression(int unit, ECheckFrequencies frequency)
    {
        var cronTemplates = new Dictionary<ECheckFrequencies, Func<int, string>>
        {{ECheckFrequencies.Minute, unit => $"*/{unit} * * * *"},
        {ECheckFrequencies.Hour, unit => $"0 */{unit} * * *"},
        {ECheckFrequencies.Day, unit => $"0 0 */{unit} * *"}};
        if (cronTemplates.TryGetValue(frequency, out var template))
        {
            return template(unit);
        }
        return "* * * * *";
    }
}
