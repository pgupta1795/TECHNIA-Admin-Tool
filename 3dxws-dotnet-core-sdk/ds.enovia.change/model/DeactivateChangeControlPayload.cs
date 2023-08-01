namespace ds.enovia.change
{
    public class DeactivateChangeControlPayload
    {
        public DeactivateChangeControlPayload(string id)
        {
            this.ObjectsListForUnSetChangeControl = new List<string> { $"pid:{id}" };
        }
        public List<string> ObjectsListForUnSetChangeControl { get; set; }
    }
}
