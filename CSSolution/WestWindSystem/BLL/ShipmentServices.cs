using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using WestWindSystem.DAL;
using WestWindSystem.Entities;
#endregion

namespace WestWindSystem.BLL
{
    public class ShipmentServices
    {
        #region setup of the connect connection variable and the class constructor

        private readonly WestWindContext _context;

        internal ShipmentServices(WestWindContext registeredcontext)
        {
            _context = registeredcontext;
        }
        #endregion

        #region Services
        //public List<Shipment> Shipment_GetByYearAndMonth(int year, int month)
        //{
        //    //it is possible to place validation of incoming parameters within your services
        //    //remember the services are independent of the outside user

        //    if(year < 1950 || year > DateTime.Today.Year)
        //    {
        //        throw new ArgumentException($"Invalid year {year}. Year must be between 1950 and today");
        //    }
        //    if (month < 1 || month > 12)
        //    {
        //        throw new ArgumentException($"Invalid month {month}. Month must be between 1 and 12");
        //    }
        //    IEnumerable<Shipment> info = _context.Shipments
        //                                        .Where(s => s.ShippedDate.Year == year
        //                                                && s.ShippedDate.Month == month)
        //                                         .OrderBy(s => s.ShippedDate);
        //    return info.ToList();
        //}


        //This uses the technique (b) discussed on the ShipmentTable page
        //note there is a required using class, see Additional namespaces above.
        //uses the .Include method to add navigational instances to the return record
        //note the predicate uses the virtual navigational property of the Shipment entity
        //This will include the associated record from the Shippers table (parent) for
        //      the shipment record (child)
        public List<Shipment> Shipment_GetByYearAndMonth(int year, int month)
        {
            //it is possible to place validation of incoming parameters within your services
            //remember the services are independent of the outside user

            if (year < 1950 || year > DateTime.Today.Year)
            {
                throw new ArgumentException($"Invalid year {year}. Year must be between 1950 and today");
            }
            if (month < 1 || month > 12)
            {
                throw new ArgumentException($"Invalid month {month}. Month must be between 1 and 12");
            }

            //use the Include to fuse the parent record for Shipment (Shipper record) to the Shipment record
            //  and returning the "join"
            //this is a child to parent join!!!!!!!!!!!!!!!
            IEnumerable<Shipment> info = _context.Shipments
                                                .Include(s => s.ShipViaNavigation)
                                                .Where(s => s.ShippedDate.Year == year
                                                        && s.ShippedDate.Month == month)
                                                 .OrderBy(s => s.ShippedDate);
            return info.ToList();
        }
        #endregion
    }
}
