namespace Lender.Slos.Utilities.Configuration
{
    public class ProductionSettings : IModificationWindowSettings
    {
        public int StartMonth
        {
            get
            {
                return 12;
            }
        }

        public int StartDay
        {
            get
            {
                return 1;
            }
        }
    }
}