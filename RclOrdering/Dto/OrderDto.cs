namespace RclOrdering.Dto
{
    public class OrderDto
    {
        public string? Uid { get; set; }

        public string? UidUser { get; set; }

        public DateTime OrderData { get; set; }

        public List<ItensDto>? Itens { get; set; }

        public float Tax { get; set; }

        public float Amount { get; set; }


    }
}
