﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.GeneralImpl
{
    public class UndirectedSparseGraph<T> : IGraph<T> where T : IComparable<T>
    {
        /// <summary>
        /// INSTANCE VARIABLES
        /// </summary>
        protected virtual int _edgesCount { get; set; }
        protected virtual T _firstInsertedNode { get; set; }
        protected virtual Dictionary<T, DLinkedList<T>> _adjacencyList { get; set; }


        /// <summary>
        /// CONSTRUCTORS
        /// </summary>
        public UndirectedSparseGraph() : this(10) { }

        public UndirectedSparseGraph(uint initialCapacity)
        {
            _edgesCount = 0;
            _adjacencyList = new Dictionary<T, DLinkedList<T>>((int)initialCapacity);
        }

        /// <summary>
        /// Returns true, if graph is directed; false otherwise.
        /// </summary>
        public virtual bool IsDirected
        {
            get { return false; }
        }

        /// <summary>
        /// Returns true, if graph is weighted; false otherwise.
        /// </summary>
        public virtual bool IsWeighted
        {
            get { return false; }
        }

        /// <summary>
        /// Gets the count of vetices.
        /// </summary>
        public int VerticesCount
        {
            get { return _adjacencyList.Count; }
        }

        /// <summary>
        /// Gets the count of edges.
        /// </summary>
        public int EdgesCount
        {
            get { return _edgesCount; }
        }

        /// <summary>
        /// Returns the list of Vertices.
        /// </summary>
        public IEnumerable<T> Vertices
        {
            get
            {
                var list = new List<T>();
                foreach (var vertex in _adjacencyList.Keys)
                    list.Add(vertex);

                return list;
            }
        }

        IEnumerable<IEdge<T>> IGraph<T>.Edges
        {
            get { return this.Edges; }
        }

        IEnumerable<IEdge<T>> IGraph<T>.IncomingEdges(T vertex)
        {
            return this.IncomingEdges(vertex);
        }

        IEnumerable<IEdge<T>> IGraph<T>.OutgoingEdges(T vertex)
        {
            return this.OutgoingEdges(vertex);
        }


        /// <summary>
        /// An enumerable collection of all unweighted edges in Graph.
        /// </summary>
        public virtual IEnumerable<UnweightedEdge<T>> Edges
        {
            get
            {
                var seen = new HashSet<KeyValuePair<T, T>>();

                foreach (var vertex in _adjacencyList)
                {
                    foreach (var adjacent in vertex.Value)
                    {
                        var incomingEdge = new KeyValuePair<T, T>(adjacent, vertex.Key);
                        var outgoingEdge = new KeyValuePair<T, T>(vertex.Key, adjacent);

                        if (seen.Contains(incomingEdge) || seen.Contains(outgoingEdge))
                            continue;
                        seen.Add(outgoingEdge);

                        yield return (new UnweightedEdge<T>(outgoingEdge.Key, outgoingEdge.Value));
                    }
                }//end-foreach
            }
        }

        /// <summary>
        /// Get all incoming unweighted edges to a vertex
        /// </summary>
        public virtual IEnumerable<UnweightedEdge<T>> IncomingEdges(T vertex)
        {
            if (!HasVertex(vertex))
                throw new KeyNotFoundException("Vertex doesn't belong to graph.");

            foreach (var adjacent in _adjacencyList[vertex])
                yield return (new UnweightedEdge<T>(adjacent, vertex));
        }

        /// <summary>
        /// Get all outgoing unweighted edges from a vertex.
        /// </summary>
        public virtual IEnumerable<UnweightedEdge<T>> OutgoingEdges(T vertex)
        {
            if (!HasVertex(vertex))
                throw new KeyNotFoundException("Vertex doesn't belong to graph.");

            foreach (var adjacent in _adjacencyList[vertex])
                yield return (new UnweightedEdge<T>(vertex, adjacent));
        }

        /// <summary>
        /// Connects two vertices together.
        /// </summary>
        public virtual bool AddEdge(T firstVertex, T secondVertex)
        {
            if (HasEdge(firstVertex, secondVertex))
                return false;

            _adjacencyList[firstVertex].Append(secondVertex);
            _adjacencyList[secondVertex].Append(firstVertex);

            // Increment the edges count
            ++_edgesCount;

            return true;
        }

        /// <summary>
        /// Deletes an edge, if exists, between two vertices.
        /// </summary>
        public virtual bool RemoveEdge(T firstVertex, T secondVertex)
        {
            if (!HasEdge(firstVertex, secondVertex))
                return false;

            _adjacencyList[firstVertex].Remove(secondVertex);
            _adjacencyList[secondVertex].Remove(firstVertex);

            // Decrement the edges count
            --_edgesCount;

            return true;
        }

        /// <summary>
        /// Deletes an edge, if exists, between two vertices.
        /// </summary>
        public virtual bool RemoveEdge(UnweightedEdge<T> edge)
        {
            if (!HasEdge(edge.Source, edge.Destination))
                return false;

            _adjacencyList[edge.Source].Remove(edge.Destination);
            _adjacencyList[edge.Destination].Remove(edge.Source);

            // Decrement the edges count
            --_edgesCount;

            return true;
        }

        /// <summary>
        /// Adds a list of vertices to the graph.
        /// </summary>
        public void AddVertices(IList<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException();

            foreach (var item in collection)
                this.AddVertex(item);
        }

        /// <summary>
        /// Adds a new vertex to graph.
        /// </summary>
        public bool AddVertex(T vertex)
        {
            // Check existence of vertex
            if (_adjacencyList.ContainsKey(vertex))
                return false;

            if (_adjacencyList.Count == 0)
                _firstInsertedNode = vertex;

            _adjacencyList.Add(vertex, new DLinkedList<T>());

            return true;
        }

        /// <summary>
        /// Removes the specified vertex from graph.
        /// </summary>
        public bool RemoveVertex(T vertex)
        {
            // Check existence of vertex
            if (!_adjacencyList.ContainsKey(vertex))
                return false;

            _adjacencyList.Remove(vertex);

            foreach (var adjacent in _adjacencyList)
            {
                if (adjacent.Value.Contains(vertex))
                {
                    adjacent.Value.Remove(vertex);

                    // Decrement the edges count.
                    --_edgesCount;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks whether two vertices are connected (there is an edge between firstVertex & secondVertex)
        /// </summary>
        public virtual bool HasEdge(T firstVertex, T secondVertex)
        {
            // Check existence of vertices
            if (!_adjacencyList.ContainsKey(firstVertex) || !_adjacencyList.ContainsKey(secondVertex))
                return false;

            return (_adjacencyList[firstVertex].Contains(secondVertex) || _adjacencyList[secondVertex].Contains(firstVertex));
        }

        /// <summary>
        /// Determines whether this graph has the specified vertex.
        /// </summary>
        public bool HasVertex(T vertex)
        {
            return _adjacencyList.ContainsKey(vertex);
        }

        /// <summary>
        /// Returns the neighbours doubly-linked list for the specified vertex.
        /// </summary>
        public DLinkedList<T> Neighbours(T vertex)
        {
            if (!HasVertex(vertex))
                return null;

            return _adjacencyList[vertex];
        }

        /// <summary>
        /// Returns the degree of the specified vertex.
        /// </summary>
        public int Degree(T vertex)
        {
            if (!HasVertex(vertex))
                throw new KeyNotFoundException();

            return _adjacencyList[vertex].Count;
        }

        /// <summary>
        /// Returns a human-readable string of the graph.
        /// </summary>
        public virtual string ToReadable()
        {
            string output = string.Empty;

            foreach (var node in _adjacencyList)
            {
                var adjacents = string.Empty;

                output = String.Format("{0}\r\n{1}: [", output, node.Key);

                foreach (var adjacentNode in node.Value)
                    adjacents = String.Format("{0}{1},", adjacents, adjacentNode);

                if (adjacents.Length > 0)
                    adjacents = adjacents.TrimEnd(new char[] { ',', ' ' });

                output = String.Format("{0}{1}]", output, adjacents);
            }

            return output;
        }

        /// <summary>
        /// A depth first search traversal of the graph starting from the first inserted node.
        /// Returns the visited vertices of the graph.
        /// </summary>
        public IEnumerable<T> DepthFirstWalk()
        {
            return DepthFirstWalk(_firstInsertedNode);
        }

        /// <summary>
        /// A depth first search traversal of the graph, starting from a specified vertex.
        /// Returns the visited vertices of the graph.
        /// </summary>
        public IEnumerable<T> DepthFirstWalk(T source)
        {
            if (VerticesCount == 0)
                return new List<T>();
            if (!HasVertex(source))
                throw new Exception("The specified starting vertex doesn't exist.");

            var visited = new HashSet<T>();
            var stack = new Stack<T>(VerticesCount);
            var listOfNodes = new List<T>(VerticesCount);

            stack.Push(source);

            while (!stack.Any())
            {
                var current = stack.Pop();

                if (!visited.Contains(current))
                {
                    listOfNodes.Add(current);
                    visited.Add(current);

                    foreach (var adjacent in Neighbours(current))
                        if (!visited.Contains(adjacent))
                            stack.Push(adjacent);
                }
            }

            return listOfNodes;
        }

        /// <summary>
        /// A breadth first search traversal of the graphstarting from the first inserted node.
        /// Returns the visited vertices of the graph.
        /// </summary>
        public IEnumerable<T> BreadthFirstWalk()
        {
            return BreadthFirstWalk(_firstInsertedNode);
        }

        /// <summary>
        /// A breadth first search traversal of the graph, starting from a specified vertex.
        /// Returns the visited vertices of the graph.
        /// </summary>
        public IEnumerable<T> BreadthFirstWalk(T source)
        {
            if (VerticesCount == 0)
                return new List<T>();
            if (!HasVertex(source))
                throw new Exception("The specified starting vertex doesn't exist.");


            var visited = new HashSet<T>();
            var queue = new Queue<T>(VerticesCount);
            var listOfNodes = new List<T>(VerticesCount);

            listOfNodes.Add(source);
            visited.Add(source);

            queue.Enqueue(source);

            while (!queue.Any())
            {
                var current = queue.Dequeue();
                var neighbors = Neighbours(current);

                foreach (var adjacent in neighbors)
                {
                    if (!visited.Contains(adjacent))
                    {
                        listOfNodes.Add(adjacent);
                        visited.Add(adjacent);
                        queue.Enqueue(adjacent);
                    }
                }
            }

            return listOfNodes;
        }

        /// <summary>
        /// Clear this graph.
        /// </summary>
        public void Clear()
        {
            _edgesCount = 0;
            _adjacencyList.Clear();
        }
    }
}
