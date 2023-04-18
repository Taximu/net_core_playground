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
        var cart = new Cart { Items = new List<Item> { _item } };
        //Act
        _cartRepository.Add(cart.Id, cart.Items[0]);
        var cartItems = _cartRepository.GetCartItems(cart.Id);

        //Assert
        Assert.IsNotNull(cartItems?.Single());
    }

    [Test]
    public void Repository_DeleteItem_CorrectData()
    {
        //Act
        var cart = new Cart { Items = new List<Item> { _item } };
        _cartRepository.Remove(cart.Id, _item.Id);
        var itemsList =_cartRepository.GetCartItems(cart.Id)?.ToList();

        //Assert
        Assert.AreEqual(0, itemsList?.Count);
    }
}