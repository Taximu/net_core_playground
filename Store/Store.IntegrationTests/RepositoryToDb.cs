using NUnit.Framework;
using Store.Core.Models;
using Store.Core.Repositories;
using Unity;

namespace Store.IntegrationTests;

[TestFixture]
public class RepositoryToDb
{
    private CartRepository _cartRepository = null!;
    private UnityContainer _container = null!;
    private Item _item = null!;
    [SetUp]
    public void Setup()
    {
        //TODO DB.Recreate() is required before each run
        _container = new UnityContainer();
        _container.RegisterType<ICartRepository, CartRepository>();
        _cartRepository = _container.Resolve<CartRepository>();

        _item = new Item
        {
            Id = 1,
            Name = "Regular Cheese",
            Image = new Image { Url = "https://static.toiimg.com/thumb/msid-78679348,width-1280,resizemode-4/78679348.jpg" },
            Price = (decimal)39.0,
            Quantity = 0
        };
    }

    [Test]
    public void Repository_UpdateItem_CorrectData()
    {
        _cartRepository.Create(_item);

        var items = new List<Item>();
        items.AddRange(_cartRepository.GetAll());

        var cart = new Cart(items);

        //Act
        _item.Name = "Cordon Blue Cheese";
        _cartRepository.Update(_item);
        cart.Items = _cartRepository.GetAll().ToList();

        //Assert
        Assert.AreEqual(_item.Name, cart.Items[0].Name!);

    }

    [Test]
    public void Repository_DeleteItem_CorrectData()
    {
        //Act
        _cartRepository.Delete(_item.Id);
        var cart = new Cart(_cartRepository.GetAll().ToList());

        //Assert
        Assert.AreEqual(0, cart.Items.Count);
    }
}