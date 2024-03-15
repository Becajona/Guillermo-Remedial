﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="ProyectoHorario.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edificio</title>
    <style>
        body {
            background-color: #ffffff; /* Blanco */
            color: #000000; /* Negro */
            font-family: Arial, sans-serif;
        }

        h2 {
            color: #0000ff; /* Azul */
        }

        /* Estilos para la navbar */
        .navbar {
            background-color: #0000ff; /* Azul */
            overflow: hidden;
        }

            .navbar a {
                float: left;
                display: block;
                color: #ffffff; /* Blanco */
                text-align: center;
                padding: 14px 16px;
                text-decoration: none;
            }

                .navbar a:hover {
                    background-color: #ffffff; /* Blanco */
                    color: #0000ff; /* Azul */
                }
    </style>
</head>
<body>
    <div class="navbar">
        
        <a href="WebForm1.aspx">Aulas</a>
        <a href="WebForm2.aspx">Edificios</a>
        <a href="WebForm3.aspx">Especialidades</a>
        <a href="WebForm4.aspx">Horario</a>
        <a href="WebForm5.aspx">Grupo</a>
        <a href="WebForm6.aspx">Docentes</a>
        <a href="WebForm7.aspx">Periodos</a>
        <a href="WebForm8.aspx">Asignacioncuatrimestral</a>
        <a href="WebForm9.aspx">Asignaturas</a>
        <a href="WebForm10.aspx">Registroasistencia</a>

    </div>
    <form id="form1" runat="server">
        <div>
            Tabla:
    <asp:GridView ID="GridView1" runat="server" AutoGenerateDeleteButton="True" AutoGenerateSelectButton="True"
        OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDeleting="GridView1_RowDeleting" DataKeyNames="idEdificio">
    </asp:GridView>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
        <div>
            <h2>Insertar</h2>
            <br />
            Nombre:
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            Descripcion:
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            Division:
    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        </div>
        <div>
            <h2>Modificar</h2>
            <br />
            <br />
            id:
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <br />
            Nombre:
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            Descripcion:
    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            Division:
    <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
        </div>
    </form>
</body>
</html>
