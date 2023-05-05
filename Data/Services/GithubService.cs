using BookWormProject.Utils.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace BookWormProject.Data.Services
{
    public class GithubService : IGithubService
    {
        private readonly IOptions<GithubOption> _options;

        public GithubService(IOptions<GithubOption> options)
        {
            _options = options;
        }

        public string UploadImage(IFormFile file)
        {
            var client = new RestClient("https://api.github.com");

            var request = new RestRequest("repos/{owner}/{repo}/contents/{path}", Method.Put);

            // Generate a unique file name
            var fileName = $"{Guid.NewGuid().ToString()}-{file.FileName}";

            // Replace with your own repository owner and repository name
            request.AddParameter("owner", _options.Value.RepositoryOwner, ParameterType.UrlSegment);
            request.AddParameter("repo", _options.Value.RepositoryName, ParameterType.UrlSegment);
            request.AddParameter("path", fileName, ParameterType.UrlSegment);


            // Convert the file to base64 string
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                var base64File = Convert.ToBase64String(fileBytes);

                // Set the request body with base64 string and file name
                request.AddJsonBody(new
                {
                    message = "Upload image",
                    content = base64File,
                    path = fileName
                });
            }

            // Set the authentication header
            request.AddHeader("Authorization", $"token {_options.Value.AccessToken}");

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                // Parse the response JSON into a JObject
                var responseJson = JObject.Parse(response.Content);

                // Return the image URL
                return responseJson["content"]["download_url"].ToString();
            }
            else
            {
                // Handle error
                throw new Exception($"Failed to upload image: {response.ErrorMessage}");
            }
        }

    }
}
