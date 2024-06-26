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

            var result = TryGet(item, _root);

            itemResult = result is null ? default : result.Data;

            return itemResult is not null;
        }

        public void Remove(T item)
        {
            if (item == null)
                return;

            _root = Remove(_root, item);
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

        private NodeTree<T>? TryGet(T item, NodeTree<T> nodeCurrent)
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

            return nodeCurrent;
        }

        private NodeTree<T>? Remove(NodeTree<T> nodeCurrent, T item)
        {
            if (nodeCurrent == null)
                return null;

            var compareResult = item.CompareTo(nodeCurrent.Data);

            if (compareResult < 0)
            {
                nodeCurrent.LeftChild = Remove(nodeCurrent.LeftChild, item);
            }
            else if (compareResult > 0)
            {
                nodeCurrent.RightChild = Remove(nodeCurrent.RightChild, item);
            }
            else
            {
                if (IsLeaf(nodeCurrent))
                {
                    return null;
                }
                else if (HasOneChild(nodeCurrent))
                {
                    return nodeCurrent.LeftChild is null ? nodeCurrent.RightChild : nodeCurrent.LeftChild;
                }
                else
                {
                    nodeCurrent.Data = FindMin(nodeCurrent.RightChild).Data;
                    nodeCurrent.RightChild = Remove(nodeCurrent.RightChild, nodeCurrent.Data);
                }
            }

            return nodeCurrent;
        }

        private static bool IsLeaf(NodeTree<T> nodeToBeDeleted)
        {
            return nodeToBeDeleted.LeftChild is null &&
                            nodeToBeDeleted.RightChild is null;
        }

        private static bool HasOneChild(NodeTree<T> nodeCurrent)
        {
            return (nodeCurrent.LeftChild is null && nodeCurrent.RightChild is not null) ||
                                    (nodeCurrent.RightChild is null && nodeCurrent.LeftChild is not null);
        }

        private NodeTree<T> FindMin(NodeTree<T> node)
        {
            while (node.LeftChild != null)
            {
                node = node.LeftChild;
            }
            return node;
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
