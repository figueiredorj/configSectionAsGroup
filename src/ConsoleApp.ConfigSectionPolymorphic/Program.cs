using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigSection;
using Infineon.DataAnalysis.eSquare.Server.DataColumnExtractor.Configuration;

namespace ConsoleApp.ConfigSectionPolymorphic
{
    class Program
    {
        static void Main(string[] args)
        {
            var title = BlogSettings.Settings.Title;
            var frontPagePostCount = BlogSettings.Settings.FrontPagePostCount;

            CustomApplicationConfigSection config = CustomApplicationConfigSection.Instance;

            var extractor = DataExtractorConfigSection.Instance;
            var sql = extractor.SqlDataExtractorConfiguration;

            //var instance = DocumentInstances.Instance;

            //var duplicated = CustomConfigSection.DuplicatedConfigInstance;
            //var original = CustomConfigSection.OriginalConfigInstance;
        }
    }
}
