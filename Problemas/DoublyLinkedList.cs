using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problemas
{
    public class DoublyLinkedList
    {
        public Node Head {  get; set; }

        public Node Last { get; set; }

        public Node Middle { get; set; }
        public int Count { get; set; }

        public DoublyLinkedList() 
        {
            Count = 0;
        }


        public bool isEmpty()
        {
            return Head == null;
        }

        public void InsertLast(int value)
        {
            Node NewNode = new Node(value);

            if (isEmpty())
            {
                Head = NewNode;
                Last = Head;

            }

            else
            {
                NewNode.Previous = Last;
                Last.Next = NewNode;
                Last = NewNode;
                
            }

            Count++;
            UpdateMiddle();
        }


        public void UpdateMiddle()
        {
            if (Count == 0)
            {
                Middle = null;
                return;
            }

            Node current = Head;
            int middleIndex = Count / 2;
            for (int i = 0; i < middleIndex; i++)
            {
                current = current.Next;
            }
            Middle = current;
        }

        public int GetMiddle()
        {
            return Middle.Data;
        }


        public void DeleteFirst()
        {
            Head = Head.Next;
            Head.Previous = null;
            Count--;
            UpdateMiddle();
        }

        public void DeleteLast()
        {
            Last = Last.Previous;
            Last.Next = null;
            Count--;
            UpdateMiddle();
        }

        public void PrintList()
        {
            if (isEmpty())
            {
                Console.WriteLine("The list is empty.");
                return;
            }

            Node current = Head;
            Console.Write("LA LISTA ES: ");

            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }

            Console.WriteLine(); // Salto de línea al final
        }

        public void InsertInOrder(int value)

        {

            Node newNode = new Node(value);
            

            if (isEmpty())
            {
                Head = newNode;
                Last = Head;
                
            }

            else if (newNode.Data >= Last.Data)
            {
                InsertLast(newNode.Data);
            }

            // Caso 3: Insertar en el lugar correcto dentro de la lista
            else
            {
                Node index = Head;

                // Encuentra la posición adecuada
                while (index != null && value >= index.Data)
                {
                    index = index.Next;
                }

                // Si el nuevo nodo debe ir al principio
                if (index == Head)
                {
                    newNode.Next = Head;
                    Head.Previous = newNode;
                    Head = newNode;
                }
                // Si el nuevo nodo debe ir en cualquier otro lugar (antes de "index")
                else
                {
                    newNode.Previous = index.Previous;
                    newNode.Next = index;

                    if (index.Previous != null)
                    {
                        index.Previous.Next = newNode;
                    }

                    index.Previous = newNode;
                }
            }

            Count++;
            UpdateMiddle();





        }













    }
}
