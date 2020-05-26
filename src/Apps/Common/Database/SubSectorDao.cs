using LiteDB;
using TravellerUtils.Libraries.Common.Objects;

namespace TravellerUtils.Libraries.Common.Database
{
    public class SubSectorDao : AbstractDao<SubSector>
    {
        public SubSectorDao(ILiteDatabase db) : base(db, "SubSector")
        {
        }
    }
}
