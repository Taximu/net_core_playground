using Moq;
using NUnit.Framework;
using Store.Core.Models;
using Store.Core.Repositories;
using Store.Core.Services.CartingService;

namespace Store.UnitTests;

[TestFixture]
public class CartingServiceTest
{
    private readonly Mock<ICartRepository> _repository = new();
    private static readonly Item Item = new()
    {
        Id = 1,
        Name = "Regular Cheese",
        Image = new Image { Url = "https://static.toiimg.com/thumb/msid-78679348,width-1280,resizemode-4/78679348.jpg" },
        Price = (decimal)39.0,
        Quantity = 0
    };
    private static readonly List<Item> Items = new() { Item };
    private readonly Cart _cart = new() { Items = Items };
    
    [SetUp]
    public void Setup()
    {
        _repository.Setup(m => m.GetCartItems(It.IsAny<string>())).Returns(Items);
        _repository.Setup(m => m.Add(_cart.Id, Item)).Callback(() => { Items.Add(Item); });
    }
    
    [Test]
    public void Add_ItemNotNull_CartItemsGreaterThanOne()
    {
        //Arrange
        var mockCartRepository = new Mock<ICartRepository>();
        mockCartRepository.Setup(m => m.GetCartItems(It.IsAny<string>())).Returns(Items);
        var cartingService = new CartingService(mockCartRepository.Object);
        
        //Act
        cartingService.Add(_cart.Id, Item);
        
        //Assert
        Assert.True(Items.Count == 2);
    }
    
    [Test]
    public void Remove_IfItemsEqualToOne_ReturnZeroItems()
    {
        //Arrange
        var mockCartRepository = new Mock<ICartRepository>();
        mockCartRepository.Setup(m => m.GetCartItems(It.IsAny<string>())).Returns(Items);
        var cartingService = new CartingService(mockCartRepository.Object);
        
        //Act
        cartingService.Remove(_cart.Id, Item.Id);
        
        //Assert
        Assert.True(_cart.Items != null && Items.Count == _cart.Items.Count);
    }
}
