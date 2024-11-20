using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using Extensions;

namespace Core
{
    public static class SessionData
    {

        private static Dictionary<ContentType, List<ContentID>>
            
            _consumedContent;


        #region Save/Load
       
        public static async Task LoadAsync(string fileName,
            
            JsonSerializerOptions options)
        {

            List<ContentNode> nodes;


            if (File.Exists(fileName))
            {

                string json = await Files.ReadString(fileName);


                nodes = JsonSerializer.Deserialize<

                    List<ContentNode>>(json, options);
            }
            else
            {

                CreateNodes(out nodes);
            }


            SetDictionary(nodes);
        }


        public static async Task SaveAsync(string fileName,
            
            JsonSerializerOptions options)
        {

            List<ContentNode> nodes = GetNodes();


            string json = JsonSerializer.Serialize(nodes, options);

            await Files.WriteString(fileName, json);
        }
        
        #endregion


        public static void AddConsumed(ContentType type,
            
            ContentID id)
        {


            if(_consumedContent.TryGetValue(type,
                
                out List<ContentID> consumed) &&
                
                !consumed.Contains(id))
            {

                consumed.Add(id);
            }
        }


        public static IEnumerable<ContentID>? GetConsumed(ContentType type)
        {

            if(_consumedContent.TryGetValue(type,
                
                out List<ContentID> consumed))
            {

                return consumed;
            }

            return null;
        }

        
        private static void CreateNodes(out List<ContentNode> nodes)
        {

            ContentType[] types = (ContentType[])

                    Enum.GetValues(typeof(ContentType));


            nodes = new List<ContentNode>(types.Length);


            foreach (ContentType type in types)
            {

                List<ContentID> ids =
                [
                    new (){Name = "Sex 1", Year = 2001 },
                    new (){Name = "Sex 2", Year = 2002 },
                    new (){Name = "Sex 3", Year = 2003 }
                ];

                nodes.Add(new ContentNode(type, ids));
            }
        }


        private static void SetDictionary(IReadOnlyCollection<ContentNode> nodes)
        {

            _consumedContent = new Dictionary<

                ContentType, List<ContentID>>(nodes.Count);


            foreach (ContentNode node in nodes)
            {

                _consumedContent.Add(node.Type, node.IDs);
            }
        }


        private static List<ContentNode> GetNodes()
        {

            List<ContentNode> nodes = new(_consumedContent.Count);


            foreach (ContentType type in _consumedContent.Keys)
            {

                ContentNode node = new(type, _consumedContent[type]);

                nodes.Add(node);
            }


            return nodes;
        }
    }
}
