namespace CatalogHandler.Services.Subscriber;

public interface ISubscriberWrapper
{
    /// <summary>
    /// Reads messages. Returns null when the operation is canceled.
    /// </summary>
    string? ReadMessage(CancellationToken cancellationToken = default);
}
