using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StoreProject.Library.Customer;
using System.Linq;
using StoreProject.Library;

namespace StoreProjectDB.DataModel
{
    public class ManagerRepository
    {
        /// <summary>
        /// Create field for context options that will be set using the context options from
        /// Program.cs -> Customer View -> right her
        /// </summary>
        private readonly DbContextOptions<danielGProj0DBContext> _contextOptions;


        /// <summary>
        /// Constructor with context options parameter that gets passed from Customer View
        /// </summary>
        public ManagerRepository(DbContextOptions<danielGProj0DBContext> contextOptions)
        {
            _contextOptions = contextOptions;
        }


        public List<Location> GetStores()
        {
            // Create Context
            using var context = new danielGProj0DBContext(_contextOptions);
            // Create DB object list of stores
            var dbStores = context.Stores.ToList();
            // Make DB list into Console Stores List
            var appStores = dbStores.Select(s => new Location(s.Location, s.Id)).ToList();

            return appStores;
        }

        public int GetNumberOfStores()
        {
            //Create Context
            using var context = new danielGProj0DBContext(_contextOptions);
            // Count the number of entries in the stores table
            var storeCount = context.Stores.Count();

            return storeCount;
        }

    }
}
