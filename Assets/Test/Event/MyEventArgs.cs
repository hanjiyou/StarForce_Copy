using System;

namespace Test
{
    public class MyEventArgs:EventArgs
    {
        public string name;
        public MyEventArgs(string _name)
        {
            name = _name;
        }
    }
}