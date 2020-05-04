using TravellerUtils.Libraries.Common.Objects;

namespace TravellerUtils.Libraries.Common.Generators
{
    public static class SectorGenerator
    {
        public static Sector Generate()
        {
            Sector output = new Sector();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    //TODO - deal with density
                    var subSector = SubsectorGenerator.Generate();

                    output.Set(i, j, subSector);
                }
            }

            return output;
        }
    }
}
