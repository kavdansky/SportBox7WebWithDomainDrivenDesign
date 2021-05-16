using System;
using System.Collections.Generic;
using System.Text;

namespace SportBox7.Domain.Models
{
    public class ModelConstants
    {
        public class Common
        {
            public const int MaxUrlLength = 2048;
            public const int MinUrlLength = 5;
            public const int Zero = 0;
            public const int MetatagsMinLength = 5;
            public const int MetatagsMaxLength = 60;
            public const int MinEmailLength = 3;
            public const int MaxEmailLength = 50;
            public const int MinNameLength = 3;
            public const int MaxNameLength = 50;
            public const string UrlRregularExpression = "[(http(s)?):\\/\\/(www\\.)?a-zA-Z0-9@:%._\\+~#=]{2,256}\\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\\+.~#?&//=]*)";
        }

        public class Article
        {
            public const int TitleMinLength = 5;
            public const int TitleMaxLength = 120;
            public const int BodyMinLength = 5;
            public const int BodyMaxLength = 11000;
            public const int H1MinLength = 5;
            public const int H1MaxLength = 120;
        }

        public class Editor
        {
            public const int NamesMinLength = 3;
            public const int NamesMaxLength = 50;
        }

        public class Source
        {
            public const int SourceNameMinLength = 3;
            public const int SourceNameMaxLength = 50;
        }

        public class Category
        {
            public const int NamesMinLength = 3;
            public const int NamesMaxLength = 50;
        }

        public class SocialSignal
        {
            public const int MinIpLength = 7;
            public const int MaxIpLength = 16;
        }
    }
}
