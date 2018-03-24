FROM microsoft/dotnet-nightly:2.1-sdk AS build
WORKDIR /app

# copy sln and csproj, and restore as distinct layers
COPY NuGet.config ./
COPY *.sln ./
COPY MinPlaintext/*.csproj ./MinPlaintext/
RUN dotnet restore

# copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# build runtime image
FROM microsoft/dotnet:runtime
WORKDIR /app
COPY --from=build /app/MinPlaintext/out ./
ENTRYPOINT ["dotnet", "MinPlaintext.dll"]
