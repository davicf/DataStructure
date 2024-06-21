namespace EstruturaDeDados
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        private NodeTree<T> _root;

        public BinarySearchTree()
        {
            _root = null;
        }

        public void Insert(T item)
        {
            if (item is null)
                return;

            _root = Insert(_root, item);
        }

        public void Remove(T item)
        {

        }

        public void DeleteTree(NodeTree<T> currentNode)
        {

        }

        public NodeTree<T> GetRoot()
        {
            return _root;
        }

        public bool TryGet(T item, out T? itemResult)
        {
            if (item is null)
            {
                itemResult = default;
                return false;
            }

            itemResult = TryGet(item, _root);

            return itemResult is not null;
        }

        private NodeTree<T> Insert(NodeTree<T> node, T item)
        {
            if (node is null)
                return new NodeTree<T> { Data = item };

            var compareResult = node.Data.CompareTo(item);

            if (compareResult > 0)
            {
                node.LeftChild = Insert(node.LeftChild, item);
            }
            else if (compareResult < 0)
            {
                node.RightChild = Insert(node.RightChild, item);
            }

            return node;
        }

        private T? TryGet(T item, NodeTree<T> nodeCurrent)
        {
            if (nodeCurrent is null)
            {
                return default;
            }

            var resultCompare = nodeCurrent.Data.CompareTo(item);

            if (resultCompare > 0)
            {
                return TryGet(item, nodeCurrent.LeftChild);
            }
            else if (resultCompare < 0)
            {
                return TryGet(item, nodeCurrent.RightChild);
            }

            return nodeCurrent.Data;
        }

        public bool IsEmpty()
        {
            return _root is null;
        }

        void PrintPreOrder(NodeTree<T> node)
        {

        }

        void PrintInOrder(NodeTree<T> node)
        {

        }

        void PrintPostOrder(NodeTree<T> node)
        {

        }
    }

    public class NodeTree<T>
    {
        public T Data;
        public NodeTree<T> LeftChild { get; set; }
        public NodeTree<T> RightChild { get; set; }
    }

    public class Student : IComparable<Student>
    {
        private static int nextId = 1;

        public int Id { get; private set; }
        public string Name { get; private set; }

        public Student(string name)
        {
            Id = nextId++;
            Name = name;
        }

        public int CompareTo(Student other)
        {
            return Id.CompareTo(other.Id);
        }
    }
}
