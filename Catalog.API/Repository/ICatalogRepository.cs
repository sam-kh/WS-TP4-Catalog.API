using Catalog.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Repository
{
    public interface ICatalogRepository
    {
        public IEnumerable<CatalogItem> GetCatalogItems();
        public CatalogItem GetCatalogItemByID(int product);
        public void InsertCatalogItem(CatalogItem catalogItem);
        public void DeleteCatalogItem(int catalogItemId);
        public void UpdateCatalogItem(CatalogItem catalogItem);
        public void Save();
    }
}
