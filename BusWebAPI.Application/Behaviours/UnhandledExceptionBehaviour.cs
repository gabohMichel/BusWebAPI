﻿using MediatR; 

namespace BusWebAPI.Application.Behaviours
{
    public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
			try
			{
				return await next();
			}
			catch (Exception e)
			{
				var requestName = typeof(TRequest).Name;
				throw;
			}
        }
    }
}
