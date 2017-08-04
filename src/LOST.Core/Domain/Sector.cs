using System;

namespace LOST.Core.Domain
{
    public class Sector
    {
        public Guid Id { get; protected set; }        
        public string Name { get; protected set; }

        protected Sector()
        {

        }

        public Sector(Guid sectorId, string name)
        {
            Id = sectorId;
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