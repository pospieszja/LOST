namespace LOST.Infrastructure.Commands
{
    public class CheckStock
    {
        public string MaterialNumber { get; set; }
        public string SectorName { get; set; }
        public string ProductionOrder { get; set; }

        public CheckStock()
        {
            MaterialNumber = "";
            SectorName = "";
            ProductionOrder = "";
        }
    }
}