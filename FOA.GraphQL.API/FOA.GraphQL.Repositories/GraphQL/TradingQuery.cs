using FOA.GraphQL.Repositories.GraphQL.Types;
using GraphQL.Types;
using System;
using System.Linq;

namespace FOA.GraphQL.Repositories.GraphQL
{
    public class TradingQuery : ObjectGraphType
    {
        public TradingQuery(
            OrdersRepository ordersRepository,
            OrdersRepositoryUrl ordersRepositoryUrl,
            AllocationsRepository allocationsRepository,
            ControlRepportRepository repository)
        {

            #region Control Reports

            Field<ListGraphType<BackFromTransferredType>>(
                "BackFromTransferred",
                    arguments: new QueryArguments(
                    new QueryArgument<DateGraphType> { Name = "dateFrom" },
                    new QueryArgument<DateGraphType> { Name = "dateTo" }),
                resolve: context =>
                {
                    var dateFrom = context.GetArgument<DateTime>("dateFrom");
                    var dateTo = context.GetArgument<DateTime>("dateTo");
                    return repository.GetBackFromTransferred(dateFrom, dateTo);
                }
            );

            Field<ListGraphType<InputAuthSameUserType>>(
                "InputAuthSameUser",
                    arguments: new QueryArguments(
                    new QueryArgument<DateGraphType> { Name = "dateFrom" },
                    new QueryArgument<DateGraphType> { Name = "dateTo" }),
                resolve: context =>
                {
                    var dateFrom = context.GetArgument<DateTime>("dateFrom");
                    var dateTo = context.GetArgument<DateTime>("dateTo");
                    return repository.GetInputAuthSameUser(dateFrom, dateTo);
                }
            );

            Field<ListGraphType<SameUserTradingType>>(
                "SameUserTrading",
                arguments: new QueryArguments(
                    new QueryArgument<DateGraphType> { Name = "dateFrom" },
                    new QueryArgument<DateGraphType> { Name = "dateTo" }),
                resolve: context =>
                {
                    var dateFrom = context.GetArgument<DateTime>("dateFrom");
                    var dateTo = context.GetArgument<DateTime>("dateTo");
                    return repository.GetSameUserTrading(dateFrom, dateTo);
                }
            );

            Field<ListGraphType<UnsolicitedTradingType>>(
                "UnsolicitedTrading",
                arguments: new QueryArguments(
                    new QueryArgument<DateGraphType> { Name = "dateFrom" },
                    new QueryArgument<DateGraphType> { Name = "dateTo" }),
                resolve: context =>
                {
                    var dateFrom = context.GetArgument<DateTime>("dateFrom");
                    var dateTo = context.GetArgument<DateTime>("dateTo");
                    return repository.GetUnsolicitedTrading(dateFrom, dateTo);
                }
            );

            #endregion

            #region Orders

            Field<ListGraphType<OrderTypeUrl>>(
                "ordersUrl",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "orderId" },
                    new QueryArgument<StringGraphType> { Name = "omsOrderId" },
                    new QueryArgument<StringGraphType> { Name = "omsOrderVersionId" },
                    new QueryArgument<DateGraphType> { Name = "createdFrom" },
                    new QueryArgument<DateGraphType> { Name = "createdTo" },
                    new QueryArgument<StringGraphType> { Name = "securityId" }
                    ),
                    resolve: context =>
                    {
                        var orderId = context.GetArgument<int>("orderId");
                        var omsOrderId = context.GetArgument<string>("omsOrderId");
                        var omsOrderVersionId = context.GetArgument<string>("omsOrderVersionId");
                        var createdFrom = context.GetArgument<DateTime>("createdFrom");
                        var createdTo = context.GetArgument<DateTime>("createdTo");
                        var securityId = context.GetArgument<string>("securityId");

                        return ordersRepositoryUrl.GetByOrderArgs(orderId, omsOrderId, omsOrderVersionId, createdFrom, createdTo, securityId);
                    });

            Field<ListGraphType<OrderType>>(
                "orders",
                resolve: context => ordersRepository.GetAll()
            );

            Field<ListGraphType<OrderType>>(
                "order",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "orderId" },
                    new QueryArgument<StringGraphType> { Name = "omsOrderId" },
                    new QueryArgument<StringGraphType> { Name = "omsOrderVersionId" },
                    new QueryArgument<DateGraphType> { Name = "createdFrom" },
                    new QueryArgument<DateGraphType> { Name = "createdTo" },
                    new QueryArgument<StringGraphType> { Name = "securityId" }
                    ),
                    resolve: context =>
                        {
                            var orderId = context.GetArgument<int>("orderId");
                            var omsOrderId = context.GetArgument<string>("omsOrderId");
                            var omsOrderVersionId = context.GetArgument<string>("omsOrderVersionId");
                            var createdFrom = context.GetArgument<DateTime>("createdFrom");
                            var createdTo = context.GetArgument<DateTime>("createdTo");
                            var securityId = context.GetArgument<string>("securityId");

                            return ordersRepository.GetByOrderArgs(orderId, omsOrderId, omsOrderVersionId, createdFrom, createdTo, securityId);
                        });


            Field<ListGraphType<MartinType>>(
                "martin",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "orderId" },
                    new QueryArgument<StringGraphType> { Name = "omsOrderId" },
                    new QueryArgument<StringGraphType> { Name = "omsOrderVersionId" },
                    new QueryArgument<DateGraphType> { Name = "createdFrom" },
                    new QueryArgument<DateGraphType> { Name = "createdTo" },
                    new QueryArgument<StringGraphType> { Name = "securityId" }
                ),
                resolve: context =>
                {
                    var orderId = context.GetArgument<int>("orderId");
                    var omsOrderId = context.GetArgument<string>("omsOrderId");
                    var omsOrderVersionId = context.GetArgument<string>("omsOrderVersionId");
                    var createdFrom = context.GetArgument<DateTime>("createdFrom");
                    var createdTo = context.GetArgument<DateTime>("createdTo");
                    var securityId = context.GetArgument<string>("securityId");

                    return ordersRepository.GetByOrderArgs(orderId, omsOrderId, omsOrderVersionId, createdFrom, createdTo, securityId);
                });

            Field<IntGraphType>(
                "orderCount",
                resolve: context => ordersRepository.GetOrderCount()
                );

            #endregion

            #region allocations

            Field<ListGraphType<AllocationType>>(
                "allocations",
                resolve: context => allocationsRepository.GetAll()
                );

            Field<ListGraphType<AllocationType>>(
                "allocationCount",
                resolve: context => allocationsRepository.GetAllocationsCount()
                );

            #endregion
        }
    }
}
