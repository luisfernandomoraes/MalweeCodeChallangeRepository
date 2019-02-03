using System;

namespace MalweeCodeChallenge.Core.Contracts.Interfaces
{
    public interface IEntity
    {
        string IdDbKey { get; set; }
        DateTime UpdateDate { get; set; }
        string UpdateUser { get; set; }
    }
}