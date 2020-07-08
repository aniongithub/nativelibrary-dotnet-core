﻿using System;
using System.Runtime.InteropServices;

// TODO: Need to generate a public header from the contents of all methods exported with
// UnmanagedCallersOnlyAttribute
namespace NativeLibrary
{
    public class Class1
    {
        [UnmanagedCallersOnly(EntryPoint = "add")]
        public static int Add(int a, int b)
        {
            return a + b;
        }

        [UnmanagedCallersOnly(EntryPoint = "write_line")]
        public static int WriteLine(IntPtr pString)
        {
            // The marshalling code is typically auto-generated by a custom tool in larger projects.
            try
            {
                // UnmanagedCallersOnly methods only accept primitive arguments. The primitive arguments
                // have to be marshalled manually if necessary.
                string str = Marshal.PtrToStringAnsi(pString);

                Console.WriteLine(str);
            }
            catch
            {
                // Exceptions escaping out of UnmanagedCallersOnly methods are treated as unhandled exceptions.
                // The errors have to be marshalled manually if necessary.
                return -1;
            }
            return 0;
        }

        [UnmanagedCallersOnly(EntryPoint = "sumstring")]
        public static IntPtr sumstring(IntPtr first, IntPtr second)
        {
            // Parse strings from the passed pointers 
            string my1String = Marshal.PtrToStringAnsi(first);
            string my2String = Marshal.PtrToStringAnsi(second);

            // Concatenate strings 
            string sum = my1String + my2String;

            // Assign pointer of the concatenated string to sumPointer
            IntPtr sumPointer = Marshal.StringToHGlobalAnsi(sum);

            // Return pointer
            return sumPointer;
        }    
    }
}
