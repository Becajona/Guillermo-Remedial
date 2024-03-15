using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassEntidadesHorario;
using MySql.Data.MySqlClient;
using System.Data;
using ClassDAL;

namespace ClassBLL
{
    public class BLLAula
    {
        DALMysql obj1 = new DALMysql("Server=127.0.0.1; port=3306; DataBase=horarios; Uid=root; SSL Mode=None;");

        public List<Aulas> ListaAula(ref string msj)
        {
            List<Aulas> lista = new List<Aulas>();
            MySqlDataReader contAtrapa = null;
            string consulta = "select * from aulas";
            MySqlConnection cn3 = null;
            cn3 = obj1.conectarDB(ref msj);
            contAtrapa = obj1.ConsultaDR(consulta, cn3, ref msj);
            if (contAtrapa != null && !contAtrapa.IsClosed)
            {
                while (contAtrapa.Read())
                {
                    lista.Add(new Aulas()
                    {
                        IdAula = (int)contAtrapa[0],
                        NombreAula = contAtrapa[1].ToString(),
                        Descripcion = contAtrapa[2].ToString(),
                        EdificioId = (int)contAtrapa[3],
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
        public Boolean InsertaAulas(Aulas nuevo, ref string msj)
        {
            Boolean salida = false;

            string insercion = "Insert into aulas(NombAula, Descripcion, EdificioID)" +
                " values(@NombreAula, @Descripcion,@EdificioId);";
            List<MySqlParameter> listap = new List<MySqlParameter>();

            listap.Add(new MySqlParameter("NombreAula", MySqlDbType.VarChar,40));
            listap.Add(new MySqlParameter("Descripcion", MySqlDbType.VarChar, 255));
            listap.Add(new MySqlParameter("EdificioId", MySqlDbType.Int32));

            //asignacion de valores a los parametros que ya estan en la lista
            listap[0].Value = nuevo.NombreAula;
            listap[1].Value = nuevo.Descripcion;
            listap[2].Value = nuevo.EdificioId;

            MySqlConnection cn3 = null;
            cn3 = obj1.conectarDB(ref msj);
            salida = obj1.ModificarDBseguro(insercion, cn3, ref msj, listap);
            return salida;
        }
        public DataTable MostrarAulaTabla(ref string msj)
        {
            string consulta = "select * from aulas";
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
        public Boolean EliminarAulaPorId(Aulas id, ref string msj)
        {
            Boolean salida = false;

            string eliminacion = "DELETE FROM aulas WHERE idAula = @IdEntrada";

            List<MySqlParameter> listEnt = new List<MySqlParameter>();
            listEnt.Add(new MySqlParameter("IdEntrada", MySqlDbType.Int32));
            listEnt[0].Value = id.IdAula;

            MySqlConnection cn3 = null;
            cn3 = obj1.conectarDB(ref msj);
            salida = obj1.ModificarDBseguro(eliminacion, cn3, ref msj, listEnt);
            return salida;
        }
        public Boolean ActualizarAulas(Aulas nuevo, ref string msj)
        {
            Boolean salida = false;

            string actualizacion = "UPDATE aulas SET NombAULA=@NombreAula, Descripcion=@Descripcion, EdificioID=@EdificioId WHERE idAula=@IdAula";
            List<MySqlParameter> listap = new List<MySqlParameter>();

            listap.Add(new MySqlParameter("IdAula", MySqlDbType.Int32));
            listap.Add(new MySqlParameter("NombreAula", MySqlDbType.VarChar, 40));
            listap.Add(new MySqlParameter("Descripcion", MySqlDbType.VarChar, 255));
            listap.Add(new MySqlParameter("EdificioId", MySqlDbType.Int32));

            //asignacion de valores a los parametros que ya estan en la lista
            listap[0].Value = nuevo.IdAula;
            listap[1].Value = nuevo.NombreAula;
            listap[2].Value = nuevo.Descripcion;
            listap[3].Value = nuevo.EdificioId;

            MySqlConnection cn3 = null;
            cn3 = obj1.conectarDB(ref msj);
            salida = obj1.ModificarDBseguro(actualizacion, cn3, ref msj, listap);
            return salida;
        }
    }
}
