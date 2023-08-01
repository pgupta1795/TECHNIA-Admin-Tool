using ds.enovia.change;
using technia.admintool.settings;

namespace technia.admintool.bulkupdate.helper
{
    public static class ChangeUtils
    {
        public static async Task<(bool, string, string)> GetChangeControlAsync(ChangeControlServices changeControlServices, string id)
        {
            bool isChangeControlExists = false;
            try
            {
                string err = $"Could not fetch change control status for {id}";
                Logger.Info($"Fetching change control status for eng item {id} ...");
                var changeControlResult = await changeControlServices.GetChangeControl(id);
                var results = changeControlResult.member;
                if (results.Count == 0) throw new Exception(err);
                var status = results[0].changeControlStatus;
                if (status == ChangeControlStatus.NONE.ToString()) isChangeControlExists = false;
                else isChangeControlExists = true;
                var comment = $"Change control status is {status}";
                Logger.Info(comment);
                return (isChangeControlExists, null, comment);
            }
            catch (Exception e)
            {
                Logger.Error($"Error while Fetching change control status for eng item {id} as status is {isChangeControlExists}: {e}");
                return (isChangeControlExists, e.Message, "Could not get change control status");
            }
        }

        public static async Task<(string, string)> DeactivateChangeControlAsync(ChangeControlServices changeControlServices, string id)
        {
            try
            {
                string err = $"Could not removing change control status for {id}";
                Logger.Info($"Removing change control status for eng item {id} ...");
                var changeControlResult = await changeControlServices.DeactivateChangeControl(id);
                var objectListChangeControlled = changeControlResult.objectListChangeControlled;
                if (objectListChangeControlled.Count == 0) throw new Exception(err);
                var comment = $"Deactivated change control";
                Logger.Info(comment);
                return (null, comment);
            }
            catch (Exception e)
            {
                Logger.Error($"Error while removing change control status for eng item {id} : {e}");
                return (e.Message, "Could not deactivate change control status");
            }
        }
    }
}
