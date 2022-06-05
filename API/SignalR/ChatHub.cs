using System;
using System.Threading.Tasks;
using Application.Comments;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace API.SignalR
{
    public class ChatHub:Hub
    {
        private readonly IMediator _mediator;

        public ChatHub(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task SendComment(Create.Command command)
        {
            var comment = await _mediator.Send(command);

            await Clients.Group(command.ResourceId.ToString())
                .SendAsync("ReceiveComment", comment.Value);
        }

        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var resourceId = httpContext.Request.Query["resourceId"];
            await Groups.AddToGroupAsync(Context.ConnectionId, resourceId);
            var result = await _mediator.Send(new List.Query
            {
                ResourceId = Guid.Parse(resourceId)
            });

            await Clients.Caller.SendAsync("LoadComments", result.Value);
        }
    }
}
