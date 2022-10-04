using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Capa_entidad;
using System.Configuration;

namespace Capa_datos
{
    public class clasedatos
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        public DataTable D_listar_clientes()
        {
            SqlCommand cmd = new SqlCommand("pc_listar_libros", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        public DataTable D_buscar_clientes(claseentidad obje)
        {
            SqlCommand cmd = new SqlCommand("pc_buscar_libros", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@titulo", obje.titulo);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public String D_mantenimiento_clientes(claseentidad obje)
        {
            String accion = "";
            SqlCommand cmd = new SqlCommand("pc_mantenimiento_libros", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("codigo", obje.codigo);
            cmd.Parameters.AddWithValue("titulo", obje.titulo);
            cmd.Parameters.AddWithValue("autor", obje.autor);
            cmd.Parameters.AddWithValue("editorial", obje.editorial);
            cmd.Parameters.AddWithValue("precio", obje.precio);

            cmd.Parameters.Add("@accion", SqlDbType.VarChar, 50).Value = obje.accion;
            cmd.Parameters["@accion"].Direction = ParameterDirection.InputOutput;
            cmd.Parameters.AddWithValue("cantidad", obje.cantidad);
            

            if (cn.State == ConnectionState.Open) cn.Close();
            cn.Open();
            cmd.ExecuteNonQuery();
            accion = cmd.Parameters["@accion"].Value.ToString();
            cn.Close();
            return accion; 
        }


    }
}
