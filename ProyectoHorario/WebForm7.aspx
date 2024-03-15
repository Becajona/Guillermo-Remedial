<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm7.aspx.cs" Inherits="ProyectoHorario.WebForm7" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Periodos</title>
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
            <h2>Lista de Periodos</h2>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="idPeriodo">
                <Columns>
                    <asp:BoundField DataField="idPeriodo" HeaderText="ID Periodo" />
                    <asp:BoundField DataField="NombrePeriodo" HeaderText="Nombre Periodo" />
                    <asp:BoundField DataField="P_inicio" HeaderText="Fecha de Inicio" />
                    <asp:BoundField DataField="P_Fin" HeaderText="Fecha de Fin" />
                    <asp:BoundField DataField="Año" HeaderText="Año" />
                    <asp:BoundField DataField="Extra" HeaderText="Extra" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>

        <div>
            <h2>Insertar Periodo</h2>
            <br />
            Nombre del Periodo:
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            Fecha de Inicio:
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            Fecha de Fin:
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            Año:
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            Extra:
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Insertar Periodo" OnClick="Button1_Click" />
        </div>

        <div>
            <h2>Modificar Periodo</h2>
            <br />
            ID del Periodo:
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <br />
            Nuevo Nombre del Periodo:
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            <br />
            Nueva Fecha de Inicio:
            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
            <br />
            Nueva Fecha de Fin:
            <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
            <br />
            Nuevo Año:
            <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
            <br />
            Nuevo Extra:
            <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Modificar Periodo" OnClick="Button2_Click" />
        </div>
    </form>
</body>
</html>
