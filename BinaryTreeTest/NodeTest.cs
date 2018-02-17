using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using BinaryTree;

namespace BinaryTreeTest
{
    [TestFixture]
    public class NodeTest
    {
        BSTree<int> tree;
        Node<int> item;//= new Node<int>(3);
        Node<int> item1;//= new Node<int>(1);
        Node<int> item2;//= new Node<int>(4);
        Node<int> item3;//= new Node<int>(-4);
        Node<int> item4;

        [SetUp]
        public void SetUp()
        {
            item = new Node<int>(7);
            item1 = new Node<int>(4);
            item2 = new Node<int>(5);
            item3 = new Node<int>(71);
            item4 = new Node<int>(50);
            tree = new BSTree<int>();
            tree.root = new Node<int>(15, new Node<int>(6), new Node<int>(23));
            
            tree. Insert(item);
            tree.Insert(item2);
            tree.Insert(item3);
            tree.Insert(item4);
            tree.Insert(item1);
            tree.Insert(new Node<int>(1));
            tree.Insert(new Node<int>(77));
            tree.AddRange(new Node<int>[] {
                new Node<int>(76), new Node<int>(75), new Node<int>(74), new Node<int>(98), new Node<int>(99),
                new Node<int>(43),new Node<int>(44),new Node<int>(51),new Node<int>(59),new Node<int>(60)
            });
            tree.Insert(null);
        }
        
        [Test]
        public void InsertAndContainsTest()
        {
            BSTree<string> treeString = new BSTree<string>();
           
            treeString.Insert(new Node<string>("S"));
            var item1C =  tree.Contains(item1);
            var item2C = tree.Contains(item3);
            var strC = treeString.Contains(new Node<string>("S"));

            var falseCon = tree.Contains(new Node<int>());
            var falseNull = tree.Contains(null);
            Assert.IsTrue(strC);
            Assert.IsTrue(item1C);
            Assert.IsTrue(item2C);
            Assert.IsFalse(falseCon);
            Assert.IsFalse(falseNull);
        }

        [Test]
        public void GetMaxNodeAndGetMinNodeTest()
        {
            var max = tree.GetMax();
            var min = tree.GetMin();
            Assert.AreEqual(99, max.Data);
            Assert.AreEqual(1, min.Data);
            Assert.AreEqual(null, tree.GetMax(null));// (new BSTree<string>()).GetMax());
            Assert.AreEqual(null, (new BSTree<string>()).GetMin());
        }

        [Test]
        public void SuccessorAndPredecessorTest()
        {
            tree.AddRange(new Node<int>[]{item });
            var suc = tree.Successor();

            var pred = tree.Predecessor();
            Assert.AreEqual(tree.GetMin(tree.root.Right), suc);
            Assert.AreEqual(tree.GetMax(tree.root.Left), pred);
        }

        [Test]
        public void RemoveTest()
        {
            var result1= tree.Remove(item);//Delete with no child
            var result2 = tree.Remove(item1);//Delete with one child (Left)
            var result7 = tree.Remove(new Node<int>(59));//Delete with one child (Right)
            var result3 = tree.Remove(item3);//Delete with  two chid
            var result4 = tree.Remove(null);//Delete with null paramater
            var result5 = tree.Remove(new Node<int>(1000));//Doesn't have element
            var result6 = tree.Remove(tree.root);//Delete root
            var BsTree = new BSTree<int>(new Node<int>(1));
            var result8 = BsTree.Remove(new Node<int>(1));

            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
            Assert.IsFalse(result4);
            Assert.IsFalse(result5);
            Assert.IsTrue(result6);
            Assert.IsFalse(result8);
            Assert.IsFalse(tree.Contains(new Node<int>(7)));
            Assert.IsFalse(tree.Contains(new Node<int>(4)));
            Assert.IsFalse(tree.Contains(new Node<int>(59)));
            Assert.IsFalse(tree.Contains(new Node<int>(71)));
            Assert.IsFalse(tree.Contains(new Node<int>(15)));
        }

        [Test]
        public void FindParentTest()
        {
            var result = tree.FindParent(new Node<int>(43));
            var result1 = tree.FindParent(null);
            var result2 = tree.FindParent(new Node<int>(10000));
            Assert.AreSame(item4, result.Item1);
            Assert.AreEqual(-1, result.Item2);
            Assert.IsNull(result1);
            Assert.IsNull(result2);
        }

        [Test]
        public void FindNodeTest()
        {
            Node<int> result = tree.FindNode(item);
            Node<int> result1 = tree.FindNode(null);
            Node<int> result2 = tree.FindNode(new Node<int>(10000));
            Assert.IsTrue(new Node<int>(7).CompareTo( result)==0);
            Assert.IsNull(result1);
            Assert.IsNull(result2);

        }
    }
}
