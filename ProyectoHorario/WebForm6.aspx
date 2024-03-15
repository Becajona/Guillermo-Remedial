﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm6.aspx.cs" Inherits="ProyectoHorario.WebForm6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Docentes</title>
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
    <form id="form1" runat="server">
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
        <div>
            <h2>Lista Docentes</h2>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateDeleteButton="true" AutoGenerateSelectButton="true"
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDeleting="GridView1_RowDeleting"
                DataKeyNames="idDocente">
            </asp:GridView>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>

        <asp:DropDownList ID="DropDownList5" runat="server"></asp:DropDownList>

        <div>
            <h2>Insertar Docente</h2>
            <br />
            Nombre:
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            Apellido Paterno:
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            Apellido Materno:
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            Extra:
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Insertar Docente" OnClick="Button1_Click" />
        </div>
        <div>
            <h2>Modificar Docente</h2>
            <br />
            ID:
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <br />
            Nuevo Nombre:
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <br />
            Nuevo Apellido Paterno:
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            <br />
            Nuevo Apellido Materno:
            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
            <br />
            Nuevo Extra:
            <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Modificar Docente" OnClick="Button2_Click" />
        </div>
    </form>
</body>
</html>