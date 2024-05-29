using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Node
    {
        public int value;
        public Node next;
        public Node(int _value) { value = _value; }
    }

    public class LinkedList
    {
        public Node head;
        public Node tail;

        public LinkedList()
        {
            head = null;
            tail = null;
        }

        public LinkedList SumElements(LinkedList other)
        {
            if (other.head == null || Count() != other.Count()) return null;
            
            LinkedList result = new LinkedList();
            Node node1 = head;
            Node node2 = other.head;
            while (node1 != null)
            {
                result.AddInTail(new Node(node1.value + node2.value));
                node1 = node1.next;
                node2 = node2.next;
            }
            return result;
        }

        public void AddInTail(Node _item)
        {
            if (head == null) head = _item;
            else tail.next = _item;
            tail = _item;
        }

        public Node Find(int _value)
        {
            Node node = head;
            while (node != null)
            {
                if (node.value == _value) return node;
                node = node.next;
            }
            return null;
        }

        public List<Node> FindAll(int _value)
        {
            List<Node> nodes = new List<Node>();
            // find all nodes with given value
            Node node = head;
            while (node != null)
            {
                if (node.value == _value) nodes.Add(node);
                node = node.next;
            }
            return nodes;
        }

        public bool Remove(int _value)
        {
            // remove node with given value

            if(head == null) return false;

            if(head.value == _value)
            {
                if (head.next == null) tail = null;
                head = head.next;
                return true; // if node was removed
            }
            
            Node prev = head;

            Node node = head.next;

            while (node != null)
            {
                if (node.value == _value)
                {
                    prev.next = prev.next.next;
                    if (prev.next == null) tail = prev;
                    return true;
                }
                else
                {
                    prev = node;
                    node = node.next;
                }
            }

            return false;
        }

        /*
        public void RemoveAll(int _value)
        {
            // remove all nodes with given value

            if(head == null) return;
            
            Node prev = head;

            Node node = head.next;

            while (node != null)
            {
                if (head.value == _value)
                {
                    head = head.next;
                }
                else
                {
                    if (node.value == _value)
                    {
                        prev.next = prev.next.next;
                        node = prev.next;
                    }
                    else
                    {
                        prev = node;
                        node = node.next;
                    }
                }
            }
            if (head.next == null) tail = null;
            else tail = prev;
        }
        */

        /*
        public void RemoveAll(int _value)
        {
            // remove all nodes with given value

            if (head == null)
                return;

            while (head.value == _value)
            {
                head = head.next;
            }

            if(head == null)
            {
                tail = null;
                return;
            }
            
            Node prev = head;
            Node node = head.next;

            while (node != null)
            {
                if (node.value == _value)
                {
                    prev.next = node.next;
                    node = node.next;
                }
                else
                {
                    prev = prev.next;
                    node = prev.next.next;
                }
            }
            if (head.next == null) tail = null;
            else tail = node;
        }
        */

        public void RemoveAll(int _value)
        {
            while (Remove(_value))
            {continue; }
        }

        public void Clear()
        {
            // clear list
            head = null;
            tail = null;
        }

        public int Count()
        {
            // count nodes in list
            Node node = head;
            int count = 0;
            while (node != null)
            {
                count++;
                node = node.next;
            }
            return count;
        }

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {
            // insert node after given

            // if _nodeAfter = null , 
            // insert as first in list
            if (_nodeAfter == null)
            {
                _nodeToInsert.next = head;
                head = _nodeToInsert;
                if (head.next == null)
                tail = head;
                return;
            }

            if (_nodeAfter == tail)
            {
                _nodeAfter.next = _nodeToInsert;
                tail = _nodeToInsert;
                return;
            }

            _nodeToInsert.next = _nodeAfter.next;
            _nodeAfter.next = _nodeToInsert;
        }

        /*
        public void PrintAll()
        {
            Node node = head;
            while (node!= null)
            {
                Console.WriteLine(node.value);
                node = node.next;
            }
            Console.WriteLine();
        }
        */
    }
}

