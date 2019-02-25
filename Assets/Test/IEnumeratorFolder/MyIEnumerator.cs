using System.Collections;

namespace Test.IEnumeratorFolder{
    public class MyIEnumerator
    {
        private string[] strList;
        private int position;
    
        public MyIEnumerator(string[] _strList)
        {
            strList = _strList;
            this.position = -1;
        }
        public bool MoveNext()
        {
            this.position++;
            if (this.position < this.strList.Length)
            {
                return true;
            }

            return false;
        }
    
        public void Reset()
        {
            this.position = -1;
        }
    
        public object Current {
            get { return strList[position]; }
        }
    }
}