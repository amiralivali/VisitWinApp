using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visit.Shared
{
    public class OprationResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public static OprationResult Success(string message)
        {
            string text = Messages.Success;
            text = string.Format(text, message);
            return new OprationResult()
            {
                IsSuccess = true,
                Message = text
            };
        }
        public static OprationResult Duplicate(string message)
        {
            string text = Messages.Duplicate;
            text = string.Format(text, message);
            return new OprationResult()
            {
                IsSuccess = false,
                Message = text
            };
        }
        public static OprationResult FalseValidation(string message)
        {
            string text = Messages.FalseValidation;
            text = string.Format(text, message);
            return new OprationResult()
            {
                IsSuccess = false,
                Message = text
            };
        }
        public static OprationResult RunTimeError()
        {
            return new OprationResult()
            {
                IsSuccess = false,
                Message = Messages.RunTimeError
            };
        }
    }
    public class OprationResult<T> : OprationResult
    {
        public T Data { get; set; }
        public static OprationResult<T> Succes(T data)
        {
            return new OprationResult<T>()
            {
                IsSuccess = true,
                Data = data
            };
        }
        public new static OprationResult<T> RunTimeError()
        {
            return new OprationResult<T>()
            {
                IsSuccess = false,
                Message = Messages.RunTimeError
            };
        }
    }
}
