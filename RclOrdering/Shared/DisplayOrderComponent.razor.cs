using Microsoft.AspNetCore.Components;
using RclOrdering.Dto;
using RclOrdering.Services.Interfaces;

namespace RclOrdering.Shared
{
    public partial class DisplayOrderComponent
    {

        private List<OrderDto>? Orders = new List<OrderDto>();

        private float Amount { get; set; }

        private int Itens { get; set; }

        [Inject]
        public IOrderingRestServices _services { get; set; }
        
        protected override async Task OnInitializedAsync()
        {
            Orders = await _services.GetAll();

            Amount = Orders![1].Amount;

            Itens = Orders![1].Itens!.Count;
        }
    }
}
