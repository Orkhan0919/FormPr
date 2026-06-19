FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Form qovluğuna keçin
COPY Form/*.csproj ./Form/
WORKDIR /app/Form
RUN dotnet restore

# Bütün faylları kopyalayın
COPY Form/. ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/Form/out ./
EXPOSE 80
EXPOSE 443

ENTRYPOINT ["dotnet", "Form.dll"]