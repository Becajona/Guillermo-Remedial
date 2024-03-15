using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ClassDAL
{
    public class DALMysql
    {
        public string cadconex { get; set; }    

        public DALMysql(string cadenaconex)
        {
            cadconex = cadenaconex;
        }

        public MySqlConnection conectarDB(ref string msj)
        {
            MySqlConnection cn1 = new MySqlConnection();
            cn1.ConnectionString = cadconex;
            try
            {
                cn1.Open();
                msj = "Conexion Abierta";
            }
            catch (Exception e)
            {
                msj = " Error: " + e.Message;
                cn1 = null;
            }
            return cn1;
        }

        public Boolean ModificarDBseguro(string SentenciasSQL, MySqlConnection cnab1, ref string msj, List<MySqlParameter> parametros)// de no saber la cantidad de parametos se hace con un list
        {
            Boolean salida = false;
            if (cnab1 != null)
            {
                MySqlCommand carrito = new MySqlCommand();//recordar que una coleccion es un areglo de objetos
                carrito.CommandText = SentenciasSQL;// el comand es como un carrito 
                carrito.Connection = cnab1;
                //si hay parametros se le agregan al commad
                if (parametros != null)//si es una collecion susu elementos se pueden recorrer por un forech
                {
                    foreach (MySqlParameter p in parametros)
                    {
                        carrito.Parameters.Add(p);
                    }
                }
                try
                {
                    carrito.ExecuteNonQuery();
                    msj = "Modificacion fue exitosa";
                    salida = true;
                }
                catch (Exception e)
                {
                    msj = "Error de MySQL: " + e.Message;
                    salida = false;
                }
                cnab1.Close();
                cnab1.Dispose();
            }
            else
            {
                salida = false;
                msj = "No hay conexion a la DB";
            }
            return salida;
        }
        public MySqlDataReader ConsultaDR(string query, MySqlConnection cnab2, ref string msj2)
        {
            MySqlDataReader contenedorR = null;
            if (cnab2 != null)
            {//verificar conexion a la Db
                MySqlCommand Vocho = new MySqlCommand();
                Vocho.CommandText = query;
                Vocho.Connection = cnab2;
                try
                {
                    contenedorR = Vocho.ExecuteReader();
                    msj2 = "Consulta DR CORECCTA";
                }
                catch (Exception e)
                {
                    contenedorR = null;
                    msj2 = "Error: " + e.Message;

                }

            }
            else
            {
                contenedorR = null;
                msj2 = "No hay conexion a DB";
            }
            return contenedorR;
        }


        public DataSet ConsultaDataSet(string query, MySqlConnection cn4, ref string msj3)
        {
            DataSet dsSalida = null;
            MySqlCommand Carrito3 = null;
            MySqlDataAdapter trailer = null;

            if (cn4 != null)
            {
                Carrito3 = new MySqlCommand();
                Carrito3.CommandText = query;
                Carrito3.Connection = cn4;
                trailer = new MySqlDataAdapter();
                trailer.SelectCommand = Carrito3;
                dsSalida = new DataSet();
                try
                {
                    trailer.Fill(dsSalida);
                    msj3 = "Consulta con el dataset es correcta";


                }
                catch (Exception e)
                {
                    dsSalida = null;
                    msj3 = msj3 + "Error: " + e.Message;
                }
                cn4.Close();
                cn4.Dispose();

            }
            else
            {
                msj3 = msj3 + ", No hay conexion con la base de datos";
                dsSalida = null;
            }
            return dsSalida;
        }

        public Boolean MultiplesConsultasDS(DataSet ds1, string queryy, MySqlConnection cnan5, string Nombredt, ref string msj)
        {
            Boolean salida = false;
            MySqlCommand Carrito3 = null;
            MySqlDataAdapter trailer = null;
            if (cnan5 != null)
            {

                Carrito3 = new MySqlCommand();
                Carrito3.CommandText = queryy;
                Carrito3.Connection = cnan5;
                trailer = new MySqlDataAdapter();
                trailer.SelectCommand = Carrito3;

                try
                {
                    trailer.Fill(ds1, Nombredt);
                    salida = true;
                    msj = "Consulta con el dataset es correcta";


                }
                catch (Exception e)
                {
                    salida = false;
                    msj = msj + "Error: " + e.Message;
                }
                cnan5.Close();
                cnan5.Dispose();

            }
            else
            {
                msj = msj + ", No hay conexion con la base de datos";
                salida = false;
            }


            return salida;

        }
    }
}
