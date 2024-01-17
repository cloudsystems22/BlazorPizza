using Microsoft.AspNetCore.Components;
using RclProducts.Dto;
using RclProducts.Services.Interfaces;

namespace RclProducts.Shared
{
    public partial class SizesComponent
    {
        [Parameter]
        public List<SizeDto> Sizes { get; set; }

        [Inject]
        public IUtilsSizeServices utilsSizeServices { get; set; }


        protected override async Task OnInitializedAsync()
        {
            int index = utilsSizeServices.Index;
            utilsSizeServices.ValueRefSize = Sizes[index].Value;
        }


        void Changed(int index)
        {
            utilsSizeServices.Index = index;
            index = (index == 0) ? utilsSizeServices.Index : index;  
            utilsSizeServices.ValueRefSize = Sizes[index].Value;
        }

    }
}
