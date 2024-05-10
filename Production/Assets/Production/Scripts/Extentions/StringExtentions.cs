using Unity.Plastic.Newtonsoft.Json;

namespace Avramov.Production
{
    public static class StringExtentions
    {
        public static T FromJson<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
