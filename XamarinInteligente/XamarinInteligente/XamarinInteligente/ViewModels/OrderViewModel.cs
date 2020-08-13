using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinInteligente.Model.BaseTypes;
using XamarinInteligente.Model.Entities;
using XamarinInteligente.Services.Interfaces;
using XamarinInteligente.Services.WebApiServices;

namespace XamarinInteligente.ViewModels
{
    public class OrderViewModel : BaseViewModel
    {
        public OrderViewModel()
        {
            Task.Run(async () => await InitViewModel());
        }

        private async Task InitViewModel()
        {
            LookForProductsCommand = new Command(async () => await LookForProducts());
            AddProductToOrderCommand = new Command(() => AddProductToOrder());
            ProductsResults = await productsService.GetAllProducts();
        }

        string searchText;

        public string SearchText
        {
            get
            {
                return searchText;
            }
            set
            {
                searchText = value;
                OnPropertyChanged();
            }
        }

        string clientId;
        public string ClientId
        {
            get
            {
                return clientId;
            }
            set
            {
                clientId = value;
                OnPropertyChanged();
            }
        }

        Product selectedProduct;
        public Product SelectedProduct
        {
            get
            {
                return selectedProduct;
            }
            set
            {
                selectedProduct = value;

                OnPropertyChanged();
            }
        }

        ObservableCollection<Product> productsResults = new ObservableCollection<Product>();
        public ObservableCollection<Product> ProductsResults
        {
            get
            {
                return productsResults;
            }
            set
            {
                productsResults = value;
                OnPropertyChanged();
            }
        }

        int quantity = 1;
        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                if (value > 0)
                {
                    quantity = value;
                    OnPropertyChanged();
                }
                else
                    Quantity = 1;
            }
        }

        ObservableCollection<ProductOrder> productsInOrder = new ObservableCollection<ProductOrder>();

        public ObservableCollection<ProductOrder> ProductsInOrder
        {
            get
            {
                return productsInOrder;
            }
            set
            {
                productsInOrder = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddProductToOrderCommand
        {
            get;
            set;
        }

        public ICommand FinishOrderCommand
        {
            get
            {
                return new Xamarin.Forms.Command(() =>
                {
                    throw new NotImplementedException();
                }

                );
            }
        }

        public ICommand LookForProductsCommand
        {
            get;
            set;
        }


        IProductsService productsService = new ProductService();

        private void AddProductToOrder()
        {
            if (selectedProduct != null)
            {
                var productOrder = new ProductOrder()
                {
                    Product = selectedProduct,
                    Quantity = quantity,
                };
                ProductsInOrder.Add(productOrder);
            }
        }

        private async Task LookForProducts()
        {

            ProductsResults = await productsService.LookForProducts(searchText);

        }
    }
}
