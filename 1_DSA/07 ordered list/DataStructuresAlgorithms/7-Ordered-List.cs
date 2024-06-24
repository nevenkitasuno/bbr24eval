using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DataStructuresAlgorithms
{
  public class Node<T>
  {
    public T value;
    public Node<T> next, prev;

    public Node(T _value)
    {
      value = _value;
      next = null;
      prev = null;
    }
  }

  public class OrderedList<T>
  {
    public Node<T> head, tail;
    private bool _ascending;
    private int _count;

    public OrderedList(bool asc)
    {
      head = null;
      tail = null;
      _ascending = asc;
      _count = 0;
    }

    public int Compare(T v1, T v2)
    {
      int result = 0;

      if (typeof(T) == typeof(String)) result = String.Compare(v1.ToString(), v2.ToString()); // version for lexicographic string comparison
      else if (v1 is IComparable<T> comparable) result = comparable.CompareTo(v2); // universal comparison

      if (result < 0) result = -1;
      else if (result > 0) result = 1;

      return result;
      // -1 if v1 < v2
      // 0 if v1 == v2
      // +1 if v1 > v2
    }

    public void Add(T value)
    {
      Node<T> nodeToAdd = new Node<T>(value);

      if (head == null)
      {
        InternalInsertAfter(null, nodeToAdd);
        return;
      }

      int _criteria = _ascending ? 1 : -1;
      if (Compare(value, tail.value) == _criteria)
      {
        InternalInsertAfter(tail, nodeToAdd);
        return;
      }

      Node<T> node = head;
      while (Compare(value, node.value) == _criteria) node = node.next;
      InternalInsertAfter(node.prev, nodeToAdd);
    }

    public Node<T> Find(T val)
    {
      if (InternalIsOutsideBoundaries(val)) return null;

      Node<T> node = head;
      while (node != null)
      {
        if (InternalIsEqual(node.value, val)) return node;
        else node = node.next;
      }
      return null;
    }

    public void Delete(T val)
    {
      Node<T> node = Find(val);
      if (node == null) return;
      InternalDeleteNode(node);
    }

    private void InternalDeleteNode(Node<T> node)
    {
      if (node.prev!= null) node.prev.next = node.next;
      if (node.next!= null) node.next.prev = node.prev;
      if (node == head) head = node.next;
      if (node == tail) tail = node.prev;
      _count--;
    }

    public void Clear(bool asc)
    {
      _ascending = asc; // given by conditions of exercise
      head = null;
      tail = null;
      _count = 0;
    }

    public int Count() => _count;

    List<Node<T>> GetAll()
    {
      List<Node<T>> r = new List<Node<T>>();
      Node<T> node = head;
      while (node != null)
      {
        r.Add(node);
        node = node.next;
      }
      return r;
    }

    private void InternalInsertAfter(Node<T> _nodeAfter, Node<T> _nodeToInsert)
    {
      _count++;

      if (_nodeAfter == null)
      {
        InternalInsertHead(_nodeToInsert);
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
      _nodeToInsert.next.prev = _nodeToInsert;
    }

    private void InternalInsertHead(Node<T> _nodeToInsert)
    {
      _nodeToInsert.next = head;
      _nodeToInsert.prev = null;
      head = _nodeToInsert;
      if (head.next == null) tail = head;
      else _nodeToInsert.next.prev = _nodeToInsert;
    }

    private bool InternalIsEqual(T val1, T val2) => Compare(val1, val2) == 0;

    private bool InternalIsOutsideBoundaries(T val)
    {
      if (head == null) return true;
      if (_ascending && (Compare(val, head.value) == -1 || Compare(tail.value, val) == -1)) return true;
      if (!_ascending && (Compare(val, tail.value) == -1 || Compare(head.value, val) == -1)) return true;
      return false;
    }
  }
}

