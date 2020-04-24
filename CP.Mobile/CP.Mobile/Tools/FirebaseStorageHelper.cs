using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CP.Mobile.Tools
{
    public class FirebaseStorageHelper
    {
        FirebaseStorage firebaseStorage;
        public FirebaseStorageHelper(string path)
        {
            firebaseStorage = new FirebaseStorage(path);
        }

        public async Task<string> UploadFile(Stream fileStream, string fileName)
        {
            //XamarinMonkeys Storage İçindeki klasör adıdır yoksa klasör kendisi ekler. 

            var imageUrl = await firebaseStorage
                .Child("XamarinMonkeys")
                .Child(fileName)
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
