using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreesExample.Lib
{
    public class BinaryTree
    {
        // as with the linked list, the BTree itself hides the root node 
        BinaryTreeNode _root;

        public BinaryTree()
        {
            // we can construct with no arguments, so the _root will be null 
            // note that here a node cannot have no value, it will either exist or it 
            // won't (i.e. will be an object of class BinaryTreeNode or be null 
        }

        public BinaryTree(int rootValue)
        {
            // if the value is given, create a node of that value 
            _root = new BinaryTreeNode(rootValue);
        }

        public void Add(int newValue)
        {
            // when adding a value, we do need to determine if the root actually exists
            // first 
            if (_root == null)
                _root = new BinaryTreeNode(newValue);
            else
                // if the root exists, pass the new value into it 
                _root.Add(newValue);
        }

        public int Count
        {
            get
            {
                // if there's no root, then 0 - otherwise ask the root for the count 
                return _root == null ? 0 : _root.Count;
            }
        }
        public int Sum
        {
            get
            {
                // if there's no root, then 0 - otherwise ask the root for the count 
                return _root == null ? 0 : _root.Sum;
            }
        }
    }

    internal class BinaryTreeNode
    {
        int _value;
        BinaryTreeNode _left;
        BinaryTreeNode _right;
        internal BinaryTreeNode(int value)
        {
            _value = value;
            // a new node will have no children 
        }

        internal void Add(int value)
        {
            if (value < _value && _left == null)
            {
                _left = new BinaryTreeNode(value);
                return;
            }
            if (value >= _value && _right == null)
            {
                _right = new BinaryTreeNode(value);
                return;
            }
            // if we've not returned, we must have a not null in the appropriate direction
            (value < _value ? _left : _right).Add(value);
            
        }

        internal int Count { get { return 1 + (_left == null ? 0 : _left.Count) + (_right == null ? 0 : _right.Count); } }
        internal int Sum { get { return _value + (_left == null ? 0 : _left.Sum) + (_right == null ? 0 : _right.Sum); } }

    }
}
