public class CurrentDate : IDate
{
    public DateTime GetDate()
    {
        return DateTime.Now;
    }
}