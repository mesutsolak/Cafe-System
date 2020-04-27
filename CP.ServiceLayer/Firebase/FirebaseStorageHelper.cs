using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CP.ServiceLayer.Firebase
{
    public class FirebaseStorageHelper
    {
        FirebaseStorage firebaseStorage;
        public FirebaseStorageHelper(string path)
        {
            firebaseStorage = new FirebaseStorage(path);
        }

        public async Task<string> UploadFile(Stream fileStream,string imagename, string fileName)
        {
            //XamarinMonkeys Storage İçindeki klasör adıdır yoksa klasör kendisi ekler. 

            var imageUrl = await firebaseStorage
                .Child(fileName)
                .Child(imagename)
                .PutAsync(fileStream);


            return imageUrl;
        }
        public async Task<string> GetFile(string fileName)
        {
            return await firebaseStorage
                .Child("XamarinMonkeys")
                .Child(fileName)
                .GetDownloadUrlAsync();
        }
        public async Task DeleteFile(string fileName)
        {
            await firebaseStorage
                 .Child("XamarinMonkeys")
                 .Child(fileName)
                 .DeleteAsync();

        }
    }
}
