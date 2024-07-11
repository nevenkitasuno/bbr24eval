using System;
using System.Collections.Generic;
using System.IO;

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

        public List<SimpleTreeNode<T>> GetAllNodes()
        {
            List<SimpleTreeNode<T>> nodes = new List<SimpleTreeNode<T>> { this };
            if (Children == null) return nodes;
            foreach (SimpleTreeNode<T> child in Children)
                nodes.AddRange(child.GetAllNodes());
            return nodes;
        }

        public List<SimpleTreeNode<T>> FindNodesByValue(T val)
        {
            List<SimpleTreeNode<T>> searchResult = new List<SimpleTreeNode<T>>();
            if (NodeValue.Equals(val)) searchResult.Add(this);
            if (Children == null) return searchResult;
            foreach (SimpleTreeNode<T> child in Children)
                searchResult.AddRange(child.FindNodesByValue(val));
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

        private bool InternalIsEvenTree() => (CountDescendants() + 1) % 2 == 0;
        public List<T> EvenTrees()
        {
            List<T> evenTreesPairs = new List<T>();
            InternalEvenTreesRecursion(evenTreesPairs);
            return evenTreesPairs;
        }
        private int InternalEvenTreesRecursion(List<T> evenTreesPairs)
        {
            if (Children == null) return 1;
            int ancestorsCount = 1;
            foreach (SimpleTreeNode<T> child in Children)
            {
                intchildAncestorsCount = child.InternalEvenTreesRecursion(evenTreesPairs);
                ancestorsCount += childAncestorsCount;
                if (childAncestorsCount % 2 == 0)
                {
                    evenTreesPairs.Add(NodeValue);
                    evenTreesPairs.Add(child.NodeValue);
                }
            }
            return ancestorsCount;
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
        public List<SimpleTreeNode<T>> GetAllNodes() => Root.GetAllNodes();

        public List<SimpleTreeNode<T>> FindNodesByValue(T val) => Root.FindNodesByValue(val);

        public void MoveNode(SimpleTreeNode<T> OriginalNode, SimpleTreeNode<T> NewParent)
        {
            if (OriginalNode != null) OriginalNode.ReplaceParent(NewParent);
        }

        public int Count() => Root.CountDescendants() + 1;

        public int LeafCount() => Root.LeafCount();

        public List<T> EvenTrees() => Root.EvenTrees();
    }
}