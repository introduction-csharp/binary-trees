namespace BinaryTreesExample.Lib
{
    public class BinaryTree
    {
        // as with the linked list, the BTree itself hides the root node
        // the Console.App or the unit test has visibility here because it 
        // is public 
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

        public int Depth {
            get
            {
                // if there's no root, then 0 - otherwise ask the root for the depth 
                return _root == null ? 0 : _root.Depth;
            }
        }

        public override string ToString()
        {
            if (_root == null)
                return "count = 0";
            return $"Count = {_root.Count} [Root = {_root}]";
        }
    }
}
