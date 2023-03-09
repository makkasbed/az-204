// See https://aka.ms/new-console-template for more information
using System;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace PhotoSharingApp
{
    class Program
    {
        static void Main(string [] args)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Director.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();
        }
    }
}

