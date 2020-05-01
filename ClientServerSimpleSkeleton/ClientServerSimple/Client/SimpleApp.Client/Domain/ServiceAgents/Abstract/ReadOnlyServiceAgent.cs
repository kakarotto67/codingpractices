using SimpleApp.Client.Commons.Rest;
using SimpleApp.Client.Domain.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleApp.Client.Domain.ServiceAgents.Abstract
{
  public abstract class ReadOnlyServiceAgent<TDto, TModel>
    where TDto : class, new()
    where TModel : class
  {
    protected ISimpleAppServiceClient ServiceClient;
    protected IMapping<TDto, TModel> Mapping;

    protected ReadOnlyServiceAgent(ISimpleAppServiceClient serviceClient,
                                   IMapping<TDto, TModel> mapping)
    {
      ServiceClient = serviceClient;
      Mapping = mapping;
    }

    protected void Get(string url, Action<List<TModel>> resultHandler, Action<Exception> errorHandler)
    {
      ServiceClient.Get<List<TDto>>(url, dto =>
        {
          List<TModel> models = null;
          if (dto != null)
          {
            models = dto.Select(Mapping.MapToDomain).ToList();
          }
          resultHandler(models);
        }, errorHandler);
    }
  }
}
