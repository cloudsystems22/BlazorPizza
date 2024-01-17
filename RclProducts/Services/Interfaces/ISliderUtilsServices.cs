namespace RclProducts.Services.Interfaces
{
    public interface ISliderUtilsServices
    {
        int Index { get; set; }
        int CountSlide { get; set; }
        float WidthSlide { get; set; }
        List<string> MarginLeftSlide { get; set; }

        public event Action OnChange;
    }
}
