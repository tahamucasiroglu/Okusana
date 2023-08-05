using Okusana.Abstract.Models.HateoasModel;

namespace Okusana.Models.HateoasModel
{
   
    public partial record Hateoas : IHateoas
    {
        public readonly string Domain = "Okusana.com";

        public Dictionary<string, List<string>> Links { get
            {
                Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
                foreach (var item in new Blog().Links) dict.Add(item.Key, item.Value);
                foreach (var item in new BlogTag().Links) dict.Add(item.Key, item.Value);
                foreach (var item in new Category().Links) dict.Add(item.Key, item.Value);
                foreach (var item in new Comment().Links) dict.Add(item.Key, item.Value);
                foreach (var item in new HashTag().Links) dict.Add(item.Key, item.Value);
                foreach (var item in new SubCategory().Links) dict.Add(item.Key, item.Value);
                foreach (var item in new User().Links) dict.Add(item.Key, item.Value);
                return dict;
            }}

        Dictionary<string, Dictionary<string, string>> IHateoas.Methods { get
            {
                Dictionary<string, Dictionary<string, string>> dict = new Dictionary<string, Dictionary<string, string>>();
                foreach (var item in new Blog().Methods) dict.Add(item.Key, item.Value);
                foreach (var item in new BlogTag().Methods) dict.Add(item.Key, item.Value);
                foreach (var item in new Category().Methods) dict.Add(item.Key, item.Value);
                foreach (var item in new Comment().Methods) dict.Add(item.Key, item.Value);
                foreach (var item in new HashTag().Methods) dict.Add(item.Key, item.Value);
                foreach (var item in new SubCategory().Methods) dict.Add(item.Key, item.Value);
                foreach (var item in new User().Methods) dict.Add(item.Key, item.Value);
                return dict;
            }
        }

        private class ConnectionType
        {
            static public readonly string Json = "Json";
            static public readonly string Xml = "Xml";
        }
        private class Methods
        {
            static public readonly string Get = "Get";
            static public readonly string Delete = "Delete";
            static public readonly string Post = "Post";
            static public readonly string Put = "Put";
            static public readonly string Patch = "Patch";
        }

        //private Dictionary<string, Dictionary<string, string>> MethodsGenerator(List<Type> Types)
        //{
        //    Dictionary<string, Dictionary<string, string>> Methods = new Dictionary<string, Dictionary<string, string>>();
        //    foreach (Type type in Types)
        //    {
        //        if (typeof(IGetDTO).IsAssignableFrom(type))
        //            Methods.Add(Hateoas.Methods.Get, type.GetPropertyDict());
        //        else if (typeof(IAddDTO).IsAssignableFrom(type))
        //            Methods.Add(Hateoas.Methods.Post, type.GetPropertyDict());
        //        else if (typeof(IUpdateDTO).IsAssignableFrom(type))
        //            Methods.Add(Hateoas.Methods.Put, type.GetPropertyDict());
        //        else if (typeof(IDeleteDTO).IsAssignableFrom(type))
        //            Methods.Add(Hateoas.Methods.Delete, type.GetPropertyDict());
        //        else
        //            Console.WriteLine("hateoas dict yapmada bilinmeyen bir cisim bulundu");
        //    }
        //    return Methods;
        //}
    }
}
