
using Firebase.Storage;
using System.Text.RegularExpressions;

namespace ManagerBack.Sistem;

public class UploadImage
{
    public async Task<string>  UploadBase64Image(string base64Image) 
    {

        var fileName = Guid.NewGuid().ToString() + ".jpg";

        var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(base64Image, "");

        byte[] imageBytes = Convert.FromBase64String(data);

        using (var memoryStream = new MemoryStream(imageBytes))
        {
            var task = new FirebaseStorage("learn-6c1b7.appspot.com")
                .Child("data")
                .Child("random")
                .Child(fileName)
                .PutAsync(memoryStream);

            return await task;
        }
    


    /*        var fileName = Guid.NewGuid().ToString() + ".jpg";

            var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(base64Image, "");

            byte[] imageBytes = Convert.FromBase64String(data);

            var blobClient = new BlobClient("Key", container, fileName);

            using (var stream = new MemoryStream(imageBytes))
            {
                blobClient.Upload(stream);
            }

            return blobClient.Uri.AbsoluteUri;*/

}
}
