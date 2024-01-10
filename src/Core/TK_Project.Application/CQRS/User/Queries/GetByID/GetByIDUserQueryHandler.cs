using MediatR;
using TK_Project.Application.Interfaces.Repositories.User;

namespace TK_Project.Application.CQRS.User.Queries.GetByID
{
    public class GetByIDUserQueryHandler : IRequestHandler<GetByIDUserQueryRequest, GetByIDUserQueryResponse>
    {
        readonly IUserReadRepository _read;

        public GetByIDUserQueryHandler(IUserReadRepository read)
        {
            _read = read;
        }

        public async Task<GetByIDUserQueryResponse> Handle(GetByIDUserQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _read.GetUserWithOrderById(request.ProductID);
            var xd = "test";
            var UserModelList = data.Select(x => new
            {
                x.Id,
                x.Username,
                x.Password,
                x.First_Name,
                x.Last_Name,
                x.Address,
                x.Mail,
                Phone = x.Phone_Number,
                Orders = x.Orders.Select(x => x.Id),
            }).ToList();
            return new GetByIDUserQueryResponse()
            {
                User = UserModelList
            };
        }
    }
}
