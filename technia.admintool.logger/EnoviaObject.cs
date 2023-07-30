namespace technia.admintool.settings
{
    public static class EnoviaObject
    {
        public static string GetTitle(IDictionary<string, object> dict)
        {
            return (string)dict["title"];
        }

        public static string GetRevision(IDictionary<string, object> dict)
        {
            return (string)dict["revision"];
        }
    }
}
