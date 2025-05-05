using CarShopApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class CarsWithTypesAndBrandsSpecification : BaseSpecification<Car>
    {
        public CarsWithTypesAndBrandsSpecification()
        {
            AddInclude(x => x.Manufacturer);
            AddInclude(x => x.Type);
        }

        public CarsWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Manufacturer);
            AddInclude(x => x.Type);
        }
    }
}
