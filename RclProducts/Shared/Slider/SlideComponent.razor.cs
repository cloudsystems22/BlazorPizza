using Microsoft.AspNetCore.Components;
using RclProducts.Dto;
using RclProducts.Services.Interfaces;

namespace RclProducts.Shared.Slider
{
    public partial class SlideComponent
    {
        [Parameter]
        public ProductDto? product { get; set; }

        [Parameter]
        public float? width { get; set; }

        [Parameter]
        public string? marginLeft { get; set; }

        public int countSlide { get; set; } = 0;

        private List<SizeDto>? sizes { get; set; }

        private string? uidprod { get; set; }

        private string? pathurlimg { get; set; }

        [Inject]
        public ISizeRestServices _servicesSize { get; set; }

        [Inject]
        public IUtilsSizeServices utilsSizeServices { get; set; }

        protected override async Task OnInitializedAsync()
        {
            uidprod = product!.Uid;
            pathurlimg = $"imgpizza/{product!.Uriimage}";

            sizes = await _servicesSize.GetAll(uidprod);

            utilsSizeServices.OnChange += StateHasChanged;
        }
    }
}
