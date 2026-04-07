//using Microsoft.AspNetCore.Components.Server.Circuits;

//public class ConnectionHub : CircuitHandler
//{
//    public override Task OnConnectionUpAsync(Circuit circuit, CancellationToken cancellationToken)
//    {
//        Console.WriteLine($"接続確立: {circuit.Id}");
//        return Task.CompletedTask;
//    }

//    public override Task OnConnectionDownAsync(Circuit circuit, CancellationToken cancellationToken)
//    {
//        Console.WriteLine($"接続断: {circuit.Id}");
//        return Task.CompletedTask;
//    }
//}