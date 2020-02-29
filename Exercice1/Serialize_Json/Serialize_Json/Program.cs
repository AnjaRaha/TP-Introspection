using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Serialize_Json
{
    class Program
    {
        static void Main(string[] args)
        {

            MonJson encoder = new MonJson();
            ObjetQuelconque obj = new ObjetQuelconque();
            String json = MonJson.Serialization(obj);
            json = MonJson.Serialization(obj);
            Console.WriteLine(json);
        }

        
        

    }
}