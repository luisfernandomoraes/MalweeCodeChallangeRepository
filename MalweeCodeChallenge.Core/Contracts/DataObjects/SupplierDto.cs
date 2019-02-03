using System;

namespace MalweeCodeChallenge.Core.Contracts.DataObjects
{
    public class SupplierDto
    {
        public string IdDbKey { get; set; }
        public string Name { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public string UsuarioAtualizacao { get; set; }
    }
}