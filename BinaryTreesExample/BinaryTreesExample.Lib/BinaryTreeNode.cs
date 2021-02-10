namespace BinaryTreesExample.Lib
{
    /// <summary>
    /// The BinaryTreeNode class is internal, so only things inside the BinaryTreeExample.Lib 
    /// namespace can access it. 
    /// </summary>
    internal class BinaryTreeNode
    {
        // by default the lack of an access modifier inside a class means 'private' so only 
        // methods inside this class can 'see' these variables. This does, though, mean that 
        // other instances of BinaryTreeNodes can 'see' them. 
        // https://stackoverflow.com/questions/12355372/private-member-accessible-from-other-instances-of-the-same-class
        
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

        internal int Depth { 
            get
            {
                if (_left == null && _right == null)
                    return 1;
                int l = _left == null ? 0 : _left.Depth;
                int r = _right == null ? 0 : _right.Depth;
                return 1 + System.Math.Max(l, r);
            }
        }

        internal int Minimum
        {
            get
            {
                if (_left == null)
                    return _value;
                return _left.Minimum;
            }
        }

        internal bool IsPresent(int target)
        {
            if (_value == target)
                return true;

            if (_value > target)
                return (_left == null ? false : _left.IsPresent(target));

            return (_right == null ? false : _right.IsPresent(target));
        }

        /// <summary>
        /// Removes the target node
        /// </summary>
        /// <param name="doomed">the value that is to be removed</param>
        /// <returns>The node that should replace the node that was being pointed at (it might be the same)</returns>
        internal BinaryTreeNode Remove(int doomed)
        {
            // first choice: does the current node equal the doomed value? 
            if(_value == doomed)
            {
                // if I am to be deleted, what should I be replaced by? 3 choices: 
                // 1/3 if there are no children 
                if (_left == null && _right == null)
                    return null;
                // 2/3 if there's one children, return it 
                if (_left == null) // no need to check if right is null because it can't be 
                    return _right;
                // and vice versa 
                if (_right == null)
                    return _left;
                // 3/3 we need to replace our value with the lowest from the right subtree, 
                // and delete that from the subtree 
                int least = _right.Minimum;
                _right = _right.Remove(least);
                _value = least;
                return this;


            } else
            {
                // it doesn't so go left or right, updating the subtree accordingly 
                // in either case, if the subtree is null do nothing with it and either 
                // way return itself 
                if (doomed < _value && _left != null) 
                    _left = _left.Remove(doomed);
                if (doomed > _value && _right!= null)
                    _right = _right.Remove(doomed);
                    
                return this;
            }
        }

        public override string ToString()
        {
            return $"Value = {_value}";
        }
    }
}

