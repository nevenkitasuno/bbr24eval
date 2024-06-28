using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Reflection;

namespace AlgorithmsDataStructures2
{
    public class BSTNode
    {
        public int NodeKey; // ключ узла
    }

    public class BSTNode<T> : BSTNode
    {
        public T NodeValue; // значение в узле
        public BSTNode<T> Parent; // родитель или null для корня
        public BSTNode<T> LeftChild; // левый потомок
        public BSTNode<T> RightChild; // правый потомок	

        public BSTNode(int key, T val, BSTNode<T> parent)
        {
            NodeKey = key;
            NodeValue = val;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }

        public int CountChildren()
        {
            int count = 0;
            if (LeftChild != null) count++;
            if (RightChild != null) count++;
            return count;
        }

        public int Count()
        {
            int count = 1;
            if (LeftChild != null) count += LeftChild.Count();
            if (RightChild != null) count += RightChild.Count();
            return count;
        }

        public override string ToString()
        {
            bool HasLeftChild = LeftChild != null;
            bool HasRightChild = RightChild != null;
            bool IsRoot = Parent == null;
            return "NodeKey: " + NodeKey + ", NodeValue: " + NodeValue + ", HasLeftChild: " + HasLeftChild + ", HasRightChild: " + HasRightChild + ", IsRoot: " + IsRoot;
        }

        public List<BSTNode> DeepAllNodes(int order) // 0 - in-order, 1 - pre-order, 2 - post-order
        {
            List<BSTNode> nodes = new List<BSTNode>();
            if (order == 1) nodes.Add(this);
            if (LeftChild != null) nodes.AddRange(LeftChild.DeepAllNodes(order));
            if (order == 0) nodes.Add(this);
            if (RightChild != null) nodes.AddRange(RightChild.DeepAllNodes(order));
            if (order == 2) nodes.Add(this);
            return nodes;
        }
    }

    // промежуточный результат поиска
    public class BSTFind<T>
    {
        // null если в дереве вообще нету узлов
        public BSTNode<T> Node;

        // true если узел найден
        public bool NodeHasKey;

        // true, если родительскому узлу надо добавить новый левым
        public bool ToLeft;

        public BSTFind() { Node = null; }
    }

    public class BST<T>
    {
        BSTNode<T> Root; // корень дерева, или null

        public BST(BSTNode<T> node)
        {
            Root = node;
        }

        public BSTFind<T> FindNodeByKey(int key) => InternalFindNodeByKey(key, Root, null, true);

        private static BSTFind<T> InternalFindNodeByKey(int key, BSTNode<T> node, BSTNode<T> parent, bool toLeft)
        {
            if (node == null) return new BSTFind<T>
            {
                Node = parent,
                NodeHasKey = false,
                ToLeft = toLeft
            };
            else if (key < node.NodeKey) return InternalFindNodeByKey(key, node.LeftChild, node, true);
            else if (key > node.NodeKey) return InternalFindNodeByKey(key, node.RightChild, node, false);
            else return new BSTFind<T>
            {
                NodeHasKey = true,
                Node = node,
                ToLeft = toLeft
            };
        }

        public bool AddKeyValue(int key, T val)
        {
            if (Root == null)
            {
                Root = new BSTNode<T>(key, val, null);
                return true;
            }
            BSTFind<T> place = FindNodeByKey(key);
            if (place.NodeHasKey) return false; // если ключ уже есть

            BSTNode<T> newNode = new(key, val, place.Node);
            if (place.ToLeft) place.Node.LeftChild = newNode;
            else place.Node.RightChild = newNode;
            return true;
        }

        public BSTNode<T> FinMinMax(BSTNode<T> FromNode, bool FindMax)
        {
            if (FromNode == null) return null;
            BSTNode<T> result = FindMax ? FromNode.RightChild : FromNode.LeftChild;
            if (result == null) return FromNode;
            return FinMinMax(result, FindMax);
        }

        public bool DeleteNodeByKey(int key)
        {
            BSTFind<T> toDelete = FindNodeByKey(key);
            if (!toDelete.NodeHasKey) return false;

            if (toDelete.Node.CountChildren() == 2) InternalDeleteNodeWithTwoChildren(toDelete);
            else if (toDelete.Node.CountChildren() == 0 && toDelete.Node.Parent != null) InternalDeleteCornerCase(toDelete);
            else InternalDeleteGeneralCase(toDelete);
            return true;
        }

        public int Count() => Root == null ? 0 : Root.Count();

        private void InternalDeleteNodeWithTwoChildren(BSTFind<T> toDelete)
        {
            BSTNode<T> ancestor = toDelete.Node.RightChild;
            while (ancestor.LeftChild != null) ancestor = ancestor.LeftChild;
            if (ancestor.RightChild != null) InternalDeleteAncestorWithChild(toDelete, ancestor);
            else InternalDeleteAncestorLeaf(toDelete, ancestor);
        }

        private void InternalDeleteAncestorWithChild(BSTFind<T> toDelete, BSTNode<T> ancestor)
        {
            if (ancestor.Parent.RightChild == ancestor) ancestor.Parent.RightChild = null;
            else ancestor.Parent.LeftChild = null;

            ancestor.Parent = toDelete.Node.Parent;

            ancestor.LeftChild = toDelete.Node.LeftChild;
            toDelete.Node.LeftChild.Parent = ancestor;

            if (toDelete.Node.RightChild == ancestor)
            {
                ancestor.RightChild = toDelete.Node.RightChild;
                toDelete.Node.RightChild.Parent = ancestor;
            }

            if (ancestor.Parent == null) Root = ancestor;
            else InternalReplaceChild(toDelete.Node.Parent, ancestor, toDelete.ToLeft);
        }
        private void InternalDeleteAncestorLeaf(BSTFind<T> toDelete, BSTNode<T> ancestor)
        {
            if (ancestor.Parent.RightChild == ancestor) ancestor.Parent.RightChild = null;
            else ancestor.Parent.LeftChild = null;
            toDelete.Node.NodeKey = ancestor.NodeKey;
            toDelete.Node.NodeValue = ancestor.NodeValue;
        }
        private void InternalDeleteCornerCase(BSTFind<T> toDelete) => InternalReplaceChild(toDelete.Node.Parent, null, toDelete.ToLeft);
        private void InternalDeleteGeneralCase(BSTFind<T> toDelete)
        {
            BSTNode<T> replacer = new(0, default, null);
            if (toDelete.Node.LeftChild == null) replacer = toDelete.Node.RightChild;
            else if (toDelete.Node.RightChild == null) replacer = toDelete.Node.LeftChild;

            if (toDelete.Node.Parent == null && toDelete.Node.CountChildren() == 0) Root = null;
            else if (toDelete.Node.Parent == null)
            {
                Root = replacer;
                Root.Parent = null;
            }
            else
            {
                replacer.Parent = toDelete.Node.Parent;
                InternalReplaceChild(toDelete.Node.Parent, replacer, toDelete.ToLeft);
            }
        }

        private void InternalReplaceChild(BSTNode<T> parent, BSTNode<T> replacer, bool isLeftChild)
        {
            if (isLeftChild) parent.LeftChild = replacer;
            else parent.RightChild = replacer;
        }

        public List<BSTNode> WideAllNodes()
        {
            List<BSTNode> nodes = new List<BSTNode>();
            if (Root == null) return nodes;
            Queue<BSTNode<T>> queue = new Queue<BSTNode<T>>();
            queue.Enqueue(Root);
            while (queue.Count > 0)
            {
                BSTNode<T> current = queue.Dequeue();
                nodes.Add(current);
                if (current.LeftChild != null) queue.Enqueue(current.LeftChild);
                if (current.RightChild != null) queue.Enqueue(current.RightChild);
            }
            return nodes;
        }

        public List<BSTNode> DeepAllNodes(int order) // 0 - in-order, 1 - pre-order, 2 - post-order
        {
            if (Root == null) return new List<BSTNode>();
            return Root.DeepAllNodes(order);
        }
    }
}

