namespace technia.admintool.settings
{
    public static class ArrayImplUtils
    {
        public static T[] AddElementAtFirst<T>(T[] arr, T value)
        {
            T[] newArray = new T[arr.Length + 1];
            newArray[0] = value;
            for (int i = 0; i < arr.Length; i++)
            {
                newArray[i + 1] = arr[i];
            }
            return newArray;
        }
    }
}
