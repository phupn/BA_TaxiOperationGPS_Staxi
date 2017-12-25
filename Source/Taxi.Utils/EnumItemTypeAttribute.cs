using System;


namespace Taxi.Utils
{
    public class EnumItemTypeAttribute : Attribute
    {        
        public string Name { get; set; }
        public string Description { get; set; }
        public string TextMask;
        public int Length = 255;
        public Enum_ItemType Type = Enum_ItemType.Auto;
        public Type ValueEnum { get; set; }
        public EnumItemTypeAttribute(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public EnumItemTypeAttribute(string name, string description, string textMask)
        {
            Name = name;
            Description = description;
            TextMask = textMask;
        }
        public EnumItemTypeAttribute(string name, string description, string textMask,int length)
        {
            Name = name;
            Description = description;
            TextMask = textMask;
            Length = length;
        }
    }
}
