using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.Constants.DbSettingConstants
{
    static public class BlogDbSettingsConstant
    {
        public const int BlogTitleLength = 150;
        public const bool BlogTitleIsRequired = true;
        public const bool BlogTitleIsUnicode = true;
        public static readonly string BlogTitleComment = "Blog başlığı 150 karakter sınırı var";

        public const int BlogContentLength = 3000;
        public const bool BlogContentIsRequired = true;
        public static readonly string BlogContentColumnType = "text";
        public static readonly string BlogContentComment = "blog gövdesi 3000 karakter sınırı var";

        public const bool BlogPublicationDateIsRequired = false;
        public static readonly string BlogPublicationDateColumnType = "timestamp with time zone";
        public static readonly string BlogPublicationDateComment = "isteğe bağlı yayınlanma tarihi";

        public const bool BlogIsPublishedIsRequired = true;
        public static readonly string BlogIsPublishedComment = "yayınlanma durumunu verir";

    }
}
