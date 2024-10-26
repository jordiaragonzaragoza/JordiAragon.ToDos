#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Directory.Packages.props", "src/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/Directory.Packages.props", "../../SharedKernel/JordiAragon.SharedKernel/src/"]
COPY ["nuget.config", "."]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/nuget.config", "../../SharedKernel/JordiAragon.SharedKernel/"]
COPY ["src/JordiAragonZaragoza.MessageHub/JordiAragonZaragoza.MessageHub.csproj", "src/JordiAragonZaragoza.MessageHub/"]
COPY ["src/JordiAragonZaragoza.MessageHub.Application/JordiAragonZaragoza.MessageHub.Application.csproj", "src/JordiAragonZaragoza.MessageHub.Application/"]
COPY ["src/JordiAragonZaragoza.MessageHub.Application.Contracts/JordiAragonZaragoza.MessageHub.Application.Contracts.csproj", "src/JordiAragonZaragoza.MessageHub.Application.Contracts/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Domain.Contracts/JordiAragon.SharedKernel.Domain.Contracts.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Domain.Contracts/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Contracts/JordiAragon.SharedKernel.Contracts.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Contracts/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Application.Contracts/JordiAragon.SharedKernel.Application.Contracts.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Application.Contracts/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Application.Contracts.IntegrationMessages/JordiAragon.SharedKernel.Application.Contracts.IntegrationMessages.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Application.Contracts.IntegrationMessages/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel/JordiAragon.SharedKernel.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Application/JordiAragon.SharedKernel.Application.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Application/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Domain/JordiAragon.SharedKernel.Domain.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Domain/"]
COPY ["src/JordiAragonZaragoza.MessageHub.Domain/JordiAragonZaragoza.MessageHub.Domain.csproj", "src/JordiAragonZaragoza.MessageHub.Domain/"]
COPY ["src/JordiAragonZaragoza.MessageHub.Infrastructure/JordiAragonZaragoza.MessageHub.Infrastructure.csproj", "src/JordiAragonZaragoza.MessageHub.Infrastructure/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Infrastructure/JordiAragon.SharedKernel.Infrastructure.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Infrastructure/"]
COPY ["src/JordiAragonZaragoza.MessageHub.Infrastructure.EntityFramework/JordiAragonZaragoza.MessageHub.Infrastructure.EntityFramework.csproj", "src/JordiAragonZaragoza.MessageHub.Infrastructure.EntityFramework/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Infrastructure.EntityFramework/JordiAragon.SharedKernel.Infrastructure.EntityFramework.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Infrastructure.EntityFramework/"]
COPY ["src/JordiAragonZaragoza.MessageHub.Presentation.IntegrationMessages/JordiAragonZaragoza.MessageHub.Presentation.IntegrationMessages.csproj", "src/JordiAragonZaragoza.MessageHub.Presentation.IntegrationMessages/"]
COPY ["../JordiAragonZaragoza.ToDos/src/JordiAragonZaragoza.ToDos.Application.Contracts.IntegrationMessages.V1/JordiAragonZaragoza.ToDos.Application.Contracts.IntegrationMessages.V1.csproj", "../JordiAragonZaragoza.ToDos/src/JordiAragonZaragoza.ToDos.Application.Contracts.IntegrationMessages.V1/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Presentation.WebApi/JordiAragon.SharedKernel.Presentation.WebApi.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Presentation.WebApi/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Presentation.WebApi.Contracts/JordiAragon.SharedKernel.Presentation.WebApi.Contracts.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Presentation.WebApi.Contracts/"]
RUN dotnet restore "src/JordiAragonZaragoza.MessageHub/JordiAragonZaragoza.MessageHub.csproj"
COPY . .
WORKDIR "/src/src/JordiAragonZaragoza.MessageHub"
RUN dotnet build "JordiAragonZaragoza.MessageHub.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JordiAragonZaragoza.MessageHub.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JordiAragonZaragoza.MessageHub.dll"]
