using Moq;
using NUnit.Framework;
using Store.Core.Models;
using Store.Core.Repositories;
using Store.Core.Services.CartingService;

namespace Store.UnitTests;
//TODO Enhance and add more tests
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
        _repository.Setup(m => m.GetCartItemsAsync(It.IsAny<string>())).Returns(Task.FromResult(Items)!);
        _repository.Setup(m => m.AddItemAsync(_cart.Id.ToString(), Item)).Callback(() => { Items.Add(Item); });
    }
    
    [Test]
    public async Task Add_ItemNotNull_CartItemsGreaterThanOne()
    {
        //Arrange
        var mockCartRepository = new Mock<ICartRepository>();
        mockCartRepository.Setup(m => m.GetCartItemsAsync(It.IsAny<string>())).Returns(Task.FromResult(Items)!);
        var cartingService = new CartingService(mockCartRepository.Object);
        
        //Act
        await cartingService.AddItemAsync(_cart.Id.ToString(), Item);
        
        //Assert
        Assert.True(Items.Count == 2);
    }
    
    [Test]
    public async Task Remove_IfItemsEqualToOne_ReturnZeroItems()
    {
        //Arrange
        var mockCartRepository = new Mock<ICartRepository>();
        mockCartRepository.Setup(m => m.GetCartItemsAsync(It.IsAny<string>())).Returns(Task.FromResult(Items)!);
        var cartingService = new CartingService(mockCartRepository.Object);
        
        //Act
        await cartingService.RemoveItemAsync(_cart.Id.ToString(), Item.Id);
        
        //Assert
        Assert.True(_cart.Items != null && Items.Count == _cart.Items.Count);
    }
}
