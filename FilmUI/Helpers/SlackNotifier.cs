namespace FilmUI.Helpers;

public interface ISlackService
{
    Task NotifyAsync(string message);
}

public class SlackService : ISlackService
{
    public async Task NotifyAsync(string message)
    {
        await Task.CompletedTask;
    }
}