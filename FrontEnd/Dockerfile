# Etapa de compilación
FROM node:18-alpine AS build-stage

# Establecer directorio de trabajo
WORKDIR /app

# Copiar archivo de configuración
COPY package*.json ./

# Instalar dependencias
RUN npm install

RUN npm install vite

RUN npm install -D sass
# Copiar archivos del proyecto
COPY . .

# Compilar la aplicación para producción
RUN npm run build

# Etapa de producción
FROM nginx:alpine AS production-stage

# Copiar la compilación de la etapa de compilación al servidor Nginx
COPY --from=build-stage /app/dist /usr/share/nginx/html

# Exponer puerto 80
EXPOSE 81

# Iniciar Nginx
CMD ["nginx", "-g", "daemon off;"]