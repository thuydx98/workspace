﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using JWS.Common.ApiResponse.ErrorResult;
using JWS.Common.Extensions;

namespace JWS.Common.ApiResponse
{
	public class ApiResult : IActionResult
	{
		public HttpCode HttpCode { get; private set; }
		public ApiJsonResult<object> Value { get; private set; }

		public static ApiResult Succeeded(object data = null) => new ApiResult
		{
			HttpCode = HttpCode.OK,
			Value = new ApiJsonResult<object>(data),
		};

		public static ApiResult Failed(HttpCode httpCode, object result = null) => new ApiResult
		{
			HttpCode = httpCode,
			Value = new ApiJsonResult<object>((int)httpCode, httpCode.GetDescription(), result),
		};

		public static ApiResult Failed(HttpCode httpCode, string errorMessage) => new ApiResult
		{
			HttpCode = httpCode,
			Value = new ApiJsonResult<object>((int)httpCode, errorMessage),
		};

		public static ApiResult Failed(ErrorCode errorCode, HttpCode httpCode = HttpCode.BadRequest) => new ApiResult
		{
			HttpCode = httpCode,
			Value = new ApiJsonResult<object>((int)errorCode, errorCode.GetDescription()),
		};

		public static ApiResult Failed(ErrorCode errorCode, object result, HttpCode httpCode = HttpCode.BadRequest) => new ApiResult
		{
			HttpCode = httpCode,
			Value = new ApiJsonResult<object>((int)errorCode, errorCode.GetDescription(), result)
		};

		public async Task ExecuteResultAsync(ActionContext context)
		{
			context.HttpContext.Response.StatusCode = (int)HttpCode;

			var result = new ObjectResult(Value)
			{
				StatusCode = (int)HttpCode,
			};

			await result.ExecuteResultAsync(context);
		}
	}
}
