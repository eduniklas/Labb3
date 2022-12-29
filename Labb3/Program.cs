
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Labb3.Menu;
using Labb3.RetrieveData;

namespace Labb3
{
    public class Program
    {   
        static void Main(string[] args)
        {
            var myMenu = new MainMenu();
            myMenu.Start();
        }
    }
}