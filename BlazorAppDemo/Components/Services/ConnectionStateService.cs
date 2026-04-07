using Microsoft.AspNetCore.Components.Server.Circuits;

public class ConnectionStateService : CircuitHandler
{
    private readonly List<string> _events = new List<string>();
    public IReadOnlyList<string> Events => _events.AsReadOnly();

    public event Action? OnChange;

    public override Task OnConnectionUpAsync(Circuit circuit, CancellationToken cancellationToken)
    {
        _events.Add($"{DateTime.Now:HH:mm:ss} 接続確立: {circuit.Id}");
        OnChange?.Invoke();
        return Task.CompletedTask;
    }

    public override Task OnConnectionDownAsync(Circuit circuit, CancellationToken cancellationToken)
    {
        _events.Add($"{DateTime.Now:HH:mm:ss} 接続断: {circuit.Id}");
        OnChange?.Invoke();
        return Task.CompletedTask;
    }
}