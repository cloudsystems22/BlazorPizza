using Microsoft.AspNetCore.Components;
using RclProducts.Dto;
using RclProducts.Services.Interfaces;

namespace RclProducts.Shared
{
    public partial class SliderComponent
    {

        [Inject]
        public IProductsRestServices? _servicesProducts { get; set; }
        private List<ProductDto>? products { get; set; }

        private int witdthPerc { get; set; } = 0;
        protected override async Task OnInitializedAsync()
        {
            products = await _servicesProducts!.GetAll();

            int qtdProd = products.Count;

            witdthPerc = qtdProd * 100;
        }

        void PreviousSlide() { }

        void NextSlide() { }

    }
}
