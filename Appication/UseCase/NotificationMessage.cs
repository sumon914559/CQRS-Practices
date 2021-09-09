using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Appication.UseCase
{
    public class NotificationMessage : INotification
    {
        public string NotifyText { get; set; }
    }
    public class Notifier1 : INotificationHandler<NotificationMessage>
    {
        public Task Handle(NotificationMessage notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine($"Debugging from Notifier 1. Message SMS  : {notification.NotifyText} ");
            return Task.CompletedTask;
        }
    }

    public class Notifier2 : INotificationHandler<NotificationMessage>
    {
        public Task Handle(NotificationMessage notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine($"Debugging from Notifier 2. Message Mail : {notification.NotifyText} ");
            return Task.CompletedTask;
        }
    }
    public class Notifier3 : INotificationHandler<NotificationMessage>
    {
        public Task Handle(NotificationMessage notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine($"Debugging from Notifier 3. Message DB Update2 : {notification.NotifyText} ");
            return Task.CompletedTask;
        }
    }
    
    public class ResultMessage : IRequest<string>
    {
        public ResultMessage(string notifyText)
        {
            NotifyText = notifyText;
        }

        public string NotifyText { get; private set; }
    }
    public class Result1 : IRequestHandler<ResultMessage,string>
    {
        private readonly IMediator _mediator;

        public Result1(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<string> Handle(ResultMessage request, CancellationToken cancellationToken)
        {
            await _mediator.Publish(new NotificationMessage { NotifyText =  request.NotifyText});
            return "Result Message Main Db: "+request.NotifyText;
        }
    }
}