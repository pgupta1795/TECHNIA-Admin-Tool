using ds.authentication;
using ds.enovia.service;
using System.Net.Http.Json;
using System.Text.Json;

namespace ds.enovia.change
{
    public class ChangeControlServices : EnoviaBaseService
    {
        private const string BASE_RESOURCE = "/resources/v1/modeler/dseng/dseng:EngItem";
        private const string CHANGE_CONTROL = "/dslc:changeControl";
        private const string DEACTIVATE_CHANGE_CONTROL = "/resources/modeler/change/changecontrol";

        public string GetBaseResource()
        {
            return BASE_RESOURCE;
        }

        public ChangeControlServices(string _enoviaService, IPassportAuthentication passport) : base(_enoviaService, passport)
        {

        }

        public async Task<GetChangeControlResult> GetChangeControl(string _itemId, ChangeControlMask _mask = ChangeControlMask.Default)
        {
            string changeControlUrl = string.Format("{0}/{1}{2}", GetBaseResource(), _itemId, CHANGE_CONTROL);
            Dictionary<string, string> queryParams = new()
            {
                { "$mask", _mask.GetString() }
            };
            HttpResponseMessage requestResponse = await GetAsync(changeControlUrl, queryParams);

            if (requestResponse.StatusCode != System.Net.HttpStatusCode.OK)
                throw (new ChangeControlException(requestResponse));
            return await requestResponse.Content.ReadFromJsonAsync<GetChangeControlResult>();
        }

        public async Task<DeactivateChangeControlResult> DeactivateChangeControl(string _itemId)
        {
            DeactivateChangeControlPayload ccPayload = new(_itemId);
            string payload = JsonSerializer.Serialize(ccPayload);

            // string changeControlUrl = string.Format("{0}/{1}{2}", GetBaseResource(), _itemId, CHANGE_CONTROL);
            HttpResponseMessage requestResponse = await PutAsync(DEACTIVATE_CHANGE_CONTROL, null, null, payload);

            if (requestResponse.StatusCode != System.Net.HttpStatusCode.OK)
                throw new ChangeControlException(requestResponse);
            return await requestResponse.Content.ReadFromJsonAsync<DeactivateChangeControlResult>();
        }
    }
}
