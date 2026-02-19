using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Api.Interfaces;
using GraphQL.Api.Type;
using GraphQL.Types;

namespace GraphQL.Api.Query
{
    public class ReservationQuery : ObjectGraphType
    {
        public ReservationQuery(IReservationRepository reservationRepository)
        {
            Field<ListGraphType<ReservationType>>(
               "reservations").Resolve(context =>
               {
                   return reservationRepository.GetReservations();
               });

            // Field<ReservationType>(
            //     "reservation")
            //     .Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "ReservationId" }))
            //     .Resolve(context =>
            //    {
            //        var reservationId = context.GetArgument<int>("ReservationId");
            //        return reservationRepository.GetReservationById(reservationId);
            //    });
        }
    }
}