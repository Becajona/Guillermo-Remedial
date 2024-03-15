using ClassDAL;
using ClassEntidadesHorario;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBLL
{
    public class BLLAsignacion
    {
        DALMysql obj1 = new DALMysql("Server=127.0.0.1; port=3306; DataBase=horarios; Uid=root; SSL Mode=None;");
        public List<AsignacionCuatrimestral> ListaAsignacion(ref string msj)
        {
            List<AsignacionCuatrimestral> lista = new List<AsignacionCuatrimestral>();
            MySqlDataReader contAtrapa = null;
            string consulta = "select * from asignacioncuatrimestral";
            MySqlConnection cn3 = null;
            cn3 = obj1.conectarDB(ref msj);
            contAtrapa = obj1.ConsultaDR(consulta, cn3, ref msj);
            if (contAtrapa != null && !contAtrapa.IsClosed)
            {
                while (contAtrapa.Read())
                {
                    lista.Add(new AsignacionCuatrimestral()
                    {
                        idAsignacion = (int)contAtrapa[0],
                        GrupoID = (int)contAtrapa[1],
                        DocenteID = (int)contAtrapa[2],
                        AsignaturaId = (int)contAtrapa[3],
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
