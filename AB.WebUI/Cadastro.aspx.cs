using AB.DTO;
using AB.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AB.DTO.Enum;

namespace AB.WebUI
{
    public partial class Cadastro : Page
    {
        PessoaBLL _pessoaBLL = new PessoaBLL();
        Pessoa _pessoa = new Pessoa();

        protected void Page_Load(object sender, EventArgs e)
        {
            ListaPessoas();

        }

        private void ListaPessoas()
        {
            try
            {
                gvPessoas.DataSource = _pessoaBLL.ExibirTodos();
                gvPessoas.DataBind();
            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
            }
        }


        protected void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        protected void gvPessoas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dplListaPessoa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private int CalculaIdade(DateTime dtNascimento)
        {
            var idade = DateTime.Now.Year - dtNascimento.Year;
            if (DateTime.Now.Month < dtNascimento.Month || (DateTime.Now.Month == dtNascimento.Month && DateTime.Now.Day < dtNascimento.Day))
                idade--;

            return idade;
        }

        protected void btnLocalizar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtId.Text))
            {
                int codigo = Convert.ToInt32(txtId.Text);
                try
                {
                    _pessoa = _pessoaBLL.GetPessoaId(codigo);
                    txtCodigo.Text = _pessoa.Codigo;

                    if (_pessoa.Status == EnumStatusPessoa.Ativo) { dplStatus.SelectedIndex = 1; }
                    if (_pessoa.Status == EnumStatusPessoa.Inativo) { dplStatus.SelectedIndex = 2; }

                    txtNome.Text = _pessoa.Nome;
                    txtCpf.Text = _pessoa.CPF;

                    if (_pessoa.Sexo == EnumSexoPessoa.Feminino) { dplSexo.SelectedIndex = 1; }
                    if (_pessoa.Sexo == EnumSexoPessoa.Masculino) { dplSexo.SelectedIndex = 2; }

                    txtDtNascimento.Text = _pessoa.DataNascimento.ToShortDateString();

                    lblIdade.Text = Convert.ToString(CalculaIdade(Convert.ToDateTime(txtDtNascimento.Text)) + " Anos");
                }
                catch (Exception ex)
                {
                    lblmsg.Text = ex.Message;
                }
            }
            else
            {
                lblmsg.Text = "Informe o Id da Pessoa...";
            }
        }

        protected void btnIncluir_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNome.Text) || !string.IsNullOrWhiteSpace(txtCpf.Text) || !string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                try
                {
                    _pessoa.Codigo = GeraNovoCodigo(Convert.ToInt32(_pessoaBLL.GetProximoCodigo()));
                    _pessoa.Status = (EnumStatusPessoa)dplStatus.SelectedIndex;  
                    _pessoa.Nome = txtNome.Text;
                    _pessoa.CPF = txtCpf.Text;
                    _pessoa.Sexo = (EnumSexoPessoa)dplSexo.SelectedIndex;
                    _pessoa.DataNascimento = Convert.ToDateTime(txtDtNascimento.Text);

                    _pessoaBLL.Incluir(_pessoa);
                }
                catch (Exception ex)
                {
                    lblmsg.Text = ex.Message;
                }
            }
            else
            {
                lblmsg.Text = "Informe o nome e o cpf...";
            }
        }

        private string GeraNovoCodigo(int id)
        {
            //int _id = id++;

            //string _len = "00" + _id + "." + da

            return string.Empty;



        }

        protected void btnSair_Click(object sender, EventArgs e)
        {
            LimpaTelaDeCadastro();
        }

        private void LimpaTelaDeCadastro()
        {
            txtId.Text = string.Empty;
            txtCodigo.Text = string.Empty;
            dplStatus.SelectedIndex = 0;
            txtNome.Text = string.Empty;
            txtCpf.Text = string.Empty;
            dplSexo.SelectedIndex = 0;
            txtDtNascimento.Text = string.Empty;
            lblIdade.Text = $"0";
        }
    }
}