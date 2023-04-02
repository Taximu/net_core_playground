using store.BLL.Models;

namespace store.DAL;

public interface IRepository
{
    public IEnumerable<Item> GetAll(int limit = 10);

    public void Create(Item item);

    public void Update(Item item);

    public void Delete(int itemId);
}