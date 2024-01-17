using Microsoft.AspNetCore.Components;
using RclProducts.Dto;
using RclProducts.Services.Interfaces;

namespace RclProducts.Shared
{
    public partial class SliderComponent
    {

        [Inject]
        public IProductsRestServices? _servicesProducts { get; set; }

        [Inject]
        public ISliderUtilsServices sliderUtilsService { get; set; }

        private List<ProductDto>? products { get; set; }

        private int witdthPerc { get; set; } = 0;

        private bool IsDisabledNext { get; set; } = false;

        private bool IsDisbledPrevious { get; set; } = false;

        protected override async Task OnInitializedAsync()
        {
            products = await _servicesProducts!.GetAll();
            await LoadMarginsLeft();

            int qtdProd = products.Count;

            witdthPerc = qtdProd * 100;

            sliderUtilsService.WidthSlide = 100f / qtdProd;

            sliderUtilsService.OnChange += StateHasChanged;
        }

        async Task LoadMarginsLeft()
        {
            foreach (var product in products) 
            {
                sliderUtilsService.MarginLeftSlide.Add("margin-left:0%");
            }
        }

        void PreviousSlide() 
        {
            if(sliderUtilsService.CountSlide != 0)
            {
                sliderUtilsService.MarginLeftSlide[sliderUtilsService.CountSlide - 1] = "margin-left:0%";
                sliderUtilsService.CountSlide--;
                IsDisabledNext = false;
                IsDisbledPrevious = false;
            }
            else
            {
                sliderUtilsService.MarginLeftSlide[0] = "margin-lef:0%";
                IsDisbledPrevious = true;
            }
            sliderUtilsService.Index = sliderUtilsService.CountSlide;


        }

        void NextSlide() 
        {
            sliderUtilsService.CountSlide++;
            sliderUtilsService.Index = sliderUtilsService.CountSlide;
            if(sliderUtilsService.CountSlide < sliderUtilsService.MarginLeftSlide.Count)
            {
                sliderUtilsService.MarginLeftSlide[sliderUtilsService.CountSlide - 1] = $"margin-left:-{sliderUtilsService.WidthSlide}%";
                IsDisabledNext = false;
                IsDisbledPrevious = false;
            }
            else
            {
                IsDisabledNext = true;
            }

        }

    }
}
