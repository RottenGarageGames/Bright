namespace Classes
{
    public static class Extensions
    {
        public static void CopyFrom<T>(this T obj, T copyObject)
        {
            var properties = copyObject.GetType().GetProperties();

            foreach(var property in properties)
            {
                property.SetValue(obj, property.GetValue(copyObject));
            }
        }

        public static bool IsNullOrWhiteSpace(this string value)
        {
            var result = string.IsNullOrWhiteSpace(value);

            return result;
        }
    }
}
