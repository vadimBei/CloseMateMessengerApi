﻿using System.Net;
using Utils.Constants;
using Utils.Exceptions;

namespace WebClient.Implementations.Exceptions
{
    public class AuthorizationException : CustomException
    {
        public AuthorizationException(HttpStatusCode code, string errorMessage) 
            : base(code, errorMessage, BaseErrorType.WebClientError)
        {
        }
    }
}
