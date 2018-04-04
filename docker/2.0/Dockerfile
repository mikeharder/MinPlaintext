FROM microsoft/dotnet-nightly:2.1-sdk AS build
WORKDIR /app

# copy minimum and restore
COPY NuGet.config ./
COPY *.sln ./
COPY MinPlaintext/*.csproj ./MinPlaintext/
RUN dotnet restore

# copy everything else and build
COPY . ./
RUN dotnet publish --no-restore -f netcoreapp2.0 -c Release -o out

# build runtime image
FROM microsoft/dotnet:2.0-runtime
WORKDIR /app
COPY --from=build /app/MinPlaintext/out ./
ENTRYPOINT ["dotnet", "MinPlaintext.dll"]
