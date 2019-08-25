using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Timelogger.Api.BL;
using Timelogger.Api.Entities;
using Timelogger.Entities;

namespace Timelogger.Api.Controllers
{
    /// <summary>
    /// The base controller class
    /// </summary>
    public class BaseApiController : Controller
	{
        /// <summary>
        /// Execute the given method 
        /// </summary>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="methodToCall"></param>
        /// <param name="returnArguments"></param>
        protected void ExecuteGatewayCall<TReturn>(Func<TReturn> methodToCall, out TReturn returnArguments)
        {
            TReturn result = default(TReturn);
            result = methodToCall();

            returnArguments = result;
        }

        /// <summary>
        /// Execute the given methos with provided arguments
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="methodToCall"></param>
        /// <param name="argument1"></param>
        /// <param name="returnArguments"></param>
        protected void ExecuteGatewayCall<T1, TReturn>(Func<T1, TReturn> methodToCall, T1 argument1, out TReturn returnArguments)
        {
            TReturn result = default(TReturn);
            result = methodToCall(argument1);

            returnArguments = result;
        }

        /// <summary>
        /// Execute the given methos with provided arguments
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="methodToCall"></param>
        /// <param name="argument1"></param>
        /// <param name="argument2"></param>
        /// <param name="returnArguments"></param>
        protected void ExecuteGatewayCall<T1, T2, TReturn>(Func<T1, T2, TReturn> methodToCall, T1 argument1, T2 argument2, out TReturn returnArguments)
        {
            TReturn result = default(TReturn);
            result = methodToCall(argument1, argument2);

            returnArguments = result;
        }
    }
}
