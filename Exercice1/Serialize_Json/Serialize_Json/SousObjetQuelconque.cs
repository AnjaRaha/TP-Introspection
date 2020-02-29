using System;
using System.Collections.Generic;
using System.Text;

namespace Serialize_Json
{
    class SousObjetQuelconque
    {
       
            public String unSousAttribut { get; set; } = "blabla";
            public String encoreUneAutre { get; set; } = "machin";

            public List<String> uneListe { get; set; } = new List<String>(new String[] { "one", "two" , "three"});
        

    }
}
