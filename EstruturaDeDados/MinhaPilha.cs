namespace EstruturaDeDados
{
    public class MinhaPilha<T>
    {
        private T[] _elementos;
        private int _top;
        private int _tamanhoMaximo;
        private int _tamanhoAtual;

        public MinhaPilha(int tamanhoMaximo)
        {
            _top = -1;
            _tamanhoMaximo = tamanhoMaximo;
            _tamanhoAtual = 0;
            _elementos = new T[tamanhoMaximo];
        }

        public void Push(T elemento)
        {
            if (_tamanhoAtual == _tamanhoMaximo)
            {
                //Ou pode ser redimensionada
                //Array.Resize(ref _elementos, _elementos.Length * 2);
                throw new Exception("Pilha cheia");
            }

            _top++;
            _elementos[_top] = elemento;
            _tamanhoAtual++;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new Exception("Pilha vazia");
            }

            var ultimoElemento = _elementos[_top];
            _elementos[_top] = default;
            _top--;
            _tamanhoAtual--;

            return ultimoElemento;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new Exception("Pilha vazia");
            }

            return _elementos[_top];
        }

        public bool IsEmpty()
        {
            return _tamanhoAtual == 0;
        }

        public int Count()
        {
            return _tamanhoAtual;
        }
    }
}
