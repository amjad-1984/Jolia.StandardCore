using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Jolia.Core.Providers
{
    //public class MyStreamProvider : MultipartFormDataStreamProvider
    //{
    //    public MyStreamProvider(string uploadPath) : base(uploadPath)
    //    {
    //    }
    //    public override string GetLocalFileName(HttpContentHeaders headers)
    //    {
    //        string fileName = Guid.NewGuid().ToString()
    //            + Path.GetExtension(headers.ContentDisposition.FileName.Replace("\"", string.Empty));
    //        return fileName;
    //    }
    //}
}