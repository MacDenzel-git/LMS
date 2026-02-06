namespace LMSystem.Web.Services;

public sealed class ToastService
{
    public event Action<string>? OnShow;

    public void Show(string message)
    {
        OnShow?.Invoke(message);
    }
}
