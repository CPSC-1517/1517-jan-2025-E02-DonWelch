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
    public class ShipperServices
    {
        #region setup of the connect connection variable and the class constructor

        private readonly WestWindContext _context;

        internal ShipperServices(WestWindContext registeredcontext)
        {
            _context = registeredcontext;
        }
        #endregion

        #region Services
        public List<Shipper> Shipper_GetAll()
        {
            //get data from dbset set (ala sql table)
            IEnumerable<Shipper> info = _context.Shippers;

            //return the data as a List<T>
            //convert from IEnumberable<T> to List<T>
            return info.ToList();
        }
        #endregion
    }
}
