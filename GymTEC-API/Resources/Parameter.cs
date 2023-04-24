using System.Drawing;

namespace GymTEC_API.Resources
{
    public class Parameter
    {

        public Parameter(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }
        public string Value { get; set; }


    }
}
