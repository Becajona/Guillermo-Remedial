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
    public class BLLGrupo
    {
        DALMysql obj1 = new DALMysql("Server=127.0.0.1; port=3306; DataBase=horarios; Uid=root; SSL Mode=None;");

        public Boolean InsertaGrupo(Grupos nuevo, ref string msj)
        {
            Boolean salida = false;

            string insercion = "Insert into grupos(NomGrupo, Cuatrimestre, Turno, PeriodoID, AulaID, TutorID, EspecialidadID)" +
                " values(@NomGrupo, @Cuatrimestre, @Turno, @PeriodoID, @AulaID, @TutorID, @EspecialidadID);";
            List<MySqlParameter> listap = new List<MySqlParameter>();

            listap.Add(new MySqlParameter("NomGrupo", MySqlDbType.VarChar,2));
            listap.Add(new MySqlParameter("Cuatrimestre", MySqlDbType.Int32));
            listap.Add(new MySqlParameter("Turno", MySqlDbType.VarChar,80));
            listap.Add(new MySqlParameter("PeriodoID", MySqlDbType.Int32));
            listap.Add(new MySqlParameter("AulaID", MySqlDbType.Int32));
            listap.Add(new MySqlParameter("TutorID", MySqlDbType.Int32));
            listap.Add(new MySqlParameter("EspecialidadID", MySqlDbType.Int32));

            //asignacion de valores a los parametros que ya estan en la lista
            listap[0].Value = nuevo.NomGrupo;
            listap[1].Value = nuevo.Cuatrimestre;
            listap[2].Value = nuevo.Turno;
            listap[3].Value = nuevo.PeriodoID;
            listap[4].Value = nuevo.AulaID;
            listap[5].Value = nuevo.TutorID;
            listap[6].Value = nuevo.EspecialidadID;

            MySqlConnection cn3 = null;
            cn3 = obj1.conectarDB(ref msj);
            salida = obj1.ModificarDBseguro(insercion, cn3, ref msj, listap);
            return salida;
        }
        public DataTable MostrarGrupoTabla(ref string msj)
        {
            string consulta = "select * from grupos";
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
        public Boolean EliminarGrupoPorId(Grupos id, ref string msj)
        {
            Boolean salida = false;

            string eliminacion = "DELETE FROM grupos WHERE idgrupo = @IdEntrada";

            List<MySqlParameter> listEnt = new List<MySqlParameter>();
            listEnt.Add(new MySqlParameter("IdEntrada", MySqlDbType.Int32));
            listEnt[0].Value = id.Idgrupo;

            MySqlConnection cn3 = null;
            cn3 = obj1.conectarDB(ref msj);
            salida = obj1.ModificarDBseguro(eliminacion, cn3, ref msj, listEnt);
            return salida;
        }
        public Boolean ActualizarGrupos(Grupos nuevo, ref string msj)
        {
            Boolean salida = false;

            string actualizacion = "UPDATE grupos SET NomGrupo=@NomGrupo, Cuatrimestre=@Cuatrimestre, Turno=@Turno, PeriodoID=@PeriodoID, AulaID=@AulaID, TutorID=@TutorID, EspecialidadID=@EspecialidadID WHERE Idgrupo=@Idgrupo";
            List<MySqlParameter> listap = new List<MySqlParameter>();

            listap.Add(new MySqlParameter("Idgrupo", MySqlDbType.Int32));
            listap.Add(new MySqlParameter("NomGrupo", MySqlDbType.VarChar, 2));
            listap.Add(new MySqlParameter("Cuatrimestre", MySqlDbType.Int32));
            listap.Add(new MySqlParameter("Turno", MySqlDbType.VarChar,80));
            listap.Add(new MySqlParameter("PeriodoID", MySqlDbType.Int32));
            listap.Add(new MySqlParameter("AulaID", MySqlDbType.Int32));
            listap.Add(new MySqlParameter("TutorID", MySqlDbType.Int32));
            listap.Add(new MySqlParameter("EspecialidadID", MySqlDbType.Int32));

            //asignacion de valores a los parametros que ya estan en la lista
            listap[0].Value = nuevo.Idgrupo;
            listap[1].Value = nuevo.NomGrupo;
            listap[2].Value = nuevo.Cuatrimestre;
            listap[3].Value = nuevo.Turno;
            listap[4].Value = nuevo.PeriodoID;
            listap[5].Value = nuevo.AulaID;
            listap[6].Value = nuevo.TutorID;
            listap[7].Value = nuevo.EspecialidadID;

            MySqlConnection cn3 = null;
            cn3 = obj1.conectarDB(ref msj);
            salida = obj1.ModificarDBseguro(actualizacion, cn3, ref msj, listap);
            return salida;
        }
    }
}

