using System;

namespace Core
{

    [Serializable]
    public struct ContentID
    {

        public string Name { get; set; }

        public int Year { get; set; }


        public ContentID(string name, int year)
        {

            Name = name;

            Year = year;
        }
    }
}
