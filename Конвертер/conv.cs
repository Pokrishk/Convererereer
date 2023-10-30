using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Конвертер
{
    public class conv
    {

        public string Title;
        public string Seting;

        public conv(string title, string desc) 
        {
            this.Title = title;
            this.Seting = desc;
        }
        public conv() 
        {

        }
        static conv p1 = new("Неночь: ", "Дарк-фэнтези\n");
        static conv p2 = new("Дом, в котором…: ", "Роман\n");
        static conv p3 = new("Шестёрка воронов: ", "Роман\n");
        static List<conv> text = new List<conv>
            {
                p1,
                p2,
                p3
            };
        public class convList
        {
            public List<conv> ConvList { get; set; }

            public convList()
            {
                ConvList = new List<conv>();
            }
            public IEnumerator<conv> GetEnumerator()
            {
                return ConvList.GetEnumerator();
            }
        }
        public static void sozd()
        {
            var rstolpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var path = Path.Combine(rstolpath, "Text.txt");
            FileInfo fi1 = new FileInfo(path);
            using (StreamWriter sw = fi1.CreateText())
            {
                foreach (conv item in text) 
                { 
                    sw.WriteLine(item.Title + item.Seting); 
                }
            }
        }
        public static void chtenie()
        {
            string path = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Сохранить файл - F1. Выход - esc. \n----------------------------------------------------------------------------");
            if (path.EndsWith(".txt"))
            {
                foreach (conv item in text) 
                {
                    Console.WriteLine(item.Title + item.Seting);
                }
            }
            else if(path.EndsWith(".json"))
            {
                string Text = File.ReadAllText(path);
                List<conv> result = JsonConvert.DeserializeObject<List<conv>>(Text);
                foreach (conv item in result)
                {
                    Console.WriteLine(item.Title + item.Seting);
                }
            }
            else if (path.EndsWith(".xml"))
            {
                convList lList;
                XmlSerializer xml = new XmlSerializer(typeof(convList));
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                   lList =(convList)xml.Deserialize(fs);
                }
                foreach (conv item in lList)
                {
                    Console.WriteLine(item.Title + item.Seting);
                }
            }
        }
        public static void zapis()
        {
            string path = Console.ReadLine() ;
            if (path.EndsWith(".txt"))
            {
                foreach (conv item in text)
                {
                    var Text = item.Title + item.Seting;
                    File.WriteAllText(path, Text);
                }
            }
            else if (path.EndsWith(".json"))
            {
                string json = JsonConvert.SerializeObject(text);
                File.WriteAllText(path, json);
            }
            else if (path.EndsWith(".xml"))
            {
                convList list = new convList();
                list.ConvList = text;
                XmlSerializer xml = new XmlSerializer(typeof(convList));
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    xml.Serialize(fs, list);
                }
            }
        }
    }
}
