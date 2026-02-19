using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Api.Data;
using GraphQL.Api.Interfaces;
using GraphQL.Api.Model;

namespace GraphQL.Api.Services
{
    public class ReservationRepository(GraphQLDbContext graphQLDbContext) : IReservationRepository

    {
        private readonly GraphQLDbContext _graphQLDbContext = graphQLDbContext;

        public Reservation AddReservation(Reservation reservation)
        {
            _graphQLDbContext.Reservations.Add(reservation);
            _graphQLDbContext.SaveChanges();
            return reservation;
        }

        public List<Reservation> GetReservations()
        {
            return _graphQLDbContext.Reservations.ToList();
        }
    }
}