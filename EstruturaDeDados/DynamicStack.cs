namespace EstruturaDeDados
{
    public class DynamicStack<T>
    {
        private Node<T> top;
        private int QuantidadeAtual = 0;

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new Exception("Dynamic stack is empty");
            }

            var topReturn = top.Data;
            top = top.Next;
            QuantidadeAtual--;

            return topReturn;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new Exception("Dynamic stack is empty");
            }

            return top.Data;
        }

        public void Push(T data)
        {
            var novoNode = new Node<T>(data);
            novoNode.Next = top;
            top = novoNode;
            QuantidadeAtual++;
        }

        public bool IsEmpty()
        {
            return top == null;
        }

        public int Count()
        {
            return QuantidadeAtual;
        }
    }

    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }
}
