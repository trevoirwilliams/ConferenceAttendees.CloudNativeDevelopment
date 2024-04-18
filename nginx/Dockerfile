# Use the official Nginx image as the base
FROM nginx:latest

# Remove the default configuration file provided by Nginx
RUN rm /etc/nginx/conf.d/default.conf

# Copy the custom Nginx configuration file into the container
COPY nginx/nginx.conf /etc/nginx/nginx.conf
COPY nginx/api-cert.key /etc/ssl/private/api-cert.key
COPY nginx/api-cert.crt /etc/ssl/certs/api-cert.crt

COPY nginx/mvc-cert.key /etc/ssl/private/mvc-cert.key
COPY nginx/mvc-cert.crt /etc/ssl/certs/mvc-cert.crt

# Set up directory for Nginx logs (if not already present)
RUN mkdir -p /var/log/nginx
RUN touch /var/log/nginx/access.log /var/log/nginx/error.log

# Expose port 8083 to the host so that Nginx can serve HTTP traffic
EXPOSE 8083

# Start Nginx when the container launches using the default command
CMD ["nginx", "-g", "daemon off;"]
