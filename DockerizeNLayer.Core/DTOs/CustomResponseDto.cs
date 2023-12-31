﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DockerizeNLayer.Core.DTOs
{
    // Factory Design Pattern
    public class CustomResponseDto<T>
    {
        public T Data { get; set; }

        /// <summary>
        /// JsonIgnore dememizin nedeni response bodysi içerisinde bunu dönmemize gerek olmaması, zaten statusCode dönüyor, bodyde de olmasına gerek yok, kod iinde bana lazım.
        /// </summary>
        [JsonIgnore]
        public int StatusCode { get; set; }

        public List<string> Errors { get; set; }

        //Static Factory Design Pattern > Dönülecek responseta oluşturulacak nesnenin örneklemesini kontrol altına almak için.
        public static CustomResponseDto<T> Success(int statusCode)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode };
        }
        public static CustomResponseDto<T> Success(int statusCode, T data)
        {
            return new CustomResponseDto<T> { Data = data, StatusCode = statusCode };
        }
        public static CustomResponseDto<T> Fail(int statusCode, string error)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode,Errors = new List<string> { error } };
        }
        public static CustomResponseDto<T> Fail(int statusCode, List<string> errors)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = errors };
        }
    }

}