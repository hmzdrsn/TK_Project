using MediatR;

namespace TK_Project.Application.CQRS.Category.Commands.AddCategory
{
    public class AddCategoryCommandRequest : IRequest<AddCategoryCommandResponse>
    {
        public string? Name { get; set; }
    }
}
