using Newtonsoft.Json;

namespace Okusana.Extensions
{
    static public class JsonExtension
    {
        static public string ToJson<T>(this T obj) => JsonConvert.SerializeObject(obj);
        static public T FromString<T>(this string str) where T : class, new() => JsonConvert.DeserializeObject<T>(str) ?? new T();
    }
}
