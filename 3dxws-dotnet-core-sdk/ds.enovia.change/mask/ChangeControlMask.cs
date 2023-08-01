using System.ComponentModel;
using System.Reflection;

namespace ds.enovia.change
{
    public enum ChangeControlMask
    {
        [DefaultValue("dsmvlc:ChangeControlMask.Status")]
        Default
    }

    public static class ChangeMaskExtension
    {
        public static string GetString(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DefaultValueAttribute[] attributes = fi.GetCustomAttributes(typeof(DefaultValueAttribute), false) as DefaultValueAttribute[];

            if (attributes != null && attributes.Any())
                return ((string)attributes.First().Value);

            return value.ToString();
        }
    }
}
