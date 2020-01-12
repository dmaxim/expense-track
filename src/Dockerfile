FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim as base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY Libraries/Mx.EntityFramework/Mx.EntityFramework.csproj Mx.EntityFramework/
COPY Libraries/Mx.EntityFramework.Contracts/Mx.EntityFramework.Contracts.csproj Mx.EntityFramework.Contracts/
COPY Libraries/Mx.Logging/Mx.Logging.csproj Mx.Logging/
COPY Libraries/Mx.Library/Mx.Library.csproj Mx.Library/
COPY Barney.Business/Barney.Business.csproj Barney.Business/
COPY Barney.Data/Barney.Data.csproj Barney.Data/
COPY Barney.Domain/Barney.Domain.csproj  Barney.Domain/
COPY Barney.Infrastructure/Barney.Infrastructure.csproj Barney.Infrastructure/
COPY Barney.WebUI/Barney.WebUI.csproj Barney.WebUI/


RUN dotnet restore Barney.WebUI/Barney.WebUI.csproj
COPY . .
WORKDIR /src/Barney.WebUI
RUN dotnet build Barney.WebUI.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Barney.WebUI.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Barney.WebUI.dll"]
