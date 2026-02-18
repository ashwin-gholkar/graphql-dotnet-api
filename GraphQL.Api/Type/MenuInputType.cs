using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
///// <summary>
///// This class is used to define the input type for the menu.
///// </summary>
namespace GraphQL.Api.Type
{
    public class MenuInputType : InputObjectGraphType
    {
        public MenuInputType()
        {
            Field<IntGraphType>("Id")
                    .Description("The ID of the menu.");
            Field<StringGraphType>("Name")
                    .Description("The name of the menu.");
            Field<StringGraphType>("Description")
                    .Description("The description of the menu.");
            Field<FloatGraphType>("Price")
                    .Description("The price of the menu.");
        }
    }
}