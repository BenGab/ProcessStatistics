using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace ProcessStatistics
{
    public static class XmlGenerator
    {
        public static XDocument GenerateXml(ICollection<ProcessStatistics> data)
        {
            XElement root = new XElement("processes");

            foreach (var item in data)
            {
                XElement processElement = new XElement("process");
                processElement.Add(new XElement("name",item.Name));
                processElement.Add(new XElement("instancecount", item.InstanceCount));
                processElement.Add(new XElement("allmemory", item.AllMemory));

                root.Add(processElement);
            }

            return new XDocument(root);
        }
    }
}
