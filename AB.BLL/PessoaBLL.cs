using AB.DTO;
using AB.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AB.DTO.Enum;

namespace AB.BLL
{
    public class PessoaBLL : IPessoa<Pessoa>
    {
        public Pessoa GetPessoaId(int id)
        {
            try
            {
                string sql = "SELECT Id, Nome, Codigo, CPF, Sexo, Status, DataNascimento FROM Pessoa WHERE Id = " + id;
                DataTable tabela = new DataTable();
                tabela = AcessoDB.GetDataTable(sql);
                return GetPessoa(tabela);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Pessoa GetPessoa(DataTable tabela)
        {
            try
            {
                Pessoa _pessoa = new Pessoa();
                if (tabela.Rows.Count > 0)
                {
                    _pessoa.Id = Convert.ToInt32(tabela.Rows[0][0]);
                    _pessoa.Nome = Convert.ToString(tabela.Rows[0]["Nome"]);
                    _pessoa.Codigo = tabela.Rows[0][2].ToString();
                    _pessoa.CPF = tabela.Rows[0][3].ToString();
                    _pessoa.Sexo = (DTO.Enum.EnumSexoPessoa)Convert.ToInt32(tabela.Rows[0][4].ToString());
                    _pessoa.Status = (DTO.Enum.EnumStatusPessoa)Convert.ToInt32 (tabela.Rows[0][5].ToString());
                    _pessoa.DataNascimento = Convert.ToDateTime(tabela.Rows[0][6].ToString());

                    return _pessoa;
                }
                else
                {
                    _pessoa = null;
                    return _pessoa;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Pessoa> Exibir()
        {
            try
            {
                string sql = "SELECT * FROM Pessoa";
                DataTable tabela = new DataTable();
                tabela = AcessoDB.GetDataTable(sql);
                return GetListaPessoa(tabela);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Pessoa> GetListaPessoa(DataTable tabela)
        {
            try
            {
                List<Pessoa> listaPessoa = new List<Pessoa>();
                int i = 0;
                dynamic registros = tabela.Rows.Count;
                if (registros > 0)
                {
                    foreach (DataRow drRow in tabela.Rows)
                    {
                        Pessoa _pessoa = new Pessoa
                        {
                            Id = Convert.ToInt32(tabela.Rows[0][0]),
                            Nome = Convert.ToString(tabela.Rows[0]["Nome"]),
                            Codigo = tabela.Rows[0][2].ToString(),
                            CPF = tabela.Rows[0][3].ToString(),
                            Sexo = (DTO.Enum.EnumSexoPessoa)Convert.ToInt32(tabela.Rows[0][4].ToString()),
                            Status = (DTO.Enum.EnumStatusPessoa)Convert.ToInt32(tabela.Rows[0][5].ToString()),
                            DataNascimento = Convert.ToDateTime(tabela.Rows[0][6].ToString())
                        };
                        listaPessoa.Add(_pessoa);
                    }
                    while (i <= registros)
                    {
                        Pessoa _pessoa = new Pessoa
                        {
                            Id = Convert.ToInt32(tabela.Rows[0][0]),
                            Nome = Convert.ToString(tabela.Rows[0]["Nome"]),
                            Codigo = tabela.Rows[0][2].ToString(),
                            CPF = tabela.Rows[0][3].ToString(),
                            Sexo = (DTO.Enum.EnumSexoPessoa)Convert.ToInt32(tabela.Rows[0][4].ToString()),
                            Status = (DTO.Enum.EnumStatusPessoa)Convert.ToInt32(tabela.Rows[0][5].ToString()),
                            DataNascimento = Convert.ToDateTime(tabela.Rows[0][6].ToString())
                        };
                        listaPessoa.Add(_pessoa);
                        i += i;
                    }
                    return listaPessoa;
                }
                else
                {
                    listaPessoa = null;
                    return listaPessoa;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetProximoCodigo()
        {
            string sql = "SELECT Max(Id) as Id FROM Pessoa ";

            try
            {
                return AcessoDB.SelectScalar(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable ConsultarPorID(int id)
        {
            string sql = "SELECT Id, Nome, Codigo, CPF, Sexo, Status, DataNascimento FROM Pessoa WHERE Id = " + id;

            try
            {
                return AcessoDB.GetDataTable(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Consultar(string nome)
        {
            string sql = "SELECT Id,Nome FROM Pessoa WHERE Nome LIKE '" + nome + "%'" + " ORDER BY Nome";
            try
            {
                return AcessoDB.GetDataTable(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Incluir(Pessoa oPessoa)
        {
            string sql = "";
            try
            {
                string[] parametrosNomes = new string[7];
                parametrosNomes[0] = "@Nome";
                parametrosNomes[1] = "@Codigo";
                parametrosNomes[2] = "@Cpf";
                parametrosNomes[3] = "@Sexo";
                parametrosNomes[4] = "@Status";
                parametrosNomes[5] = "@DataNascimento";

                string[] parametrosValores = new string[7];
                parametrosValores[0] = oPessoa.Nome;
                parametrosValores[1] = oPessoa.Codigo;
                parametrosValores[2] = oPessoa.CPF;

                int _sexo = Convert.ToInt32(oPessoa.Sexo);
                int _satus = Convert.ToInt32(oPessoa.Status);

                parametrosValores[3] = Convert.ToString(_sexo);
                parametrosValores[4] = Convert.ToString(_satus);
                parametrosValores[5] = Convert.ToString (oPessoa.DataNascimento);

                sql = "INSERT INTO Pessoa(Nome,Codigo, Cpf, Sexo, Status, datanascimento) values (@Nome,@Codigo, @Cpf, @Sexo, @Status, @datanascimento)";
                AcessoDB.CRUD(sql, parametrosNomes, parametrosValores);

                AcessoDB.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Alterar(Pessoa oPessoa)
        {
            string sql = "";
            try
            {
                //string[] parametrosNomes = new string[7];
                //parametrosNomes[0] = "@Id";
                //parametrosNomes[1] = "@Nome";
                //parametrosNomes[2] = "@Endereco";
                //parametrosNomes[3] = "@Telefone";
                //parametrosNomes[4] = "@Email";
                //parametrosNomes[5] = "@Observacao";
                //string[] parametrosValores = new string[7];
                //parametrosValores[0] = oPessoa.Id.ToString();
                //parametrosValores[1] = oPessoa.nome;
                //parametrosValores[2] = oPessoa.endereco;
                //parametrosValores[3] = oPessoa.telefone;
                ////
                //parametrosValores[4] = oPessoa.email;
                //parametrosValores[5] = oPessoa.observacao;
                //sql = "UPDATE Pessoa SET Nome=@Nome, Endereco=@Endereco ,Telefone=@Telefone,Email=@Email , Observacao=@Observacao Where Id=@Id";
                //AcessoDB.CRUD(sql, parametrosNomes, parametrosValores);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Excluir(Pessoa oPessoa)
        {
            string sql = "";
            try
            {
                string[] parametrosNomes = new string[1];
                parametrosNomes[0] = "@Id";
                string[] parametrosValores = new string[1];
                parametrosValores[0] = oPessoa.Id.ToString();
                sql = "DELETE FROM Pessoa Where Id=@Id";
                AcessoDB.CRUD(sql, parametrosNomes, parametrosValores);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ExibirTodos()
        {
            string sql = "SELECT ID, Nome, Codigo, CPF, " +
                         "CASE WHEN Sexo = 0 THEN 'Feminino' WHEN Sexo = 1 THEN 'Masculino' END as Sexo, " +
                         "CASE WHEN status = 0 THEN 'Ativo' WHEN status = 1 THEN 'Inativo' END as Status, " +
                         "dbo.FormataData(DataNascimento) as DataNascimento FROM Pessoa order by nome";
            try
            {
                return AcessoDB.GetDataTable(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable MontaComboPessoa()
        {
            string sql = "SELECT id, nome FROM Pessoa";
            try
            {
                return AcessoDB.GetDataTable(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
