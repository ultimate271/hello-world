using System;
using System.Runtime.InteropServices;

namespace HaskellTester
{
    public sealed class Hello : IDisposable
    {
        #region DLL imports

        [DllImport("hs\\HSdll.dll", CallingConvention=CallingConvention.StdCall)]
        private static extern void hs_init(IntPtr argc, IntPtr argv);

        [DllImport("hs\\HSdll.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern void hs_exit();

        [DllImport("hs\\HSdll.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern Int32 cFunc(Int32 a1);

        #endregion

        #region Public interface

		public static void Main() {
			System.Console.WriteLine("Hello World");
			Hello f = new Hello();
			System.Console.WriteLine(f.fibonacci(4));
			System.Console.ReadLine();
		}
        public Hello()
        {
            Console.WriteLine("Initialising DLL...");
			hs_init(IntPtr.Zero, IntPtr.Zero);
        }

        public void Dispose()
        {
            Console.WriteLine("Shutting down DLL...");
            hs_exit();
        }

        public Int32 fibonacci(Int32 i)
        {
            Console.WriteLine(string.Format("Calling c_fibonacci({0})...", i));
            Int32 result = cFunc(i);
            Console.WriteLine(string.Format("Result = {0}", result));
            return result;
        }

        #endregion
    }
}