namespace MalweeCodeChallenge.Core.Contracts.DataObjects
{
    public class SupplierAverageByServiceDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Service { get; set; }
        public decimal Value { get; set; }
    }
}