namespace TravellerUtils.Libraries.Common.Objects
{
    public class SubSector
    {
        private readonly StellarSystem[,] m_StellarSystems;

        public SubSector()
        {
            m_StellarSystems = new StellarSystem[8, 10];
        }

        public string Name { get; set; }

        public StellarSystem Get(int x, int y)
        {
            //TODO - Validate x, y
            return m_StellarSystems[x, y];
        }

        public void Set(int x, int y, StellarSystem stellarSystem)
        {
            m_StellarSystems[x, y] = stellarSystem;
        }
    }
}
