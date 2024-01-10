using MediatR;
using TK_Project.Application.Interfaces.Repositories.Category;

namespace TK_Project.Application.CQRS.Category.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
    {
        readonly ICategoryWriteRepository _write;

        public UpdateCategoryCommandHandler(ICategoryWriteRepository write)
        {
            _write = write;
        }

        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Category category = new()
            {
                Id = request.ID,
                Name = request.Name
            };
            await _write.UpdateAsync(category);
            return new UpdateCategoryCommandResponse()
            {
                Message = "Kategori Başarıyla Güncellendi",
                UpdatedName = request.Name
            };
        }
    }
}
