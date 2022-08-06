using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserAPI.CORE.Entities;
using UserAPI.CORE.Repositories;
using UserAPI.WebApp.ViewModels;

namespace UserAPI.WebApp.Controllers
{
   
    public class ProductController : Controller
    {
        private readonly IProductRespository _productRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IProductFeatureMappingRepository _productFeatureMappingRepository;
        private readonly IProductFeatureRepository _productFeatureRepository;
        private readonly UserManager<User> _userManager;
        public SignInManager<User> _signInManager;

        public ProductController(IProductRespository productRepository, SignInManager<User> signInManager, IProductFeatureRepository productFeatureRepository, IProductFeatureMappingRepository productFeatureMappingRepository, IBrandRepository brandRepository, UserManager<User> userManager)
        {
            _productRepository = productRepository;
            _userManager = userManager;
            _brandRepository = brandRepository;
            _productFeatureMappingRepository = productFeatureMappingRepository;
            _productFeatureRepository = productFeatureRepository;
            _signInManager = signInManager;


        }

        public IActionResult Index()
        {
            List<Product> model;
            
            if (HttpContext.User.IsInRole("SysAdmin") || HttpContext.User.IsInRole("Customer"))
                model = _productRepository.GetAllAsync().GetAwaiter().GetResult();
            else
            {
                int brandId = _userManager.GetUserAsync(HttpContext.User).Result.BrandId;
                model = _productRepository.GetAsync(s => s.BrandId == brandId).GetAwaiter().GetResult();
            }
                

            List< ProductListViewModel> products = new List< ProductListViewModel>();   
            
            foreach (Product product in model)
            {
                List<ProductFeatureMapping> productFeatureMappings = _productFeatureMappingRepository.GetAsync(s => s.ProductId  == product.Id).GetAwaiter().GetResult();
                string brandName  = _brandRepository.GetByIdAsync(product.BrandId).GetAwaiter().GetResult().BrandName;
                foreach (ProductFeatureMapping productFeatureMapping in productFeatureMappings)
                {
                    ProductListViewModel viewModel = new ProductListViewModel();
                    viewModel.Name = product.Name;
                    viewModel.BrandName = brandName;
                    viewModel.Price = product.Price;
                    viewModel.ProductFeature = _productFeatureRepository.GetByIdAsync(productFeatureMapping.ProductFeatureId).GetAwaiter().GetResult().FeatureName;
                    viewModel.DiscountAmount = productFeatureMapping.DiscountAmount;
                    products.Add(viewModel);
                }

            }
            return View(products);
        }
        
    }
}
