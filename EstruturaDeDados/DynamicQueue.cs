namespace EstruturaDeDados
{
    public class DynamicQueue<T>
    {
        private NodeDynamicQueue<T> front;
        private NodeDynamicQueue<T> rear;
        private int count;

        public DynamicQueue()
        {
            front = null;
            count = 0;
        }

        public void Enqueue(T item)
        {
            NodeDynamicQueue<T> newNode = new NodeDynamicQueue<T> { Data = item };

            if (rear == null)
            {
                front = newNode;
                rear = newNode;
            }
            else
            {
                rear.Next = newNode;
                rear = newNode;
            }

            count++;
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("A fila está vazia.");
            }

            T data = front.Data;
            front = front.Next;
            count--;

            if (front == null)
            {
                rear = null; // Se front se tornar nulo, rear também deve ser nulo
            }

            return data;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return front.Data;
        }

        public void Clear()
        {
            front = null;
            rear = null;
            count = 0;
        }

        public bool IsEmpty()
        {
            return front == null;
        }

        public int Count()
        {
            return count;
        }
    }

    public class NodeDynamicQueue<T>
    {
        public T Data { get; set; }
        public NodeDynamicQueue<T> Next { get; set; }
    }
}
