using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



namespace JsonModifier
{
    public class JsonStructure
    {
        string _key;
        string _value;

        public void Put(string key, string value)
        {
            this._key = key;
            this._value = value;
        }

    }

    class Program
    {
       
        static void Main(string[] args)
        {
           List<List<JsonStructure>> jsonoutput = new List<List<JsonStructure>>();
            var jsonString = @"
                            [   
                                {
                                    ""serverTime"": ""2013-08-12 02:45:55,558"",
                                    ""data1"": ""Hit1"",
                                    ""data2"": ""Hit11""
                                },
                                {
                                    ""serverTime"": ""2013-08-12 02:45:56,578"",
                                    ""data1"": ""Hit2"",
                                    ""data2"": ""Hit22""
                                },
                            ]";

            var jsonResult = JArray.Parse(jsonString);
            foreach (JToken jt in jsonResult)
            {
                List<JsonStructure> ljs = new List<JsonStructure>();
                var fields = jt.ToObject<Dictionary<string, string>>();
                int counterkv = 0;
                for (int i = 0; i < fields.Count; i++)
                {
                     JsonStructure tempjs = new JsonStructure();
                    if (!fields.ElementAt(i).Key.Equals("data1") && !fields.ElementAt(i).Key.Equals("data2"))
                    {
                        continue;
                    }
                    else
                    {
                        tempjs.Put(fields.ElementAt(i).Key, fields.ElementAt(i).Value);
                        ljs.Add(tempjs);
                        jsonoutput.Add(ljs);
                    }
                }
            }
        }
    }
}
