using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MalweeCodeChallenge.Core.Contracts.Interfaces;

namespace MalweeCodeChallenge.Core.Contracts.Abstracts
{
    public abstract class Entity:IEntity
    {
        public Entity()
        {
            this.IdDbKey = Guid.NewGuid().ToString();
        }
        [Key]
        public string IdDbKey { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateUser { get; set; }
    }
}
