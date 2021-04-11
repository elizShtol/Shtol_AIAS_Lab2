using System;
using System.IO;
using System.Xml;

namespace AIAS_Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь до файла с данными для эксперимента");
            var path = Console.ReadLine();
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            var rootElement = xmlDoc.DocumentElement;
            foreach (XmlNode childNode in rootElement.ChildNodes)
            {
                if(childNode.Name=="experiment" && childNode.Attributes.GetNamedItem("name").Value == "Qsort")
                    QsortExperiment(childNode);
            }
        }

        private static void QsortExperiment(XmlNode rootNode)
        {
            using (var sw = new StreamWriter("results.txt",false, System.Text.Encoding.Default))
                sw.WriteLine("");
            foreach (XmlElement xmlElement in rootNode.ChildNodes)
            {
                if (xmlElement.Attributes.GetNamedItem("name").Value == "Arithmetic Progression")
                {
                    for (var i = 0; i < int.Parse(xmlElement.Attributes.GetNamedItem("repeat").Value); i++)
                    {
                        for (int j = int.Parse(xmlElement.Attributes.GetNamedItem("startLength").Value);
                            j < int.Parse(xmlElement.Attributes.GetNamedItem("maxLength").Value); 
                            j+=int.Parse(xmlElement.Attributes.GetNamedItem("diff").Value))
                            QsortExperimentForArrayWithLength(j, xmlElement);
                    }
                }
                
                if (xmlElement.Attributes.GetNamedItem("name").Value == "Geometric Progression")
                {
                    for (var i = 0; i < int.Parse(xmlElement.Attributes.GetNamedItem("repeat").Value); i++)
                    {
                        for (int j = int.Parse(xmlElement.Attributes.GetNamedItem("startLength").Value);
                            j < int.Parse(xmlElement.Attributes.GetNamedItem("maxLength").Value); 
                            j*=int.Parse(xmlElement.Attributes.GetNamedItem("znamen").Value))
                            QsortExperimentForArrayWithLength(j, xmlElement);
                    }
                }
            }
            
            Console.WriteLine("Данные, полученные в ходе эксперимента, записаны в файл results.txt");
        }

        private static void QsortExperimentForArrayWithLength(int length, XmlElement xmlElement)
        {
            var minElement = int.Parse(xmlElement.Attributes.GetNamedItem("minElement").Value);
            var maxElement = int.Parse(xmlElement.Attributes.GetNamedItem("maxElement").Value);
            var array = new int[length];
            var random = new Random(Environment.TickCount);
            for (int k = 0; k < length; k++)
                array[k] = random.Next(minElement, maxElement);

            var operationsCount = 0;
            Qsort.QuickSort(array, 0, array.Length-1, ref operationsCount);
            using (var sw = new StreamWriter("results.txt", true, System.Text.Encoding.Default))
                sw.WriteLine($"{length}\t{operationsCount}");
        }
    }
}