using System;
using System.Configuration;

namespace ConfigSection
{
    public enum Direction
    {
        Entry,
        Exit
    }
    public class CredentialsConfigElement : System.Configuration.ConfigurationElement
    {
        [ConfigurationProperty("Username")]
        public string Username
        {
            get
            {
                return base["Username"] as string;
            }
        }

        [ConfigurationProperty("Password")]
        public string Password
        {
            get
            {
                return base["Password"] as string;
            }
        }
    }

    public class ServerInfoConfigElement : ConfigurationElement
    {
        [ConfigurationProperty("Address")]
        public string Address
        {
            get
            {
                return base["Address"] as string;
            }
        }

        [ConfigurationProperty("Port")]
        public int? Port
        {
            get
            {
                return base["Port"] as int?;
            }
        }
    }

    public class LaneConfigElement : ConfigurationElement
    {
        [ConfigurationProperty("Id")]
        public string Id
        {
            get
            {
                return base["Id"] as string;
            }
        }

        [ConfigurationProperty("PointId")]
        public string PointId
        {
            get
            {
                return base["PointId"] as string;
            }
        }

        [ConfigurationProperty("Direction")]
        public Direction? Direction
        {
            get
            {
                return base["Direction"] as Direction?;
            }
        }
    }

    public class SiteConfigElement : ConfigurationElement
    {
        [ConfigurationProperty("Id")]
        public int Id
        {
            get { return int.Parse(base["Id"].ToString()); }
        }
    }



    [ConfigurationCollection(typeof(LaneConfigElement), AddItemName = "Lane", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class LaneConfigCollection : ConfigurationElementCollection
    {
        public LaneConfigElement this[int index]
        {
            get { return (LaneConfigElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public void Add(LaneConfigElement serviceConfig)
        {
            BaseAdd(serviceConfig);
        }

        public void Clear()
        {
            BaseClear();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new LaneConfigElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((LaneConfigElement)element).Id;
        }

        public void Remove(LaneConfigElement serviceConfig)
        {
            BaseRemove(serviceConfig.Id);
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(String name)
        {
            BaseRemove(name);
        }

    }

    public class CustomApplicationConfigSection : System.Configuration.ConfigurationSection
    {

        public const string SECTION_NAME = "CustomApplicationConfig";

        [ConfigurationProperty("Credentials")]
        public CredentialsConfigElement Credentials
        {
            get
            {
                return base["Credentials"] as CredentialsConfigElement;
            }
        }

        [ConfigurationProperty("PrimaryAgent")]
        public ServerInfoConfigElement PrimaryAgent
        {
            get
            {
                return base["PrimaryAgent"] as ServerInfoConfigElement;
            }
        }

        [ConfigurationProperty("SecondaryAgent")]
        public ServerInfoConfigElement SecondaryAgent
        {
            get
            {
                return base["SecondaryAgent"] as ServerInfoConfigElement;
            }
        }

        [ConfigurationProperty("Site")]
        public SiteConfigElement Site
        {
            get
            {
                return base["Site"] as SiteConfigElement;
            }
        }

        [ConfigurationProperty("Lanes")]
        public LaneConfigCollection Lanes
        {
            get { return base["Lanes"] as LaneConfigCollection; }
        }

        private static CustomApplicationConfigSection _instance;

        public static CustomApplicationConfigSection Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = System.Configuration.ConfigurationManager.GetSection(CustomApplicationConfigSection.SECTION_NAME) as CustomApplicationConfigSection;
                }

                return _instance;
            }
        }
    }

}