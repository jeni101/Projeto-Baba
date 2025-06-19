# Use uma imagem base do SDK do .NET para construir a aplicação
FROM mcr.microsoft.com/dotnet/sdk:9.0-preview AS build

# Defina o diretório de trabalho dentro do contêiner
WORKDIR /app

# Copie o arquivo de projeto (.csproj) e restaure as dependências
# Como o Dockerfile está na raiz do projeto, *.csproj funcionará se houver apenas um
COPY *.csproj ./
RUN dotnet restore

# Copie o restante do código da aplicação
COPY . .

# Publique a aplicação para produção
RUN dotnet publish -c Release -o out

# Use uma imagem base de runtime do .NET para rodar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:9.0-preview AS final
WORKDIR /app
COPY --from=build /app/out .

# Exponha a porta que sua aplicação .NET usa (ex: 80 para ASP.NET Core)
EXPOSE 80

# Comando para iniciar a aplicação
# SUBSTITUA "FurApp.dll" pelo nome exato do seu arquivo .dll principal
ENTRYPOINT ["dotnet", "FurApp.dll"]