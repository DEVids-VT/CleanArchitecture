using CleanArchitecture.Domain.Common;
using System.Linq.Expressions;

namespace CleanArchitecture.Domain.UnitTests.Models.Specifications
{
    public class TrueSpecification : Specification<object>
    {
        public override Expression<Func<object, bool>> ToExpression() => o => true;
    }
}
