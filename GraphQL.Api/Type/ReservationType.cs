using GraphQL.Api.Model;
using GraphQL.Types;

namespace GraphQL.Api.Type
{
    public class ReservationType : ObjectGraphType<Reservation>
    {
        public ReservationType()
        {
            Field(x => x.Id).Description("The ID of the reservation.");
            Field(x => x.CustomerName).Description("The name of the customer.");
            Field(x => x.Email).Description("The email of the customer.");
            Field(x => x.PartySize).Description("The party size of the reservation.");
            Field(x => x.PhoneNumber).Description("The phone number of the customer.");
            Field(x => x.ReservationDate).Description("The date of the reservation.");
            Field(x => x.SpecialRequest).Description("The special request of the reservation.");
        }
    }
}