DROP DATABASE IF EXISTS MecaFlow;
CREATE DATABASE MecaFlow;
USE MecaFlow;



-- Crear primero la tabla de Roles
CREATE TABLE Roles (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL
);

-- Ahora sí podemos crear Usuarios y hacer referencia a Roles
CREATE TABLE Usuarios (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL,
    Password VARCHAR(255) NOT NULL,
    RolID INT,
    FOREIGN KEY (RolID) REFERENCES Roles(ID) ON DELETE SET NULL
);

-- Tabla de Permisos
CREATE TABLE Permisos (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL
);

-- Relación entre Roles y Permisos (Muchos a Muchos)
CREATE TABLE RolPermisos (
    RolID INT,
    PermisoID INT,
    PRIMARY KEY (RolID, PermisoID),
    FOREIGN KEY (RolID) REFERENCES Roles(ID) ON DELETE CASCADE,
    FOREIGN KEY (PermisoID) REFERENCES Permisos(ID) ON DELETE CASCADE
);

-- Tabla de Clientes
CREATE TABLE Clientes (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Telefono VARCHAR(20) UNIQUE
);

-- Tabla de Vehículos
CREATE TABLE Vehiculos (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    Placa VARCHAR(20) UNIQUE NOT NULL,
    Marca VARCHAR(50),
    Modelo VARCHAR(50),
    ClienteID INT,
    FOREIGN KEY (ClienteID) REFERENCES Clientes(ID) ON DELETE CASCADE
);

-- Tabla de Diagnósticos (Cada vehículo puede tener muchos diagnósticos)
CREATE TABLE Diagnosticos (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    VehiculoID INT,
    Fecha DATE NOT NULL,
    Descripcion TEXT,
    FOREIGN KEY (VehiculoID) REFERENCES Vehiculos(ID) ON DELETE CASCADE
);

-- Tabla de Facturación
CREATE TABLE Facturas (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    ClienteID INT,
    Fecha DATE NOT NULL,
    Monto DECIMAL(10,2) NOT NULL,
    Estado ENUM('Pendiente', 'Pagado') DEFAULT 'Pendiente',
    FOREIGN KEY (ClienteID) REFERENCES Clientes(ID) ON DELETE CASCADE
);

-- Tabla de Pagos
CREATE TABLE Pagos (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    FacturaID INT,
    FechaPago DATE NOT NULL,
    Monto DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (FacturaID) REFERENCES Facturas(ID) ON DELETE CASCADE
);

-- Tabla de Reportes Financieros
CREATE TABLE ReportesFinancieros (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    Fecha DATE NOT NULL,
    Ingresos DECIMAL(10,2) NOT NULL,
    Gastos DECIMAL(10,2) NOT NULL
);

-- Tabla de Empleados
CREATE TABLE Empleados (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Cargo VARCHAR(50),
    Salario DECIMAL(10,2) NOT NULL
);

-- Tabla de Turnos
CREATE TABLE Turnos (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    EmpleadoID INT,
    Fecha DATE NOT NULL,
    Horario VARCHAR(50),
    FOREIGN KEY (EmpleadoID) REFERENCES Empleados(ID) ON DELETE CASCADE
);

-- Tabla de Asistencia
CREATE TABLE Asistencias (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    EmpleadoID INT,
    Fecha DATE NOT NULL,
    Estado ENUM('Presente', 'Ausente') DEFAULT 'Presente',
    FOREIGN KEY (EmpleadoID) REFERENCES Empleados(ID) ON DELETE CASCADE
);

-- Tabla de Usuarios y Roles (Muchos a Muchos)
CREATE TABLE UsuarioRoles (
    UsuarioID INT,
    RolID INT,
    PRIMARY KEY (UsuarioID, RolID),
    FOREIGN KEY (UsuarioID) REFERENCES Usuarios(ID) ON DELETE CASCADE,
    FOREIGN KEY (RolID) REFERENCES Roles(ID) ON DELETE CASCADE
);