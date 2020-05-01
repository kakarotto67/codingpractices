using NHibernate.Context;
using SimpleApp.Server.Repositories.NHibernate;
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace SimpleApp.Server.Commons.WCF.NHibernate
{
  public class NHibernateUnitOfWorkMessageInspector : IDispatchMessageInspector
  {
    public object AfterReceiveRequest(ref Message request,
                                      IClientChannel channel,
                                      InstanceContext instanceContext)
    {
      try
      {
        var session = NHibernateConfiguration.SessionFactory.OpenSession();
        CurrentSessionContext.Bind(session);
      }
      catch (Exception exception)
      {
        throw new Exception(exception.Message);
      }
      return null;
    }

    public void BeforeSendReply(ref Message reply, object correlationState)
    {
      var session = CurrentSessionContext.Unbind(NHibernateConfiguration.SessionFactory);
      if (session == null) return;
      session.Flush();
      session.Close();
      session.Dispose();
    }
  }
}
