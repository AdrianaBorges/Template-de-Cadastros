<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="AB.WebUI.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style type="text/css">
        .style1
        {
            width: 158px;
        }
        .auto-style1 {
            width: 210px;
        }
    </style>

    <br />
    <br />


        <asp:Panel ID="pnlRegistro" runat="server" GroupingText="Cadastro de Motorista(s)">

<%--            <center>--%>


           <table class="corpo-form" border="0" cellpadding="10" cellspacing="10" width="250px">
                <tr>
                  <th>Código:</th>
                    <td colspan="4">
                        <div>
                            <asp:TextBox ID="TextBox1" runat="server" Width="90px" Text="" MaxLength="10"
                                ForeColor="Black" TabIndex="8" Height="20px" Enabled="False" OnBlur="ValidarNumMacoAFD(txtCodigo, 7);"
                                OnKeyDown="onEnter(event);"></asp:TextBox>
                        </div>
                    </td>
                </tr>

                <tr>
                 <th>Nome:</th>
                    <td colspan="4">
                        <div>
                            <asp:TextBox ID="TextBox3" 
                                runat="server" 
                                Width="400px" 
                                Text="" 
                                MaxLength="10"
                                ForeColor="Black" 
                                TabIndex="8" 
                                Height="20px" OnBlur="ValidarNumMacoAFD(txtCodigo, 7);"
                                OnKeyDown="onEnter(event);"></asp:TextBox>
                        </div>
                    </td>
                <th>CPF:</th>
                    <td colspan="4">
                        <div>
                            <asp:TextBox ID="TextBox4" runat="server" Width="150px" Text="" MaxLength="10"
                                ForeColor="Black" TabIndex="8" Height="20px" OnBlur="ValidarNumMacoAFD(txtCodigo, 7);"
                                OnKeyDown="onEnter(event);"></asp:TextBox>
                        </div>
                    </td>
                </tr>


                <tr>
                  <th rowspan="2">Telefone:</th>
                  <td>8888-8888</td>
                </tr>
                <tr>
                  <td>9999-9999</td>
                </tr>
            </table>


                <table class="corpo-form" border="0" cellpadding="10" cellspacing="10" width="875px">
                    
                    <tr align="left">
                        <td colspan="4">
                            <div>
                                Código: &nbsp; &nbsp;
                                    <asp:TextBox ID="txtCodigo" runat="server" Width="150px" Text="" MaxLength="10"
                                        ForeColor="Black" TabIndex="8" Height="20px" Enabled="False" OnBlur="ValidarNumMacoAFD(txtCodigo, 7);"
                                        OnKeyDown="onEnter(event);"></asp:TextBox>
                            </div>
                        </td>
                    </tr>

                    <tr align="left">
                        <td colspan="4">
                            <div>
                                Nome: &nbsp; &nbsp;
                                    <asp:TextBox ID="txtNome" runat="server" Width="300px" Text="" MaxLength="10"
                                        ForeColor="Black" TabIndex="8" Height="20px" OnBlur="ValidarNumMacoAFD(txtCodigo, 7);"
                                        OnKeyDown="onEnter(event);"></asp:TextBox>
                            </div>
                        </td>
                    </tr>

                    <tr align="left">
                        <td colspan="4">
                            <div>
                                CPF: &nbsp; &nbsp;
                                    <asp:TextBox ID="txtCpf" runat="server" Width="150px" Text="" MaxLength="10"
                                        ForeColor="Black" TabIndex="8" Height="20px" OnBlur="ValidarNumMacoAFD(txtCodigo, 7);"
                                        OnKeyDown="onEnter(event);"></asp:TextBox>
                            </div>
                        </td>
                    </tr>


                    <tr align="left">
                        <td colspan="4">
                            <div>
                                Sexo: &nbsp; &nbsp;
                                    <asp:DropDownList ID="DropDownList1" runat="server" Width="499px" AutoPostBack="True"
                                        Font-Names="Arial" TabIndex="1" Height="20px" Enabled="true" AppendDataBoundItems="True">
                                    </asp:DropDownList>
                            </div>
                        </td>


                    </tr>

                </table>
<%--            </center>--%>

            <div>
                Selecione o tipo do documento: &nbsp; &nbsp;
                    <asp:DropDownList ID="DropDownList" runat="server" Width="499px" AutoPostBack="True"
                        Font-Names="Arial" TabIndex="1" Height="20px" Enabled="true" AppendDataBoundItems="True">
                    </asp:DropDownList>
            </div>

          



        </asp:Panel>






</asp:Content>
