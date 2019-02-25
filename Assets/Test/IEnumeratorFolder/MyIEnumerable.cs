using System.Collections;

namespace Test.IEnumeratorFolder
{
    public class MyIEnumerable
    {
        private string[] strList;

        public MyIEnumerable(string[] _strList)
        {
            this.strList = _strList;
        }
        public MyIEnumerator GetEnumerator()
        {
            return new MyIEnumerator(strList);
        }
    }
}