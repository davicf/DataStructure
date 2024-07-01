namespace EstruturaDeDados
{
    public class AVLTree<T> where T : IComparable<T>
    {
        private NodeAVLTree<T> _root;

        public AVLTree()
        {
            _root = null;
        }

        public bool IsEmpty()
        {
            return _root is null;
        }

        public void Insert(T item)
        {
            if (item is null)
                return;

            _root = Insert(_root, item);
        }

        public void DeleteTree()
        {
            DeleteTree(_root);
        }

        public NodeAVLTree<T> GetRoot()
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

        public void PrintPreOrder()
        {
            PrintPreOrder(_root);
        }

        public void PrintInOrder()
        {
            PrintInOrder(_root);
        }

        public void PrintPostOrder()
        {
            PrintPostOrder(_root);
        }

        public void PrintPreOrder(NodeAVLTree<T> node)
        {
            if (node is not null)
            {
                Console.WriteLine(node.Data.ToString());
            }
            else
            {
                return;
            }

            PrintPreOrder(node.LeftChild);
            PrintPreOrder(node.RightChild);
        }

        private int Height(NodeAVLTree<T> node)
        {
            if (node == null)
                return -1;
            return node.Height;
        }

        private int GetBalance(NodeAVLTree<T> node)
        {
            if (node == null)
                return 0;
            return Height(node.LeftChild) - Height(node.RightChild);
        }


        ////private NodeAVLTree<T> DoRotation(NodeAVLTree<T> node)
        ////{
        ////    node.Height = 1 + Math.Max(Height(node.LeftChild), Height(node.RightChild));
        ////    var balance = GetBalance(node);

        ////    //if(balance > 1 && node.Data)
        ////}

        ////private NodeAVLTree<T> RightRotation(NodeAVLTree<T> node)
        ////{

        ////}

        ////private NodeAVLTree<T> LeftRotation(NodeAVLTree<T> node)
        ////{

        ////}

        private void PrintInOrder(NodeAVLTree<T> node)
        {
            if (node is null)
            {
                return;
            }

            PrintInOrder(node.LeftChild);

            Console.WriteLine(node.Data.ToString());

            PrintInOrder(node.RightChild);
        }

        private void PrintPostOrder(NodeAVLTree<T> node)
        {
            if (node is null)
            {
                return;
            }

            PrintPostOrder(node.LeftChild);
            PrintPostOrder(node.RightChild);

            Console.WriteLine(node.Data.ToString());
        }

        private NodeAVLTree<T> Insert(NodeAVLTree<T> node, T item)
        {
            if (node is null)
            {
                return new NodeAVLTree<T> { Data = item, Height = 0 };
            }

            var compareResult = node.Data.CompareTo(item);

            if (compareResult > 0)
            {
                node.LeftChild = Insert(node.LeftChild, item);
            }
            else if (compareResult < 0)
            {
                node.RightChild = Insert(node.RightChild, item);
            }
            else
            {
                return node;
            }

            return node;//DoRotation(node);
        }

        private NodeAVLTree<T>? TryGet(T item, NodeAVLTree<T> nodeCurrent)
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

        private NodeAVLTree<T>? Remove(NodeAVLTree<T> nodeCurrent, T item)
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

        private static bool IsLeaf(NodeAVLTree<T> nodeToBeDeleted)
        {
            return nodeToBeDeleted.LeftChild is null &&
                            nodeToBeDeleted.RightChild is null;
        }

        private static bool HasOneChild(NodeAVLTree<T> nodeCurrent)
        {
            return (nodeCurrent.LeftChild is null && nodeCurrent.RightChild is not null) ||
                                    (nodeCurrent.RightChild is null && nodeCurrent.LeftChild is not null);
        }

        private NodeAVLTree<T> FindMin(NodeAVLTree<T> node)
        {
            while (node.LeftChild != null)
            {
                node = node.LeftChild;
            }
            return node;
        }

        private void DeleteTree(NodeAVLTree<T> currentNode)
        {
            if (currentNode is not null)
            {
                DeleteTree(currentNode.LeftChild);
                DeleteTree(currentNode.RightChild);

                Remove(currentNode.Data);
            }
        }
    }

    public class NodeAVLTree<T>
    {
        public T Data;
        public NodeAVLTree<T> LeftChild { get; set; }
        public NodeAVLTree<T> RightChild { get; set; }
        public int Height { get; set; }
    }
}
