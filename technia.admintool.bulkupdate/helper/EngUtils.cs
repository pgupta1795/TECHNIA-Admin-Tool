using ds.enovia.common.collection;
using ds.enovia.common.search;
using ds.enovia.dseng.mask;
using ds.enovia.dseng.model;
using ds.enovia.dseng.service;
using ds.enovia.dslc.model;
using ds.enovia.dslc.service;
using System.Dynamic;
using technia.admintool.settings;

namespace technia.admintool.bulkupdate.helper
{
    public static class EngUtils
    {
        public static async Task<(EngineeringItem, string, string)> GetEngItemDetailAsync(EngineeringServices engServices, ExpandoObject record)
        {
            var dict = ExpandoObjectUtils.GetDictionary(record);
            string title = EnoviaObject.GetTitle(dict);
            string rev = EnoviaObject.GetRevision(dict);
            try
            {
                string err = $"Could not find engineering item {title} - {rev}";
                SearchQuery searchQuery = new SearchByTitleRevision(title, rev);
                Logger.Info($"Fetching details of {title}-{rev} ...");
                List<NlsLabeledItemSet<EngineeringItem>> pages = await engServices.SearchAll(searchQuery, EngineeringSearchMask.Details, 1);

                if (pages.Count == 0) throw new Exception(err);
                NlsLabeledItemSet<EngineeringItem> page = pages[0];

                if (page.totalItems == 0) throw new Exception(err);
                EngineeringItem item = page.member[0];
                var comment = "Details Fetched";
                return (item, null, comment);
            }
            catch (Exception e)
            {
                Logger.Error($"Error while fetching details of engineering item {title} : {e}");
                return (new EngineeringItem(), e.Message, "Details Not Fetched");
            }
        }

        public static async Task<(string, string, string)> UnreserveEngItemAsync(CollaborativeLifecycleService collabServices, string id)
        {
            string reservedBy = "";
            IList<IPhysicalId> data = new List<IPhysicalId>();
            data.Add(new PhysicalId(id));
            Unreserve unreserve = new(data);

            try
            {
                string err = $"Could not reserve engineering item {id}";
                Logger.Info($"Unreserving eng item {id} ...");
                UnreserveResults unreserveResults = await collabServices.UnreserveObject(unreserve);
                IList<UnreservePayload> results = unreserveResults.results;
                if (results.Count == 0) throw new Exception(err);
                reservedBy = results[0].reservedBy;
                if (reservedBy != null) throw new Exception(err);
                var comment = "EngItem Unreserved";
                return (reservedBy, null, comment);
            }
            catch (Exception e)
            {
                Logger.Error($"Error while unreserving engineering item {id} from {reservedBy} : {e}");
                return (reservedBy, e.Message, "EngItem Could not be reserved");
            }
        }

        public static async Task<(string, string)> UpdateEngItemAsync(EngineeringServices engServices, ExpandoObject record, string id)
        {
            throw new NotImplementedException();
        }
    }
}
