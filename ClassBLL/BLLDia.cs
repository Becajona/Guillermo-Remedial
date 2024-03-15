﻿using ClassDAL;
using ClassEntidadesHorario;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBLL
{
    public class BLLDia
    {
<<<<<<< HEAD
        DALMysql obj1 = new DALMysql("Server=127.0.0.1; port=3306; DataBase=hoarrios5b; Uid=root; SSL Mode=None;");
=======
        DALMysql obj1 = new DALMysql("Server=127.0.0.1; port=3306; DataBase=horarios; Uid=root; Pwd=zxcv1234;SSL Mode=None;");
>>>>>>> 80bfbab8a12e5e132fdb5e0fee0f091e2d160067
        public List<DiaSemana> ListaDia(ref string msj)
        {
            List<DiaSemana> lista = new List<DiaSemana>();
            MySqlDataReader contAtrapa = null;
            string consulta = "select * from diasemana";
            MySqlConnection cn3 = null;
            cn3 = obj1.conectarDB(ref msj);
            contAtrapa = obj1.ConsultaDR(consulta, cn3, ref msj);
            if (contAtrapa != null && !contAtrapa.IsClosed)
            {
                while (contAtrapa.Read())
                {
                    lista.Add(new DiaSemana()
                    {
                        iddia = (int)contAtrapa[0],
                        NomDia = (string)contAtrapa[1].ToString(),
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
