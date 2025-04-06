using System;

namespace PluginInterface
{
    [AttributeUsage(AttributeTargets.Class)]
    public class OperationMetadataAttribute : Attribute
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string[] Aliases { get; set; } 

      
        public OperationMetadataAttribute()
        {
            Aliases = new string[] { }; 
        }
    }
}