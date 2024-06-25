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

        public int CountChildren()
        {
            int count = 0;
            if (LeftChild!= null) count++;
            if (RightChild!= null) count++;
            return count;
        }

        public int Count()
        {
            int count = 1;
            if (LeftChild != null) count += LeftChild.Count();
            if (RightChild != null) count += RightChild.Count();
            // Console.WriteLine("count " + count + ": " + ToString());
            return count;
        }

        public override string ToString()
        {
            bool HasLeftChild = LeftChild!= null;
            bool HasRightChild = RightChild!= null;
            bool IsRoot = Parent == null;
            return "NodeKey: " + NodeKey + ", NodeValue: " + NodeValue + ", HasLeftChild: " + HasLeftChild + ", HasRightChild: " + HasRightChild + ", IsRoot: " + IsRoot;
        }

        public void DeepCopy(BSTNode<T> source)
        {
            NodeKey = source.NodeKey;
            NodeValue = source.NodeValue;
            // Parent = source.Parent;
            LeftChild = source.LeftChild;
            RightChild = source.RightChild;
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

            if (toDelete.Node.CountChildren() == 2)
            {
                BSTNode<T> ancestor = toDelete.Node.RightChild;
                while (ancestor.LeftChild != null) ancestor = ancestor.LeftChild;
                if (ancestor.RightChild != null)
                {
                    if (toDelete.Node.RightChild == ancestor)
                    {
                        // correct
                        if (ancestor.Parent.RightChild == ancestor) ancestor.Parent.RightChild = null;
                        else ancestor.Parent.LeftChild = null;
                        ancestor.Parent = toDelete.Node.Parent; // = null
                        ancestor.LeftChild = toDelete.Node.LeftChild;
                        toDelete.Node.LeftChild.Parent = ancestor;
                        if (toDelete.ToLeft) toDelete.Node.Parent.LeftChild = ancestor;
                        else toDelete.Node.Parent.RightChild = ancestor;
                        if (ancestor.Parent == null) Root = ancestor;
                        return true;
                    }
                    else
                    {
                        // bug mess
                        toDelete.Node.NodeKey = ancestor.NodeKey;
                        toDelete.Node.NodeValue = ancestor.NodeValue;
                        ancestor.DeepCopy(ancestor.RightChild);
                        if (ancestor.Parent == null) Root = ancestor;
                        return true;
                    }
                }
                else // ancestor is leaf
                {
                    if (ancestor.Parent.RightChild == ancestor) ancestor.Parent.RightChild = null;
                    else ancestor.Parent.LeftChild = null;
                    toDelete.Node.NodeKey = ancestor.NodeKey;
                    toDelete.Node.NodeValue = ancestor.NodeValue;
                }
                return true;
            }

            if (toDelete.Node.Parent == null && toDelete.Node.CountChildren() == 0)
            {
                Root = null;
                return true;
            }

            if (toDelete.Node.Parent == null && toDelete.Node.LeftChild == null)
            {
                Root = toDelete.Node.RightChild;
                Root.Parent = null;
                return true;
            }

            if (toDelete.Node.Parent == null && toDelete.Node.RightChild == null)
            {
                Root = toDelete.Node.LeftChild;
                Root.Parent = null;
                return true;
            }

            // Node not root

            if (toDelete.Node.CountChildren() == 0)
            {
                if (toDelete.ToLeft) toDelete.Node.Parent.LeftChild = null;
                else toDelete.Node.Parent.RightChild = null;
                return true;
            }

            if (toDelete.Node.LeftChild == null)
            {
                toDelete.Node.RightChild.Parent = toDelete.Node.Parent;
                if (toDelete.ToLeft) toDelete.Node.Parent.LeftChild = toDelete.Node.RightChild;
                else toDelete.Node.Parent.RightChild = toDelete.Node.RightChild;
                return true;
            }

            if (toDelete.Node.RightChild == null)
            {
                toDelete.Node.LeftChild.Parent = toDelete.Node.Parent;
                if (toDelete.ToLeft) toDelete.Node.Parent.LeftChild = toDelete.Node.LeftChild;
                else toDelete.Node.Parent.RightChild = toDelete.Node.LeftChild;
                return true;
            }

            return false;
        }

        public int Count() => Root == null ? 0 : Root.Count();
    }
}

