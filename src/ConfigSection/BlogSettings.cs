using System;
using System.Configuration;


namespace ConfigSection
{
    public class BlogSettings : ConfigurationSection
    {
        private static BlogSettings _settings;

        public static BlogSettings Settings => _settings ?? (_settings = ConfigurationManager.GetSection("BlogSettings") as BlogSettings);

        [ConfigurationProperty("frontPagePostCount"
          , DefaultValue = 20
          , IsRequired = false)]
        //[IntegerValidator(MinValue = 1
        //  , MaxValue = 100)]
        public int FrontPagePostCount
        {
            get { return (int)this["frontPagePostCount"]; }
            set { this["frontPagePostCount"] = value; }
        }


        [ConfigurationProperty("title"
          , IsRequired = true)]
        //[StringValidator(InvalidCharacters = "  ~!@#$%^&*()[]{}/;’\"|\\"
        //  , MinLength = 1
        //  , MaxLength = 256)]
        public string Title
        {
            get { return (string)this["title"]; }
            set { this["title"] = value; }
        }
    }
}