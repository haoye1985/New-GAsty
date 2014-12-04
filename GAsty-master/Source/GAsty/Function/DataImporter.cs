using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using GAsty.Services;
using Microsoft.Office.Interop.Excel;

namespace GAsty.Function
{
    public static class DataImporter
    {

        public static void GetTrainServicePerformance()
        {
            var doc = XElement.Load(@"D:\GAsty\GAsty\XMLData\TrainSummary.xml");

            IEnumerable<XElement> childElement =
                from el in doc.Elements()
                where el.HasElements
                select el;

            foreach (var el in childElement)
            {
                MessageBox.Show(el.Element("P").Attribute("N").Value);
            }
        }

        public static void GetTubeLineService()
        {
            var doc = XElement.Load(@"D:\GAsty\GAsty\XMLData\LineStatus.xml");

            IEnumerable<XElement> childElements =
                from el in doc.Elements()
                //where el.Element("Line").Value != null
                select el;

            List<TubeLineStatus> LineServiceList = new List<TubeLineStatus>();

            foreach (var el in childElements)
            {
                var lineService = new TubeLineStatus();

            }


        }

        public static void GetOperationPerformance()
        {
            var doc = XElement.Load(@"D:\GAsty\GAsty\XMLData\LineStatus.xml");

            IEnumerable<XElement> childElements =
                from el in doc.Elements()
                //where el.FirstAttribute.Value =="7"
                select el;

            var lineOperations = new List<TubeLineStatus>();

            foreach (var el in childElements)
            {
                var LineStatus = new TubeLineStatus();

                XNode node = el.FirstNode.NextNode;
                XNode nextNode = el.FirstNode.NextNode.NextNode;

                LineStatus.LineCode= (node as XElement).Attribute("ID").Value;
                LineStatus.LineName = (node as XElement).Attribute("Name").Value;
                LineStatus.LineStatus= (nextNode as XElement).Attribute("CssClass").Value;

                lineOperations.Add(LineStatus);

            }

            foreach (var opt in lineOperations)
            {
                MessageBox.Show(opt.LineCode + " " + opt.LineName + " " + opt.LineStatus);
            }


        }


    }
}
