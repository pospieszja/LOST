namespace LOST.Infrastructure.Commands
{
    public class GoodsIssue
    {
        public string MaterialNumber { get; set; }
        public int Quantity { get; set; }
        public string SectorName { get; set; }
        public string ProductionOrder { get; set; }
    }
}