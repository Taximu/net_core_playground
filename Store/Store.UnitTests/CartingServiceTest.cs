using Moq;
using NUnit.Framework;
using Store.Core.Models;
using Store.Core.Services;
using Store.Core.Services.CartingService;

namespace Store.UnitTests;

[TestFixture]
public class CartingServiceTest
{
    private readonly Mock<IItemRepository> _repository = new();
    private static readonly Item Item = new()
    {
        Id = 1,
        Name = "Regular Cheese",
        Image = "https://static.toiimg.com/thumb/msid-78679348,width-1280,resizemode-4/78679348.jpg",
        Price = (decimal)39.0,
        Quantity = 0
    };
    private readonly List<Item> _items = new() { Item };
    
    [SetUp]
    public void Setup()
    {
        _repository.Setup(m => m.GetAll(It.IsAny<int>())).Returns(_items);
        _repository.Setup(m => m.Create(Item)).Callback(() => { _items.Add(Item); });
    }
    
    [Test]
    public void Add_ItemNotNull_CartItemsGreaterThanOne()
    {
        //Arrange
        var cart = new Cart(_items);
        var cartingService = new CartingService(cart);
        
        //Act
        cartingService.Add(Item);
        
        //Assert
        Assert.True(_items.Count == 2);
    }
    
    [Test]
    public void Remove_IfItemsEqualToOne_ReturnZeroItems()
    {
        //Arrange
        var cart = new Cart(_items);
        var cartingService = new CartingService(cart);
        
        //Act
        cartingService.Remove(Item);
        
        //Assert
        Assert.True(_items.Count == 1);
    }
}
