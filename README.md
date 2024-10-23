Base de Datos 
CREATE DATABASE IF NOT EXISTS fruteria;

-- Seleccionar la base de datos
USE fruteria;

-- Crear la tabla proveedores
CREATE TABLE IF NOT EXISTS proveedores (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    contacto VARCHAR(50),
    direccion VARCHAR(200),
    telefono VARCHAR(20),
    email VARCHAR(100),
    pais VARCHAR(100),
    descripcion TEXT
);

-- Crear la tabla productos con una clave foránea que referencie a proveedores
CREATE TABLE IF NOT EXISTS productos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    categoria VARCHAR(50),
    precio DECIMAL(10, 2) NOT NULL,
    cantidad INT NOT NULL,
    origen VARCHAR(100),
    descripcion TEXT,
    proveedor_id INT,
    FOREIGN KEY (proveedor_id) REFERENCES proveedores(id) ON DELETE CASCADE
);

-- Insertar algunos proveedores como ejemplo
INSERT INTO proveedores (nombre, contacto, direccion, telefono, email, pais, descripcion)
VALUES
('Frutas del Valle', 'Juan Perez', 'Calle Los Frutales 123, Lima', '987654321', 'contacto@frutasdelvalle.com', 'Peru', 'Proveedor de frutas frescas y tropicales.'),
('Distribuidora La Cosecha', 'Maria Gomez', 'Av. Principal 456, Quito', '987654322', 'ventas@lacosecha.com', 'Ecuador', 'Proveedor de plátanos y frutas tropicales.'),
('Exportaciones Ibericas', 'Carlos Ruiz', 'Calle Mayor 789, Madrid', '987654323', 'info@exportacionesibericas.es', 'España', 'Proveedor de frutas cítricas y de temporada.'),
('Frutos Andinos', 'Luis Fernández', 'Av. Andina 321, Mendoza', '987654324', 'ventas@frutosandinos.com', 'Argentina', 'Proveedor de peras y manzanas.'),
('Delicias del Sur', 'Ana Martínez', 'Ruta 66, Santiago', '987654325', 'contacto@deliciasdelsur.cl', 'Chile', 'Proveedor de uvas y otros frutos del sur de Chile.');

-- Insertar algunos productos y asignar proveedores
INSERT INTO productos (nombre, categoria, precio, cantidad, origen, descripcion, proveedor_id)
VALUES
('Manzana', 'Fruta', 2.50, 100, 'Peru', 'Manzana roja fresca.', 1),
('Plátano', 'Fruta', 1.20, 200, 'Ecuador', 'Plátano amarillo maduro.', 2),
('Naranja', 'Fruta', 3.00, 150, 'España', 'Naranja dulce y jugosa.', 3),
('Pera', 'Fruta', 2.80, 120, 'Argentina', 'Pera verde madura.', 4),
('Uva', 'Fruta', 4.50, 80, 'Chile', 'Uvas verdes sin semillas.', 5);

-- Verificar el contenido de la tabla productos
SELECT * FROM productos;

-- Verificar el contenido de la tabla proveedores
SELECT * FROM proveedores;

-- Tabla usuarios
CREATE TABLE IF NOT EXISTS usuario (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    pass VARCHAR(150)
);

-- hash 
DELIMITER //

CREATE PROCEDURE registrar_usuario(
    IN p_nombre VARCHAR(100),
    IN p_pass VARCHAR(150)
)
BEGIN
    -- Hashear la contraseña usando SHA2 con 256 bits
    DECLARE hashed_pass VARCHAR(150);
    SET hashed_pass = SHA2(p_pass, 256);
    
    -- Insertar el nuevo usuario en la tabla
    INSERT INTO usuario (nombre, pass) 
    VALUES (p_nombre, hashed_pass);
END //

DELIMITER ;

CALL registrar_usuario('Marrufo', '123456789');
select * from usuario;
-- Login 
DELIMITER //

CREATE PROCEDURE verificar_usuario(
    IN p_nombre VARCHAR(100),
    IN p_pass VARCHAR(150),
    OUT resultado BOOLEAN
)
BEGIN
    -- Declarar la variable para almacenar la contraseña hasheada
    DECLARE stored_pass VARCHAR(150);
    
    -- Intentar obtener la contraseña hasheada almacenada
    SELECT pass INTO stored_pass 
    FROM usuario 
    WHERE nombre = p_nombre;
    
    -- Comparar la contraseña ingresada (hasheada) con la almacenada
    IF stored_pass = SHA2(p_pass, 256) THEN
        SET resultado = TRUE;  -- Credenciales correctas
    ELSE
        SET resultado = FALSE; -- Credenciales incorrectas
    END IF;
    
END //

DELIMITER ;

CALL verificar_usuario('Marrufo', '123456789', @resultado);
SELECT @resultado;

...Cambiar la Conexion en Appsettings.json...