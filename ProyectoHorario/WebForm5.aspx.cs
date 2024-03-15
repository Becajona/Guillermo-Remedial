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
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

            }
            else
            {
                BLLGrupo Objlogica = new BLLGrupo();
                string cad = "";
                GridView1.DataSource = Objlogica.MostrarGrupoTabla(ref cad);
                GridView1.DataBind();
                Label1.Text = cad;

                //periodo
                BLLPeriodo objautomovil = new BLLPeriodo();
                List<Periodos> lista1 = null;
                string m = "";
                lista1 = objautomovil.ListaPeriodo(ref m);
                Label1.Text = m;
                DropDownList1.Items.Clear();
                if (lista1 != null)
                {
                    foreach (Periodos z in lista1)
                    {
                        DropDownList1.Items.Add(new ListItem(z.NombrePeriodo, z.idPeriodo.ToString()));
                        DropDownList5.Items.Add(new ListItem(z.NombrePeriodo, z.idPeriodo.ToString()));
                    }
                }
                //aula
                BLLAula objautomovil2 = new BLLAula();
                List<Aulas> lista2 = null;
                lista2 = objautomovil2.ListaAula(ref m);
                Label1.Text = m;
                DropDownList2.Items.Clear();
                if (lista2 != null)
                {
                    foreach (Aulas z in lista2)
                    {
                        DropDownList2.Items.Add(new ListItem(z.NombreAula, z.IdAula.ToString()));
                        DropDownList6.Items.Add(new ListItem(z.NombreAula, z.IdAula.ToString()));
                    }
                }
                //tutor
                BLLDocente objautomovil3 = new BLLDocente();
                List<Docentes> lista3 = null;
                lista3 = objautomovil3.ListaDocente(ref m);
                Label1.Text = m;
                DropDownList3.Items.Clear();
                if (lista3 != null)
                {
                    foreach (Docentes z in lista3)
                    {
                        DropDownList3.Items.Add(new ListItem(z.Nombre, z.idDocente.ToString()));
                        DropDownList7.Items.Add(new ListItem(z.Nombre, z.idDocente.ToString()));
                    }
                }
                //especialidad
                BLLEspecialidades objautomovil4 = new BLLEspecialidades();
                List<Especialidades> lista4 = null;
                lista4 = objautomovil4.ListaEspecialidades(ref m);
                Label1.Text = m;
                DropDownList4.Items.Clear();
                if (lista4 != null)
                {
                    foreach (Especialidades z in lista4)
                    {
                        DropDownList4.Items.Add(new ListItem(z.NombreEspe, z.IdEspecialidad.ToString()));
                        DropDownList8.Items.Add(new ListItem(z.NombreEspe, z.IdEspecialidad.ToString()));
                    }
                }

            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idEntrada = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["Idgrupo"]);

            Grupos temp = new Grupos()
            {
                Idgrupo = idEntrada
            };

            string cad = "";
            BLLGrupo oblogauto = new BLLGrupo();
            oblogauto.EliminarGrupoPorId(temp, ref cad);
            Label1.Text = cad;

            GridView1.DataSource = oblogauto.MostrarGrupoTabla(ref cad);
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = GridView1.SelectedIndex;
            int indiceRow = GridView1.SelectedIndex;

            if (index >= 0 && index < GridView1.Rows.Count)
            {

                string id = GridView1.DataKeys[index].Values["Idgrupo"].ToString();

                Label2.Text = id;

                TextBox4.Text = HttpUtility.HtmlDecode(GridView1.Rows[indiceRow].Cells[2].Text);
                TextBox5.Text = HttpUtility.HtmlDecode(GridView1.Rows[indiceRow].Cells[3].Text);
                TextBox6.Text = HttpUtility.HtmlDecode(GridView1.Rows[indiceRow].Cells[4].Text);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Grupos temp = new Grupos()
            {
                NomGrupo=TextBox1.Text,
                Cuatrimestre=int.Parse(TextBox2.Text),
                Turno=TextBox3.Text,
                PeriodoID=int.Parse(DropDownList1.Text),
                AulaID=int.Parse(DropDownList2.Text),
                TutorID=int.Parse(DropDownList3.Text),
                EspecialidadID=int.Parse(DropDownList4.Text),
            };
            string cad = "";
            BLLGrupo oblogauto = new BLLGrupo();
            oblogauto.InsertaGrupo(temp, ref cad);
            Label1.Text = cad;

            GridView1.DataSource = oblogauto.MostrarGrupoTabla(ref cad);
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreAulaAntes = TextBox3.Text;
                string descripcionAntes = TextBox4.Text;


                BLLGrupo objhor = new BLLGrupo();
                Grupos actualizacionGrupo = new Grupos
                {
                    Idgrupo = Convert.ToInt32(Label2.Text),
                    NomGrupo = Convert.ToString(TextBox4.Text),
                    Cuatrimestre = int.Parse(TextBox5.Text),
                    Turno = Convert.ToString(TextBox6.Text),
                    PeriodoID = int.Parse(DropDownList5.SelectedValue),
                    AulaID = int.Parse(DropDownList6.SelectedValue),
                    TutorID = int.Parse(DropDownList7.SelectedValue),
                    EspecialidadID = int.Parse(DropDownList8.SelectedValue)
                };

                string cad = "";
                objhor.ActualizarGrupos(actualizacionGrupo, ref cad);
                Label1.Text = cad;

                GridView1.DataSource = objhor.MostrarGrupoTabla(ref cad);
                GridView1.DataBind();

                TextBox3.Text = nombreAulaAntes;
                TextBox4.Text = descripcionAntes;

            }
            catch (Exception ex)
            {
                Label1.Text = "Error al procesar la actualización: " + ex.Message;
            }
        }
    }
}