using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnurBerkerALHAS_2015280003_Morse
{
    class Converter
    {
        private  Dictionary<string, string> data;
        public Node tree;
        public Converter(Dictionary<string,string> data)
        {
            this.data = data;
           
               
        }

        

        /// <summary>
        /// Verileri yerleştiriyoruz ağacımıza
        /// </summary>
        public void fill()
        {
          
            tree = new Node(data.ElementAt(0).Value);
            
             for(int i = 1; i <data.Keys.Count;i++)
             {
                 Node g = tree;
                 string temp = data.ElementAt(i).Value;

                 for(int j = 0; j <temp.Length ;j++)
                 {
                     if(temp[j] == '.' )
                     {
                         if (g.left != null) g = g.left;
                         else
                         {
                             
                             g.left = new Node(data.ElementAt(i).Key);

                             break;
                         }
                     }
                     else
                     {
                         if (g.right != null) g = g.right;
                         else
                         {

                             g.right = new Node(data.ElementAt(i).Key);
                             break;
                         }
                     }

                 }
             }

        }

         

        /// <summary>
        /// inorder traversal
        /// </summary>
        /// <param name="node"> root</param>
        public void inOrder(Node node)
        {
            if (node == null)
                return;
            inOrder(node.left);
            Console.WriteLine(node.val + "   " + data[node.val]);
            inOrder(node.right);

        }

        /// <summary>
        /// preorder traversal
        /// </summary>
        /// <param name="node">root</param>
        public void preOrder(Node node)
        {
            if (node == null)
                return;
            Console.WriteLine(node.val + "   " + data[node.val]);
            preOrder(node.left);
            preOrder(node.right);

        }


        /// <summary>
        /// postorder traversal
        /// </summary>
        /// <param name="node">root</param>
        public  void postOrder(Node node)
        {
           
            if (node == null)
                return;

            postOrder(node.left);
            postOrder(node.right);
            Console.WriteLine(node.val + "   " + data[node.val]);
        }

        public void convertStringToMorse(string s)
        {
            Node g;
           for(int i = 0; i < s.Length;i++)
           {
               g = tree;
             
               find(g,s[i] + "");
               Console.Write(" ");

           }
           Console.WriteLine();
        }


        private void find(Node root, string val)
        {
            if (root == null)
                return;
            if (root.val == val) Console.Write(data[val]);
            find(root.left, val);
            find(root.right, val);
            

        }

        public void convertMorseToString(string s)
        {
            List<int> spaceIndex = new List<int>();
            List<string> pieces = mySplit(s,ref spaceIndex);
           
            for (int i = 0; i < pieces.Count; i++)
            {
                if (spaceIndex.Contains(i)) Console.Write(" ");
               if(data.ContainsValue(pieces[i]))
                   Console.Write(data.FirstOrDefault(x => x.Value == pieces[i]).Key);
               else
               {

                   Console.WriteLine("Invalid morse code");
                   return;
               }
               
            }
           
           
        }
        /// <summary>
        /// harfleri tek tek ayırdım
        /// </summary>
        /// <param name="s"> morse kodu</param>
        /// <returns></returns>
        private List<string> mySplit(string s,ref List<int> spaceIndex)
        {
            List<string> splits = new List<string>();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
               
                if (s[i] != ' ') sb.Append(s[i]);
                else
                {
                    if (i + 1 != s.Length && s[i + 1] == ' ') { i++; spaceIndex.Add(splits.Count +1 ); }
                   


                    splits.Add(sb.ToString());
                    sb = new StringBuilder();
                }
                
            }
            if (sb.ToString().Length != 0) splits.Add(sb.ToString());
            return splits;
        }


        public  Node getTree()
        {
            return tree;
        }


    }
}
