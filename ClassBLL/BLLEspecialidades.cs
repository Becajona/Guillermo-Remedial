using ClassDAL;
using ClassEntidadesHorario;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBLL
{
    public class BLLEspecialidades
    {
        DALMysql obj1 = new DALMysql("Server=127.0.0.1; port=3306; DataBase=horarios; Uid=root; SSL Mode=None;");

        public Boolean InsertaEspecialidades(Especialidades nuevo, ref string msj)
        {
            Boolean salida = false;

            string insercion = "Insert into especialidades(NombreEsp, DescripcionEsp, DivisionID)" +
                " values(@NombreEspe, @Descripcion,@DivisionID);";
            List<MySqlParameter> listap = new List<MySqlParameter>();

            listap.Add(new MySqlParameter("NombreEspe", MySqlDbType.VarChar, 40));
            listap.Add(new MySqlParameter("Descripcion", MySqlDbType.VarChar, 255));
            listap.Add(new MySqlParameter("DivisionID", MySqlDbType.Int32));

            //asignacion de valores a los parametros que ya estan en la lista
            listap[0].Value = nuevo.NombreEspe;
            listap[1].Value = nuevo.Descripcion;
            listap[2].Value = nuevo.IdDivicion;

            MySqlConnection cn3 = null;
            cn3 = obj1.conectarDB(ref msj);
            salida = obj1.ModificarDBseguro(insercion, cn3, ref msj, listap);
            return salida;
        }
        public DataTable MostrarEspecialidadesTabla(ref string msj)
        {
            string consulta = "select * from especialidades";
            MySqlConnection cna = null;
            DataSet dsAtrapa = null;
            DataTable dtSalida = null;
            cna = obj1.conectarDB(ref msj);
            dsAtrapa = obj1.ConsultaDataSet(consulta, cna, ref msj);
            if (dsAtrapa != null)
            {
                dtSalida = dsAtrapa.Tables[0];
            }
            else
            {
                dtSalida = null;
            }
            return dtSalida;
        }
        public Boolean EliminarEspecialidadesPorId(Especialidades id, ref string msj)
        {
            Boolean salida = false;

            string eliminacion = "DELETE FROM especialidades WHERE idEspecialidad = @IdEntrada";

            List<MySqlParameter> listEnt = new List<MySqlParameter>();
            listEnt.Add(new MySqlParameter("IdEntrada", MySqlDbType.Int32));
            listEnt[0].Value = id.IdEspecialidad;

            MySqlConnection cn3 = null;
            cn3 = obj1.conectarDB(ref msj);
            salida = obj1.ModificarDBseguro(eliminacion, cn3, ref msj, listEnt);
            return salida;
        }
        public Boolean ActualizarEspecialidad(Especialidades nuevo, ref string msj)
        {
            Boolean salida = false;

            string actualizacion = "UPDATE especialidades SET NombreEsp=@NombreEsp, DescripcionEsp=@DescripcionEsp, DivisionID=@EdificioId WHERE idEspecialidad=@IdEntrada";
            List<MySqlParameter> listap = new List<MySqlParameter>();

            listap.Add(new MySqlParameter("IdEntrada", MySqlDbType.Int32));
            listap.Add(new MySqlParameter("NombreEsp", MySqlDbType.VarChar, 40));
            listap.Add(new MySqlParameter("DescripcionEsp", MySqlDbType.VarChar, 255));
            listap.Add(new MySqlParameter("EdificioId", MySqlDbType.Int32));

            //asignacion de valores a los parametros que ya estan en la lista
            listap[0].Value = nuevo.IdEspecialidad;
            listap[1].Value = nuevo.NombreEspe;
            listap[2].Value = nuevo.Descripcion;
            listap[3].Value = nuevo.IdDivicion;

            MySqlConnection cn3 = null;
            cn3 = obj1.conectarDB(ref msj);
            salida = obj1.ModificarDBseguro(actualizacion, cn3, ref msj, listap);
            return salida;
        }
        public List<Especialidades> ListaEspecialidades(ref string msj)
        {
            List<Especialidades> lista = new List<Especialidades>();
            MySqlDataReader contAtrapa = null;
            string consulta = "select * from especialidades";
            MySqlConnection cn3 = null;
            cn3 = obj1.conectarDB(ref msj);
            contAtrapa = obj1.ConsultaDR(consulta, cn3, ref msj);
            if (contAtrapa != null && !contAtrapa.IsClosed)
            {
                while (contAtrapa.Read())
                {
                    lista.Add(new Especialidades()
                    {
                        IdEspecialidad = (int)contAtrapa[0],
                        NombreEspe = contAtrapa[1].ToString(),
                        Descripcion = contAtrapa[2].ToString(),
                        IdDivicion = (int)contAtrapa[3],
                    });
                }
                cn3.Close();
                cn3.Dispose();
            }
            else
            {
                if (contAtrapa != null && contAtrapa.IsClosed)
                {
                    msj = msj + ", Esta cerrado el data reader";

                }
                lista = null;
            }
            return lista;
        }
    }
}
