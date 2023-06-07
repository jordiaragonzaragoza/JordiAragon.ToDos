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
COPY ["src/JordiAragon.ToDos/JordiAragon.ToDos.csproj", "src/JordiAragon.ToDos/"]
COPY ["src/JordiAragon.ToDos.Application/JordiAragon.ToDos.Application.csproj", "src/JordiAragon.ToDos.Application/"]
COPY ["src/JordiAragon.ToDos.Application.Contracts/JordiAragon.ToDos.Application.Contracts.csproj", "src/JordiAragon.ToDos.Application.Contracts/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Domain.Contracts/JordiAragon.SharedKernel.Domain.Contracts.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Domain.Contracts/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Contracts/JordiAragon.SharedKernel.Contracts.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Contracts/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Application.Contracts/JordiAragon.SharedKernel.Application.Contracts.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Application.Contracts/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Application.Contracts.IntegrationMessages/JordiAragon.SharedKernel.Application.Contracts.IntegrationMessages.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Application.Contracts.IntegrationMessages/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel/JordiAragon.SharedKernel.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel/"]
COPY ["src/JordiAragon.ToDos.Domain/JordiAragon.ToDos.Domain.csproj", "src/JordiAragon.ToDos.Domain/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Domain/JordiAragon.SharedKernel.Domain.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Domain/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Application/JordiAragon.SharedKernel.Application.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Application/"]
COPY ["src/JordiAragon.ToDos.Application.Contracts.IntegrationMessages.V1/JordiAragon.ToDos.Application.Contracts.IntegrationMessages.V1.csproj", "src/JordiAragon.ToDos.Application.Contracts.IntegrationMessages.V1/"]
COPY ["src/JordiAragon.ToDos.Infrastructure/JordiAragon.ToDos.Infrastructure.csproj", "src/JordiAragon.ToDos.Infrastructure/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Infrastructure/JordiAragon.SharedKernel.Infrastructure.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Infrastructure/"]
COPY ["src/JordiAragon.ToDos.Infrastructure.EntityFramework/JordiAragon.ToDos.Infrastructure.EntityFramework.csproj", "src/JordiAragon.ToDos.Infrastructure.EntityFramework/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Infrastructure.EntityFramework/JordiAragon.SharedKernel.Infrastructure.EntityFramework.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Infrastructure.EntityFramework/"]
COPY ["src/JordiAragon.ToDos.Presentation.WebApi/JordiAragon.ToDos.Presentation.WebApi.csproj", "src/JordiAragon.ToDos.Presentation.WebApi/"]
COPY ["src/JordiAragon.ToDos.Presentation.WebApi.Contracts.V1/JordiAragon.ToDos.Presentation.WebApi.Contracts.V1.csproj", "src/JordiAragon.ToDos.Presentation.WebApi.Contracts.V1/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Presentation.WebApi.Contracts/JordiAragon.SharedKernel.Presentation.WebApi.Contracts.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Presentation.WebApi.Contracts/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Presentation.WebApi/JordiAragon.SharedKernel.Presentation.WebApi.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Presentation.WebApi/"]
COPY ["src/JordiAragon.ToDos.Presentation.IntegrationMessages/JordiAragon.ToDos.Presentation.IntegrationMessages.csproj", "src/JordiAragon.ToDos.Presentation.IntegrationMessages/"]
RUN dotnet restore "src/JordiAragon.ToDos/JordiAragon.ToDos.csproj"
COPY . .
WORKDIR "/src/src/JordiAragon.ToDos"
RUN dotnet build "JordiAragon.ToDos.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JordiAragon.ToDos.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JordiAragon.ToDos.dll"]
