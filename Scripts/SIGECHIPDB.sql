CREATE TABLE usuario (
  id SERIAL PRIMARY KEY NOT NULL,
  id_tipo_documento integer,
  documento integer,
  correo varchar(50),
  password varchar(50),
  primer_nombre varchar(50),
  segundo_nombre varchar(50),
  primer_apellido varchar(50),
  segundo_apellido varchar(50),
  rol integer,
  foto varchar,
  activo bool DEFAULT true
);

CREATE TABLE veterinario (
  id SERIAL PRIMARY KEY NOT NULL,
  id_tipo_documento integer,
  documento integer,
  correo varchar(50),
  password varchar(50),
  primer_nombre varchar(50),
  segundo_nombre varchar(50),
  primer_apellido varchar(50),
  segundo_apellido varchar(50),
  licencia integer,
  activo bool DEFAULT true
);

CREATE TABLE paciente (
  id SERIAL PRIMARY KEY NOT NULL,
  id_usuario integer,
  id_tipo_documento integer,
  documento integer,
  nombre varchar(255),
  apellido varchar(255),
  edad varchar(255),
  raza varchar(255),
  especie varchar(255),
  foto varchar(255),
  historia varchar(255),
  activo bool DEFAULT true
);

CREATE TABLE rol (
  id SERIAL PRIMARY KEY NOT NULL,
  nombre varchar(50),
  activo bool DEFAULT true
);

CREATE TABLE historial (
  id SERIAL PRIMARY KEY NOT NULL,
  id_paciente integer,
  activo bool DEFAULT true
);

CREATE TABLE procedimiento (
  id SERIAL PRIMARY KEY NOT NULL,
  id_historial integer,
  id_veterinario integer,
  nombre varchar(255),
  fecha_inicio date,
  fecha_fin date,
  descripcion varchar(255),
  id_estado integer,
  activo bool DEFAULT true
);

CREATE TABLE recomendacion (
  id SERIAL PRIMARY KEY NOT NULL,
  id_veterinario integer,
  id_paciente integer,
  recomendacion varchar(255),
  observaciones varchar(255),
  id_estado integer,
  activo bool DEFAULT true
);

CREATE TABLE formula (
  id SERIAL PRIMARY KEY NOT NULL,
  id_veterinario integer,
  id_paciente integer,
  medicamento varchar(255),
  fecha_inicio date,
  fecha_fin date,
  dosis varchar(255),
  observaciones varchar(255),
  id_estado integer,
  activo bool DEFAULT true
);

CREATE TABLE evidencias (
  id SERIAL PRIMARY KEY NOT NULL,
  id_procedimiento integer,
  imagen varchar(255),
  activo bool DEFAULT true
);

CREATE TABLE tipo_documento (
  id SERIAL PRIMARY KEY NOT NULL,
  sigla varchar(5),
  documento varchar(255),
  activo bool DEFAULT true
);

CREATE TABLE vacunas (
  id SERIAL PRIMARY KEY NOT NULL,
  id_paciente integer,
  nombre varchar(255),
  fecha date,
  fecha_proxima date
);

CREATE TABLE estado (
  id SERIAL PRIMARY KEY NOT NULL,
  estado varchar(255)
);

CREATE TABLE code_qr (
  id SERIAL PRIMARY KEY NOT NULL,
  id_paciente integer,
  codigo varchar(255)
);

CREATE TABLE veterinaria (
  id SERIAL PRIMARY KEY NOT NULL,
  id_veterinario int,
  razon_social varchar(255),
  direccion varchar(255),
  telefono varchar(255),
  id_estado integer
);

ALTER TABLE usuario ADD FOREIGN KEY (id_tipo_documento) REFERENCES tipo_documento (id);

ALTER TABLE usuario ADD FOREIGN KEY (rol) REFERENCES rol (id);

ALTER TABLE veterinario ADD FOREIGN KEY (id_tipo_documento) REFERENCES tipo_documento (id);

ALTER TABLE paciente ADD FOREIGN KEY (id_usuario) REFERENCES usuario (id);

ALTER TABLE paciente ADD FOREIGN KEY (id_tipo_documento) REFERENCES tipo_documento (id);

ALTER TABLE historial ADD FOREIGN KEY (id_paciente) REFERENCES paciente (id);

ALTER TABLE procedimiento ADD FOREIGN KEY (id_historial) REFERENCES historial (id);

ALTER TABLE procedimiento ADD FOREIGN KEY (id_veterinario) REFERENCES veterinario (id);

ALTER TABLE procedimiento ADD FOREIGN KEY (id_estado) REFERENCES estado (id);

ALTER TABLE recomendacion ADD FOREIGN KEY (id_veterinario) REFERENCES veterinario (id);

ALTER TABLE recomendacion ADD FOREIGN KEY (id_paciente) REFERENCES paciente (id);

ALTER TABLE recomendacion ADD FOREIGN KEY (id_estado) REFERENCES estado (id);

ALTER TABLE formula ADD FOREIGN KEY (id_veterinario) REFERENCES veterinario (id);

ALTER TABLE formula ADD FOREIGN KEY (id_paciente) REFERENCES paciente (id);

ALTER TABLE formula ADD FOREIGN KEY (id_estado) REFERENCES estado (id);

ALTER TABLE evidencias ADD FOREIGN KEY (id_procedimiento) REFERENCES procedimiento (id);

ALTER TABLE vacunas ADD FOREIGN KEY (id_paciente) REFERENCES paciente (id);

ALTER TABLE code_qr ADD FOREIGN KEY (id_paciente) REFERENCES paciente (id);

ALTER TABLE veterinaria ADD FOREIGN KEY (id_veterinario) REFERENCES veterinario (id);

ALTER TABLE veterinaria ADD FOREIGN KEY (id_estado) REFERENCES estado (id);
