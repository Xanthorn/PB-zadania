using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using PS7.Models;

namespace PS7.DAL
{
    public class ProductXmlDB : IProductDB
    {
        XmlDocument db = new XmlDocument();
        string xmlDB_path;
        
        public ProductXmlDB(IConfiguration _configuration)
        {
            xmlDB_path = _configuration.GetValue<string>("AppSettings:XmlDB_path");
            LoadDB();
        }
        private void LoadDB()
        {
            db.Load(xmlDB_path);
        }
        private void SaveDB()
        {
            db.Save(xmlDB_path);
        }
        private Product XmlNode2Product(XmlNode node)
        {
            Product p = new Product();
            p.id = int.Parse(node.Attributes["id"].Value);
            p.name = node["name"].InnerText;
            p.price = decimal.Parse(node["price"].InnerText);
            return p;
        }
        private XmlElement Product2XmlElement(Product product)
        {
            XmlElement xmlElement = db.CreateElement("product");
            xmlElement.SetAttribute("id", product.id.ToString());
            XmlElement xmlName = db.CreateElement("name");
            xmlName.InnerText = product.name;
            XmlElement xmlPrice = db.CreateElement("price");
            xmlPrice.InnerText = product.price.ToString();

            xmlElement.AppendChild(xmlName);
            xmlElement.AppendChild(xmlPrice);

            return xmlElement;
        }
        private XmlNode GetXMLNode(int id)
        {
            XmlNodeList list = db.SelectNodes("/store/product[@id=" + id.ToString() +
           "]");
            XmlNode node = list[0];
            return node;
        }
        private int GetNewId()
        {
            XmlNode node = db.SelectSingleNode("/store/id");
            int id = int.Parse(node.InnerText);
            node.InnerText = (id + 1).ToString();
            return id;
        }
        public List<Product> List()
        {
            List<Product> productList = new List<Product>();
            XmlNodeList productXmlNodeList = db.SelectNodes("/store/product");

            foreach (XmlNode productXmlNode in productXmlNodeList)
            {
                productList.Add(XmlNode2Product(productXmlNode));
            }
            return productList;
        }
        
        public  Product Get(int id)
        {
            XmlNode node = null;
            XmlNodeList list = db.SelectNodes("/store/product[@id=" + id.ToString() +
           "]");
            node = list[0];
            Product product = XmlNode2Product(node);
            return product;
        }
        public void Update(Product product)
        {
            LoadDB();
            XmlNode node = GetXMLNode(product.id);
            node["name"].InnerText = product.name;
            node["price"].InnerText = product.price.ToString();
            SaveDB();
        }
        public void Delete(int id)
        {
            LoadDB();
            XmlNodeList XmlNodeList = db.SelectNodes("/store/product");
            for(int i = 0; i < XmlNodeList.Count; i++)
            {
                Product product = XmlNode2Product(XmlNodeList[i]);
                if (product.id == id)
                {
                    XmlNodeList[i].ParentNode.RemoveChild(XmlNodeList[i]);
                    break;
                }
            }
            SaveDB();
        }
        public void Add(Product product)
        {
            LoadDB();
            XmlNode productsNode = db.SelectSingleNode("/store");
            product.id = GetNewId();
            productsNode.AppendChild(Product2XmlElement(product));
            SaveDB();
        }
    }
}
