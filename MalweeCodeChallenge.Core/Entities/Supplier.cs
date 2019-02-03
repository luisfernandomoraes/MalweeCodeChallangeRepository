using System;
using MalweeCodeChallenge.Core.Contracts.Abstracts;
using MalweeCodeChallenge.Core.Contracts.Interfaces;

namespace MalweeCodeChallenge.Core.Entities
{
    public class Supplier:Entity
    {
        public Supplier()
        {
            this.IdDbKey = Guid.NewGuid().ToString();
        }
        public string Name { get; set; }
    }
}