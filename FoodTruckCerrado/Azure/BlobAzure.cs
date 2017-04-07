using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;

namespace FoodTruckCerrado.Azure
{
    public class BlobAzure
    {
        public CloudStorageAccount storageAccount;

        public BlobAzure()
        {
            string UserConnection = string.Format("DefaultEndpointsProtocol=https;AccountName=foodtruckimg;AccountKey=8EdkctIIc1w/00L+2YFVIPhn27SDrDHk/NZLAxa0m7pKFeh5EQUkUe6Ud7bhhYplavJpFdyrGv5r01V0KJBQsQ==");
            storageAccount = CloudStorageAccount.Parse(UserConnection);
        }

        public CloudBlockBlob UploadBlob(string BlobName, Stream strem)
        {
            CloudBlobClient blobCliente = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobCliente.GetContainerReference("containerfoodtruck".ToLower());
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(BlobName);

            try
            {
                blockBlob.UploadFromStream(strem);
                return blockBlob;
            }
            catch (Exception e)
            {
                var r = e.Message;
                return null;
            }
        }

        public void DeletaBlob(string BlobNameToDelete)
        {
            CloudBlobClient blobCliente = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer conataine = blobCliente.GetContainerReference("containerfoodtruck".ToLower());
            CloudBlockBlob blockBlob = conataine.GetBlockBlobReference(BlobNameToDelete);
            blockBlob.Delete();
        }
    }
}