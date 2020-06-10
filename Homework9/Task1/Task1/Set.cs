using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    /// <summary>
    /// Well-defined collection of distinct objects.
    /// </summary>
    /// <typeparam name="T">Type of the stored elements.</typeparam>
    public class Set<T> : ISet<T>
    {
        private TreeNode root;
        private IComparer<T> comparer;
        private int count;

        public Set(IComparer<T> comparer)
        {
            this.comparer = comparer;
        }

        private class TreeNode : IEnumerable<T>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="TreeNode"/> class.
            /// </summary>
            /// <param name="value">Node value.</param>
            public TreeNode(T value)
            {
                Value = value;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="TreeNode"/> class.
            /// </summary>
            /// <param name="value">Node value.</param>
            /// <param name="parent">Node's parent.</param>
            public TreeNode(T value, TreeNode parent)
            {
                Value = value;
                Parent = parent;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="TreeNode"/> class.
            /// </summary>
            /// <param name="value">Node value.</param>
            /// <param name="left">Left node.</param>
            /// <param name="right">Right node.</param>
            public TreeNode(T value, TreeNode left, TreeNode right)
            {
                Value = value;
                Left = left;
                Right = right;
            }

            /// <summary>
            /// Gets node value.
            /// </summary>
            public T Value { get; }

            /// <summary>
            /// Gets or sets right node.
            /// </summary>
            public TreeNode Right { get; set; }

            /// <summary>
            /// Gets or sets left node.
            /// </summary>
            public TreeNode Left { get; set; }

            /// <summary>
            /// Gets or sets parent.
            /// </summary>
            public TreeNode Parent { get; set; }

            /// <summary>
            /// Checks if the node has no children/
            /// </summary>
            public bool IsLeaf => Right == null && Left == null;

            /// <summary>
            /// Get set enumerator function.
            /// </summary>
            /// <returns>Set elements enumerator.</returns>
            public IEnumerator<T> GetEnumerator()
            {
                if (Left != null)
                {
                    foreach (var item in Left)
                    {
                        yield return item;
                    }
                }

                yield return Value;

                if (Right != null)
                {
                    foreach (var item in Right)
                    {
                        yield return item;
                    }
                }
            }

            /// <summary>
            /// Get set enumerator function.
            /// </summary>
            /// <returns>Set elements enumerator.</returns>
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        public int Count => count;

        public bool IsReadOnly { get; } = false;

        public bool Add(T item)
        {
            if (root == null)
            {
                root = new TreeNode(item, null);
                count++;
                return true;
            }

            var currentNode = root;

            while (true)
            {
                if (comparer.Compare(currentNode.Value, item) > 0)
                {
                    if (currentNode.Left == null)
                    {
                        currentNode.Left = new TreeNode(item, currentNode);
                        count++;
                        return true;
                    }

                    currentNode = currentNode.Left;
                }
                else if (comparer.Compare(currentNode.Value, item) < 0)
                {
                    if (currentNode.Right == null)
                    {
                        currentNode.Right = new TreeNode(item, currentNode);
                        count++;
                        return true;
                    }
                    currentNode = currentNode.Right;
                }
                else
                {
                    return false;
                }
            }
        }

        public void Clear()
        {
            root = null;
            count = 0;
        }

        public bool Contains(T item)
        {
            if (root == null)
            {
                return false;
            }

            var currentNode = root;

            while (currentNode != null)
            {
                if (comparer.Compare(currentNode.Value, item) == 0)
                {
                    return true;
                }
                else if (comparer.Compare(currentNode.Value, item) > 0)
                {
                    currentNode = currentNode.Left;
                }
                else
                {
                    currentNode = currentNode.Right;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var node in this)
            {
                if(array.Length - arrayIndex < count)
                {
                    throw new ArgumentException();
                }

                array[arrayIndex] = node;
                arrayIndex++;
            }
        }

        public void ExceptWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }

            if (other.Equals(this))
            {
                Clear();
                return;
            }

            foreach (var item in other)
            {
                Remove(item);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (root != null)
            {
                return root.GetEnumerator();
            }

            return Enumerable.Empty<T>().GetEnumerator();
        }

        public void IntersectWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }

            var temporarySet = new Set<T>(comparer);

            foreach (var item in other)
            {
                temporarySet.Add(item);
            }

            var nodesToRemoveList = new List<T>();

            foreach (var node in this)
            {
                if (!temporarySet.Contains(node))
                {
                    nodesToRemoveList.Add(node);
                }
            }

            foreach (var item in nodesToRemoveList)
            {
                Remove(item);
            }
        }

        public bool IsProperSubsetOf(IEnumerable<T> other)
            => IsSubsetOf(other) && !SetEquals(other);

        public bool IsProperSupersetOf(IEnumerable<T> other)
            => IsSupersetOf(other) && !SetEquals(other);

        public bool IsSubsetOf(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }

            var temporarySet = new Set<T>(comparer);

            foreach (var node in other)
            {
                if (Contains(node))
                {
                    temporarySet.Add(node);
                }
            }

            return temporarySet.Count == count;
        }

        public bool IsSupersetOf(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var node in other)
            {
                if (!Contains(node))
                {
                    return false;
                }
            }

            return true;
        }

        public bool Overlaps(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var item in other)
            {
                if (Contains(item))
                {
                    return true;
                }
            }

            return false;
        }

        public bool Remove(T item)
        {
            TreeNode currentNode = root;
            TreeNode previousNode = null;
            int previousComparison = 0;
            int comparison = 0;

            while (currentNode != null)
            {
                previousComparison = comparison;
                comparison = comparer.Compare(item, currentNode.Value);

                if (comparison < 0)
                {
                    previousNode = currentNode;
                    currentNode = currentNode.Left;
                }
                else if (comparison > 0)
                {
                    previousNode = currentNode;
                    currentNode = currentNode.Right;
                }
                else
                {
                    count--;

                    if (previousNode != null)
                    {
                        if (currentNode.Left == null)
                        {
                            if (previousComparison < 0)
                            {
                                previousNode.Left = currentNode.Right;
                            }
                            else
                            {
                                previousNode.Right = currentNode.Right;
                            }

                            return true;
                        }

                        var right = currentNode.Right;

                        if (previousComparison < 0)
                        {
                            previousNode.Left = currentNode.Left;
                        }
                        else
                        {
                            previousNode.Right = currentNode.Left;
                        }

                        currentNode = currentNode.Left;

                        if (right == null)
                        {
                            return true;
                        }

                        while (currentNode.Right != null)
                        {
                            currentNode = currentNode.Right;
                        }

                        currentNode.Right = right;
                    }
                    else
                    {
                        if (currentNode.Left == null)
                        {
                            root = currentNode.Right;

                            return true;
                        }

                        var right = currentNode.Right;

                        root = currentNode.Left;
                        currentNode = currentNode.Left;

                        if (right == null)
                        {
                            return true;
                        }

                        while (currentNode.Right != null)
                        {
                            currentNode = currentNode.Right;
                        }

                        currentNode.Right = right;
                    }

                    return true;
                }
            }

            return false;
        }

        public bool SetEquals(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }

            var temporarySet = new Set<T>(comparer);

            foreach (var item in other)
            {
                temporarySet.Add(item);
            }

            foreach (var item in other)
            {
                if (!Contains(item))
                {
                    return false;
                }
            }

            return count == temporarySet.Count;
        }

        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }

            if (other.Equals(this))
            {
                Clear();
            }

            var temporarySet = new Set<T>(comparer);

            foreach (var item in other)
            {
                temporarySet.Add(item);
            }

            foreach (var node in temporarySet)
            {
                if (Contains(node))
                {
                    Remove(node);
                }
                else
                {
                    Add(node);
                }
            }
        }

        public void UnionWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var item in other)
            {
                Add(item);
            }
        }

        void ICollection<T>.Add(T item)
        {
            Add(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
