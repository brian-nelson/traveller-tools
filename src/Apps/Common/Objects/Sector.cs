namespace TravellerUtils.Libraries.Common.Objects
{
    public class Sector
    {
        private readonly SubSector[,] m_SubSectors;

        public Sector()
        {
            m_SubSectors = new SubSector[4,4];
        }

        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public SubSector Get(int x, int y)
        {
            //TODO - Validate x, y
            return m_SubSectors[x, y];
        }

        public void Set(int x, int y, SubSector subSector)
        {
            m_SubSectors[x, y] = subSector;
        }
    }
}
