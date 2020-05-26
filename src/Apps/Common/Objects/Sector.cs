using System;
using TravellerUtils.Libraries.Common.Database;
using TravellerUtils.Libraries.Common.Interfaces;

namespace TravellerUtils.Libraries.Common.Objects
{
    public class Sector : IDatabaseObject, IHasCoordinates
    {
        public Sector()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
