using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Web.Http;
using Tema_02___Web_Services.Models;

namespace Tema_02___Web_Services.Controllers
{
    /*public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }*/
    public class ProductsController : Controller
    {
        static readonly IProductRepository repository = new ProductRepository();
    }

    
    public class ProductsController : Controller
    {
        public IEnumerable<Product> GetAllProducts()
        {
            return repository.GetAll();
        }

    }

    public IEnumerable<Product> GetProductsByCategory(string category)
    {
        return repository.GetAll().Where(
            p => string.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase));
    }

    public HttpResponseMessage PostProduct(Product item)
    {
        item = ProductRepository.Add(item);
        var response = Request.CreateResponse<Product>(HttpStatusCode.Created, item);

        string uri = Url.Link("DefaultApi", new { id = item.Id });
        response.Headers.Location = new Uri(uri);
        return response;
    }

    public void PutProduct(int id, Product product)
    {
        product.Id = id;
        if (!ProductRepository.Update(product))
        {
            throw new HttpResponseException(HttpStatusCode.NotFound);
        }
    }

    public void DeleteProduct(int id)
    {
        Product item = ProductRepository.Get(id);
        if (item == null)
        {
            throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        ProductRepository.Remove(id);
    }
}
