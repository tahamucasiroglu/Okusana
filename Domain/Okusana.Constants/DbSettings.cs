namespace Okusana.Constants
{
    static public class DbSettings //partial yapabilirsin sonra ama kısa gerekte yok gibi gerçi uzarda ilerde bakarsın
    {
        static public readonly string NonGuidMessage = "Id tipi Uyumsuz";
        static public class Blog
        {
            static public class UserId { public const bool Required = true; }
            static public class SubCategoryId { public const bool Required = true; }

            static public class Title
            {
                public const int Length = 150;
                public const bool Required = true;
            }

            static public class Content
            {
                public const int Length = 3000;
                public const bool Required = true;
            }
            static public class PublicationDate { public const bool Required = false; }
            static public class IsPublished { public const bool Required = true; }
        }

        static public class BlogTag
        {
            static public class BlogId { public const bool Required = true; }
            static public class HashTagId { public const bool Required = true; }
        }

        static public class Category
        {
            static public class Name
            {
                public const int Length = 50;
                public const bool Required = true;
            }
            static public class Description
            {
                public const int Length = 150;
                public const bool Required = false;
            }
        }

        static public class Comment
        {
            static public class UserId { public const bool Required = true; }
            static public class BlogId { public const bool Required = true; }
            static public class Content
            {
                public const bool Required = true;
                public const int Length = 250;
            }
            static public class Rate
            {
                public const bool Required = true;
                public const int Min = 0;
                public const int Max = 5;
            }
        }

        static public class HashTag
        {
            static public class Name
            {
                public const bool Required = true;
                public const int Length = 50;
            }
        }

        static public class SubCategory
        {
            static public class CategoryId { public const bool Required = true; }
            static public class Name
            {
                public const bool Required = true;
                public const int Length = 50;
            }
            static public class Describtion
            {
                public const bool Required = false;
                public const int Length = 150;
            }
        }

        static public class User
        {
            static public class Name
            {
                public const bool Required = true;
                public const int Length = 100;
            }
            static public class Surname
            {
                public const bool Required = true;
                public const int Length = 100;
            }
            static public class Email
            {
                public const bool Required = true;
                public const int Length = 100;
            }
            static public class Phone
            {
                public const bool Required = false;
                public const int Length = 10;
            }
            static public class Identity
            {
                public const bool Required = false;
                public const int Length = 11;
            }
            static public class BirthDate
            {
                public const bool Required = true;
            }
            static public class Gender
            {
                public const bool Required = false;
            }
            static public class Password
            {
                public const bool Required = true;
                public const int Length = 64;
            }
            static public class Status
            {
                public const bool Required = true;
                public const int Length = 10;
            }
        }


    }
}
