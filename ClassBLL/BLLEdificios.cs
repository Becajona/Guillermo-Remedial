using ClassDAL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassEntidadesHorario;
using System.Data;


namespace ClassBLL
{
    public class BLLEdificios
    {
        DALMysql obj1 = new DALMysql("Server=127.0.0.1; port=3306; DataBase=horarios; Uid=root; SSL Mode=None;");

        public List<Edificios> ListaEdificios(ref string msj)
        {
            List<Edificios> lista = new List<Edificios>();
            MySqlDataReader contAtrapa = null;
            string consulta = "select * from edificios";
            MySqlConnection cn3 = null;
            cn3 = obj1.conectarDB(ref msj);
            contAtrapa = obj1.ConsultaDR(consulta, cn3, ref msj);
            if (contAtrapa != null && !contAtrapa.IsClosed)
            {
                while (contAtrapa.Read())
                {
                    lista.Add(new Edificios()
                    {
                        IdEdificios = (int)contAtrapa[0],
                        NombreEdi = (string)contAtrapa[1].ToString(),
                        DescripcionEdif = (string)contAtrapa[2].ToString(),
                        DivisionID = (int)contAtrapa[3],
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
        public Boolean InsertaEdificios(Edificios nuevo, ref string msj)
        {
            Boolean salida = false;

            string insercion = "Insert into edificios(NombreEdificio, DescripcionEdif, DivisionID)" +
                " values(@NombreEdi, @DescripcionEdif,@DivisionID);";
            List<MySqlParameter> listap = new List<MySqlParameter>();

            listap.Add(new MySqlParameter("NombreEdi", MySqlDbType.VarChar, 40));
            listap.Add(new MySqlParameter("DescripcionEdif", MySqlDbType.VarChar, 255));
            listap.Add(new MySqlParameter("DivisionID", MySqlDbType.Int32));

            //asignacion de valores a los parametros que ya estan en la lista
            listap[0].Value = nuevo.NombreEdi;
            listap[1].Value = nuevo.DescripcionEdif;
            listap[2].Value = nuevo.DivisionID;

            MySqlConnection cn3 = null;
            cn3 = obj1.conectarDB(ref msj);
            salida = obj1.ModificarDBseguro(insercion, cn3, ref msj, listap);
            return salida;
        }
        public DataTable MostrarEdificioTabla(ref string msj)
        {
            string consulta = "select * from edificios";
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
        public Boolean EliminarEdificioPorId(Edificios id, ref string msj)
        {
            Boolean salida = false;

            string eliminacion = "DELETE FROM edificios WHERE idEdificio = @IdEntrada";

            List<MySqlParameter> listEnt = new List<MySqlParameter>();
            listEnt.Add(new MySqlParameter("IdEntrada", MySqlDbType.Int32));
            listEnt[0].Value = id.IdEdificios;

            MySqlConnection cn3 = null;
            cn3 = obj1.conectarDB(ref msj);
            salida = obj1.ModificarDBseguro(eliminacion, cn3, ref msj, listEnt);
            return salida;
        }
        public Boolean ActualizarEdificio(Edificios nuevo, ref string msj)
        {
            Boolean salida = false;

            string actualizacion = "UPDATE edificios SET NombreEdificio=@NombreAula, DescripcionEdif=@Descripcion, DivisionID=@EdificioId WHERE idEdificio=@IdEntrada";
            List<MySqlParameter> listap = new List<MySqlParameter>();

            listap.Add(new MySqlParameter("IdEntrada", MySqlDbType.Int32));
            listap.Add(new MySqlParameter("NombreAula", MySqlDbType.VarChar, 40));
            listap.Add(new MySqlParameter("Descripcion", MySqlDbType.VarChar, 255));
            listap.Add(new MySqlParameter("EdificioId", MySqlDbType.Int32));

            //asignacion de valores a los parametros que ya estan en la lista
            listap[0].Value = nuevo.IdEdificios;
            listap[1].Value = nuevo.NombreEdi;
            listap[2].Value = nuevo.DescripcionEdif;
            listap[3].Value = nuevo.DivisionID;

            MySqlConnection cn3 = null;
            cn3 = obj1.conectarDB(ref msj);
            salida = obj1.ModificarDBseguro(actualizacion, cn3, ref msj, listap);
            return salida;
        }
    }
}
