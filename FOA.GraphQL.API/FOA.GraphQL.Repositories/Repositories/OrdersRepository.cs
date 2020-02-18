using FOA.GraphQL.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace FOA.GraphQL.Repositories
{
    public class OrdersRepository
    {
        private readonly GTPSContext _dbContext;

        public OrdersRepository(GTPSContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Orders> GetAll()
        {
            return _dbContext.Orders.Take(500).OrderByDescending(o => o.CreatedDate);
        }

        public int GetOrderCount()
        {
            return _dbContext.Orders.Count();
        }

        public IEnumerable<Orders> GetByOrderArgs(int? orderId, string omsOrderId, string omsOrderVersionId, DateTime createdFrom, DateTime createdTo, string securityId)
        {
            var ret1 = (from ord in _dbContext.Orders
                        select ord);

            if (!string.IsNullOrEmpty(securityId))
            {
                ret1 = (from ord in _dbContext.Orders
                        join allo in _dbContext.Allocations
                        on ord.OrderId equals allo.OrderId
                        where allo.SecurityId.Contains(securityId)
                        select ord);
            }

            if (orderId != 0)
            {
                ret1 = ret1.Where(x => x.OrderId.ToString().Contains(orderId.ToString()));
            }

            if (!string.IsNullOrEmpty(omsOrderId))
            {
                ret1 = ret1.Where(x => x.OmsOrderId.Contains(omsOrderId));
            }

            if (!string.IsNullOrEmpty(omsOrderVersionId))
            {
                ret1 = ret1.Where(x => x.OmsOrderVersionId.Contains(omsOrderVersionId));
            }

            ret1 = ret1.GroupBy(x => x.OrderId).Select(g => g.FirstOrDefault());

            var ret2 = from f in ret1 select f;

            return ret2;
        }

        public IEnumerable<Orders> GetByOrderArgs2(int? orderId, string omsOrderId, string omsOrderVersionId, DateTime createdFrom, DateTime createdTo, string securityId)
        {
            var query = _dbContext.Orders.AsQueryable();

            ParameterExpression pe = Expression.Parameter(typeof(Orders), "Orders");

            Expression id = Expression.PropertyOrField(pe, "orderId");
            Expression orderIdParam = Expression.Constant(orderId);
            Expression e1 = Expression.Equal(id, orderIdParam);

            Expression Id2 = Expression.PropertyOrField(pe, "omsOrderId");
            Expression omsOrderIdParam = Expression.Constant(omsOrderId);
            MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            Expression e2 = Expression.Call(Id2, method, omsOrderIdParam);

            Expression e3 = Expression.And(e1, e2);

            MethodCallExpression whereCallExpression = Expression.Call(
                typeof(Queryable),
                "Where",
                new Type[] { query.ElementType },
                query.Expression,
                Expression.Lambda<Func<Orders, bool>>(e3, new ParameterExpression[] { pe }));

            var results = query.Provider.CreateQuery<Orders>(whereCallExpression);

            return results;
        }

        public IEnumerable<Orders> GetByOrderArgs1(int? orderId, string omsOrderId, string omsOrderVersionId, DateTime createdFrom, DateTime createdTo, string securityId)
        {
            if (String.IsNullOrEmpty(securityId)) securityId = String.Empty;
            if (orderId == 0) orderId = null;
            if (String.IsNullOrEmpty(omsOrderId)) omsOrderId = String.Empty;
            if (String.IsNullOrEmpty(omsOrderVersionId)) omsOrderVersionId = String.Empty;
            if (createdTo.ToUniversalTime() == new DateTime().ToUniversalTime()) createdTo = DateTime.UtcNow;

            var ret1 = (from ord in _dbContext.Orders
                        join allo in _dbContext.Allocations
                        on ord.OrderId equals allo.OrderId
                        where allo.SecurityId == securityId
                        where ord.OrderId == orderId
                        where ord.OmsOrderId.Contains(omsOrderId)
                        where ord.OmsOrderVersionId.Contains(omsOrderVersionId)
                        where ord.CreatedDate >= createdFrom
                        where ord.CreatedDate <= createdTo
                        select ord)
                       .GroupBy(x => x.OrderId)
                       .Select(g => g.FirstOrDefault());

            var ret2 = from f in ret1 select f;

            return ret2;

            //return _dbContext.Orders.Where(x => x.OrderId.ToString().Contains(orderId.ToString()))
            //                        .Where(x => x.OmsOrderId.Contains(omsOrderId))
            //                        .Where(x => x.OmsOrderVersionId.Contains(omsOrderVersionId))
            //                        .Where(x => x.CreatedDate >= createdfrom)
            //                        .Where(x => x.CreatedDate <= createdTo);
        }
    }
}
