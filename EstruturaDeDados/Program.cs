// See https://aka.ms/new-console-template for more information
using EstruturaDeDados;

ExecuteQueue();
ExecuteStack();
ExecuteDynamicQueue();
ExecuteDynamicStack();
ExecuteBinarySearchTree();

static void ExecuteQueue()
{
    var fila = new EstruturaDeDados.Queue<string>(3);

    fila.Enqueue("Primeiro");
    fila.Enqueue("Segundo");
    fila.Enqueue("Terceiro");

    Console.WriteLine("Exibindo elementos da fila com " + fila.Count() + " elementos");
    while (!fila.IsEmpty())
    {
        Console.WriteLine("Elemento removido: " + fila.Dequeue());
    }
}

static void ExecuteStack()
{
    var pilha = new EstruturaDeDados.Stack<int>(3);

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
}

static void ExecuteDynamicStack()
{
    DynamicStack<int> dynamicStack = new DynamicStack<int>();

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
}

static void ExecuteDynamicQueue()
{
    DynamicQueue<int> dynamicQueue = new DynamicQueue<int>();

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
}

static void ExecuteBinarySearchTree()
{
    var binaryTree = new BinarySearchTree<Student>();

    var seventhStudent = new Student("Name 1");
    var fifthStudent = new Student("Name 2");
    var sixthStudent = new Student("Name 3");
    binaryTree.Insert(fifthStudent);
    binaryTree.Insert(new Student("Name 4"));
    binaryTree.Insert(new Student("Name 5"));
    binaryTree.Insert(new Student("Name 6"));
    binaryTree.Insert(sixthStudent);
    var fourthStudent = new Student("Name 7");
    binaryTree.Insert(fourthStudent);
    binaryTree.Insert(seventhStudent);

    Console.WriteLine("Pre Order");
    binaryTree.PrintPreOrder();

    Console.WriteLine("In Order");
    binaryTree.PrintInOrder();

    Console.WriteLine("Post Order");
    binaryTree.PrintPostOrder();

    Console.WriteLine("Delete tree");
    binaryTree.DeleteTree();
    ////Student? studentResult;
    ////var success = binaryTree.TryGet(fifthStudent, out studentResult);
    ////Console.WriteLine("Elemento:" + studentResult.Name);

    //binaryTree.Remove(fifthStudent);
    //var success2 = binaryTree.TryGet(fifthStudent, out studentResult);
    //Console.WriteLine("Elemento:" + studentResult?.Name);
}