namespace CleanArchitecture.Domain.UnitTests.Helpers
{
    using System.Linq.Expressions;
    using System.Reflection;

    public static class PrivateSetterCaller
    {
        public static void SetPrivate<T, TValue>(this T instance, Expression<Func<T, TValue>> propertyExpression, TValue value)
        {
             var propName = GetName(propertyExpression);
             var t = typeof(T).BaseType;
                if (t.GetProperty(propName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance) == null)
                    throw new ArgumentOutOfRangeException("propName", string.Format("Property {0} was not found in Type {1}", propName, nameof(T)));
                t.InvokeMember(propName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty | BindingFlags.Instance, null, instance, new object[] { value });
        }

        private static string GetName<T, TValue>(Expression<Func<T, TValue>> exp)
        {
            MemberExpression body = exp.Body as MemberExpression;

            if (body == null)
            {
                UnaryExpression ubody = (UnaryExpression)exp.Body;
                body = ubody.Operand as MemberExpression;
            }

            return body.Member.Name;
        }
    }
}
