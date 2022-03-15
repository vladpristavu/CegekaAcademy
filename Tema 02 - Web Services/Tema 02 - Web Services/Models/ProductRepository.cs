namespace Tema_02___Web_Services.Models
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> products = new List<Product>();
        private int _nextId = 1;

        public ProductRepository()
        {
            Add(new Product { Name = "Audi", Model = "Q3", Category="SUV", Price = 4600 });
            Add(new Product { Name = "Bentley", Model = "Continetal GT", Category = "coupe", Price = 25000 });
            Add(new Product { Name = "Dodge", Model = "Avenger", Category = "sedan", Price = 2700 });
            Add(new Product { Name = "Ford", Model = "Focus", Category = "sedan", Price = 1300 });
            Add(new Product { Name = "BMW", Model = "316I", Category = "coupe", Price = 6700 });
            Add(new Product { Name = "Chevrolet", Model = "Camaro", Category = "coupen", Price = 23000 });

        }

        public IEnumerable<Product> GetAll()
        {
            return products;
        }

        public Product Get(int id)
        {
            return products.Find(p => p.Id == id);
        }

        public Product Add(Product item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            products.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            products.RemoveAll(p => p.Id == id);
        }

        public bool Update(Product item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = products.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            products.RemoveAt(index);
            products.Add(item);
            return true;
        }
    }
}
