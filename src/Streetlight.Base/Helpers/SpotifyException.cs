using System;
using SpotifyAPI.Web.Models;

namespace Streetlight.Base.Helpers
{
    public class SpotifyException : Exception
    {
        public string ErrorMessage { get; }
        public int ErrorCode { get; }
        public SpotifyException(Error err)
        {
            ErrorMessage = err.Message;
            ErrorCode = err.Status;
        }
    }
}