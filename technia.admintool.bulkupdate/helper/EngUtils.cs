using ds.enovia.common.collection;
using ds.enovia.common.search;
using ds.enovia.dseng.mask;
using ds.enovia.dseng.model;
using ds.enovia.dseng.service;
using ds.enovia.dslc.model;
using ds.enovia.dslc.service;
using System.Dynamic;
using System.Reflection;
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

        public static async Task<(string, string)> UpdateEngItemAsync(EngineeringServices engServices, ExpandoObject record, EngineeringItem engItem)
        {
            var dict = ExpandoObjectUtils.GetDictionary(record);
            string title = EnoviaObject.GetTitle(dict);
            string rev = EnoviaObject.GetRevision(dict);

            try
            {
                var newEnterpriseAttrs = new Dictionary<string, object>();
                foreach (var key in dict.Keys)
                {
                    var value = dict[key];
                    PropertyInfo property = typeof(EngineeringItem).GetProperty(key);

                    //if csv column name is not found as direct properties of engItem like name,rev,desc,etc
                    //then we dive into enterpriseAttributes property and find that csv column in enterpriseAttributes property
                    if (property == null)
                    {
                        Dictionary<string, object> enterpriseAttrs = engItem.enterpriseAttributes;
                        string newEntrAttributesValue = "";
                        if (enterpriseAttrs.ContainsKey(key))
                        {
                            object entrAttributesValue = enterpriseAttrs[key];
                            Logger.Info($"old entrAttributesValue - {entrAttributesValue}");
                        }
                        newEnterpriseAttrs.Add(key, value);
                    }
                    else if (key.Equals("isManufacturable"))
                    {
                        engItem.isManufacturable = (bool)value;
                    }
                    else if (key.Equals("cestamp"))
                    {
                        // cestamp should be always new
                    }
                    else if (key.Equals("name"))
                    {
                        engItem.name = (string)value;
                    }
                    else if (key.Equals("title"))
                    {
                        engItem.title = (string)value;
                    }
                    else if (key.Equals("description"))
                    {
                        engItem.description = (string)value;
                    }
                    else if (key.Equals("id"))
                    {
                        // id remains as is
                    }
                    else if (key.Equals("type"))
                    {
                        // type remains as is
                    }
                    else if (key.Equals("modified"))
                    {
                        // engItem.modified = (string)value;
                        // do not change
                    }
                    else if (key.Equals("created"))
                    {
                        // engItem.created = (string)value;
                        // do not change
                    }
                    else if (key.Equals("revision"))
                    {
                        // engItem.revision = (string)value;
                        // do not change
                    }
                    else if (key.Equals("state"))
                    {
                        // engItem.state = (string)value;
                        // do not change
                    }
                    else if (key.Equals("owner"))
                    {
                        // engItem.owner = (string)value;
                        // do not change
                    }
                    else if (key.Equals("organization"))
                    {
                        engItem.organization = (string)value;
                    }
                    else if (key.Equals("collabspace"))
                    {
                        engItem.collabspace = (string)value;
                    }
                }

                engItem.enterpriseAttributes = newEnterpriseAttrs;

                Logger.Info($"Updating eng Item {title}-{rev} ...");
                EngineeringItem updatedEngItems = await engServices.UpdateEngineeringItem(engItem);
                var comment = "Updated eng Item";
                return (null, comment);
            }
            catch (Exception e)
            {
                Logger.Error($"Error while updating eng item attributes {title} : {e}");
                return (e.Message, "Updation of eng item failed");
            }
        }
    }
}
