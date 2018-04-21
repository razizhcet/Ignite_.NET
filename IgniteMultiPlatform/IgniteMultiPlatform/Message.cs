using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgniteMultiPlatform
{
    class Message
    {
        public Message(string author, string text)
        {
            Author = author;
            Text = text;
        }

        public string Author { get; }
        public string Text { get; }
    }
}
