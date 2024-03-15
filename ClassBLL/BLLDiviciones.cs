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
    public class BLLDiviciones
    {
        DALMysql obj1 = new DALMysql("Server=127.0.0.1; port=3306; DataBase=horarios; Uid=root; SSL Mode=None;");

        public List<Diviciones> ListaDivisiones(ref string msj)
        {
            List<Diviciones> lista = new List<Diviciones>();
            MySqlDataReader contAtrapa = null;
            string consulta = "select * from divisiones";
            MySqlConnection cn3 = null;
            cn3 = obj1.conectarDB(ref msj);
            contAtrapa = obj1.ConsultaDR(consulta, cn3, ref msj);
            if (contAtrapa != null && !contAtrapa.IsClosed)
            {
                while (contAtrapa.Read())
                {
                    lista.Add(new Diviciones()
                    {
                        idDivicion = (int)contAtrapa[0],
                        NombreDivicion = (string)contAtrapa[1].ToString(),
                        DescripcionDiv = (string)contAtrapa[2].ToString(),
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
