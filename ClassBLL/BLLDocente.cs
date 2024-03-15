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
    public class BLLDocente
    {
        DALMysql obj1 = new DALMysql("Server=127.0.0.1; port=3306; DataBase=horarios; Uid=root; SSL Mode=None;");
        public List<Docentes> ListaDocente(ref string msj)
        {
            List<Docentes> lista = new List<Docentes>();
            MySqlDataReader contAtrapa = null;
            string consulta = "select * from docentes";
            MySqlConnection cn3 = null;
            cn3 = obj1.conectarDB(ref msj);
            contAtrapa = obj1.ConsultaDR(consulta, cn3, ref msj);
            if (contAtrapa != null && !contAtrapa.IsClosed)
            {
                while (contAtrapa.Read())
                {
                    lista.Add(new Docentes()
                    {
                        idDocente = (int)contAtrapa[0],
                        Nombre = contAtrapa[1].ToString(),
                        A_Paterno = contAtrapa[2].ToString(),
                        A_Materno = contAtrapa[3].ToString(),
                        Extra = contAtrapa[4].ToString(),
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
