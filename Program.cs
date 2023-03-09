// See https://aka.ms/new-console-template for more information
using System;
using Microsoft.Extensions.Configuration;
using System.IO;
using Azure.Storage.Blobs;

namespace PhotoSharingApp
{
    class Program
    {
        static void Main(string [] args)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();

            //set connection string and container name
            var connectionString = configuration.GetConnectionString("StorageAccount");
            var containerName = "photos";

            //create blob container
            BlobContainerClient container = new BlobContainerClient(connectionString, containerName);

            //create the container
            container.CreateIfNotExists();

        }
    }
}

