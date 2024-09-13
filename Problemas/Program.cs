using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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

        public DoublyLinkedList MergeSorted(DoublyLinkedList A, DoublyLinkedList B, SortDirection Direction)
        {
            Console.WriteLine("Merging:");
            A.PrintList();
            B.PrintList();

            if (A == null || B == null)
            {
                throw new ArgumentNullException("Both A and B must be of type DoublyLinkedList");
            }

            if (A.Head == null) // Si A está vacía, copiar todos los nodos de B a A.
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

            // Si la lista B está vacía, simplemente devuelve A (invertida si es necesario)
            if (B.Head == null)
            {
                if (Direction != SortDirection.Ascending)
                {
                    InvertList(A);
                }
                A.PrintList();
                A.UpdateMiddle();
                return A;
            }

            // Fusión de las listas A y B
            Node currentA = A.Head;
            Node currentB = B.Head;

            while (currentB != null)
            {
                if (currentA == null) // Si A se termina, inserta todo B en A
                {
                    A.Last.Next = currentB;
                    currentB.Previous = A.Last;
                    A.Last = B.Last;
                    A.Count += B.Count;
                    break;
                }
                else if (currentB.Data < currentA.Data)
                {
                    // Insertar el nodo de B antes del nodo actual de A
                    Node nextB = currentB.Next;
                    if (currentA.Previous == null) // Insertar al principio de A
                    {
                        currentB.Next = A.Head;
                        A.Head.Previous = currentB;
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
                    currentA = currentA.Next; // Continuar recorriendo A
                }
            }

            // Si es necesario invertir la lista final
            if (Direction != SortDirection.Ascending)
            {
                InvertList(A);
                A.UpdateMiddle();
            }

            // Actualizar el nodo del medio después de la fusión
            A.UpdateMiddle();
            A.PrintList();
            return A;
        }


        public DoublyLinkedList InvertList(DoublyLinkedList list)
        {

            if (list == null)
            {
                throw new ArgumentNullException("list must be of type DoublyLinkedList");
            }


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


        public int GetMiddle(DoublyLinkedList list)
        {
            if (list == null)
            {
                throw new ArgumentNullException("List is null");
            }

            else if (list.Head == null)
                    {
                        throw new ArgumentNullException("List is empty");
                    }


                    else
                    { return list.Middle.Data; }
        }




        public static void Main(string[] args)
        {
            // Crear listas A y B
            DoublyLinkedList A = new DoublyLinkedList();
            DoublyLinkedList B = new DoublyLinkedList();

            Program p = new Program();

            // Insertar valores en la lista A (orden ascendente)
            A.InsertLast(10);
            A.InsertLast(60);

            Console.WriteLine("El nodo del medio de la lista A es: " + p.GetMiddle(A));


            // Insertar valores en la lista B (orden ascendente)
            B.InsertLast(9);
            B.InsertLast(40);
            B.InsertLast(50);
            B.InsertInOrder(35);
            B.InsertInOrder(25);

            Console.WriteLine("El nodo del medio de la lista B es: " + p.GetMiddle(B));


            // Mostrar listas antes de la fusión
            Console.WriteLine("Antes de la fusión:");
            Console.Write("Lista A: ");
            A.PrintList();
            Console.Write("Lista B: ");
            B.PrintList();

            // Fusionar listas
            
            p.MergeSorted(A, B, Program.SortDirection.Descending);

            // Mostrar listas después de la fusión
            Console.WriteLine("Después de la fusión:");
            A.PrintList();

            Console.WriteLine("El nodo del medio de la lista A es: " + p.GetMiddle(A));
        }

    }


}

    
