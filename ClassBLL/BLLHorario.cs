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
    public class BLLHorario
    {
        DALMysql obj1 = new DALMysql("Server=127.0.0.1; port=3306; DataBase=hoarrios5b; Uid=root; SSL Mode=None;");

        public Boolean InsertaHorario(Horario nuevo, ref string msj)
        {
            Boolean salida = false;

            string insercion = "Insert into horario(AsignacionID, DiaID, HrInicio, HrFinal, AulaID)" +
                " values(@AsignacionID, @DiaID, @HrInicio, @HrFinal, @AulaID);";
            List<MySqlParameter> listap = new List<MySqlParameter>();

            listap.Add(new MySqlParameter("AsignacionID", MySqlDbType.Int32));
            listap.Add(new MySqlParameter("DiaID", MySqlDbType.Int32));
            listap.Add(new MySqlParameter("HrInicio", MySqlDbType.Time));
            listap.Add(new MySqlParameter("HrFinal", MySqlDbType.Time));
            listap.Add(new MySqlParameter("AulaID", MySqlDbType.Int32));
            //asignacion de valores a los parametros que ya estan en la lista
            listap[0].Value = nuevo.AsignacionID;
            listap[1].Value = nuevo.DiaID;
            listap[2].Value = nuevo.HrInicio;
            listap[3].Value = nuevo.HrFinal;
            listap[4].Value = nuevo.AulaID;

            MySqlConnection cn3 = null;
            cn3 = obj1.conectarDB(ref msj);
            salida = obj1.ModificarDBseguro(insercion, cn3, ref msj, listap);
            return salida;
        }
        public DataTable MostrarHorarioTabla(ref string msj)
        {
            string consulta = "select * from horario";
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
        public Boolean EliminarHorarioPorId(Horario id, ref string msj)
        {
            Boolean salida = false;

            string eliminacion = "DELETE FROM horario WHERE idHorario = @IdEntrada";

            List<MySqlParameter> listEnt = new List<MySqlParameter>();
            listEnt.Add(new MySqlParameter("IdEntrada", MySqlDbType.Int32));
            listEnt[0].Value = id.idHorario;

            MySqlConnection cn3 = null;
            cn3 = obj1.conectarDB(ref msj);
            salida = obj1.ModificarDBseguro(eliminacion, cn3, ref msj, listEnt);
            return salida;
        }
        public Boolean ActualizarHorario(Horario nuevo, ref string msj)
        {
            Boolean salida = false;

            string actualizacion = "UPDATE horario SET AsignacionID=@AsignacionID, DiaID=@DiaID, HrInicio=@HrInicio, HrFinal=@HrFinal, AulaID=@AulaID WHERE idHorario=@IdEntrada";
            List<MySqlParameter> listap = new List<MySqlParameter>();

            listap.Add(new MySqlParameter("IdEntrada", MySqlDbType.Int32));
            listap.Add(new MySqlParameter("AsignacionID", MySqlDbType.Int32));
            listap.Add(new MySqlParameter("DiaID", MySqlDbType.Int32));
            listap.Add(new MySqlParameter("HrInicio", MySqlDbType.Time));
            listap.Add(new MySqlParameter("HrFinal", MySqlDbType.Time));
            listap.Add(new MySqlParameter("AulaID", MySqlDbType.Int32));

            //asignacion de valores a los parametros que ya estan en la lista
            listap[0].Value = nuevo.idHorario;
            listap[1].Value = nuevo.AsignacionID;
            listap[2].Value = nuevo.DiaID;
            listap[3].Value = nuevo.HrInicio;
            listap[4].Value = nuevo.HrFinal;
            listap[5].Value = nuevo.AulaID;

            MySqlConnection cn3 = null;
            cn3 = obj1.conectarDB(ref msj);
            salida = obj1.ModificarDBseguro(actualizacion, cn3, ref msj, listap);
            return salida;
        }
    }
}
