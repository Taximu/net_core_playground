using Microsoft.Practices.Unity;
using store.BLL;
using store.BLL.Models;
using store.BLL.Services;
using store.DAL;

var container = new UnityContainer();
container.RegisterType<IRepository, Repository>();

var repository = container.Resolve<Repository>();

Console.WriteLine("Module #2");

var item = new Item
{
    Id = 1,
    Name = "Regular Cheese",
    Image = "https://static.toiimg.com/thumb/msid-78679348,width-1280,resizemode-4/78679348.jpg",
    Price = (decimal)39.0,
    Quantity = 0
};

repository.Create(item);

var items = new List<Item>();
items.AddRange(repository.GetAll());

var cart = new Cart(items);

container.RegisterType<ICartingService, CartingService>(new InjectionConstructor(cart));
var cartingService = container.Resolve<CartingService>();

Console.WriteLine($"Id of cart: {cart.Id}");
Console.WriteLine($"Item name before change is: {item.Name}");

item.Name = "Cordon Blue Cheese";
repository.Update(item);
cart.Items = repository.GetAll().ToList();
Console.WriteLine($"Item name after change is: {cart.Items[0].Name}");

Console.WriteLine($"Number of items in db before delete is: {cart.Items.Count}");
repository.Delete(item.Id);
cart.Items = repository.GetAll().ToList();
Console.WriteLine($"Number of items in db after delete is: {cart.Items.Count}");

var milk = new Item
{
    Id = 2,
    Name = "Milk", 
    Price = (decimal)2.10,
    Quantity = 2
};

cartingService.Add(milk);

var meat = new Item
{
    Id = 3,
    Name = "Meat", 
    Price = (decimal)39.0,
    Quantity = 0
};

cartingService.Add(meat);
Console.WriteLine($"Products in cart total: {cart.Items.Count}");

foreach (var product in cart.Items)
{
    Console.WriteLine($"Item in cart: {product.Image}");
    Console.WriteLine($"Item in cart: {product.Quantity}");
    Console.WriteLine($"Item in cart: {product.Price}");
    Console.WriteLine($"Item in cart: {product.Id}");
}

cartingService.Remove(milk);
Console.WriteLine("Products in cart after delete:");

foreach (var product in cart.Items)
{
    Console.WriteLine($"Item in cart: {product.Name}");
}

Console.ReadKey();