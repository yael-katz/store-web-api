
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
// See https://aka.ms/new-console-template for more information

internal class DataProductAccess
{
    public void fillDataSet(string connectionString)
    {
       
    }
    private static void CreateCommand(string quaryString,string connectionString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(quaryString,connection);
            command.Connection.Open();
            command.ExecuteNonQuery();
        }
    }
    static public void AddProduct(string product_name, int price,string description,int category_id)
    {


    }

    public int Insert(string connectionString)
    {
        Console.WriteLine("Insert product name ");
        string productName = Console.ReadLine();
        Console.WriteLine("Insert category id ");
        string categoryId = Console.ReadLine();
        Console.WriteLine("Insert product price ");
        string productPrice = Console.ReadLine();
        Console.WriteLine("Insert product description ");
        string productDescription = Console.ReadLine();
        string query = "INSERT INTO PRODUCT(PRODUCT_NAME, PRICE, CATEGORY_ID, DESCRIPTION)" +
                       "VALUES (@PRODUCT_NAME, @PRICE, @CATEGORY_ID, @DESCRIPTION)";

        using (SqlConnection cn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, cn))
        { cn.Open();
            cmd.Parameters.Add("@PRODUCT_NAME", SqlDbType.VarChar).Value = productName;
            cmd.Parameters.Add("@PRICE", SqlDbType.VarChar).Value = productPrice;
            cmd.Parameters.Add("@CATEGORY_ID", SqlDbType.VarChar).Value = categoryId;
            cmd.Parameters.Add("@DESCRIPTION", SqlDbType.VarChar).Value = productDescription;
            int rowsEffected = cmd.ExecuteNonQuery();
            cn.Close();
            return rowsEffected;
        }

    }
    public void ReadProductData(string connectionString)
    {
        string query = "SELECT * FROM PRODUCT";
        using (SqlConnection cn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(query, cn);
            try
            {
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}",
                        reader[0], reader[1], reader[2], reader[3], reader[4]);
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            Console.ReadLine();
        }
    }
    public void FillProduct(string connectionString)
    {
        string yesOrNo = "y";

        int countRows = Insert(connectionString);
        Console.WriteLine( "Doyou want to continue? y/n");
        yesOrNo = Console.ReadLine();
        while(yesOrNo.Equals("y"))
        {
            countRows += Insert(connectionString);
            Console.WriteLine("Doyou want to continue? y/n");
            yesOrNo = Console.ReadLine();

        }
        Console.WriteLine(countRows +"  rows effected");
        ReadProductData(connectionString);
    }

}