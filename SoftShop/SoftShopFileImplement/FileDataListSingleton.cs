﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using SoftShopBusinessLogic.Enums;
using SoftShopListImplement.Models;
using System.Linq;
namespace SoftShopListImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;
        private readonly string SoftFileName = "C:\\Users\\masha\\source\\Semestr2\\SoftShop\\Soft.xml";
        private readonly string OrderFileName = "C:\\Users\\masha\\source\\Semestr2\\SoftShop\\Order.xml";
        private readonly string PackFileName = "C:\\Users\\masha\\source\\Semestr2\\SoftShop\\Pack.xml";
        private readonly string PackSoftFileName = "C:\\Users\\masha\\source\\Semestr2\\SoftShop\\PackSoft.xml";
        public List<Soft> Softs { get; set; }
        public List<Order> Orders { get; set; }
        public List<Pack> Packs { get; set; }
        public List<PackSoft> PackSofts { get; set; }
        private FileDataListSingleton()
        {
            Softs = LoadSofts();
            Orders = LoadOrders();
            Packs = LoadPacks();
            PackSofts = LoadPackSofts();
        }
        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }
        ~FileDataListSingleton()
        {
            SaveSofts();
            SaveOrders();
            SavePacks();
            SavePackSofts();
        }
        private List<Soft> LoadSofts()
        {
            var list = new List<Soft>();
            if (File.Exists(SoftFileName))
            {
                XDocument xDocument = XDocument.Load(SoftFileName);
                var xElements = xDocument.Root.Elements("Soft").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Soft
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        SoftName = elem.Element("SoftName").Value
                    });
                }
            }
            return list;
        }
        private List<Order> LoadOrders()
        {
            var list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                XDocument xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        PackId = Convert.ToInt32(elem.Element("PackId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = (OrderStatus)Enum.Parse(typeof(OrderStatus),
                   elem.Element("Status").Value),
                        DateCreate =
                   Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement =
                   string.IsNullOrEmpty(elem.Element("DateImplement").Value) ? (DateTime?)null :
                   Convert.ToDateTime(elem.Element("DateImplement").Value),
                    });
                }
            }
            return list;
        }
        private List<Pack> LoadPacks()
        {
            var list = new List<Pack>();
            if (File.Exists(PackFileName))
            {
                XDocument xDocument = XDocument.Load(PackFileName);
                var xElements = xDocument.Root.Elements("Pack").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Pack
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        PackName = elem.Element("PackName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value)
                    });
                }
            }
            return list;
        }
        private List<PackSoft> LoadPackSofts()
        {
            var list = new List<PackSoft>();
            if (File.Exists(PackSoftFileName))
            {
                XDocument xDocument = XDocument.Load(PackSoftFileName);
                var xElements = xDocument.Root.Elements("PackSoft").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new PackSoft
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        PackId = Convert.ToInt32(elem.Element("PackId").Value),
                        SoftId = Convert.ToInt32(elem.Element("SoftId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value)
                    });
                }
            }
            return list;
        }
        private void SaveSofts()
        {
            if (Softs != null)
            {
                var xElement = new XElement("Softs");
                foreach (var Soft in Softs)
                {
                    xElement.Add(new XElement("Soft",
                    new XAttribute("Id", Soft.Id),
                    new XElement("SoftName", Soft.SoftName)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(SoftFileName);
            }
        }
        private void SaveOrders()
        {
            if (Orders != null)
            {
                var xElement = new XElement("Orders");
                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                    new XAttribute("Id", order.Id),
                    new XElement("PackId", order.PackId),
                    new XElement("Count", order.Count),
                    new XElement("Sum", order.Sum),
                    new XElement("Status", order.Status),
                    new XElement("DateCreate", order.DateCreate),
                    new XElement("DateImplement", order.DateImplement)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }
        private void SavePacks()
        {
            if (Packs != null)
            {
                var xElement = new XElement("Packs");
                foreach (var Pack in Packs)
                {
                    xElement.Add(new XElement("Pack",
                    new XAttribute("Id", Pack.Id),
                    new XElement("PackName", Pack.PackName),
                    new XElement("Price", Pack.Price)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(PackFileName);
            }
        }
        private void SavePackSofts()
        {
            if (PackSofts != null)
            {
                var xElement = new XElement("PackSofts");
                foreach (var PackSoft in PackSofts)
                {
                    xElement.Add(new XElement("PackSoft",
                    new XAttribute("Id", PackSoft.Id),
                    new XElement("PackId", PackSoft.PackId),
                    new XElement("SoftId", PackSoft.SoftId),
                    new XElement("Count", PackSoft.Count)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(PackSoftFileName);
            }
        }
    }
}