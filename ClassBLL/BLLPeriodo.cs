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
    public class BLLPeriodo
    {
        DALMysql obj1 = new DALMysql("Server=127.0.0.1; port=3306; DataBase=horarios; Uid=root; SSL Mode=None;");
        public List<Periodos> ListaPeriodo(ref string msj)
        {
            List<Periodos> lista = new List<Periodos>();
            MySqlDataReader contAtrapa = null;
            string consulta = "select * from periodos";
            MySqlConnection cn3 = null;
            cn3 = obj1.conectarDB(ref msj);
            contAtrapa = obj1.ConsultaDR(consulta, cn3, ref msj);
            if (contAtrapa != null && !contAtrapa.IsClosed)
            {
                while (contAtrapa.Read())
                {
                    lista.Add(new Periodos()
                    {
                        idPeriodo = (int)contAtrapa[0],
                        NombrePeriodo = contAtrapa[1].ToString(),
                        P_inicio = (DateTime)contAtrapa[2],
                        P_fin = (DateTime)contAtrapa[3],
                        Año = (int)contAtrapa[4],
                        Extra = contAtrapa[5].ToString(),
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
