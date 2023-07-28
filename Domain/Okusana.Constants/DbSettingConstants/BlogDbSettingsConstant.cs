using Okusana.Constants.DbSettingConstants.Base;

namespace Okusana.Constants.DbSettingConstants
{
    static public class BlogDbSettingsConstant
    {
        public static readonly string NonGuid = DbSettingsConstant.NonGuid;

        public const bool BlogUserIdIsRequired = true;
        public const bool BlogSubCategoryIdIsRequired = true;

        public const int BlogTitleLength = 150;
        public const bool BlogTitleIsRequired = true;
        public const bool BlogTitleIsUnicode = true;

        public const int BlogContentLength = 3000;
        public const bool BlogContentIsRequired = true;

        public const bool BlogPublicationDateIsRequired = false;

        public const bool BlogIsPublishedIsRequired = true;

    }
}
