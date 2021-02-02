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

        public override string ToString()
        {
            return $"Value = {_value}";
        }
    }
}

