using System;

class Node
{
    public int Data;
    public Node Left, Right;

    public Node(int data)
    {
        Data = data;
        Left = null;
        Right = null;
    }
}

class BinarySearchTree
{
    public Node Root;

    // Метод для вставки элемента в дерево
    public Node Insert(Node node, int key)
    {
        if (node == null) // Если узел пуст, создаем новый
            return new Node(key);

        if (key < node.Data)
            node.Left = Insert(node.Left, key); // Вставляем в левое поддерево
        else if (key > node.Data)
            node.Right = Insert(node.Right, key); // Вставляем в правое поддерево

        return node; // Возвращаем текущий узел
    }

    // Метод для обхода дерева в глубину (симметричный обход)
    public void InOrderTraversal(Node node)
    {
        if (node != null)
        {
            InOrderTraversal(node.Left);
            Console.Write(node.Data + " ");
            InOrderTraversal(node.Right);
        }
    }

    public static void Main()
    {
        BinarySearchTree bst = new BinarySearchTree();

        Console.WriteLine("Введите элементы дерева через пробел:");
        string input = Console.ReadLine();
        int[] keys = Array.ConvertAll(input.Split(' '), int.Parse);

        foreach (int key in keys)
        {
            bst.Root = bst.Insert(bst.Root, key); // Последовательно добавляем элементы
        }

        Console.WriteLine("Симметричный обход дерева:");
        bst.InOrderTraversal(bst.Root);
    }
}
