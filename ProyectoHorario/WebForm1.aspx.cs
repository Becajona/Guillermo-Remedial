using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassBLL;
using ClassEntidadesHorario;

namespace ProyectoHorario
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

            }
            else
            {
                BLLAula Objlogica = new BLLAula();
                string cad = "";
                GridView1.DataSource = Objlogica.MostrarAulaTabla(ref cad);
                GridView1.DataBind();
                Label1.Text = cad;


                BLLEdificios objautomovil = new BLLEdificios();
                List<Edificios> lista1 = null;
                string m = "";
                lista1 = objautomovil.ListaEdificios(ref m);
                Label1.Text = m;
                DropDownList1.Items.Clear();
                if (lista1 != null)
                {
                    foreach (Edificios z in lista1)
                    {
                        DropDownList1.Items.Add(new ListItem(z.NombreEdi, z.IdEdificios.ToString()));
                        DropDownList2.Items.Add(new ListItem(z.NombreEdi, z.IdEdificios.ToString()));
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
 
                string idAula = GridView1.DataKeys[index].Values["idAula"].ToString();

                Label2.Text = idAula;

                TextBox3.Text = HttpUtility.HtmlDecode(GridView1.Rows[indiceRow].Cells[2].Text);
                TextBox4.Text = HttpUtility.HtmlDecode(GridView1.Rows[indiceRow].Cells[3].Text);
            }

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idEntrada = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["idAula"]);

            Aulas temp = new Aulas()
            {
                IdAula = idEntrada
            };

            string cad = "";
            BLLAula oblogauto = new BLLAula();
            oblogauto.EliminarAulaPorId(temp, ref cad);
            Label1.Text = cad;

            GridView1.DataSource = oblogauto.MostrarAulaTabla(ref cad);
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Aulas temp = new Aulas()
            {
                NombreAula = TextBox1.Text,
                Descripcion = TextBox2.Text,
                EdificioId = int.Parse(DropDownList1.Text),

            };
            string cad = "";
            BLLAula oblogauto = new BLLAula();
            oblogauto.InsertaAulas(temp, ref cad);
            Label1.Text = cad;

            GridView1.DataSource = oblogauto.MostrarAulaTabla(ref cad);
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreAulaAntes = TextBox3.Text;
                string descripcionAntes = TextBox4.Text;
                int edificioIdAntes = int.Parse(DropDownList2.SelectedValue);

                int idAula = Convert.ToInt32(Label2.Text);

                Aulas temp = new Aulas()
                {
                    IdAula = idAula,
                    NombreAula = nombreAulaAntes,
                    Descripcion = descripcionAntes,
                    EdificioId = edificioIdAntes,
                };

                string cad = "";
                BLLAula oblogauto = new BLLAula();
                oblogauto.ActualizarAulas(temp, ref cad);
                Label1.Text = cad;

                GridView1.DataSource = oblogauto.MostrarAulaTabla(ref cad);
                GridView1.DataBind();

                TextBox3.Text = nombreAulaAntes;
                TextBox4.Text = descripcionAntes;
                DropDownList2.SelectedValue = edificioIdAntes.ToString();
            }
            catch (Exception ex)
            {
                Label1.Text = "Error al procesar la actualización: " + ex.Message;
            }
        }
    }
}