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
COPY ["src/JordiAragonZaragoza.ToDos/JordiAragonZaragoza.ToDos.csproj", "src/JordiAragonZaragoza.ToDos/"]
COPY ["src/JordiAragonZaragoza.ToDos.Application/JordiAragonZaragoza.ToDos.Application.csproj", "src/JordiAragonZaragoza.ToDos.Application/"]
COPY ["src/JordiAragonZaragoza.ToDos.Application.Contracts/JordiAragonZaragoza.ToDos.Application.Contracts.csproj", "src/JordiAragonZaragoza.ToDos.Application.Contracts/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Domain.Contracts/JordiAragon.SharedKernel.Domain.Contracts.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Domain.Contracts/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Contracts/JordiAragon.SharedKernel.Contracts.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Contracts/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Application.Contracts/JordiAragon.SharedKernel.Application.Contracts.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Application.Contracts/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Application.Contracts.IntegrationMessages/JordiAragon.SharedKernel.Application.Contracts.IntegrationMessages.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Application.Contracts.IntegrationMessages/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel/JordiAragon.SharedKernel.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel/"]
COPY ["src/JordiAragonZaragoza.ToDos.Domain/JordiAragonZaragoza.ToDos.Domain.csproj", "src/JordiAragonZaragoza.ToDos.Domain/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Domain/JordiAragon.SharedKernel.Domain.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Domain/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Application/JordiAragon.SharedKernel.Application.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Application/"]
COPY ["src/JordiAragonZaragoza.ToDos.Application.Contracts.IntegrationMessages.V1/JordiAragonZaragoza.ToDos.Application.Contracts.IntegrationMessages.V1.csproj", "src/JordiAragonZaragoza.ToDos.Application.Contracts.IntegrationMessages.V1/"]
COPY ["src/JordiAragonZaragoza.ToDos.Infrastructure/JordiAragonZaragoza.ToDos.Infrastructure.csproj", "src/JordiAragonZaragoza.ToDos.Infrastructure/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Infrastructure/JordiAragon.SharedKernel.Infrastructure.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Infrastructure/"]
COPY ["src/JordiAragonZaragoza.ToDos.Infrastructure.EntityFramework/JordiAragonZaragoza.ToDos.Infrastructure.EntityFramework.csproj", "src/JordiAragonZaragoza.ToDos.Infrastructure.EntityFramework/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Infrastructure.EntityFramework/JordiAragon.SharedKernel.Infrastructure.EntityFramework.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Infrastructure.EntityFramework/"]
COPY ["src/JordiAragonZaragoza.ToDos.Presentation.WebApi/JordiAragonZaragoza.ToDos.Presentation.WebApi.csproj", "src/JordiAragonZaragoza.ToDos.Presentation.WebApi/"]
COPY ["src/JordiAragonZaragoza.ToDos.Presentation.WebApi.Contracts.V1/JordiAragonZaragoza.ToDos.Presentation.WebApi.Contracts.V1.csproj", "src/JordiAragonZaragoza.ToDos.Presentation.WebApi.Contracts.V1/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Presentation.WebApi.Contracts/JordiAragon.SharedKernel.Presentation.WebApi.Contracts.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Presentation.WebApi.Contracts/"]
COPY ["../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Presentation.WebApi/JordiAragon.SharedKernel.Presentation.WebApi.csproj", "../../SharedKernel/JordiAragon.SharedKernel/src/JordiAragon.SharedKernel.Presentation.WebApi/"]
COPY ["src/JordiAragonZaragoza.ToDos.Presentation.IntegrationMessages/JordiAragonZaragoza.ToDos.Presentation.IntegrationMessages.csproj", "src/JordiAragonZaragoza.ToDos.Presentation.IntegrationMessages/"]
RUN dotnet restore "src/JordiAragonZaragoza.ToDos/JordiAragonZaragoza.ToDos.csproj"
COPY . .
WORKDIR "/src/src/JordiAragonZaragoza.ToDos"
RUN dotnet build "JordiAragonZaragoza.ToDos.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JordiAragonZaragoza.ToDos.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JordiAragonZaragoza.ToDos.dll"]
