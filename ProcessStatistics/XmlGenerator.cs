using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;

namespace ProcessStatistics
{
    public static class XmlGenerator
    {
        public static XDocument GenerateXml(List<object> data)
        {
            XElement root = new XElement($"data");

            foreach (var item in data)
            {

                Type instanceType = item.GetType();
                XElement node = new XElement("instance");

                foreach(PropertyInfo info in instanceType.GetProperties())
                {


                  node.Add(new XElement(info.Name, info.GetValue(item)));
                }

            }

            return new XDocument(root);
        }
    }
}
