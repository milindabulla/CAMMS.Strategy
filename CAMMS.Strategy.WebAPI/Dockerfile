#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CAMMS.Strategy.WebAPI/CAMMS.Strategy.WebAPI.csproj", "CAMMS.Strategy.WebAPI/"]
COPY ["CAMMS.Strategy.Infrastructure/CAMMS.Strategy.Infrastructure.csproj", "CAMMS.Strategy.Infrastructure/"]
COPY ["CAMMS.Strategy.Infrastructure.Persistence/CAMMS.Strategy.Infrastructure.Persistence.csproj", "CAMMS.Strategy.Infrastructure.Persistence/"]
COPY ["CAMMS.Core/CAMMS.Domain.csproj", "CAMMS.Core/"]
COPY ["CAMMS.Strategy.Application.Interface/CAMMS.Strategy.Application.Interface.csproj", "CAMMS.Strategy.Application.Interface/"]
COPY ["CAMMS.Strategy.Infrastructure.Behavior/CAMMS.Strategy.Infrastructure.Behavior.csproj", "CAMMS.Strategy.Infrastructure.Behavior/"]
COPY ["CAMMS.Strategy.Application/CAMMS.Strategy.Application.csproj", "CAMMS.Strategy.Application/"]
COPY ["CAMMS.Strategy.Application.DTO/CAMMS.Strategy.Application.DTO.csproj", "CAMMS.Strategy.Application.DTO/"]
COPY ["CAMMS.Strategy.Application.ObjectMapping/CAMMS.Strategy.Application.ObjectMapping.csproj", "CAMMS.Strategy.Application.ObjectMapping/"]
COPY ["CAMMS.Strategy.Infrastructure.Identity/CAMMS.Strategy.Infrastructure.Identity.csproj", "CAMMS.Strategy.Infrastructure.Identity/"]
COPY ["CAMMS.Strategy.Infrastructure.Notification/CAMMS.Strategy.Infrastructure.Notification.csproj", "CAMMS.Strategy.Infrastructure.Notification/"]
COPY ["CAMMS.Strategy.Application.Query/CAMMS.Strategy.Application.Query.csproj", "CAMMS.Strategy.Application.Query/"]
COPY ["CAMMS.Strategy.Application.Command/CAMMS.Strategy.Application.Command.csproj", "CAMMS.Strategy.Application.Command/"]
RUN dotnet restore "CAMMS.Strategy.WebAPI/CAMMS.Strategy.WebAPI.csproj"
COPY . .
WORKDIR "/src/CAMMS.Strategy.WebAPI"
RUN dotnet build "CAMMS.Strategy.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CAMMS.Strategy.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CAMMS.Strategy.WebAPI.dll"]