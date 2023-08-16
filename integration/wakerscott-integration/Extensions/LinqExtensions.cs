using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using walkerscott_domain.Entities;

namespace wakerscott_integration.Extensions
{
    public static class LinqExtensions
    {
        public static IQueryable<NewsArticle> DescriptionLikeAny(this IQueryable<NewsArticle> products, params string[] words)
        {
            var parameter = Expression.Parameter(typeof(NewsArticle));

            var body = words.Select(word => Expression.Call(typeof(DbFunctionsExtensions).GetMethod(nameof(DbFunctionsExtensions.Like), new[] { typeof(DbFunctions), typeof(string), typeof(string) }),
                                                            Expression.Constant(EF.Functions),
                                                            Expression.Property(parameter, typeof(NewsArticle).GetProperty(nameof(NewsArticle.Description))),
                                                            Expression.Constant('%'+word+'%')))
                            .Aggregate<MethodCallExpression, Expression>(null, (current, call) => current != null ? Expression.OrElse(current, call) : (Expression)call);

            return products.Where(Expression.Lambda<Func<NewsArticle, bool>>(body, parameter));
        }

        public static IQueryable<T> WhereAny<T>(this IQueryable<T> queryable, params Expression<Func<T, bool>>[] predicates)
        {
            var parameter = Expression.Parameter(typeof(T));
            return queryable.Where(Expression.Lambda<Func<T, bool>>(predicates.Aggregate<Expression<Func<T, bool>>, Expression>(null,
                                                                                                                                (current, predicate) =>
                                                                                                                                {
                                                                                                                                    var visitor = new ParameterSubstitutionVisitor(predicate.Parameters[0], parameter);
                                                                                                                                    return current != null ? Expression.OrElse(current, visitor.Visit(predicate.Body)) : visitor.Visit(predicate.Body);
                                                                                                                                }),
                                                                    parameter));
        }
    }
}

public class ParameterSubstitutionVisitor : ExpressionVisitor
{
    private readonly ParameterExpression _destination;
    private readonly ParameterExpression _source;

    public ParameterSubstitutionVisitor(ParameterExpression source, ParameterExpression destination)
    {
        _source = source;
        _destination = destination;
    }

    protected override Expression VisitParameter(ParameterExpression node)
    {
        return ReferenceEquals(node, _source) ? _destination : base.VisitParameter(node);
    }
}