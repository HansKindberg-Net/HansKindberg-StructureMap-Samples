using System;

namespace HansKindberg.StructureMap.Samples.TestTypes
{
    public class DifferentConstructors : IDifferentConstructors
    {
        #region Fields

        private readonly IFirstInterface _firstInterface;
        private readonly string _firstString;
        private readonly ISecondInterface _secondInterface;
        private readonly string _secondString;
        private readonly string _thirdString;

        #endregion

        #region Constructors

        public DifferentConstructors() {}
        public DifferentConstructors(IFirstInterface firstInterface) : this(firstInterface, SecondClass.Instance) {}
        public DifferentConstructors(ISecondInterface secondInterface) : this(FirstClass.Instance, secondInterface) {}
        public DifferentConstructors(string firstString) : this(firstString, "DefaultSecondValue", "DefaultThirdValue") {}

        public DifferentConstructors(IFirstInterface firstInterface, ISecondInterface secondInterface)
        {
            if(firstInterface == null)
                throw new ArgumentNullException("firstInterface");

            if(secondInterface == null)
                throw new ArgumentNullException("secondInterface");

            this._firstInterface = firstInterface;
            this._secondInterface = secondInterface;
        }

        public DifferentConstructors(string firstString, string secondString, string thirdString)
        {
            if(firstString == null)
                throw new ArgumentNullException("firstString");

            if(secondString == null)
                throw new ArgumentNullException("secondString");

            if(thirdString == null)
                throw new ArgumentNullException("thirdString");

            this._firstString = firstString;
            this._secondString = secondString;
            this._thirdString = thirdString;
        }

        #endregion

        #region Properties

        public virtual IFirstInterface FirstInterface
        {
            get { return this._firstInterface; }
        }

        public virtual string FirstString
        {
            get { return this._firstString; }
        }

        public virtual ISecondInterface SecondInterface
        {
            get { return this._secondInterface; }
        }

        public virtual string SecondString
        {
            get { return this._secondString; }
        }

        public virtual string ThirdString
        {
            get { return this._thirdString; }
        }

        #endregion
    }
}