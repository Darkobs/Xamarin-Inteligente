using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using XamarinInteligente.Model.Entities;

namespace XamarinInteligente.Services.Interfaces
{
    public interface IProductsService
    {
        Task<DateTime> GetProductCatalogVersion();
        Task<Product> GetProductById(string productId);
        Task<ObservableCollection<Product>> GetAllProducts();
        Task<ObservableCollection<Product>> LookForProducts(string query);
    }
}
