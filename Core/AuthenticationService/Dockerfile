FROM mcr.microsoft.com/dotnet/core/sdk:3.1
COPY . /app
WORKDIR /app

RUN dotnet tool install --global dotnet-ef
RUN export ENV PATH="${PATH}:/root/.dotnet/tools"

# Restores the dependencies, builds the project
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]

# Exposes it to port 80
EXPOSE 80/tcp
RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh