namespace HansKindberg.StructureMap.Samples.TestTypes
{
    public interface IDifferentConstructors
    {
        #region Properties

        IFirstInterface FirstInterface { get; }
        string FirstString { get; }
        ISecondInterface SecondInterface { get; }
        string SecondString { get; }
        string ThirdString { get; }

        #endregion
    }
}