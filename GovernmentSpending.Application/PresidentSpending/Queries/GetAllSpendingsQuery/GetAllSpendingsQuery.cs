using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovernmentSpending.Application.PresidentSpending.Queries.GetAllSpendingsQuery
{
    public class GetAllSpendingsQuery : IRequest<int>
    {
        public int Id;
    }
    public class ProductBrandGetByIdQueryHandler : IRequestHandler<GetAllSpendingsQuery, int>
    {

        public async Task<int> Handle(GetAllSpendingsQuery request, CancellationToken cancellationToken)
        {
            return request.Id;
        }
    }
}
