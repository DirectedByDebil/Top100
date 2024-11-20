using System;
using System.Collections.Generic;

namespace Core
{

    [Serializable]
    public struct ContentNode
    {

        public ContentType Type { get; set; }

        public List<ContentID> IDs { get; set; }


        public ContentNode(ContentType type,
            
            List<ContentID> ids)
        {

            Type = type;

            IDs = ids;
        }    
    }
}
