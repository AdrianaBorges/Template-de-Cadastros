using AB.DTO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.DTO
{
    [Serializable()]
    public class Pessoa
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public EnumSexoPessoa Sexo { get; set; }
        public EnumStatusPessoa Status { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
