using System;

namespace Interface
{
    public class MyClass : IFile1, IFile2 //implement 3(cách 1) hay 4(cách 2) phương thức.
    {
        // //Cách 1:
        // public void A()
        // {
        //     Console.WriteLine("A");
        // }

        // public void B()
        // {
        //     Console.WriteLine("B");
        // }

        // public void C()
        // {
        //     Console.WriteLine("C");
        // }

        // public void F()
        // {
        //     Console.WriteLine("F");
        // }
        //Cách 2: bỏ cụm từ public và thay vào tên lớp interface trước tên hàm

            public void F()
            {
                Console.WriteLine("F");
            }

            void IFile1.A()
            {
                Console.WriteLine("A1");
            }

            void IFile2.A()
            {
                Console.WriteLine("A2");
            }

            void IFile1.B()
            {
                Console.WriteLine("B");
            }

            void IFile2.C()
            {
                Console.WriteLine("C");
            }
        }
    }
    