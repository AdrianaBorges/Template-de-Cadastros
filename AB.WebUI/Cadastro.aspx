<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="AB.WebUI.Cadastro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style type="text/css">
        .auto-style4 {
            height: 23px;
            width: 512px;
        }
        .auto-style5 {
        }
        .auto-style6 {
            height: 23px;
            width: 128px;
        }
        .auto-style7 {
            width: 114px;
            height: 29px;
        }
        .auto-style9 {
            height: 37px;
            width: 114px;
        }
        .auto-style10 {
            height: 29px;
            width: 512px;
        }
        .auto-style11 {
            width: 512px;
        }
    </style>

    <br />


    <asp:Panel ID="pnlRegistro" runat="server" GroupingText="Cadastro de Motorista(s)">

        <div>
           <table class="corpo-form" border="0" cellpadding="10" cellspacing="10">

                <tr>
                    <td style="height: 29px; width: 114px;" ForeColor="Black">ID</td>
                        <td class="auto-style10">
                            <asp:TextBox ID="txtId" 
                                runat="server" 
                                Width="93px" 
                                Enable="False"
                                ForeColor="Black" 
                                Height="25px" 
                                OnKeyDown="onEnter(event);"> 
                            </asp:TextBox>
                               
                            <asp:Button ID="btnLocalizar" 
                                        runat="server" 
                                        Text="Localizar" 
                                        Width="79px" 
                                        OnClick="btnLocalizar_Click" 
                                        Height="25px" />
                        </td>                      
                </tr>

                <tr>
                    <td ForeColor="Black" class="auto-style7">Código</td>
                        <td class="auto-style10">
                            <asp:TextBox ID="txtCodigo" 
                                runat="server" 
                                Width="93px" 
                                Enable="False"
                                ForeColor="Black" 
                                Height="25px" 
                                OnBlur="ValidarNumMacoAFD(txtCodigo, 7);"
                                OnKeyDown="onEnter(event);" Enabled="False" OnTextChanged="txtCodigo_TextChanged">
                            </asp:TextBox>
                        </td>
                    </tr>

                <tr>
                    <td Height="20px" class="auto-style9">Status</td>
                        <td class="auto-style11">
                            <asp:DropDownList ID="dplStatus" 
                                runat="server"
                                OnSelectedIndexChanged ="dplSexo_SelectedIndexChanged"
                                Height="25px"
                                Width="93px">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Value="0">Ativo</asp:ListItem>
                                <asp:ListItem Value="1">Inativo</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                </tr>


                <tr>
                    <td style="height: 30px; width: 114px;" ForeColor="Black">Nome</td>
                        <td class="auto-style11">
                            <asp:TextBox ID="txtNome" 
                                runat="server" 
                                Width="662px" 
                                ForeColor="Black" 
                                Height="25px" 
                                OnBlur="ValidarNumMacoAFD(txtCodigo, 7);"
                                OnKeyDown="onEnter(event);"></asp:TextBox>

                        </td>
                </tr>

                <tr>
                    <td style="height: 30px; width: 114px;">CPF</td>
                        <td class="auto-style11">
                            <asp:TextBox ID="txtCpf" 
                                runat="server" 
                                Width="120px"
                                ForeColor="Black" 
                                Height="25px" 
                                OnBlur="ValidarNumMacoAFD(txtCodigo, 7);"
                                OnKeyDown="onEnter(event);"></asp:TextBox>
                        </td>
                </tr>

                <tr>
                    <td style="height: 37px; width: 114px;" Height="20px">Sexo</td>
                    <td class="auto-style11">
                        <asp:DropDownList ID="dplSexo" 
                            runat="server"
                            OnSelectedIndexChanged ="dplSexo_SelectedIndexChanged"
                            Height="25px"
                            Width="120px">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem Value="0">Feminino</asp:ListItem>
                            <asp:ListItem Value="1">Masculino</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>

               <tr>
                    <td style="height: 30px; width: 114px;">Data Nascimento  </td>
                        <td class="auto-style11">
                            <asp:TextBox ID="txtDtNascimento" 
                                runat="server" 
                                ForeColor="Black" 
                                Height="25px" 
                                Width="120px"
                                OnBlur="ValidarNumMacoAFD(txtCodigo, 7);"
                                OnKeyDown="onEnter(event);"></asp:TextBox> 
                            <asp:Label ID="lblIdade" runat="server" Text="   0"></asp:Label>
                        </td>
                   
                </tr>

                <tr>
                    <td colspan="2" style="background-color: #99CCFF">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5" style="width: 114px">&nbsp;</td>
                    <td class="auto-style11">
                        <asp:Button ID="btnNovo" runat="server" Text="Novo" Width="90px" OnClick="btnNovo_Click" />
                        <asp:Button ID="btnIncluir" runat="server" Text="Incluir" Width="90px" OnClick="btnIncluir_Click" />
                        <asp:Button ID="btnAlterar" runat="server" Text="Alterar" Width="90px" />
                        <asp:Button ID="btnExcluir" runat="server" Text="Excluir" Width="90px" />
                        <asp:Button ID="btnSair" runat="server" Text="Limpar" Width="90px" OnClick="btnSair_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5" colspan="2">
                        <asp:Label ID="lblmsg" runat="server"></asp:Label>
                    </td>
                </tr>


            </table>    
        </div>

    </asp:Panel>


     <asp:Panel ID="pnlConsulta" runat="server" GroupingText="Lista Registros">
        <div>
            <table class="corpo-form" border="0" cellpadding="10" cellspacing="10">

                <tr>
                    <td class="auto-style6" style="width: 114px">&nbsp;</td>
                    <td class="auto-style4">
                        <asp:GridView ID="gvPessoas" 
                                        runat="server" 
                                        Height="117px" 
                                        Width="636px" 
                                        OnSelectedIndexChanged="gvPessoas_SelectedIndexChanged">
                        </asp:GridView>
                    </td>
                </tr>
               
            </table>    
        </div>

    </asp:Panel>


</asp:Content>
