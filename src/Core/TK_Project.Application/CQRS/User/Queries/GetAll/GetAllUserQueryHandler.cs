using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.Interfaces.Repositories.User;

namespace TK_Project.Application.CQRS.User.Queries.GetAllCustomer
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQueryRequest, GetAllUserQueryResponse>
    {
        readonly IUserReadRepository _read;

        public GetAllUserQueryHandler(IUserReadRepository read)
        {
            _read = read;
        }

        public async Task<GetAllUserQueryResponse> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _read.GetUserWithOrderIds();
            var xd = "test";
            var userModelList = data.Select(x => new
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

            return new GetAllUserQueryResponse()
            {
                userList = userModelList
            };
        }
    }
}
