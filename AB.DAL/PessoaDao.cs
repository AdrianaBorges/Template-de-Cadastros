using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Data.Base;
using AB.DTO;
using AB.DTO.Enum;

namespace AB.DAL
{
    public class P_RegistraPessoa : IStoredProcedureContext
    {
        public string Operacao { get; set; }

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public EnumSexoPessoa Sexo { get; set; }
        public EnumStatusPessoa Status { get; set; }
        public DateTime DataNascimento { get; set; }


        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@Operacao", Operacao);
            command.Parameters.Add("@Nome", Nome);
            command.Parameters.Add("@Codigo", Codigo);
            command.Parameters.Add("@Cpf", CPF);

            int _sexo = Convert.ToInt32(Sexo);
            int _status = Convert.ToInt32(Status);

            command.Parameters.Add("@Sexo", _sexo);
            command.Parameters.Add("@Status", _status);    
            command.Parameters.Add("@DataNascimento", DataNascimento);
            
        }

        public string NAME
        {
            get { return "p_RegistraPessoa"; }
        }
    }

    public class PessoaDao : BaseDao<Pessoa>
    {
        protected override string GetDeleteCommand(Pessoa entidade)
        {
            throw new NotImplementedException();
        }

        protected override string GetExistsCommand(Pessoa entidade)
        {
            throw new NotImplementedException();
        }

        protected override string GetInsertCommand(Pessoa entidade)
        {
            throw new NotImplementedException();
        }

        protected override string GetSelectCommand()
        {
            throw new NotImplementedException();
        }

        protected override string GetSelectCommand(string id)
        {
            throw new NotImplementedException();
        }

        protected override string GetSelectCommandWithJoin(string foreignKey)
        {
            throw new NotImplementedException();
        }

        protected override string GetUpdateCommand(Pessoa entidade)
        {
            throw new NotImplementedException();
        }

        protected override Pessoa Hydrate(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
