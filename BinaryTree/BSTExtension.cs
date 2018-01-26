using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public static class BSTExtension
    {
        /// <summary>
        /// Searches for an element that matches the conditions defined by the specified
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        public static Node<T> FindNode<T>(this Node<T> root,Node<T> node) where T:IComparable
        {

            if (node == null)
            {
                return null;
            }
            Node<T> temp = root;
            while (temp != null)
            {
                if (temp.CompareTo(node) == 0)
                {
                    return temp;
                }
                if (temp > node)
                {
                    temp = temp.Left;
                }
                else
                {
                    temp = temp.Right;
                }
            }
            return null;
        }
    }
}
