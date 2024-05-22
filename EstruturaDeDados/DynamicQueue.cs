namespace EstruturaDeDados
{
    public class DynamicQueue<T>
    {
        private NodeDynamicQueue<T> _front;
        private NodeDynamicQueue<T> _rear;
        private int _count;

        public DynamicQueue()
        {
            _front = null;
            _rear = null;
            _count = 0;
        }

        public void Enqueue(T data)
        {
            var newNode = new NodeDynamicQueue<T>
            {
                Data = data
            };

            if (_front == null)
            {
                _front = newNode;
            }
            else
            {
                _rear.Next = newNode;
            }

            _rear = newNode;
            _count++;
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new Exception("Queue is empty");
            }

            _count--;
            var tempItem = _front.Data;
            _front = _front.Next;
            if (_front == null)
            {
                _rear = null;
            }

            return tempItem;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return _front.Data;
        }

        public void Clear()
        {
            _front = null;
            _rear = null;
            _count = 0;
        }

        public bool IsEmpty()
        {
            return _front == null;
        }

        public int Count()
        {
            return _count;
        }
    }

    public class NodeDynamicQueue<T>
    {
        public T Data { get; set; }
        public NodeDynamicQueue<T> Next { get; set; }
    }
}
