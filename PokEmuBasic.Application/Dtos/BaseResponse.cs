using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Application.Dtos
{
    public class BaseResponse<T> where T : class
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
        public IDictionary<string, string[]>? Errors { get; set; }
        public PaginationMetadata? PaginationMetadata { get; set; }

        // ----------- Constructors ------------

        /// <summary>
        /// Constructor cho các response thành công hoặc lỗi chung (không có lỗi validation).
        /// </summary>
        //public BaseResponse(int statusCode, T? data, string? message = null, PaginationMetadata? paginationMetadata = null)
        //{
        //    StatusCode = statusCode;
        //    Message = message;
        //    Data = data;
        //    PaginationMetadata = paginationMetadata;
        //    Errors = null;
        //}

        /// <summary>
        /// Constructor cho các response lỗi validation.
        /// </summary>
        //public BaseResponse(int statusCode, string? message, IDictionary<string, string[]>? errors)
        //{
        //    StatusCode = statusCode;
        //    Message = message;
        //    Data = default;
        //    PaginationMetadata = null;
        //    Errors = errors;
        //}
    }

    public class BaseResponse : BaseResponse<object>
    {
    }
}
