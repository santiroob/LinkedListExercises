using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problemas
{
    public class Program
    {
        public enum SortDirection
        {
            Ascending,
            Descending
        }

        public DoublyLinkedList  MergeSorted(DoublyLinkedList A, DoublyLinkedList B, SortDirection Direction)
        {
            Console.WriteLine("Merging:");
            A.PrintList();
            B.PrintList();

            if (A.Head == null)
            {
                A.Head = B.Head;
                A.Last = B.Last;
                A.Count = B.Count;
                if (Direction != SortDirection.Ascending)
                {
                    InvertList(A);
                }
                A.PrintList();
                A.UpdateMiddle();
                return A;
            }

            if (B.Head == null)
            {
                if (Direction != SortDirection.Ascending)
                {
                    InvertList(A);
                }
                A.PrintList();
                A.UpdateMiddle();
                return A ;
            }
           

            Node currentA = A.Head;
            Node currentB = B.Head;

            while (currentB != null)
            {
                if (currentA == null) // Si la lista A se termina, inserta el resto de la lista B.
                {
                    A.Last.Next = currentB;
                    currentB.Previous = A.Last;
                    A.Last = B.Last;
                    A.Count += B.Count;
                    break;
                }
                else if (currentB.Data < currentA.Data)
                {
                    // Insertar el nodo de B antes del nodo actual de A.
                    Node nextB = currentB.Next;
                    if (currentA.Previous == null) // Insertar al principio
                    {
                        A.Head.Previous = currentB;
                        currentB.Next = A.Head;
                        A.Head = currentB;
                    }
                    else
                    {
                        currentB.Previous = currentA.Previous;
                        currentA.Previous.Next = currentB;
                        currentB.Next = currentA;
                        currentA.Previous = currentB;
                    }
                    A.Count++;
                    currentB = nextB;
                }
                else
                {
                    currentA = currentA.Next; // Continuar en la lista A.
                }
            }

            

            if (Direction != SortDirection.Ascending)
            {
                InvertList(A);
            }

            A.UpdateMiddle();
            return A;
        }

        public static DoublyLinkedList InvertList(DoublyLinkedList list)
        {
            Node current = list.Head;
            Node temp = null;

            // Intercambiamos los punteros Next y Previous de cada nodo
            while (current != null)
            {
                temp = current.Previous;
                current.Previous = current.Next;
                current.Next = temp;
                current = current.Previous; // Nos movemos al siguiente nodo que ahora es Previous
            }

            // Ajustamos los punteros Head y Last
            if (temp != null)
            {
                list.Last = list.Head;
                list.Head = temp.Previous;
            }

            return list;
        }



        



        public static void Main(string[] args)
        {
            // Crear listas A y B
            DoublyLinkedList A = new DoublyLinkedList();
            DoublyLinkedList B = new DoublyLinkedList();

            // Insertar valores en la lista A (orden ascendente)
            A.InsertLast(10);
            A.InsertLast(60);

            Console.WriteLine("El nodo del medio de la lista A es: " + A.GetMiddle());


            // Insertar valores en la lista B (orden ascendente)
            B.InsertLast(9);
            B.InsertLast(40);
            B.InsertLast(50);
            B.InsertInOrder(35);
            B.InsertInOrder(25);

            Console.WriteLine("El nodo del medio de la lista B es: " + B.GetMiddle());


            // Mostrar listas antes de la fusión
            Console.WriteLine("Antes de la fusión:");
            Console.Write("Lista A: ");
            A.PrintList();
            Console.Write("Lista B: ");
            B.PrintList();

            // Fusionar listas
            Program p = new Program();
            p.MergeSorted(A, B, Program.SortDirection.Descending);

            // Mostrar listas después de la fusión
            Console.WriteLine("Después de la fusión:");
            A.PrintList();

            Console.WriteLine("El nodo del medio de la lista A es: " + A.GetMiddle());
        }

    }


}

    
