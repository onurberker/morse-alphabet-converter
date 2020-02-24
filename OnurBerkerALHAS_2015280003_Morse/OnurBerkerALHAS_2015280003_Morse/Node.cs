using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnurBerkerALHAS_2015280003_Morse
{
    class Node
    {
        public Node left;
        public Node right;
        public string val;
         
        public Node( string val)
        {
            this.val = val;
            left = null;
            right = null;
        }


    }
}
