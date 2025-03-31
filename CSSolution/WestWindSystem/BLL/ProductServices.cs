
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Microsoft.EntityFrameworkCore; //needed for the .Include
using WestWindSystem.DAL;
using WestWindSystem.Entities;
#endregion

namespace WestWindSystem.BLL
{
    public class ProductServices
    {
        #region setup the context connection variable and class constructor
        private readonly WestWindContext _context;

        //constructor to be used in the creation of the instance of this class
        //the registered reference for the context connection (database connection)
        //  will be passed from the IServiceCollection registered services
        internal ProductServices(WestWindContext registeredcontext)
        {
            _context = registeredcontext;
        }
        #endregion

        //Queries

        public List<Product> Product_GetByCategoryID(int categoryid)
        {
            //IEnumerable<Product> info = _context.Products
            //                                    .Where(x => x.CategoryID == categoryid)
            //                                    .OrderBy(x => x.ProductName);
            //return info.ToList();

            //alternate
            List<Product> info = _context.Products
                                               .Where(x => x.CategoryID == categoryid)
                                               .OrderBy(x => x.ProductName)
                                               .ToList();
            return info;

        }

        //if you wish to use the Include technique to obtain the Supplier company name
        //public List<Product> Product_GetByCategoryID(int categoryid)
        //{

        //    List<Product> info = _context.Products
        //                                        .Include(x => x.Supplier)
        //                                       .Where(x => x.CategoryID == categoryid)
        //                                       .OrderBy(x => x.ProductName)
        //                                       .ToList();
        //    return info;
        //}

        //obtain the record from the database using the appropriate table and it's primary key
        public Product Product_GetByID(int productid)
        {
            return _context.Products
                           .Where(x => x.ProductID == productid)
                           .FirstOrDefault();

            //.Find checks for primary keys
            //return _context.Products.Find(productid);
        }

    }
}
