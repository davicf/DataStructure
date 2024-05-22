// See https://aka.ms/new-console-template for more information
using EstruturaDeDados;

MinhaFila<string> fila = new MinhaFila<string>(3);

// Adicionando elementos à fila
fila.Enqueue("Primeiro");
fila.Enqueue("Segundo");
fila.Enqueue("Terceiro");
//fila.Enqueue("Quarto"); // Disparada exceção

// Removendo e exibindo elementos da fila
Console.WriteLine("Exibindo elementos da fila com " + fila.Count() + " elementos");
while (!fila.IsEmpty())
{
    Console.WriteLine("Elemento removido: " + fila.Dequeue());
}

MinhaPilha<int> pilha = new MinhaPilha<int>(3);

// Adicionando elementos à pilha
pilha.Push(1);
pilha.Push(2);
pilha.Push(3);
//pilha.Push(4); // Disparada exceção

Console.WriteLine("Exibindo elementos da pilha com " + pilha.Count() + " elementos");
while (!pilha.IsEmpty())
{
    Console.WriteLine("Elemento removido: " + pilha.Pop());
}

DynamicStack<int> dynamicStack = new DynamicStack<int>();

// Adicionando elementos à pilha
dynamicStack.Push(20);
dynamicStack.Push(41);
dynamicStack.Push(5);
dynamicStack.Push(98);
dynamicStack.Push(17);
dynamicStack.Push(22);

Console.WriteLine("Exibindo elementos da pilha dinâmica com " + dynamicStack.Count() + " elementos");
while (!dynamicStack.IsEmpty())
{
    Console.WriteLine("Elemento removido: " + dynamicStack.Pop());
}

DynamicQueue<int> dynamicQueue = new DynamicQueue<int>();

// Adicionando elementos à pilha
dynamicQueue.Enqueue(20);
dynamicQueue.Enqueue(41);
dynamicQueue.Enqueue(5);
dynamicQueue.Enqueue(98);
dynamicQueue.Enqueue(17);
dynamicQueue.Enqueue(22);

Console.WriteLine("Exibindo elementos da fila dinâmica com " + dynamicQueue.Count() + " elementos");
while (!dynamicQueue.IsEmpty())
{
    Console.WriteLine("Elemento removido: " + dynamicQueue.Dequeue());
}
