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

            //upload files
            string blobName = "docs-and-friends-selfie-stick";
            string fileName = "docs-and-friends-selfie-stick.png";

            BlobClient blobClient = container.GetBlobClient(blobName);
            blobClient.Upload(fileName, true);

            //get files
            var blobs = container.GetBlobs();
            foreach(var blob in blobs)
            {
                Console.WriteLine($"{blob.Name} --> Created On: {blob.Properties.CreatedOn:yyyy-MM-dd HH:mm:ss}  Size: {blob.Properties.ContentLength}");
            }

        }
    }
}

