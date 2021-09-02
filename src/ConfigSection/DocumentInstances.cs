using System;
using System.Configuration;

namespace ConfigSection
{

    public class DocumentInstances : ConfigurationSectionGroup
    {
        private static DocumentInstances _instance;

        public static DocumentInstances Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DocumentInstances();
                    
                }

                return _instance;
            }
        }



        private DocumentInstances()
        {

        }


    }

    [Serializable]
    public class BaseConfigInstance : ConfigurationElement
    {
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            // Return the value of the 'name' attribute as a string
            get => (string)base["name"];
            // Set the value of the 'name' attribute
            set => base["name"] = value;
        }


    }
    [Serializable]
    public class OriginalInstance : BaseConfigInstance
    {
        [ConfigurationProperty("original", IsKey = false, IsRequired = false)]
        public string OriginalValue
        {
            get => (string)base["original"];
            set => base["original"] = value;
        }
    }
    [Serializable]
    public class DuplicatedInstance : BaseConfigInstance
    {
        [ConfigurationProperty("duplicated", IsKey = false, IsRequired = false)]
        public string DuplicatedValue
        {
            // Return the value of the 'name' attribute as a string
            get => (string)base["duplicated"];
            // Set the value of the 'name' attribute
            set => base["duplicated"] = value;
        }
    }
}
