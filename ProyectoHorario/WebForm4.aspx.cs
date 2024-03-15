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
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

            }
            else
            {
                BLLHorario Objlogica = new BLLHorario();
                string cad = "";
                GridView1.DataSource = Objlogica.MostrarHorarioTabla(ref cad);
                GridView1.DataBind();
                Label1.Text = cad;


                BLLAsignacion objautomovil = new BLLAsignacion();
                List<AsignacionCuatrimestral> lista1 = null;
                string m = "";
                lista1 = objautomovil.ListaAsignacion(ref m);
                Label1.Text = m;
                DropDownList1.Items.Clear();
                //DropDownList4.Items.Clear();
                if (lista1 != null)
                {
                    foreach (AsignacionCuatrimestral z in lista1)
                    {
                        DropDownList1.Items.Add(new ListItem(z.idAsignacion.ToString(),z.idAsignacion.ToString()));
                        DropDownList4.Items.Add(new ListItem(z.idAsignacion.ToString(),z.idAsignacion.ToString()));
                    }
                }

                BLLDia objautomovil1 = new BLLDia();
                List<DiaSemana> lista2 = null;
                List<DiaSemana> lista22 = null;
                lista2 = objautomovil1.ListaDia(ref m);
                lista22 = objautomovil1.ListaDia(ref m);
                Label1.Text = m;
                DropDownList2.Items.Clear();
                //DropDownList5.Items.Clear();
                if (lista2 != null && lista22 != null)
                {
                    foreach (DiaSemana z in lista2)
                    {
                        DropDownList2.Items.Add(new ListItem(z.NomDia, z.iddia.ToString()));
                        
                    }
                    foreach (DiaSemana x in lista22)
                    {
                        DropDownList5.Items.Add(new ListItem(x.NomDia, x.iddia.ToString()));
                    }
                }

                BLLAula objautomovil3 = new BLLAula();
                List<Aulas> lista3 = null;
                lista3 = objautomovil3.ListaAula(ref m);
                Label1.Text = m;
                DropDownList3.Items.Clear();
                //DropDownList6.Items.Clear();
                if (lista3 != null)
                {
                    foreach (Aulas z in lista3)
                    {
                        DropDownList3.Items.Add(new ListItem(z.NombreAula, z.IdAula.ToString()));
                        DropDownList6.Items.Add(new ListItem(z.NombreAula, z.IdAula.ToString()));
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

                string idAula = GridView1.DataKeys[index].Values["idHorario"].ToString();

                Label2.Text = idAula;

                TextBox3.Text = HttpUtility.HtmlDecode(GridView1.Rows[indiceRow].Cells[4].Text);
                TextBox4.Text = HttpUtility.HtmlDecode(GridView1.Rows[indiceRow].Cells[5].Text);
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idEntrada = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["idHorario"]);

            Horario temp = new Horario()
            {
                idHorario = idEntrada
            };

            string cad = "";
            BLLHorario oblogauto = new BLLHorario();
            oblogauto.EliminarHorarioPorId(temp, ref cad);
            Label1.Text = cad;

            GridView1.DataSource = oblogauto.MostrarHorarioTabla(ref cad);
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Horario temp = new Horario()
            {
                AsignacionID = int.Parse(DropDownList1.Text),
                DiaID = int.Parse(DropDownList2.Text),
                HrInicio =TimeSpan.Parse(TextBox1.Text),
                HrFinal = TimeSpan.Parse(TextBox2.Text),
                AulaID = int.Parse(DropDownList3.Text),

            };
            string cad = "";
            BLLHorario oblogauto = new BLLHorario();
            oblogauto.InsertaHorario(temp, ref cad);
            Label1.Text = cad;

            GridView1.DataSource = oblogauto.MostrarHorarioTabla(ref cad);
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreAulaAntes = TextBox3.Text;
                string descripcionAntes = TextBox4.Text;


                BLLHorario objhor = new BLLHorario();
                Horario actualizacionHorario = new Horario
                {
                    idHorario = Convert.ToInt32(Label2.Text),
                    AsignacionID = int.Parse(DropDownList4.SelectedValue),
                    DiaID = int.Parse(DropDownList5.SelectedValue),
                    HrInicio = TimeSpan.Parse(TextBox3.Text),
                    HrFinal = TimeSpan.Parse(TextBox4.Text),
                    AulaID = int.Parse(DropDownList6.SelectedValue)
                };

                string cad = "";
                objhor.ActualizarHorario(actualizacionHorario, ref cad);
                Label1.Text = cad;

                GridView1.DataSource = objhor.MostrarHorarioTabla(ref cad);
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