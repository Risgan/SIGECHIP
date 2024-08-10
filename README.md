# SIGECHIP
Sistema de Gestión y Consulta del Historial Clínico de Mascotas Usando Raspberry Pi y RFID para la Identificación Rápida.

///
sudo su -  (entrar como aldmin desde cmd)
///

# Servidor

## Requisitos

- Raspberry Pi 3
- Tarjeta microSD de al menos 32GB
- Adaptador de corriente para Raspberry Pi
- Monitor, teclado y ratón (opcional, solo si no usarás SSH)
- Conexión a Internet

## Pasos para la Instalación

1. **Descargar la Imagen de Ubuntu Server:**
   - Descarga [Ubuntu para Raspberry Pi](https://ubuntu.com/download/raspberry-pi).
   - Descarga la imagen <Ubuntu Server 24.04 LTS (64-bit)>.

2. **Configurar la Tarjeta SD:**
   - Inserta la tarjeta SD en tu computadora y accede a la partición `boot`.
   - Crea un archivo vacío llamado `ssh` (sin extensión) para habilitar SSH.
   - Para conectarte a una red Wi-Fi, crea un archivo llamado `network-config` en la partición `boot` con el siguiente contenido:

     ```yaml
     version: 2
     ethernets:
       eth0:
         dhcp4: true
     wifis:
       wlan0:
         optional: true
         access-points:
           "SSID":
             password: "password"
         dhcp4: true
     ```

     Reemplaza `"SSID"` y `"password"` con los detalles de tu red Wi-Fi.

4. **Iniciar la Raspberry Pi:**
   - Inserta la tarjeta SD en la Raspberry Pi 3.
   - Conéctala a la fuente de alimentación

5. **Primer Inicio y Configuración:**
   - Accedes por SSH con el comando

     ```
        ssh <usuario>@<IP-de-tu-Raspberry-Pi> ssh admin@192.168.0.14
     ```

   - La contraseña es la establecida en la configuración.

6. **Actualizar el Sistema:**
   - Una vez conectado, actualiza el sistema con los siguientes comandos:

     ```sh
     sudo apt update
     sudo apt upgrade -y
     ```

7. **Instalar Docker:**
    - Descarga e instala Docker usando el script de instalación:

    ```sh
    curl -fsSL https://get.docker.com -o get-docker.sh
    sudo sh get-docker.sh
     ```
    Agregar tu Usuario al Grupo Docker:
    Para ejecutar comandos de Docker sin sudo, agrega tu usuario al grupo docker:

    ```sh
    sudo usermod -aG docker ${USER}
     ```

    Cierra sesión y vuelve a iniciar sesión para que los cambios surtan efecto, o aplica los cambios en la sesión actual con:
    
    ```sh
    newgrp docker
    
     ```
    Verificar la Instalación de Docker:

    ```sh
    docker --version
    
     ```
    Instalación de Nginx usando Docker
    Ejecutar un Contenedor Nginx:
    Inicia un contenedor Nginx con el siguiente comando:

    ```sh
    docker run --name nginx-server -p 80:80 -d nginx
     ```

----------------------------


2. Instalar PostgreSQL
Instalar PostgreSQL y las herramientas adicionales:

Ejecuta el siguiente comando para instalar PostgreSQL y las herramientas de administración:

sh
Copiar código
sudo apt install postgresql postgresql-contrib
postgresql: Instala el servidor de PostgreSQL.
postgresql-contrib: Instala módulos adicionales y herramientas útiles para PostgreSQL.
Verificar la Instalación:

Después de la instalación, PostgreSQL debería estar en ejecución. Verifica el estado del servicio con:

sh
Copiar código
sudo systemctl status postgresql
Deberías ver que el servicio está activo y funcionando.

3. Configurar PostgreSQL
Acceder al Usuario PostgreSQL:

PostgreSQL crea un usuario postgres durante la instalación. Accede a este usuario con el siguiente comando:

sh
Copiar código
sudo -i -u postgres
Iniciar la Consola de PostgreSQL:

Dentro del usuario postgres, inicia la consola de PostgreSQL:

sh
Copiar código
psql
Verás el prompt de PostgreSQL. Desde aquí, puedes ejecutar comandos SQL.

Crear una Nueva Base de Datos y Usuario:

Para crear una nueva base de datos y un usuario con acceso a esa base de datos, puedes usar los siguientes comandos dentro de la consola de PostgreSQL:

sql
Copiar código
CREATE DATABASE mi_base_de_datos;
CREATE USER mi_usuario WITH ENCRYPTED PASSWORD 'mi_contraseña';
GRANT ALL PRIVILEGES ON DATABASE mi_base_de_datos TO mi_usuario;
Reemplaza mi_base_de_datos, mi_usuario, y mi_contraseña con los valores que prefieras.

Salir de la Consola de PostgreSQL:

Para salir de la consola, usa el comando:

sql
Copiar código
\q
Configurar el Acceso Remoto (Opcional):

Si necesitas acceder a PostgreSQL desde una máquina remota, edita el archivo de configuración de PostgreSQL para permitir conexiones remotas:

sh
Copiar código
sudo nano /etc/postgresql/13/main/pg_hba.conf
Busca la línea que dice local all all peer y cámbiala a:

plaintext
Copiar código
local   all             all                                     trust
Luego, edita el archivo postgresql.conf para permitir conexiones desde cualquier IP:

sh
Copiar código
sudo nano /etc/postgresql/13/main/postgresql.conf
Busca la línea que dice #listen_addresses = 'localhost' y cámbiala a:

plaintext
Copiar código
listen_addresses = '*'
Guarda los cambios y reinicia PostgreSQL para aplicar la nueva configuración:

sh
Copiar código
sudo systemctl restart postgresql
4. Acceder a PostgreSQL Remotamente (Opcional)
Si has configurado el acceso remoto, puedes conectarte a PostgreSQL desde otra máquina usando un cliente como psql o una herramienta GUI como pgAdmin.

sh
Copiar código
psql -h <IP-del-servidor> -U mi_usuario -d mi_base_de_datos
Reemplaza <IP-del-servidor>, mi_usuario, y mi_base_de_datos con los valores correspondientes.

-------

2. Instalar .NET SDK
- Primero, instala las dependencias necesarias.

```sh
sudo apt-get install -y wget
```
Luego, descarga e instala el SDK de .NET 8.

```sh
wget https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-8.0.100-linux-x64-binaries
sudo mkdir -p /usr/share/dotnet
sudo tar -zxf dotnet-sdk-8.0.100-linux-x64.tar.gz -C /usr/share/dotnet
sudo ln -s /usr/share/dotnet/dotnet /usr/bin/dotnet
```


---

2. Instalar Nginx
Instala Nginx utilizando el siguiente comando:

sh
Copiar código
sudo apt install nginx -y
3. Iniciar y habilitar Nginx
Después de la instalación, inicia el servicio de Nginx y asegúrate de que se ejecute al iniciar el sistema.

sh
Copiar código
sudo systemctl start nginx
sudo systemctl enable nginx
4. Configurar el firewall
Si tienes ufw (Uncomplicated Firewall) habilitado, necesitas permitir el tráfico HTTP y HTTPS.

sh
Copiar código
sudo ufw allow 'Nginx Full'
5. Verificar la instalación
Puedes verificar que Nginx esté funcionando abriendo un navegador web y accediendo a la dirección IP de tu Raspberry Pi. Deberías ver la página de bienvenida de Nginx.

6. Configurar un sitio web
Crea un archivo de configuración para tu sitio web en /etc/nginx/sites-available.

sh
Copiar código
sudo nano /etc/nginx/sites-available/your_app
Agrega la siguiente configuración básica para tu sitio web:

nginx
Copiar código
server {
    listen 80;
    server_name your_domain_or_ip;

    location / {
        proxy_pass http://localhost:5000;
        proxy_http_version 1.1;
        proxy_set_header Upgrade $http_upgrade;
        proxy_set_header Connection keep-alive;
        proxy_set_header Host $host;
        proxy_cache_bypass $http_upgrade;
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Proto $scheme;
    }
}
Reemplaza your_domain_or_ip con tu dominio o la dirección IP de tu Raspberry Pi.

7. Habilitar la configuración del sitio web
Enlaza el archivo de configuración a la carpeta sites-enabled.

sh
Copiar código
sudo ln -s /etc/nginx/sites-available/your_app /etc/nginx/sites-enabled/
8. Probar la configuración
Verifica que la configuración de Nginx no tenga errores:

sh
Copiar código
sudo nginx -t
9. Reiniciar Nginx
Reinicia el servicio de Nginx para aplicar los cambios.

sh
Copiar código
sudo systemctl restart nginx
Ahora Nginx debería estar configurado y sirviendo tu aplicación. Puedes verificar esto accediendo a la dirección IP o dominio de tu Raspberry Pi desde un navegador web.



-------

Instalar en Docker \
Dockerfile
```sh 
docker pull nginx
docker pull nginx:alpine

docker run -d -p 8080:80 nginx:alpine

docker ps
docker stop <ID>

ng new docker-angular
ng build --prod

docker run -d -p 8080:80 -v $(pwd)/dist/docker-angular:/usr/share/nginx/html nginx:alpine

# Poner archivo dist en destino

FROM node:latest as node
WORKDIR /app
COPY ./ /app/
RUN npm install
RUN npm run build -- --prod

FROM nginx:alpine
COPY --from=node /app/dist/docker-angular /usr/shre/nginx/html


```
