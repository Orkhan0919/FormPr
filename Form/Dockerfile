FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Bütün faylları kopyalayın
COPY . ./

# Proyekti publish edin
RUN dotnet publish "Form.csproj" -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./
EXPOSE 80
EXPOSE 443

ENTRYPOINT ["dotnet", "Form.dll"]