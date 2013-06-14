using System.Diagnostics.CodeAnalysis;

namespace HansKindberg.StructureMap.Samples.TestTypes
{
    [SuppressMessage("Microsoft.Design", "CA1053:StaticHolderTypesShouldNotHaveConstructors")]
    public class FirstClass : IFirstInterface
    {
        #region Fields

        private static FirstClass _instance;

        #endregion

        #region Properties

        public static FirstClass Instance
        {
            get { return _instance ?? (_instance = new FirstClass()); }
        }

        #endregion
    }
}