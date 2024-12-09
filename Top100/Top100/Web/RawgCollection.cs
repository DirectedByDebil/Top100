using System;
using System.Collections.Generic;

namespace Web
{

    [Serializable]
    public struct RawgCollection
    {

        public int Count { get; set; }

       
        public List<RawgTag> Results { get; set; }
    }
}
