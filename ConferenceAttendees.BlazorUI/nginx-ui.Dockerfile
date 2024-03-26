FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build-env
WORKDIR /app
COPY . ./
RUN dotnet publish "ConferenceAttendees.BlazorUI/ConferenceAttendees.BlazorUI.csproj" -c Release -o output

FROM nginx:alpine
WORKDIR /user/share/nginx/html
COPY --from=build-env /app/output/wwwroot .
COPY nginx-ui.conf /etc/nginx/nginx.conf
EXPOSE 80