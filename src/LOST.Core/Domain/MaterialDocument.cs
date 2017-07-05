using System;
using System.Collections.Generic;
using System.Text;

namespace LOST.Core.Domain
{
    public class MaterialDocument
    {
        public Guid Id { get; protected set; }
        public string MaterialNumber { get; protected set; }
        public string ProductionOrder { get; protected set; }
        public int Quantity { get; set; }
        public char MovementType { get; protected set; }
        public Guid SectorId { get; set; }
        public DateTime CreatedAt { get; set; }

        protected MaterialDocument()
        {

        }

        public MaterialDocument(string materialNumber, int quantity, Sector sector, string productionOrder = "")
        {
            SetMaterialNumber(materialNumber);
            SetQuantity(quantity);
            SetMovementType(quantity);
            SetProductionOrder(productionOrder);

            SectorId = sector.Id;
            CreatedAt = DateTime.UtcNow;
        }

        private void SetProductionOrder(string productionOrder)
        {
            if (productionOrder.Length != 9 || productionOrder.Substring(1, 3) != "160")
            {
                throw new Exception($"{nameof(ProductionOrder)} property value is incorrect.");
            }
            ProductionOrder = productionOrder;
        }

        private void SetMovementType(int quantity)
        {
            if (quantity > 0)
                MovementType = '+';
            else
                MovementType = '-';

        }

        private void SetQuantity(int quantity)
        {
            if (quantity == 0)
            {
                throw new Exception($"{nameof(Quantity)} property must be different than 0.");
            }
            Quantity = quantity;
        }

        private void SetMaterialNumber(string materialNumber)
        {
            if (string.IsNullOrWhiteSpace(materialNumber))
            {
                throw new Exception($"{nameof(materialNumber)} can't be empty.");
            }

            if (materialNumber.Length >= 4 && materialNumber.Length <= 8)
            {
                throw new Exception($"{nameof(materialNumber)} length must be 4 or 8 characters.");
            }

            MaterialNumber = materialNumber;
        }
    }
}