<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm8.aspx.cs" Inherits="ProyectoHorario.WebForm8" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<<<<<<< HEAD
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Asignacioncuatrimestral</title>
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
            <h2>Lista de Asignaciones Cuatrimestrales</h2>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="idAsignacion">
                <Columns>
                    <asp:BoundField DataField="idAsignacion" HeaderText="ID Asignación" />
                    <asp:BoundField DataField="GrupoID" HeaderText="ID Grupo" />
                    <asp:BoundField DataField="DocenteID" HeaderText="ID Docente" />
                    <asp:BoundField DataField="AsignaturaID" HeaderText="ID Asignatura" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>

        <div>
            <h2>Insertar Asignación Cuatrimestral</h2>
            <br />
            ID del Grupo:
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            ID del Docente:
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            ID de la Asignatura:
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Insertar Asignación" OnClick="Button1_Click" />
        </div>

        <div>
            <h2>Modificar Asignación Cuatrimestral</h2>
            <br />
            ID de la Asignación:
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            Nuevo ID del Grupo:
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <br />
            Nuevo ID del Docente:
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <br />
            Nuevo ID de la Asignatura:
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Modificar Asignación" OnClick="Button2_Click" />
        </div>
=======
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Asignacioncuatrimestral</title>
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
        
>>>>>>> 80bfbab8a12e5e132fdb5e0fee0f091e2d160067
    </form>
</body>
</html>
