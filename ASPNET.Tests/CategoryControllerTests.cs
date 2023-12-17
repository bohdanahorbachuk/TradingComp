using ASPNET;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASPNET.Controllers;
using ASPNET.Models;
using Fluent.Infrastructure.FluentModel;

[TestClass]
public class CategoryControllerTests
{
    private ApplicationDbContext _context;

    [TestInitialize]
    public void TestInitialize()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "InMemoryTestDatabase")
            .Options;

        _context = new ApplicationDbContext(options);

        // Додайте тестові дані в базу даних
        _context.Categories.Add(new Category { ID_Category = 1, CategoryName = "TestCategory" });
        _context.SaveChanges();
    }

    [TestMethod]
    public async Task Index_ReturnsViewWithCategories()
    {
        // Arrange
        var controller = new CategoryController(_context);

        // Act
        var result = await controller.Index() as ViewResult;

        // Assert
        Assert.IsNotNull(result);
        var model = result.Model as List<Category>;
        Assert.IsNotNull(model);
        Assert.AreEqual(1, model.Count); // Перевірте, чи є 1 категорія у списку
    }

    // Інші тести можна додати аналогічно

    [TestCleanup]
    public void TestCleanup()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }
}
