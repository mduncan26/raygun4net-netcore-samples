using System;
using System.Collections.Generic;
using Mindscape.Raygun4Net;

namespace ConsoleApp3_1
{
  class Program
  {
    private static RaygunClient _raygunClient = new RaygunClient("YOUR_APP_API_KEY");

    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");

      // Listen to the global unhandled error event
      AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

      try
      {
        // Do something here that might go wrong
        throw new Exception("Hello Raygun!");
      }
      catch (Exception e)
      {
        _raygunClient.Send(e);
      }

      PerformOperation();
    }

    private static void PerformOperation()
    {
      // Calling unsafe method without explicit error handling
      PerformUnsafeOperation();
    }

    private static void PerformUnsafeOperation()
    {
      int zero = 0;
      int one = 1;

      var value = one / zero;
    }

    private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
      _raygunClient.Send(e.ExceptionObject as Exception, new List<string>() { "UnhandledException" });
    }
  }
}