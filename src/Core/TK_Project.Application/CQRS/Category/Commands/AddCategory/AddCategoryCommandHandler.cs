using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.Interfaces.Repositories.Category;

namespace TK_Project.Application.CQRS.Category.Commands.AddCategory
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommandRequest, AddCategoryCommandResponse>
    {
        readonly ICategoryWriteRepository _write;

        public AddCategoryCommandHandler(ICategoryWriteRepository write)
        {
            _write = write;
        }

        public async Task<AddCategoryCommandResponse> Handle(AddCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await _write.AddAsync(new Domain.Entities.Category()
            {
                Name = request.Name
            });
            return new AddCategoryCommandResponse() { Message = "Kategori Başarıyla Eklendi." };
        }
    }
}
