using System;
using System.Collections.Generic;
using System.Reflection;

namespace AlgorithmsDataStructures2
{
    public class BSTNode<T>
    {
        public int NodeKey; // ключ узла
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

        public bool IsLeaf() => LeftChild == null && RightChild == null;

        public void Delete()
        {
            if (IsLeaf()) Parent.ReplaceChild(this, null);
            else if (LeftChild == null) Parent.ReplaceChild(this, RightChild);
            else if (RightChild == null) Parent.ReplaceChild(this, LeftChild);
            else
            {
                BSTNode<T> ancestor = LeftChild;
                while (ancestor.LeftChild != null) ancestor = ancestor.LeftChild;
                if (ancestor.IsLeaf()) Parent.ReplaceChild(this, ancestor);
                else
                {
                    Parent.ReplaceChild(ancestor, ancestor.RightChild);
                    Parent.ReplaceChild(this, ancestor);
                }
            }
            Parent = null;
        }
        
        public void ReplaceChild(in BSTNode<T> oldChild, BSTNode<T> newChild)
        {
            // Remove link to child from old parent
            if (newChild.Parent.LeftChild == newChild) newChild.Parent.LeftChild = null;
            if (newChild.Parent.RightChild == newChild) newChild.Parent.RightChild = null;

            // Replace child of new (this) parent
            if (NodeKey < oldChild.NodeKey) LeftChild = newChild;
            else RightChild = newChild;

            // Replace new child's link to parent
            newChild.Parent = this;
        }

        public int Count()
        {
            int count = 1;
            if (LeftChild != null) count += LeftChild.Count();
            if (RightChild != null) count += RightChild.Count();
            return count;
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
            else if (node.NodeKey < key) return InternalFindNodeByKey(key, node.LeftChild, node, true);
            else if (node.NodeKey > key) return InternalFindNodeByKey(key, node.RightChild, node, false);
            else return new BSTFind<T>
            {
                NodeHasKey = true,
                Node = node
            };
        }

        public bool AddKeyValue(int key, T val)
        {
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
            if (!toDelete.NodeHasKey) return false; // если узел не найден
            toDelete.Node.Delete();
            return true;
        }

        public int Count() => Root.Count();

    }
}