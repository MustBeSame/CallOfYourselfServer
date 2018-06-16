using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesLib
{
    class Message
    {
        protected char Tipo { get; set; }
        protected char IdPlayer { get; set; }
        protected char IdTable { get; set; }

        public virtual char[] createMessage()
        {
            return new char[0];
        }

        protected virtual void addArrayOnList(int length,  char[] array, List<char> list)
        {
            for (int i = 0; i < length; i++)
            {
                list.Add(array[i]);
            }
        }

    }
}
