using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class Node<T>:IComparable
        where T : IComparable
    {
        private T data;
        private Node<T> letf;
        private Node<T> right;
        public T Data { get => data; set => data = value; }
        public Node<T> Letf { get => letf; set => letf = value; }
        public Node<T> Right { get => right; set => right = value; }

        public Node()
        {            
            object dbNull = null;
            Data = Data is DBNull ? (T)dbNull : default(T);
            Letf = null;// Letf is DBNull ? (T)dbNull : default(T);
            Right = null;
        }


        public Node(T data,Node<T> nodelift,Node<T> noderight)
        {
            this.Data = data;
            this.Letf = nodelift;
            this.Right = noderight;
        }
        public Node(T data)
        {
            this.Data = data;
            this. Letf = null;// Letf is DBNull ? (T)dbNull : default(T);
            this. Right = null;
        }

        public Node(Node<T> node)
        {
            this.Data = node.Data;
            this.Letf = node.Letf;
            this.Right = node.Right;
        }

        public bool Remove(Node<int> item1)
        {
            return false;
            //throw new NotImplementedException();
        }

        public void AddRange(Node<T>[] node)
        {
            foreach (var item in node)
            {
                Insert(item);
            }
        }

        public T GetMin()
        {
            var temp = this;
            if (this.Data == null)
            {
                return this.Data;
            }
            while (true)
            {
                if (temp.Letf == null)
                {
                    return temp.Data;
                }
                else if (temp.Letf != null)
                {
                    temp = temp.Letf;
                }
            }
        }

        public object Predecessor()
        {
            return this.Letf.GetMax();
            //throw new NotImplementedException();
        }

        public object Successor()
        {
            return this.Right.GetMin();
            //throw new NotImplementedException();
        }

        public T GetMax()
        {
            var temp = this;
            if (this.Data==null)
            {
                return this.Data;
            }
            while (true)
            {
               if (temp.Right == null)
                {
                    return temp.Data;
                }
                else if(temp.Right!=null)
                {
                    temp = temp.Right;                    
                }                
            }
        }

        public void Insert( Node<T> item)
        {
            Node<T> temp = this;
            if (item==null)
            {
                return;
            }
            if (this.Data==null)
            {
                this.Data = item.Data;
                this.Letf = item.Letf;
                this.Right = item.Right;
            }
            //Node<T> temp = root;
            while (item!=null)
            {
                if (temp.Data.Equals(item.Data))
                {
                    break;
                }
                if (item<temp)
                {
                    if (temp.Letf!=null)
                    {
                        temp = temp.Letf;
                    }
                    else
                    {
                        temp.Letf = item;
                        break;
                    }
                }
                else if(item>temp)
                {
                    if (temp.Right!=null)
                    {
                        temp = temp.Right;
                    }
                    else
                    {
                        temp.Right = item;
                        break;
                    }
                }
            }
        }


        public bool Contains(Node<T> node)
        {
            Node< T> temp = this ;
            while (temp!=null)
            {
                if (temp.CompareTo(node)==0)
                {
                    return true;
                }
                if (temp>node)
                {
                    temp = temp.Letf;
                }
                else
                {
                    temp = temp.Right;
                }
            }
            return false;
        }

        public int CompareTo(object obj)
        {
            try
            {
                Node<T> node=obj as Node<T>;
                return this.Data.CompareTo(node.Data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public static bool  operator <(Node<T> node ,Node<T> node2)
        {
            return node.Data.CompareTo(node2.Data)<0;
        }
        public static bool operator >(Node<T> node, Node<T> node2)
        {
            return node.Data.CompareTo(node2.Data) > 0;
        }
    }
}
