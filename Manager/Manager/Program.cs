// See https://aka.ms/new-console-template for more information
using static System.Runtime.InteropServices.JavaScript.JSType;

Console.WriteLine("Hello, World!");
string connectionString = "Data Source=SRV2\\PUPILS; Initial Catalog = MyShop_214957326; Integrated Security = True; Encrypt = False";
DataProductAccess da = new DataProductAccess();
da.FillProduct(connectionString);
