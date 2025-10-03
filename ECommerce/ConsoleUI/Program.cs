

using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

class Program
{
    static void Main(string[] args)
    {
        ProductTest();
        //CategoryTest();
    }

    private static void CategoryTest()
    {
        CategoryService categoryService = new CategoryService(new EFCategoryDal());
        foreach (var category in categoryService.GetAll())
        {
            Console.WriteLine(category.CategoryName);
        }
    }

    private static void ProductTest()
    {
        ProductService productService = new ProductService(new EFProductDal());
        var result = productService.GetProductDetails();

        if (!result.Success)
        {
            Console.WriteLine(result.Message);
            return;
        }
        foreach (var product in result.Data)
        {
            Console.WriteLine(product.ProductName + "/" + product.CategoryName);
        }

    }
}