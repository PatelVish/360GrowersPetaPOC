using _360GrowersPetaPOC.Extentions;
using PetaExample;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360GrowersPetaPOC
{
    class Program
    {
        static void Main(string[] args)
        {
            // Option 2: Look for *Vishal* in solution
            using (var db = new Database("PetaExample"))
            // Option: 1
            //comment above line and uncomment below 2 lines for fixing https://github.com/CollaboratingPlatypus/PetaPoco/issues/201 
            //var connectionString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            //using (var db = new Database(connectionString, new CustomSqlServerDatabaseProvider()))
            {
                //try
                //{
                //    var result = db.Query<ADM_CustomerSupplier> ("select top 10 * from ADM_CustomerSupplier").ToList();

                //    result.ForEach(PrintResults);
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.Message);
                //}


                //try to insert one
                var person = new ADM_CustomerSupplier
                {
                    FirstName = "VishalTest",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsDeleted = false,
                    IPAddress = "127.0.0.1",
                };

                // Tell PetaPoco to insert it
                var id = db.Insert(person);
            }

            Console.ReadKey();
        }

        private static void PrintResults(ADM_CustomerSupplier customerSupplier)
        {
            Console.WriteLine("{0} {1} {2} {3} {4}", customerSupplier.FirstName, customerSupplier.LastName, customerSupplier.Company, customerSupplier.DOB, customerSupplier.Email);
        }
    }
}
