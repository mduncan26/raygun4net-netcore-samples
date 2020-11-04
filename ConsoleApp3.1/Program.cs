using System;
using Mindscape.Raygun4Net;

namespace ConsoleApp3_1
{
  class Program
  {
    private static RaygunClient _raygunClient = new RaygunClient("YOUR_APP_API_KEY");

    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");

      try
      {
        // Do something here that might go wrong
        throw new Exception("Hello Raygun!");
      }
      catch (Exception e)
      {
        _raygunClient.Send(e);
      }
    }
  }
}