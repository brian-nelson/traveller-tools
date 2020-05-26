using LiteDB;
using TravellerUtils.Libraries.Common.Objects;

namespace TravellerUtils.Libraries.Common.Database
{
    public class SectorDao : AbstractDao<Sector>
    {
        public SectorDao(ILiteDatabase db) : 
            base(db, "Sector")
        {
        }
    }
}
