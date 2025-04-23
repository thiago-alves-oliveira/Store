using System;

namespace DevStore.Domain.Entities
{
    public class SaleItem
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid ProductId { get; private set; }
        public string ProductName { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal DiscountPercent { get; private set; }
        public bool IsCancelled { get; private set; }

        public decimal Total =>
            IsCancelled
                ? 0m
                : Math.Round(UnitPrice * Quantity * (1 - DiscountPercent), 2);             
   

        public SaleItem(
            Guid productId,
            string productName,
            int quantity,
            decimal unitPrice)
        {
            if (quantity < 1 || quantity > 20)
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be between 1 and 20");

            if (unitPrice <= 0)
                throw new ArgumentOutOfRangeException(nameof(unitPrice), "Unit price must be positive");

            ProductId = productId;
            ProductName = productName ?? throw new ArgumentNullException(nameof(productName));
            Quantity = quantity;
            UnitPrice = unitPrice;
            DiscountPercent = ComputeDiscount(quantity);
        }

        internal void UpdateQuantity(int newQuantity)
        {
            if (IsCancelled)
                throw new InvalidOperationException("Cannot change a cancelled item.");

            if (newQuantity < 1 || newQuantity > 20)
                throw new ArgumentOutOfRangeException(nameof(newQuantity), "Quantity must be between 1 and 20");

            Quantity = newQuantity;
            DiscountPercent = ComputeDiscount(newQuantity);
        }

        internal void Cancel() => IsCancelled = true;

        private static decimal ComputeDiscount(int qty) =>
            qty >= 10 ? 0.20m :
            qty >= 4 ? 0.10m : 0m;
    }
}
