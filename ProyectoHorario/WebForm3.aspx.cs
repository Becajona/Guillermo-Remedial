using ClassBLL;
using ClassEntidadesHorario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoHorario
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

            }
            else
            {
                BLLEspecialidades Objlogica = new BLLEspecialidades();
                string cad = "";
                GridView1.DataSource = Objlogica.MostrarEspecialidadesTabla(ref cad);
                GridView1.DataBind();
                Label1.Text = cad;


                BLLDiviciones objautomovil = new BLLDiviciones();
                List<Diviciones> lista1 = null;
                string m = "";
                lista1 = objautomovil.ListaDivisiones(ref m);
                Label1.Text = m;
                DropDownList1.Items.Clear();
                if (lista1 != null)
                {
                    foreach (Diviciones z in lista1)
                    {
                        DropDownList1.Items.Add(new ListItem(z.NombreDivicion, z.idDivicion.ToString()));
                        DropDownList2.Items.Add(new ListItem(z.NombreDivicion, z.idDivicion.ToString()));
                    }
                }
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = GridView1.SelectedIndex;
            int indiceRow = GridView1.SelectedIndex;

            if (index >= 0 && index < GridView1.Rows.Count)
            {

                string idAula = GridView1.DataKeys[index].Values["idEspecialidad"].ToString();

                Label2.Text = idAula;

                TextBox3.Text = HttpUtility.HtmlDecode(GridView1.Rows[indiceRow].Cells[2].Text);
                TextBox4.Text = HttpUtility.HtmlDecode(GridView1.Rows[indiceRow].Cells[3].Text);
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idEntrada = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["idEspecialidad"]);

            Especialidades temp = new Especialidades()
            {
                IdEspecialidad = idEntrada
            };

            string cad = "";
            BLLEspecialidades oblogauto = new BLLEspecialidades();
            oblogauto.EliminarEspecialidadesPorId(temp, ref cad);
            Label1.Text = cad;

            GridView1.DataSource = oblogauto.MostrarEspecialidadesTabla(ref cad);
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Especialidades temp = new Especialidades()
            {
                NombreEspe = TextBox1.Text,
                Descripcion = TextBox2.Text,
                IdDivicion = int.Parse(DropDownList1.Text),

            };
            string cad = "";
            BLLEspecialidades oblogauto = new BLLEspecialidades();
            oblogauto.InsertaEspecialidades(temp, ref cad);
            Label1.Text = cad;

            GridView1.DataSource = oblogauto.MostrarEspecialidadesTabla(ref cad);
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreEspeAntes = TextBox3.Text;
                string descripcionAntes = TextBox4.Text;
                int IdAntes = int.Parse(DropDownList2.SelectedValue);

                int idAula = Convert.ToInt32(Label2.Text);

                Especialidades temp = new Especialidades()
                {
                    IdEspecialidad = idAula,
                    NombreEspe = nombreEspeAntes,
                    Descripcion = descripcionAntes,
                    IdDivicion = IdAntes,
                };

                string cad = "";
                BLLEspecialidades oblogauto = new BLLEspecialidades();
                oblogauto.ActualizarEspecialidad(temp, ref cad);
                Label1.Text = cad;

                GridView1.DataSource = oblogauto.MostrarEspecialidadesTabla(ref cad);
                GridView1.DataBind();

                TextBox3.Text = nombreEspeAntes;
                TextBox4.Text = descripcionAntes;
                DropDownList2.SelectedValue = IdAntes.ToString();
            }
            catch (Exception ex)
            {
                Label1.Text = "Error al procesar la actualización: " + ex.Message;
            }
        }
    }
}