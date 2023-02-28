using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SharedLiblary.Dtos
{
    public class Response<T> where T : class
    {
        //private set ona gore yaziram ki sirf burdadan istifade edim basqa yerden giris olmasin
        public T Data { get; private set; }
        public int StatusCode { get; private set; }

        [JsonIgnore]
        public bool IsSuccessfull { get; private set; } //Clientlere vermeyecem bunu. Ozum ucun nizamlayiram ugurlu oldu ya olmadi. Day her defe status code veya errorlar ile mueyyen etmeyim. Ele clientlere vermek istemediyim ucun [JsonIgnore] yaziram yuxarida
        public ErrorDto errorDto { get; private set; }

        public static Response<T> Succsess(T data, int statusCode)
        {
            return new Response<T>()
            {
                Data = data,
                StatusCode = statusCode,
                IsSuccessfull = true
            };
        }

        public static Response<T> Succsess(int statusCode)
        {
            return new Response<T>()
            {
                StatusCode = statusCode,
                IsSuccessfull=true
            };
        }


        public static Response<T> Fail(ErrorDto error, int statusCode)
        {
            return new Response<T>()
            {
                errorDto = error,
                StatusCode = statusCode,
                IsSuccessfull = false
            };
        }

       

    }
}
