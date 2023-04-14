using Store.Core.Models;

namespace Store.Core.Repositories;

public interface ICartRepository
{
    IEnumerable<Item> GetAll(int limit = 10);
    void Create(Item item);
    
    void Update(Item item);
    void Delete(int itemId);
}
