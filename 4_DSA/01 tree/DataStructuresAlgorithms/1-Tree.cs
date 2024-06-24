using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace AlgorithmsDataStructures2
{
    public class SimpleTreeNode<T>
    {
        public T NodeValue;
        public SimpleTreeNode<T> Parent; // null for root
        public List<SimpleTreeNode<T>> Children; // null if no children
        public int Level { get; private set; }

        public SimpleTreeNode(T val, SimpleTreeNode<T> parent)
        {
            NodeValue = val;
            Parent = parent;
            Children = null;
            Level = parent == null ? 0 : parent.Level + 1;
        }

        public List<SimpleTreeNode<T>> GetDescendants()
        {
            if (Children == null) return new();
            List<SimpleTreeNode<T>> nodes = new List<SimpleTreeNode<T>>();
            foreach (SimpleTreeNode<T> child in Children)
                nodes.AddRange(child.GetDescendants());
            return nodes;
        }

        public List<SimpleTreeNode<T>> FindDescendants(T val)
        {
            if (Children == null) return new();
            List<SimpleTreeNode<T>> searchResult = new List<SimpleTreeNode<T>>();
            foreach (SimpleTreeNode<T> child in Children)
            {
                if (child.NodeValue.Equals(val)) searchResult.Add(child);
                searchResult.AddRange(child.FindDescendants(val));
            }
            return searchResult;
        }

        public int CountDescendants()
        {
            if (Children == null) return 0;
            int count = Children.Count;
            foreach (SimpleTreeNode<T> child in Children)
                count += child.CountDescendants();
            return count;
        }

        public int LeafCount()
        {
            if (Children == null) return 1;
            int count = 0;
            foreach (SimpleTreeNode<T> child in Children)
                count += child.LeafCount();
            return count;
        }

        public void RemoveChild(SimpleTreeNode<T> child)
        {
            if (Children == null) return;
            Children.Remove(child);
            if (Children.Count == 0) Children = null;
            child.Level = 0;
        }

        public void ReplaceParent(SimpleTreeNode<T> newParent) // remove parent if newParent is null
        {
            if (Parent != null) Parent.RemoveChild(this);
            if (newParent != null) newParent.AddChild(this);
            Parent = newParent;
            Level = newParent == null ? 0 : newParent.Level + 1;
        }

        public void AddChild(SimpleTreeNode<T> NewChild)
        {
            if (Children == null) Children = new List<SimpleTreeNode<T>>();
            Children.Add(NewChild);
            NewChild.Parent = this;
            NewChild.Level = Level + 1;
        }
    }

    public class SimpleTree<T>
    {
        public SimpleTreeNode<T> Root;

        public SimpleTree(SimpleTreeNode<T> root)
        {
            Root = root;
        }

        public void AddChild(SimpleTreeNode<T> ParentNode, SimpleTreeNode<T> NewChild)
        {
            if (ParentNode != null) ParentNode.AddChild(NewChild);
        }

        public void DeleteNode(SimpleTreeNode<T> NodeToDelete) => MoveNode(NodeToDelete, null); // make parent null
        public List<SimpleTreeNode<T>> GetAllNodes() => Root.GetDescendants();

        public List<SimpleTreeNode<T>> FindNodesByValue(T val) => Root.FindDescendants(val);

        public void MoveNode(SimpleTreeNode<T> OriginalNode, SimpleTreeNode<T> NewParent)
        {
            if (OriginalNode != null) OriginalNode.ReplaceParent(NewParent);
        }

        public int Count() => Root.CountDescendants() + 1;

        public int LeafCount() => Root.LeafCount();
    }
}

