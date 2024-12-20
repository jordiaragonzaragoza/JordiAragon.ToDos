﻿namespace JordiAragonZaragoza.ToDos.Presentation.WebApi.Controllers.V1
{
    using Ardalis.Result;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Account.Commands;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Account.Queries;
    using JordiAragonZaragoza.ToDos.Presentation.WebApi.Contracts.V1.Accounts.Requests;
    using JordiAragonZaragoza.ToDos.Presentation.WebApi.Contracts.V1.Accounts.Responses;
    using JordiAragonZaragoza.ToDos.Presentation.WebApi.Mappers.V1;

    public static class AccountsMapperExtension
    {
        public static void MapAccount(this Mapper maps)
        {
            // Requests to queries or commands.
            maps.CreateMap<RegisterAccountRequest, RegisterAccountCommand>();
            maps.CreateMap<LoginAccountRequest, LoginAccountQuery>();

            // OutputDtos to responses.
            maps.CreateMap<AuthenticationOutputDto, AuthenticationResponse>();
            maps.CreateMap<Result<AuthenticationOutputDto>, Result<AuthenticationResponse>>();
        }
    }
}