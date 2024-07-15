using Microsoft.AspNetCore.Components;
using RclProducts.Dto;
using RclProducts.Services;
using RclProducts.Services.Interfaces;

namespace RclProducts.Shared.Cards
{
    public partial class CardsCarousel
    {
        [Inject]
        public IProductsRestServices? _servicesProducts { get; set; }

        [Inject]
        public ICardsUtilsServices cardsUtilsServices { get; set; }

        private List<ProductDto>? products { get; set; }

        private bool IsDisabledNext { get; set; } = false;

        private bool IsDisbledPrevious { get; set; } = false;

        protected override async Task OnInitializedAsync()
        {
            products = await _servicesProducts!.GetAll();
            LoadMarginsLeft();

            int qtdProd = products.Count;

            cardsUtilsServices.OnChange += StateHasChanged;

        }

        async Task LoadMarginsLeft()
        {
            foreach (var product in products)
            {
                cardsUtilsServices.MarginLeftSlide.Add("margin-left:0%");
            }
        }


        void PreviousCard()
        {
            if (cardsUtilsServices.CountSlide != 0)
            {
                cardsUtilsServices.MarginLeftSlide[cardsUtilsServices.CountSlide - 1] = "margin-left:0%";
                cardsUtilsServices.CountSlide--;
                IsDisabledNext = false;
                IsDisbledPrevious = false;
            }
            else
            {
                cardsUtilsServices.MarginLeftSlide[0] = "margin-lef:0%";
                IsDisbledPrevious = true;
            }
            cardsUtilsServices.Index = cardsUtilsServices.CountSlide;
        }

        void NextCard()
        {
            cardsUtilsServices.CountSlide++;
            cardsUtilsServices.Index = cardsUtilsServices.CountSlide;
            if (cardsUtilsServices.CountSlide < cardsUtilsServices.MarginLeftSlide.Count)
            {
                cardsUtilsServices.MarginLeftSlide[cardsUtilsServices.CountSlide - 1] = $"margin-left:-7%";
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
