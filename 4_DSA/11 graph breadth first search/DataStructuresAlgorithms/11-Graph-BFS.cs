using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsDataStructures2
{
    public class Queue<T> : IEnumerable<T>
    {
        private LinkedList<T> _elements;
        public Queue() => _elements = new LinkedList<T>();
        public void Enqueue(T item) => _elements.AddLast(item);
        public int Count => _elements.Count;
        public T Dequeue()
        {
            if (Count == 0) return default;
            T val = _elements.First.Value;
            _elements.RemoveFirst();
            return val;
        }
        public void Rotate(int n)
        {
            while (n-- > 0) Enqueue(Dequeue());
        }

        public IEnumerator<T> GetEnumerator() => _elements.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    public class Vertex<T>
    {
        public bool Hit;
        public T Value;
        public Vertex(T val)
        {
            Value = val;
            Hit = false;
        }
    }

    public class SimpleGraph<T>
    {
        public Vertex<T>[] vertex;
        public int[,] m_adjacency;
        public int max_vertex;

        public SimpleGraph(int size)
        {
            max_vertex = size;
            m_adjacency = new int[size, size];
            vertex = new Vertex<T>[size];
        }

        public void AddVertex(T value)
        {
            bool isPlaceFound = false;

            for (int i = 0; i < max_vertex && !isPlaceFound; i++)
            {
                if (vertex[i] == null)
                {
                    vertex[i] = new Vertex<T>(value);
                    isPlaceFound = true;
                }
            }
        }

        // здесь и далее, параметры v -- индекс вершины
        // в списке  vertex
        public void RemoveVertex(int v)
        {
            if (InternalIsVertex(v))
            {
                vertex[v] = null;
                for (int i = 0; i < max_vertex; i++) RemoveEdge(v, i);
            }
        }

        public bool IsEdge(int v1, int v2) => InternalIsVertex(v1, v2) && m_adjacency[v1, v2] != 0;

        public void AddEdge(int v1, int v2)
        {
            if (InternalIsVertex(v1, v2))
            {
                m_adjacency[v1, v2] = 1;
                m_adjacency[v2, v1] = 1;
            }
        }

        public void RemoveEdge(int v1, int v2)
        {
            if (InternalIsVertex(v1, v2))
            {
                m_adjacency[v1, v2] = 0;
                m_adjacency[v2, v1] = 0;
            }
        }

        private bool InternalIsVertex(int v) => 0 <= v && v < max_vertex && vertex[v] != null;
        private bool InternalIsVertex(int v1, int v2) => InternalIsVertex(v1) && InternalIsVertex(v2);

        public List<Vertex<T>> BreadthFirstSearch(int VFrom, int VTo)
        {
            if (!InternalIsVertex(VFrom, VTo)) return new();

            foreach (Vertex<T> vtx in vertex) if (vtx != null) vtx.Hit = false;
            int[] previous = new int[vertex.Count()];

            Queue<int> traverse = new();
            InternalPickVertex(traverse, VFrom, previous, -1);
            while (traverse.Count > 0)
            {
                int current = traverse.Dequeue();
                if (current == VTo) return InternalFormPath(previous, VTo);
                int edge;
                while ((edge = InternalFindNextPossible(current)) != -1) InternalPickVertex(traverse, edge, previous, current);
            }
            // узлы задаются позициями в списке vertex.
            // возвращает список узлов -- путь из VFrom в VTo
            // или пустой список, если пути нету
            return new();
        }
        private void InternalPickVertex(Queue<int> path, int v, int[] allPreviousArray, int previousOfThisVertex)
        {
            vertex[v].Hit = true;
            path.Enqueue(v);
            allPreviousArray[v] = previousOfThisVertex;
        }
        private int InternalFindNextPossible(int current)
        {
            int nextPossible = -1;
            for (int i = 0, vertexCount = vertex.Count(); i < vertexCount && nextPossible == -1; i++)
                if (IsEdge(i, current) && !vertex[i].Hit) nextPossible = i;
            return nextPossible;
        }
        private List<Vertex<T>> InternalFormPath(int[] previous, int VTo)
        {
            List<Vertex<T>> path = new();
            int current = VTo;
            while (current != -1)
            {
                path.Add(vertex[current]);
                current = previous[current];
            }
            path.Reverse();
            return path;
        }
    }
}