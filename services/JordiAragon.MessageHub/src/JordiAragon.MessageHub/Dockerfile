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
COPY ["src/JordiAragon.MessageHub/JordiAragon.MessageHub.csproj", "src/JordiAragon.MessageHub/"]
COPY ["src/JordiAragon.MessageHub.Application/JordiAragon.MessageHub.Application.csproj", "src/JordiAragon.MessageHub.Application/"]
COPY ["src/JordiAragon.MessageHub.Application.Contracts/JordiAragon.MessageHub.Application.Contracts.csproj", "src/JordiAragon.MessageHub.Application.Contracts/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Domain.Contracts/JordiAragon.SharedKernel.Domain.Contracts.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Domain.Contracts/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Contracts/JordiAragon.SharedKernel.Contracts.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Contracts/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Application.Contracts/JordiAragon.SharedKernel.Application.Contracts.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Application.Contracts/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Application.Contracts.IntegrationMessages/JordiAragon.SharedKernel.Application.Contracts.IntegrationMessages.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Application.Contracts.IntegrationMessages/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel/JordiAragon.SharedKernel.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Application/JordiAragon.SharedKernel.Application.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Application/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Domain/JordiAragon.SharedKernel.Domain.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Domain/"]
COPY ["src/JordiAragon.MessageHub.Domain/JordiAragon.MessageHub.Domain.csproj", "src/JordiAragon.MessageHub.Domain/"]
COPY ["src/JordiAragon.MessageHub.Infrastructure/JordiAragon.MessageHub.Infrastructure.csproj", "src/JordiAragon.MessageHub.Infrastructure/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Infrastructure/JordiAragon.SharedKernel.Infrastructure.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Infrastructure/"]
COPY ["src/JordiAragon.MessageHub.Infrastructure.EntityFramework/JordiAragon.MessageHub.Infrastructure.EntityFramework.csproj", "src/JordiAragon.MessageHub.Infrastructure.EntityFramework/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Infrastructure.EntityFramework/JordiAragon.SharedKernel.Infrastructure.EntityFramework.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Infrastructure.EntityFramework/"]
COPY ["src/JordiAragon.MessageHub.Presentation.IntegrationMessages/JordiAragon.MessageHub.Presentation.IntegrationMessages.csproj", "src/JordiAragon.MessageHub.Presentation.IntegrationMessages/"]
COPY ["../JordiAragon.ToDos/src/JordiAragon.ToDos.Application.Contracts.IntegrationMessages.V1/JordiAragon.ToDos.Application.Contracts.IntegrationMessages.V1.csproj", "../JordiAragon.ToDos/src/JordiAragon.ToDos.Application.Contracts.IntegrationMessages.V1/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Presentation.WebApi/JordiAragon.SharedKernel.Presentation.WebApi.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Presentation.WebApi/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Presentation.WebApi.Contracts/JordiAragon.SharedKernel.Presentation.WebApi.Contracts.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Presentation.WebApi.Contracts/"]
RUN dotnet restore "src/JordiAragon.MessageHub/JordiAragon.MessageHub.csproj"
COPY . .
WORKDIR "/src/src/JordiAragon.MessageHub"
RUN dotnet build "JordiAragon.MessageHub.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JordiAragon.MessageHub.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JordiAragon.MessageHub.dll"]
