using System;

namespace Test.InterfaceAndAbstract
{
    public class MyClassDemo3:MyAbstractClassDemo3 ,IMyInterfaceDemo3
    {
        private int _count;

        public override Type type
        {
            get { return null; }
            
        }
        public override int Count
        {
            get { return this._count; }
        }
#if DEBUG
#else
        
    #endif

    }

}