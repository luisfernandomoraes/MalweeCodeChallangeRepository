namespace MalweeCodeChallenge.Core.Contracts.DataObjects
{
    public class ExpensesPerMonthDto
    {
        public long Id { get; set; }
        public string IdUsuario { get; set; }
        public string Name { get; set; }
        public int Month { get; set; }
        public decimal Value { get; set; }
    }
}