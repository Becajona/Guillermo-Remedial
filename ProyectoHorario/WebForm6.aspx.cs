using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassBLL;
using ClassEntidadesHorario;

namespace ProyectoHorario
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDropDowns();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lógica para manejar la selección de un docente en el GridView
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Lógica para eliminar un docente
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Lógica para insertar un nuevo docente
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // Lógica para modificar un docente existente
        }

        private void CargarDropDowns()
        {
            // Lógica para cargar los dropdowns
        }
    }
}
