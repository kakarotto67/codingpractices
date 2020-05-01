# escape = `

# ------------------------------- For Windows -------------------------------

FROM mcr.microsoft.com/windows/servercore:1803 as installer

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop';$ProgressPreference='silentlyContinue';"]

RUN Invoke-WebRequest -OutFile nodejs.zip -UseBasicParsing "https://nodejs.org/dist/v12.4.0/node-v12.4.0-win-x64.zip"; `
Expand-Archive nodejs.zip -DestinationPath C:\; `
Rename-Item "C:\\node-v12.4.0-win-x64" c:\nodejs

FROM mcr.microsoft.com/windows/nanoserver:1803

WORKDIR C:\nodejs
COPY --from=installer C:\nodejs\ .
RUN SETX PATH C:\nodejs
RUN npm config set registry https://registry.npmjs.org/

WORKDIR /app

# install and cache app dependencies
COPY src/WebSpa/package.json /app/src/WebSpa/package.json

WORKDIR /app/src/WebSpa
RUN npm install
RUN npm install -g @angular/cli@latest

# add app
COPY . /app

# start app
CMD cd /app/src/WebSpa && ng serve --host 0.0.0.0

# ------------------------------- For Linux -------------------------------
# node image can be used as base image for angular app
# FROM node:latest

# # set working directory
# WORKDIR /app

# # add node modules bins to $PATH
# ENV PATH /app/src/WebSpa/node_modules/.bin:$PATH

# # install and cache app dependencies
# COPY src/WebSpa/package.json /app/src/WebSpa/package.json

# WORKDIR /app/src/WebSpa
# RUN npm install
# RUN npm install -g @angular/cli@latest

# # add app
# COPY . /app

# # start app
# CMD cd /app/src/WebSpa && ng serve --host 0.0.0.0