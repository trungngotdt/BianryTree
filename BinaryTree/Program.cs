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
            int aaa ;
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
            temp = item1;
            nodeRoot = new Node<int>(15, new Node<int>(6), new Node<int>(23));
            nodeRoot.Insert(item);
            nodeRoot.Insert(item2);
            nodeRoot.Insert(item3);
            nodeRoot.Insert(item4);
            nodeRoot.Insert(item1);

            nodeRoot.Insert(new Node<int>(1));
            nodeRoot.Insert(new Node<int>(77));
            nodeRoot.AddRange(new Node<int>[] {
                new Node<int>(76), new Node<int>(75), new Node<int>(74), new Node<int>(98), new Node<int>(99),
                new Node<int>(43),new Node<int>(44),new Node<int>(51),new Node<int>(59),new Node<int>(60)
            });
            nodeRoot.Insert(null);
            //Node<int> nodeaa = new Node<int>(aaa);
            nodeRoot.Remove(new Node<int>(23));
            Console.ReadLine();
        }
    }
}
