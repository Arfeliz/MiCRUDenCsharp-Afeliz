    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace CRUD.WindowsForm
{
   class BD
    {
        public static SqlConnection Conexion()
        {
            SqlConnection connection = new SqlConnection("SERVER=AFELIZ;DATABASE=RegistroEmpleados; Integrated Security=True");
            connection.Open();
            return connection;
        }
    }
}
