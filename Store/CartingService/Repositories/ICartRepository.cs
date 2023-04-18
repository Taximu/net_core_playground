using Store.Core.Models;

namespace Store.Core.Repositories;

public interface ICartRepository
{
    List<Item>? GetCartItems(string cartId);

    string Add(string cartId, Item item);

    int Remove(string cartId, int itemId);
}
