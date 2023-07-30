using ds.enovia.common.collection;
using ds.enovia.common.model;
using ds.enovia.common.search;
using ds.enovia.dseng.mask;
using ds.enovia.dseng.model;
using ds.enovia.dseng.service;
using System.Dynamic;
using technia.admintool.settings;

namespace technia.admintool.bulkupdate.helper
{
    public static class EngUtils
    {
        public static async Task<(Item, string)> GetEngItemDetailAsync(EngineeringServices engServices, ExpandoObject record)
        {
            var dict = ExpandoObjectUtils.GetDictionary(record);
            string title = EnoviaObject.GetTitle(dict);
            string rev = EnoviaObject.GetRevision(dict);
            try
            {
                string err = $"Could not find engineering item {title} - {rev}";
                SearchQuery searchQuery = new SearchByTitleRevision(title, rev);
                Logger.Info($"Fetching details of ${title}-${rev} ...");
                List<NlsLabeledItemSet<EngineeringItem>> pages = await engServices.SearchAll(searchQuery, EngineeringSearchMask.Details, 1);

                if (pages.Count == 0) throw new Exception(err);
                NlsLabeledItemSet<EngineeringItem> page = pages[0];

                if (page.totalItems == 0) throw new Exception(err);
                Item item = page.member[0];
                return (item, null);
            }
            catch (Exception e)
            {
                Logger.Error($"Error while fetching details of engineering item {title} : {e}");
                return (new Item(), e.Message);
            }
        }
    }
}
