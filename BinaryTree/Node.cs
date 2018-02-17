using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class Node<T> : IComparable
        where T : IComparable
    {
        private T data;
        private Node<T> left;
        private Node<T> right;
        private int size;

        public T Data { get => data; set => data = value; }
        public Node<T> Left { get => left; set => left = value; }
        public Node<T> Right { get => right; set => right = value; }
        public int Size { get => size; set => size = value; }

        public Node()
        {
            object dbNull = null;
            Data = Data is DBNull ? (T)dbNull : default(T);
            Left = null;// Letf is DBNull ? (T)dbNull : default(T);
            Right = null;
        }


        public Node(T data, Node<T> nodeChild, Node<T> nodeChild2)
        {
            this.Data = data;
            if (nodeChild.CompareTo(this) == 0)
            {
                this.Left = nodeChild;
                this.Right = null;
            }
            else if (nodeChild < this)
            {
                this.Left = nodeChild;
                this.Right = nodeChild2;
            }
            else if (nodeChild > this)
            {
                this.Left = nodeChild2;
                this.Right = nodeChild;
            }
        }

        public Node(T data)
        {
            this.Data = data;
            this.Left = null;// Letf is DBNull ? (T)dbNull : default(T);
            this.Right = null;
            this.Size = 1;
        }


        public Node(T data,int size)
        {
            this.Data = data;
            this.Left = null;// Letf is DBNull ? (T)dbNull : default(T);
            this.Right = null;
            this.Size = size;
        }

        public Node(Node<T> node)
        {
            this.Data = node.Data;
            this.Left = node.Left;
            this.Right = node.Right;
            this.Size = node.Size;
        }
        
        public int CompareTo(object obj)
        {
            try
            {
                Node<T> node = obj as Node<T>;
                return this.Data.CompareTo(node.Data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool operator <(Node<T> node, Node<T> node2)
        {
            return node.Data.CompareTo(node2.Data) < 0;
        }
        public static bool operator >(Node<T> node, Node<T> node2)
        {
            return node.Data.CompareTo(node2.Data) > 0;
        }
    }
}
