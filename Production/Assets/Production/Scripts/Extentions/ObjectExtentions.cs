using Newtonsoft.Json;

namespace Avramov.Production
{
    public static class ObjectExtentions
    {
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
