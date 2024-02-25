using CleanArchitecture.Domain.Common;
using System.Linq.Expressions;

namespace CleanArchitecture.Domain.UnitTests.Models.Specifications
{
    public class FalseSpecification : Specification<object>
    {
        public override Expression<Func<object, bool>> ToExpression() => o => false;
    }
}
