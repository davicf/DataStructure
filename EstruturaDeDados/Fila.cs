namespace EstruturaDeDados
{
    public class MinhaFila<T>
    {
        private T[] _elementos;
        private int _tamanhoMaximo;
        private int _inicio;
        private int _fim;
        private int _tamanhoAtual;

        public MinhaFila(int tamanhoMaximo)
        {
            _tamanhoMaximo = tamanhoMaximo;
            _inicio = 0;
            _fim = 0;
            _tamanhoAtual = 0;
            _elementos = new T[_tamanhoMaximo];
        }

        public void Enqueue(T item)
        {
            if (_tamanhoAtual == _tamanhoMaximo)
            {
                throw new Exception("Fila está cheia");
            }

            _elementos[_fim] = item;
            _fim = (_fim + 1) % _tamanhoMaximo;
            _tamanhoAtual++;
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new Exception("Fila está vazia");
            }

            var primeiroElemento = _elementos[_inicio];
            _elementos[_inicio] = default;
            _tamanhoAtual--;
            _inicio = (_inicio + 1) % _tamanhoMaximo;

            return primeiroElemento;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new Exception("Fila está vazia");
            }

            return _elementos[_inicio];
        }

        public bool IsEmpty()
        {
            return _tamanhoAtual == 0;
        }

        public void Clear()
        {
            _elementos = new T[_tamanhoMaximo];
            _inicio = 0;
            _fim = 0;
            _tamanhoAtual = 0;
        }

        public int Count()
        {
            return _tamanhoAtual;
        }
    }
}
