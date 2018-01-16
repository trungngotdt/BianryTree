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


        public Node(T data, Node<T> nodeChild, Node<T> nodeChild2)
        {
            this.Data = data;
            if (nodeChild.CompareTo(this) == 0)
            {
                this.Letf = nodeChild;
                this.Right = null;
            }
            else if (nodeChild < this)
            {
                this.Letf = nodeChild;
                this.Right = nodeChild2;
            }
            else if (nodeChild > this)
            {
                this.Letf = nodeChild2;
                this.Right = nodeChild;
            }
        }
        public Node(T data)
        {
            this.Data = data;
            this.Letf = null;// Letf is DBNull ? (T)dbNull : default(T);
            this.Right = null;
        }

        public Node(Node<T> node)
        {
            this.Data = node.Data;
            this.Letf = node.Letf;
            this.Right = node.Right;
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
            if (this.Data == null)
            {
                return this.Data;
            }
            while (true)
            {
                if (temp.Right == null)
                {
                    return temp.Data;
                }
                else if (temp.Right != null)
                {
                    temp = temp.Right;
                }
            }
        }

        public bool Remove(Node<T> item)
        {
            Node<T> node = this;
            Node<T> nodeNull = new Node<T>();
            if (item==null)
            {
                return false;
            }
            while (node != null)
            {
                if (node.CompareTo(item) == 0)
                {
                    if (node.Right != null && node.Letf == null|| node.Right == null && node.Letf != null)
                    {
                        node = node.Right ?? node.Letf;
                        return true;
                    }
                    else if (node.Right == null && node.Letf == null)
                    {
                        object dbNull = null;
                        node.Data = Data is DBNull ? (T)dbNull : default(T);
                        //.Right;
                        node.Letf = null;
                        node.Right = null;
                        return true;
                    }
                    else
                    {
                        var suc= (T)node.Successor();
                        var nodeFind= node.FindNode(new Node<T>(suc));
                        nodeFind = null;//.Remove(new Node<T>((T)suc));
                        //Node<T> succ =new Node<T>((T) node.Successor(),node.Right,node.Letf);
                        node.Data = suc;
                        return true;
                    }
                }
                if (node < item)
                {
                    node = node.Right;
                }
                else
                {
                    node = node.Letf;
                }
            }
            return false;
            //throw new NotImplementedException();
        }

        public Node<T> FindNode(Node<T> node)
        {
            if (node==null)
            {
                return null;
            }
            Node<T> temp = this;
            while (temp != null)
            {
                if (temp.CompareTo(node) == 0)
                {
                    return temp;
                }
                if (temp > node)
                {
                    temp = temp.Letf;
                }
                else
                {
                    temp = temp.Right;
                }
            }
            return null;
            //throw new NotImplementedException();
        }

        public void Insert(Node<T> item)
        {
            Node<T> temp = this;
            if (item == null)
            {
                return;
            }
            if (this.Data == null)
            {
                this.Data = item.Data;
                this.Letf = item.Letf;
                this.Right = item.Right;
            }
            //Node<T> temp = root;
            while (item != null)
            {
                if (temp.Data.Equals(item.Data))
                {
                    break;
                }
                if (item < temp)
                {
                    if (temp.Letf != null)
                    {
                        temp = temp.Letf;
                    }
                    else
                    {
                        temp.Letf = item;
                        break;
                    }
                }
                else if (item > temp)
                {
                    if (temp.Right != null)
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
            Node<T> temp = this;
            if (node==null)
            {
                return false;
            }
            while (temp != null)
            {
                if (temp.CompareTo(node) == 0)
                {
                    return true;
                }
                if (temp > node)
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
