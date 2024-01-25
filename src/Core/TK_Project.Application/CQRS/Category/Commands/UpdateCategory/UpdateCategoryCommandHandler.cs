using MediatR;
using TK_Project.Application.Interfaces.Repositories.Category;

namespace TK_Project.Application.CQRS.Category.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
    {
        readonly ICategoryWriteRepository _write;
        readonly ICategoryReadRepository _read;

        public UpdateCategoryCommandHandler(ICategoryWriteRepository write, ICategoryReadRepository read)
        {
            _write = write;
            _read = read;
        }

        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {

            var category = await _read.GetByIdAsync(request.ID);
            if(category == null)
            {
                return new UpdateCategoryCommandResponse()
                {
                    Message = "No Data",
                };
            }
            else
            {
                category.Name = request.Name;
                await _write.UpdateAsync(category);
                return new UpdateCategoryCommandResponse()
                {
                    Message = "Category Updated",
                };
            }
        }
    }
}
