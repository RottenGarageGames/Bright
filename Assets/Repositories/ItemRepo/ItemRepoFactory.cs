using ItemRepository.CSV;
using ItemRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assets.Repositories.RepoEnums;

namespace Assets.Repositories.ItemRepo
{
    public static class ItemRepoFactory
    {
        public static IItemRepository GetItemRepo()
        {
            //Probably not necessary, but I'm practicing with multiple data sources for fun. Could probably switch to only return the data source we decide to go with

            var dataSource = DataSource.JSON;

            switch (dataSource)
            {
                case DataSource.CSV:
                {
                   return new CSVRepository();
                }
                case DataSource.JSON:
                {
                   return new JsonItemRepository();  
                }
                default:
                {
                    throw new Exception("Invalid Data Type: Current supported types are Json and CSV");
                }
            }
        }
    }
}
