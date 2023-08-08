namespace LibraryNoDB.Models
{
    public class ProductRepository
    {
        private static List<Product> _products = new List<Product>();

        public List<Product> GetAll() => _products;

        public void Add(Product newProduct) => _products.Add(newProduct);

        public void Remove(int id)
        {
            var hasProduct = _products.FirstOrDefault(x => x.Id == id);

            if (hasProduct == null)
            {
                throw new Exception($"Bu id({id})'ye sahip ürün bulunmamaktadır.");
            }

            _products.Remove(hasProduct);
        }

        public void Update(Product updateProduct)
        {
            var hasProduct = _products.FirstOrDefault(x => x.Id == updateProduct.Id);

            if (hasProduct == null)
            {
                throw new Exception($"Bu id({updateProduct.Id})'ye sahip ürün bulunmamaktadır.");
            }

            hasProduct.BookName = updateProduct.BookName;
            hasProduct.BookAuthor = updateProduct.BookAuthor;
            hasProduct.BookEdition = updateProduct.BookEdition;
            hasProduct.BookPrice = updateProduct.BookPrice;
            hasProduct.BookStock = updateProduct.BookStock;
            hasProduct.BookPublishDate = updateProduct.BookPublishDate;

            var index = _products.FindIndex(x => x.Id == updateProduct.Id);

            _products[index] = hasProduct;
        }
    }
}
