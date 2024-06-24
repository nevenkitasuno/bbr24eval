using System;
using System.Collections.Generic;

namespace DataStructuresAlgorithms
{

    public class Node
    {
        public int value;
        public Node next, prev;

        public Node(int _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class LinkedList2
    {
        public Node head;
        public Node tail;

        public LinkedList2()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node _item)
        {
            if (head == null)
            {
                head = _item;
                head.next = null;
                head.prev = null;
            }
            else
            {
                tail.next = _item;
                _item.prev = tail;
            }
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
            if(head == null) return false;

            if(head.value == _value)
            {
                if (head.next == null) tail = null;
                head = head.next;
                if (head != null) head.prev = null;
                return true;
            }
            
            Node prevNode = head;
            Node node = head.next;
            while (node != null && node != tail)
            {
                if (node.value == _value)
                {
                    node = prevNode.next.next;
                    prevNode.next = node;
                    node.prev = prevNode;
                    return true;
                }
                else
                {
                    prevNode = node;
                    node = node.next;
                }
            }

            if (tail.value == _value)
            {
                tail = tail.prev;
                tail.next = null;
                return true;
            }

            return false;
        }

        public void RemoveAll(int _value)
        {
            while (Remove(_value))
            {continue; }
        }

        public void Clear()
        {
            head = null;
            tail = null;
        }

        public int Count()
        {
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
            if (_nodeAfter == null)
            {
                _nodeToInsert.next = head;
                _nodeToInsert.prev = null;
                head = _nodeToInsert;
                if (head.next == null)
                    tail = head;
                return;
            }

            if (_nodeAfter == tail)
            {
                _nodeAfter.next = _nodeToInsert;
                _nodeToInsert.prev = _nodeAfter;
                tail = _nodeToInsert;
                return;
            }

            _nodeToInsert.next = _nodeAfter.next;
            _nodeToInsert.prev = _nodeAfter;
            _nodeAfter.next = _nodeToInsert;
        }

    }
}

