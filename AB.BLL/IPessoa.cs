using AB.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.BLL
{
    public interface IPessoa<T>
    {
        DataTable ExibirTodos();
        DataTable MontaComboPessoa();
        List<T> Exibir();
        void Incluir(T obj);
        void Alterar(T obj);
        void Excluir(T obj);
        DataTable Consultar(string nome);
        Pessoa GetPessoaId(int id);

    }
}
