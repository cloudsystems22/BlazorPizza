namespace RclProducts.Services.Interfaces
{
    public interface IUtilsSizeServices
    {

        int Index { get; set; }
        float ValueRefSize { get; set; }

        public event Action OnChange;

    }
}
