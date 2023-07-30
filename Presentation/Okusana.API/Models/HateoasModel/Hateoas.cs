using Okusana.DTOs.Abstract;
using Okusana.Extensions;

namespace Okusana.API.Models.HateoasModel
{
    public partial record Hateoas
    {
        public readonly string Domain = "Okusana.com";

        private static class ConnectionType
        {
            static public readonly string Json = "Json";
            static public readonly string Xml = "Xml";
        }
        private static class Methods
        {
            static public readonly string Get = "Get";
            static public readonly string Delete = "Delete";
            static public readonly string Post = "Post";
            static public readonly string Put = "Put";
            static public readonly string Patch = "Patch";
        }

        private Dictionary<string, Dictionary<string, string>> MethodsGenerator(List<Type> Types)
        {
            Dictionary<string, Dictionary<string, string>> Methods = new Dictionary<string, Dictionary<string, string>>();
            foreach (Type type in Types)
            {
                if (typeof(IGetDTO).IsAssignableFrom(type))
                    Methods.Add(Hateoas.Methods.Get, type.GetPropertyDict());
                else if (typeof(IAddDTO).IsAssignableFrom(type))
                    Methods.Add(Hateoas.Methods.Post, type.GetPropertyDict());
                else if (typeof(IUpdateDTO).IsAssignableFrom(type))
                    Methods.Add(Hateoas.Methods.Put, type.GetPropertyDict());
                else if (typeof(IDeleteDTO).IsAssignableFrom(type))
                    Methods.Add(Hateoas.Methods.Delete, type.GetPropertyDict());
                else
                    Console.WriteLine("hateoas dict yapmada bilinmeyen bir cisim bulundu");
            }
            return Methods;
        }
    }
}
