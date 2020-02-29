using System;
using System.Collections.Generic;
using System.Text;

namespace Serialize_Json
{
    class ObjetQuelconque
    {

        public String premierAttribut { get; set; } = "Hello";
        public String secondAttribut { get; set; } = "World";
        public List<String> uneListe { get; set; } = new List<String>(new String[] { "element", "un autre" });

        public SousObjetQuelconque sousObj { get; set; } = new SousObjetQuelconque();
    }
}
