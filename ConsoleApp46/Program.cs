using System;

namespace Linkedlist
{
    class Program
    {
        public class DNode
        {
            public int data;
            public DNode prev;
            public DNode next;
            public DNode(int d)
            {
                data = d;
                prev = null;
                next = null;
            }
        }
        public class DoubleLinkedList
        {
            public DNode head;
        }
        public void InsertFront(DoubleLinkedList doubleLinkedList, int data)
        {
            DNode newNode = new DNode(data);
            newNode.next = doubleLinkedList.head;
            newNode.prev = null;
            if (doubleLinkedList.head != null)
            {
                doubleLinkedList.head.prev = newNode;
            }
            doubleLinkedList.head = newNode;
        }
        public void InsertLast(DoubleLinkedList doubleLinkedList, int data)
        {
            DNode newNode = new DNode(data);
            if (doubleLinkedList.head == null)
            {
                newNode.prev = null;
                doubleLinkedList.head = newNode;
                return;
            }
            DNode lastNode = GetLastNode(doubleLinkedList);
            lastNode.next = newNode;
            newNode.prev = lastNode;
        }
        public DNode GetLastNode(DoubleLinkedList DoubleLinkedList)
        {
            DNode temp = DoubleLinkedList.head;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            return temp;
        }
        public void InsertAfter(DNode prev_node, int data)
        {
            if (prev_node == null)
            {
                Console.WriteLine("The given prevoius node cannot be null");
                return;
            }
            DNode newNode = new DNode(data);
            newNode.next = prev_node.next;
            prev_node.next = newNode;
            newNode.prev = prev_node;
            if (newNode.next != null)
            {
                newNode.next.prev = newNode;
            }
        }
        public void DeleteNodebyKey(DoubleLinkedList doubleLinkedList, int key)
        {
            DNode temp = doubleLinkedList.head;
            if (temp != null && temp.data == key)
            {
                doubleLinkedList.head = temp.next;
                doubleLinkedList.head.prev = null;
                return;
            }
            while (temp != null && temp.data != key)
            {
                temp = temp.next;
            }
            if (temp == null)
            {
                return;
            }
            if (temp.next != null)
            {
                temp.next.prev = temp.prev;
            }
            if (temp.prev != null)
            {
                temp.prev.next = temp.next;
            }
        }
        static void Main(string[] args)
        {
            Program L = new Program();

            DoubleLinkedList list = new DoubleLinkedList();
            //add nodes to list
            L.InsertFront(list, 5);
            L.InsertFront(list, 7);
            L.InsertLast(list, 8);
            

            L.InsertAfter(list.head, 6);
            
            DNode node = list.head;
            //print list
            while(node!=null)

            {
                Console.WriteLine(node.data);
                node = node.next;

            }

            


            

        }
    }
}
