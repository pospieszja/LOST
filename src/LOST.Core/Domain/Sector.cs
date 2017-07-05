using System;

namespace LOST.Core.Domain
{
    public class Sector
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        protected Sector()
        {

        }

        public Sector(string name)
        {
            SetName(name);
        }

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception($"{nameof(Name)} property can't be empty.");
            }

            Name = name;
        }
    }
}