﻿using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using OnlineStore.Core;

namespace OnlineStore.ServiceHost.API.Core
{
    public class WindsorHttpControllerActivator : IHttpControllerActivator
    {
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            var instance = DependencyContainer.Resolve(controllerType);

            if (instance == null)
            {
                throw new HttpException((int)HttpStatusCode.NotFound, string.Format("{0} cannot be resolved.", controllerType.Name));
            }

            return (IHttpController) instance;
        }
    }
}