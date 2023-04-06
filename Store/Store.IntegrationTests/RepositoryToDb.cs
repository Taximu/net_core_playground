using NUnit.Framework;
using Store.Core.Models;
using Store.Core.Services;
using Store.Core.Services.CartingService;
using Unity;

namespace Store.IntegrationTests;

[TestFixture]
public class RepositoryToDb
{
    private ItemRepository _itemRepository = null!;
    private UnityContainer _container = null!;
    private Item _item = null!;
    [SetUp]
    public void Setup()
    {
        //TODO DB.Recreate() is required before each run
        _container = new UnityContainer();
        _container.RegisterType<IItemRepository, ItemRepository>();
        _itemRepository = _container.Resolve<ItemRepository>();

        _item = new Item
        {
            Id = 1,
            Name = "Regular Cheese",
            Image = "https://static.toiimg.com/thumb/msid-78679348,width-1280,resizemode-4/78679348.jpg",
            Price = (decimal)39.0,
            Quantity = 0
        };
    }

    [Test]
    public void Repository_UpdateItem_CorrectData()
    {
        _itemRepository.Create(_item);

        var items = new List<Item>();
        items.AddRange(_itemRepository.GetAll());

        var cart = new Cart(items);

        //Act
        _item.Name = "Cordon Blue Cheese";
        _itemRepository.Update(_item);
        cart.Items = _itemRepository.GetAll().ToList();

        //Assert
        Assert.AreEqual(_item.Name, cart.Items[0].Name!);

    }

    [Test]
    public void Repository_DeleteItem_CorrectData()
    {
        //Act
        _itemRepository.Delete(_item.Id);
        var cart = new Cart(_itemRepository.GetAll().ToList());

        //Assert
        Assert.AreEqual(0, cart.Items.Count);
    }
}