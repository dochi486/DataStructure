namespace BinarySearchTree
{
    public class BinarySearchTree<T> where T : IComparable<T>
    { 
        public class Node<T>
        {
            public Node<T> Left;
            public Node<T> Right;
            public Node<T> Parent;
            public T Item;

            public Node(T item, Node<T> parent, Node<T> left, Node<T> right)
            {
                Item = item;
                Parent = parent;
                Left = left;
                Right = right;
            }

            public bool IsRootNode { get { return Parent == null; } }
            public bool IsLeftChild { get { return Parent != null && Parent.Left == this; } }
            public bool IsRightChild { get { return Parent != null && Parent.Right == this; } }
            public bool HasNoChild { get { return Left == null && Right == null; } }
            public bool HasLeftChild { get { return Left != null && Right == null; } }
            public bool HasRightChild { get { return Left == null && Right != null; } }
        }

        private Node<T> root;

        public BinarySearchTree()
        {
            this.root = null;
        }

        public bool Add(T item)
        {
            Node<T> newNode = new Node<T>(item, null, null, null);

            if (root == null)
            {
                root = newNode;
                return true;
            }

            Node<T> current = root;

            while (current != null)
            {
                if (item.CompareTo(current.Item) < 0)
                {
                    if(current.Left != null)
                        current = current.Left;
                    else
                    {
                        current.Left = newNode;
                        newNode.Parent = current;
                        break;
                    }
                }
                else if (item.CompareTo(current.Item) > 0)
                {
                    if (current.Right != null)
                        current = current.Right;
                    else
                    {
                        current.Right = newNode;
                        newNode.Parent = current;
                        break;
                    }
                }
                else
                    return false;
            }

            return true;
        }

        private void EraseNode(Node<T> node)
        {
            if (node.HasNoChild)
            {
                if (node.IsLeftChild)
                    node.Parent.Left = null;
                else if (node.IsRightChild)
                    node.Parent.Right = null;
                else
                    root = null;
            }
            else if (node.HasLeftChild || node.HasRightChild)
            {
                Node<T> parent = node.Parent;
                Node<T> child = node.HasLeftChild ? node.Left : node.Right;

                if (node.IsLeftChild)
                {
                    parent.Left = child;
                    child.Parent = parent;
                }
                else if (node.IsRightChild)
                {
                    parent.Right = child;
                    child.Parent = parent;
                }
                else
                {
                    root = child;
                    child.Parent = null;
                }
            }
            else
            {
                Node<T> nextNode = node.Right;

                while (nextNode.Left != null)
                {
                    nextNode = nextNode.Left;
                }

                node.Item = nextNode.Item;
                EraseNode(nextNode);
            }
        }

        private Node<T> FindNode(T item)
        {
            if (root == null)
                return null;

            Node<T> current = root;

            while (current != null)
            {
                if (root == null)
                    return null;

                if (item.CompareTo(current.Item) < 0)
                    current = current.Left;
                else if (item.CompareTo(current.Item) > 0)
                    current = current.Right;
                else
                    return current;
            }

            return null;
        }

    }
    

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(92);
            tree.Add(25);
        }
    }
}
