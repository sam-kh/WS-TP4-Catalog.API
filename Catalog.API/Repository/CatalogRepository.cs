using Catalog.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Repository
{
    public class CatalogRepository :ICatalogRepository
    {
        private readonly CatalogContext _dbContext;

        public CatalogRepository(CatalogContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<CatalogItem> GetCatalogItems()
        {
            return _dbContext.CatalogItems.ToList();
        }
        public CatalogItem GetCatalogItemByID(int catalogItemId)
        {
            return _dbContext.CatalogItems.Find(catalogItemId);
        }
        public void InsertCatalogItem(CatalogItem catalogItem)
        {
            _dbContext.Add(catalogItem);
            Save();
        }
        public void DeleteCatalogItem(int catalogItemId)
        {
            var catalogItem = _dbContext.CatalogItems.Find(catalogItemId);
            _dbContext.CatalogItems.Remove(catalogItem);
            Save();

        }
        public void UpdateCatalogItem(CatalogItem catalogItem)
        {
            _dbContext.Entry(catalogItem).State = EntityState.Modified;
            Save();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }

    }
}
