using System;
using System.Collections.Generic;

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

class BinaryTree
{
    public Node Root;

    // Метод для вставки элемента в дерево с использованием BFS
    public void InsertBFS(int[] keys)
    {
        if (keys.Length == 0)
            return;

        Root = new Node(keys[0]); // Первый элемент становится корнем
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(Root);

        int i = 1;
        while (i < keys.Length)
        {
            Node current = queue.Dequeue();

            // Добавляем левый потомок
            if (i < keys.Length)
            {
                current.Left = new Node(keys[i]);
                queue.Enqueue(current.Left);
                i++;
            }

            // Добавляем правый потомок
            if (i < keys.Length)
            {
                current.Right = new Node(keys[i]);
                queue.Enqueue(current.Right);
                i++;
            }
        }
    }

    // Метод для симметричного обхода дерева (InOrderTraversal)
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
        BinaryTree tree = new BinaryTree();

        Console.WriteLine("Введите элементы дерева через пробел:");
        string input = Console.ReadLine();
        int[] keys = Array.ConvertAll(input.Split(' '), int.Parse);

        tree.InsertBFS(keys);

        Console.WriteLine("Симметричный обход дерева:");
        tree.InOrderTraversal(tree.Root);
    }
}
