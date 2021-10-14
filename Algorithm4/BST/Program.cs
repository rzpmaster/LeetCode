using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    class Program
    {
        static void Main(string[] args)
        {
            BST<int, int> tree = new BST<int, int>();
            for (int i = 0; i < 10; i++)
            {
                tree.Put(i, 0);
            }

            var keys = tree.Keys().ToList();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(keys[i]);
            }
            Console.WriteLine("-----------------------------");

            RedBlackBST<int, int> rbTree = new RedBlackBST<int, int>();
            for (int i = 0; i < 10; i++)
            {
                rbTree.Put(i, 0);
            }
            var rbKeys = rbTree.Keys().ToList();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(rbKeys[i]);
            }


            Console.ReadKey();
        }
    }
}
