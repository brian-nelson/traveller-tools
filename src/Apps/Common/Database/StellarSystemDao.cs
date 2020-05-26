using LiteDB;
using TravellerUtils.Libraries.Common.Objects;

namespace TravellerUtils.Libraries.Common.Database
{
    public class StellarSystemDao : AbstractDao<StellarSystem>
    {
        public StellarSystemDao(ILiteDatabase db) : base(db, "StellarSystem")
        {
        }
    }
}
