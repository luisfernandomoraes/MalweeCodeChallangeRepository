using System;

namespace MalweeCodeChallenge.Core.Contracts.DataObjects
{
    public class ClientDto
    {
        public string IdDbKey { get; set; }

        public string Name { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateUser { get; set; }
    }
}