using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class BSTree<T> : IComparable where T : IComparable
    {
        public Node<T> root;

        public BSTree()
        {
            root = null;
        }
        public BSTree(Node<T> node)
        {
            root = node;
        }

        #region AddRange
        /// <summary>
        /// Adds the elements of the specified collection to the BST
        /// </summary>
        /// <param name="node"></param>
        public void AddRange(Node<T>[] node)
        {
            foreach (var item in node)
            {
                Insert(item);
            }
        }

        /// <summary>
        /// Adds the elements of the specified collection to the BST
        /// </summary>
        /// <param name="data"></param>
        public void AddRange(T[] data)
        {

            foreach (var item in data)
            {
                Insert(new Node<T>(item));
            }
        }

        #endregion

        #region GetPredecessor
        /// <summary>
        /// Find inorder predecessor of a node
        /// </summary>
        /// <returns></returns>
        public object Predecessor(Node<T> node)
        {
            return GetMax(node.Left);
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Find inorder predecessor of a BST
        /// </summary>
        /// <returns></returns>
        public object Predecessor()
        {
            return Predecessor(root);
            //throw new NotImplementedException();
        }


        #endregion

        #region GetSuccessor
        /// <summary>
        /// Find inorder successor of a BST
        /// </summary>
        /// <returns><seealso cref="Node{T}"/></returns>
        public object Successor()
        {
            return Successor(root);//GetMin(root.Right);//root.Right.GetMin();
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Find inorder successor of a node 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public object Successor(Node<T> node)
        {
            return GetMin(node.Right);
        }

        #endregion

        #region GetMin

        /// <summary>
        /// Return a minimum value in Node
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public Node<T> GetMin(Node<T> node)
        {
            var temp = node;
            if (node == null)
            {
                return null;
            }
            while (true)
            {
                if (temp.Left == null)
                {
                    return temp;
                }
                else if (temp.Left != null)
                {
                    temp = temp.Left;
                }
            }
        }

        /// <summary>
        ///Return a minimum value in BST 
        /// </summary>
        /// <returns></returns>
        public Node<T> GetMin()
        {
            return GetMin(root);
        }
        #endregion

        #region GetMax
        /// <summary>
        /// Return a maximum value in BST
        /// </summary>
        /// <returns></returns>
        public Node<T> GetMax()
        {
            return GetMax(root);
        }

        /// <summary>
        /// Return a maximum value in node
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public Node<T> GetMax(Node<T> node)
        {
            var temp = node;
            if (node == null)
            {
                return node;
            }
            while (true)
            {
                if (temp.Right == null)
                {
                    return temp;
                }
                else if (temp.Right != null)
                {
                    temp = temp.Right;
                }
            }
        }

        #endregion

        #region Contains
        /// <summary>
        /// Determines whether an element is in the BST
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool Contains(Node<T> nodeMatch, Node<T> nodeRoot)
        {
            Node<T> temp = nodeRoot;
            if (nodeMatch == null)
            {
                return false;
            }
            while (temp != null)
            {
                if (temp.CompareTo(nodeMatch) == 0)
                {
                    return true;
                }
                if (temp > nodeMatch)
                {
                    temp = temp.Left;
                }
                else
                {
                    temp = temp.Right;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether an element is in the BST
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool Contains(Node<T> node)
        {
            return Contains(node, root);
        }


        #endregion

        #region Size

        /// <summary>
        /// Return size of tree
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return Size(root);
        }

        /// <summary>
        /// Return size of node
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private int Size(Node<T> node)
        {
            if (node == null)
            {
                return 0;
            }
            else return node.Size;
        }
        #endregion

        #region Traversal
        public void LRN(Node<T> node)
        {
            if (node==null)
            {
                return;
            }
            LRN(node.Left);
            LRN(node.Right);
            Console.WriteLine(node.Data);
        }

        public void LRN()
        {
            LRN(root);
        }

        public void RLN(Node<T> node)
        {
            if (node==null)
            {
                return;
            }
            RLN(node.Right);
            RLN(node.Left);
            Console.WriteLine(node.Data);
        }

        public void RLN()
        {
            RLN(root);
        }

        public void LNR(Node<T> node)
        {
            if (node==null)
            {
                return;
            }
            LNR(node.Left);
            Console.WriteLine(node.Data);
            LNR(node.Right);
        }

        public void LNR()
        {
            LNR(root);
        }

        #endregion

        #region Remove
        /// <summary>
        ///  Remove a element in BST - tree root
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool Remove(Node<T> node)
        {
            return Remove(node, root);
        }

        /// <summary>
        /// Remove a element in BST
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool Remove(Node<T> item, Node<T> nodeTree)
        {
            Node<T> node = nodeTree;
            if (item == null)
            {
                return false;
            }
            
            while (node != null)
            {
                if (node.CompareTo(item) == 0)
                {
                    if (node.Right == null && node.Left == null)//no child
                    {
                        var parent = FindParent(node);
                        if (parent.Item1==null)
                        {
                            root = null;
                            return false;
                        }
                        parent.Item1.Left = parent.Item2 == -1 ? null : parent.Item1.Left;
                        parent.Item1.Right = parent.Item2 == 1 ? null : parent.Item1.Right;
                        return true;
                    }

                    if (node.Right == null)
                    {
                        node.Data = node.Left.Data;
                        var right = node.Left == null ? null : node.Left.Right;
                        node.Left = node.Left == null ? null : node.Left.Left;
                        node.Right = right;
                        return true;
                    }
                    else if (node.Left == null)
                    {
                        node.Data = node.Right.Data;

                        var left = node.Right == null ? null : node.Right.Left;
                        node.Right = node.Right == null ? null : node.Right.Right;
                        node.Left = left;
                        return true;
                    }
                    else//two child
                    {
                        var suc = Successor(node) as Node<T>;// (T)node.Successor();
                                                             //var nodeFind = FindNode(suc);
                        var parent = FindParent(suc);


                        if (parent.Item1.Data.Equals(item.Data))
                        {
                            parent.Item1.Right = suc.Right;
                            node.Data = suc.Data;
                            return true;
                        }
                        if (suc.Right != null)
                        {
                            parent.Item1.Right = suc.Right;
                        }
                        else
                        {
                            parent.Item1.Left = null;
                        }
                        node.Data = suc.Data;
                        return true;
                    }
                }
                if (node < item)
                {
                    node = node.Right;
                }
                else
                {
                    node = node.Left;
                }
            }
            return false;
            //throw new NotImplementedException();
        }
        #endregion

        #region Find Parent's node  
        /// <summary>
        /// Searches for an parent of element that matches the conditions defined by the specified
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public Tuple<Node<T>, int> FindParent(Node<T> node)
        {
            int check = 0;
            if (node == null)
            {
                return null;
            }
            Node<T> temp = root;
            Node<T> parent = null;
            while (temp != null)
            {
                if (temp.CompareTo(node) == 0)
                {
                    return new Tuple<Node<T>, int>(parent, check);// temp;
                }
                if (temp > node)
                {
                    parent = temp;
                    check = -1;
                    temp = temp.Left;
                }
                else
                {
                    parent = temp;
                    check = 1;
                    temp = temp.Right;

                }
            }
            return null;
        }

        #endregion

        #region Find a node
        /// <summary>
        /// Searches for an element that matches the conditions defined by the specified
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public Node<T> FindNode(Node<T> node)
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
            //throw new NotImplementedException();
        }

        #endregion

        /// <summary>
        /// Adds an object to the BST
        /// </summary>
        /// <param name="item"></param>
        public void Insert(Node<T> item)
        {
            Node<T> temp = root;
            if (item == null)
            {
                return;
            }
            if (root == null)
            {
                root = new Node<T>(item.Data,1);
                return;
            }
            //Node<T> temp = root;
            while (item != null)
            {
                if (temp.Data.Equals(item.Data))
                {
                    break;
                }
                temp.Size = 1 + Size(temp);
                if (item < temp)
                {
                    if (temp.Left != null)
                    {
                        
                        temp = temp.Left;
                    }
                    else
                    {
                        temp.Left = item;
                        
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
                //item.Size = 1 + Size(item.Left) + Size(item.Right);
            }
        }

        public int Rank(Node<T> node, Node<T> nodeTree)
        {
            if (nodeTree == null) return 0;
            int cmp = node.CompareTo(nodeTree);
            if (cmp < 0) return Rank(node, nodeTree.Left);
            else if (cmp > 0) return 1 + Size(nodeTree.Left) + Rank(node, nodeTree.Right);
            else return Size(nodeTree.Left);
        }
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

    }
}
