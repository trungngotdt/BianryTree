using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] aa = { 10  ,20,12,11,13,22,21,23, 15,16,17};
            
            string a = "Btn10Btn11";
            var dn = a.IndexOf("n");
            var cn = a.LastIndexOf("n");
            var bd = a.LastIndexOf("B");
            var number= a.Substring(dn + 1, bd - dn - 1);
            var numStr = a.Length - cn - 1;
            var number2 = a.Substring(cn + 1, numStr);
            var b= a.StartsWith("Btn");
            BSTree<int> tree=new BSTree<int>();
            tree.root = null;// new Node<int>(10);
            tree.AddRange(new int[] {2,3,4 });
            tree.AddRange(aa);tree.LNR();
            tree.LRN(tree.root);
            Console.WriteLine();
            tree.LNR();
            int debug = 0;
            /*
            List<int> listas = new List<int>( );
            for (int h = 0; h < 100; h++)
            {
                listas.Add(h);
                listas.Add(h);
            }
            var a = listas.AsParallel().Where(p => p == 50).ToList();
            int aaa =1;
            List<string> list = new List<string>();
            list.Add("A");
            List<string> listb = new List<string>();
            listb = list;
            listb.Add("B");
            List<string> listc = new List<string>();
            listc.Add("D");
            listc = listb;
            listc.Add("C");
            List<string> listd = new List<string>();
            listd = list;
            listd[1] = "R";
            listb = null;
            Node<int> nodeRoot;
            nodeRoot = new Node<int>(10);
            int[] aa = { 10 }; //{ 20,12,11,13,22,21,23 };//{15,16,17,10,11,12 };
            foreach (var itema in aa)
            {
                nodeRoot.Insert(new Node<int>(itema));
            }
            int debug = 0;
            Node<int> item;//= new Node<int>(3);
            Node<int> item1;//= new Node<int>(1);
            Node<int> item2;//= new Node<int>(4);
            Node<int> item3;//= new Node<int>(-4);
            Node<int> item4;
            item = new Node<int>(7);
            item1 = new Node<int>(4);
            item2 = new Node<int>(5);
            item3 = new Node<int>(71);
            item4 = new Node<int>(50);
            var temp = item;
            nodeRoot = new Node<int>(15, new Node<int>(6), new Node<int>(23));
            nodeRoot.Insert(item);
            nodeRoot.Insert(item2);
            nodeRoot.Insert(item3);
            nodeRoot.Insert(item4);
            nodeRoot.Insert(item1);
            nodeRoot.Insert(new Node<int>(1));
            nodeRoot.Insert(new Node<int>(77));
            nodeRoot.AddRange(new Node<int>[] {
                new Node<int>(76), new Node<int>(75),  new Node<int>(98), new Node<int>(99),
                new Node<int>(43),new Node<int>(44),new Node<int>(51),new Node<int>(59),new Node<int>(60)
            });
            var pp = nodeRoot.FindParent(item1);
            //nodeRoot.Remove(new Node<int>(6));
            temp = item1;
            
            var result1 = nodeRoot.Remove(item);//Delete with no child
            var result2 = nodeRoot.Remove(item1);//Delete with one child (Left)
            var result7 = nodeRoot.Remove(new Node<int>(59));//Delete with one child (Right)
            nodeRoot.Remove(item3);
                nodeRoot.Insert(null);
            var i= nodeRoot.FindNode(new Node<int>(23));
            i = null;

            var ia = nodeRoot.FindNode(new Node<int>(23));
            ia.Right = null;
            //Node<int> nodeaa = new Node<int>(aaa);
            nodeRoot.Remove(new Node<int>(23));
            */
            Console.ReadLine();
        }
    }
}
