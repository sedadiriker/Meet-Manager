# .NET SDK imajını kullanarak uygulama oluşturma
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Proje dosyalarını kopyalama
COPY *.csproj ./
RUN dotnet restore

# Uygulama kodlarını kopyalama ve derleme
COPY . ./
RUN dotnet publish -c Release -o out

# Çalıştırma imajı için .NET Runtime imajını kullanma
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Uygulama çalıştırma komutu
ENTRYPOINT ["dotnet", "Meet-Manager.dll"]
