using System.Diagnostics.CodeAnalysis;

namespace HansKindberg.StructureMap.Samples.TestTypes
{
    [SuppressMessage("Microsoft.Design", "CA1053:StaticHolderTypesShouldNotHaveConstructors")]
    public class SecondClass : ISecondInterface
    {
        #region Fields

        private static SecondClass _instance;

        #endregion

        #region Properties

        public static SecondClass Instance
        {
            get { return _instance ?? (_instance = new SecondClass()); }
        }

        #endregion
    }
}