using System;

namespace OshudhwalaDotCom.Models
{
    internal class FileTypesAttribute : Attribute
    {
        private string v;

        public FileTypesAttribute(string v)
        {
            this.v = v;
        }
    }
}