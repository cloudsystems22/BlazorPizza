using Microsoft.AspNetCore.Components;
using RclProducts.Dto;
using RclProducts.Services.Interfaces;

namespace RclProducts.Shared
{
    public partial class IndicatorsComponent
    {
        [Parameter]
        public List<ProductDto> Products { get; set; }

        [Inject]
        public ISliderUtilsServices sliderUtilsService { get; set; }

        void Changed(int index)
        {
            sliderUtilsService.Index = index;
            index = (index == 0) ? sliderUtilsService.Index : index;
            Console.WriteLine(index);
            SlideSelected(index);
        }

        void SlideSelected(int value)
        {
            if (sliderUtilsService.CountSlide > value)
            {
                for (int i = (sliderUtilsService.CountSlide - 1); i >= value; --i)
                {
                    sliderUtilsService.MarginLeftSlide[i] = "margin-left:0%";
                    Console.WriteLine(sliderUtilsService.CountSlide);
                    sliderUtilsService.CountSlide--;
                }
            }
            else
            {
                for (sliderUtilsService.CountSlide = sliderUtilsService.CountSlide; 
                    sliderUtilsService.CountSlide < value; 
                    sliderUtilsService.CountSlide++)
                {
                    sliderUtilsService.MarginLeftSlide[sliderUtilsService.CountSlide] = $"margin-left:-{sliderUtilsService.WidthSlide}%";
                    Console.WriteLine(sliderUtilsService.CountSlide);
                }
            }
        }

    }
}
