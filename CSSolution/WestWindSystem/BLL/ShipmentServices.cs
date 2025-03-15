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
        public List<Shipment> Shipment_GetByYearAndMonth(int year, int month)
        {
            IEnumerable<Shipment> info = _context.Shipments
                                                .Where(s => s.ShippedDate.Year == year
                                                        && s.ShippedDate.Month == month)
                                                 .OrderBy(s => s.ShippedDate);
            return info.ToList();
        }
        #endregion
    }
}
