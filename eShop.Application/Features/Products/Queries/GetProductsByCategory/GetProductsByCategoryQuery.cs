using eShop.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.Features.Products.Queries.GetProductsByCategory
{
	public class GetProductsByCategoryQuery : IRequest<List<Product>?>
	{
		public string Category { get; set; }
	}
}
