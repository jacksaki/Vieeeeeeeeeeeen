using Amazon.S3;
using Amazon.S3.Model;
using Livet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace Vieeeeeeeeeeeen.Models
{
    internal class S3Object:NotificationObject
    {
        public async Task DeleteAsync()
        {
            using (var client = new AmazonS3Client())
            {
                await client.DeleteObjectAsync(new DeleteObjectRequest
                {
                    BucketName = this.BucketName,
                    Key = this.Key,
                });
            }
        }
        public async Task<string> DownloadAsync()
        {
            using (var client = new AmazonS3Client())
            {
                var response = await client.GetObjectAsync(new GetObjectRequest()
                {
                    BucketName = this.BucketName,
                    Key = this.Key,
                });
                using (var sr = new System.IO.StreamReader(response.ResponseStream))
                {
                    return sr.ReadToEnd();
                }
            }
        }

        public async Task UploadAsync(string text)
        {
            using (var client = new AmazonS3Client())
            {
                var response = await client.PutObjectAsync(new PutObjectRequest()
                {
                    BucketName = this.BucketName,
                    Key = this.Key,
                    ContentBody = text
                });
            }
        }

        private bool _IsChecked;

        public bool IsChecked
        {
            get
            {
                return _IsChecked;
            }
            set
            { 
                if (_IsChecked == value)
                {
                    return;
                }
                _IsChecked = value;
                RaisePropertyChanged();
            }
        }
        public string FileName
        {
            get
            {
                var s = this.Key.Split('/');
                if (s.Length == 1)
                {
                    return Key;
                }
                else
                {
                    return s[s.Length - 1];
                }
            }
        }
        public string BucketName
        {
            get;
            private set;
        }
        public string Key
        {
            get;
            private set;
        }
    }
}
