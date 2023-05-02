using NUnit.Framework;
using Store.Core.Models;
using Store.Core.Repositories;
using Unity;

namespace Store.IntegrationTests;
//TODO Enhance and add more tests
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
    public async Task Repository_UpdateItem_CorrectData()
    {
        var cart = new Cart { Items = new List<Item> { _item } };
        //Act
        await _cartRepository.AddItemAsync(cart.Id.ToString(), cart.Items[0]);
        var cartItems = _cartRepository.GetCartItemsAsync(cart.Id.ToString());

        //Assert
        Assert.IsNotNull(cartItems.Result?.Single());
    }

    [Test]
    public async Task Repository_DeleteItem_CorrectData()
    {
        //Act
        var cart = new Cart { Items = new List<Item> { _item } };
        await _cartRepository.RemoveItemAsync(cart.Id.ToString(), _item.Id);
        var result = _cartRepository.GetCartItemsAsync(cart.Id.ToString()).Result;
        if (result != null)
        {
            var itemsList =result.ToList();

            //Assert
            Assert.AreEqual(0, itemsList.Count);
        }
    }
}