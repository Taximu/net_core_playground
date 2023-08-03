namespace CatalogHandler.Services.Publisher;

public interface IPublisherWrapper
{
    Task WriteMessage(string message);
}
